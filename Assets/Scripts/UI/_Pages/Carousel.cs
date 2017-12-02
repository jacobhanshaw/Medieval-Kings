/// Credit BinaryX 
/// Sourced from - http://forum.unity3d.com/threads/scripts-useful-4-6-scripts-collection.264161/page-2#post-1945602
/// Updated by ddreaper - removed dependency on a custom ScrollRect script. Now implements drag interfaces and standard Scroll Rect.
/// Updated by Jacob Hanshaw - converted to a carousel. Now has recycling pages with ability to drag or click button to go between them.
/// 
using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions
{
	[RequireComponent(typeof(ScrollRect))]
	[AddComponentMenu("Layout/Extensions/Carousel")]
	public class Carousel : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
	{
		public delegate void PageChange(int newPageNumber);
		public PageChange PageChangeListeners;

		const float CLICK_DISTANCE = 1.0f;

		private Transform _screensContainer;

		private int _pageNumber = -1; //ensure update in first pass
		private int _itemCount;
		private int _pageCount;

		private int _screens = 3;
		private int _startingScreen = 0;

		private bool _fastSwipeTimer = false;
		private int _fastSwipeCounter = 0;
		private int _fastSwipeTarget = 30;

		private Vector3[] _positions;
		private ScrollRect _scroll_rect;
		private Vector3 _lerp_target;
		private bool _lerp;
		private int _offset;
		private bool[] _originalScrollValues;

		[Tooltip("The minimum padding around the cells.")]
		public Vector2 minPadding;

		[Tooltip("The minimum spacing between the cells.")]
		public Vector2 minSpacing;

		[Tooltip("The script that manages updating the pages.")]
		public PagesScript pagesScript;

		[Tooltip("The gameobject that contains toggles which suggest pagination. (optional)")]
		public PaginationScript paginationScript;

		[Tooltip("Button to go to the previous page. (optional)")]
		public Button PrevButton;
		[Tooltip("Button to go to the next page. (optional)")]
		public Button NextButton;

		public bool UseFastSwipe = true;
		public int FastSwipeThreshold = 0;

		private bool _startDrag = true;
		private Vector3 _startPosition = new Vector3();
		private int _currentScreen;

		private bool fastSwipe = false; //to determine if a fast swipe was performed

		void Start()
		{
			_scroll_rect = gameObject.GetComponent<ScrollRect>();
			_screensContainer = _scroll_rect.content;

			DistributePages();

			if(_screensContainer.childCount != _screens)
				throw new UnityException("Carousel needs 3 cells to function properly.");

			_lerp = false;
			_positions = new Vector3[_screens];

			for (int i = 0; i < _screens; ++i)
			{
				_scroll_rect.horizontalNormalizedPosition = (float)i / (float)(_screens - 1);
				_positions[i] = _screensContainer.localPosition;
			}

			_scroll_rect.horizontalNormalizedPosition = (float)(_startingScreen) / (float)(_screens - 1);

			if (NextButton != null)
				NextButton.onClick.AddListener(() => { NextScreen(); });

			if (PrevButton)
				PrevButton.onClick.AddListener(() => { PreviousScreen(); });

			UpdateLayout(Screen.width > Screen.height);
			pagesScript.ContentUpdatedListeners += Refresh;
			RotationUpdater.Instance.RotationChangedListeners += UpdateLayout;
		}

		//separates pages
		private void DistributePages()
		{
			float offset = 0;
			Vector2 farCorner = Camera.main.ViewportToWorldPoint(new Vector2(1.0f, 1.0f));
			float step = Mathf.Max(farCorner.x, farCorner.y);

			float dimension = 0;

			float currentXPosition = 0;

			for (int i = 0; i < _screensContainer.transform.childCount; i++)
			{
				RectTransform child = ((RectTransform)_screensContainer.transform.GetChild(i));
				currentXPosition = offset + (float)i * step;
				child.anchoredPosition = new Vector2(currentXPosition, 0f);
				child.sizeDelta = new Vector2(((RectTransform)transform).rect.width, ((RectTransform)transform).rect.height);
			}

			dimension = currentXPosition + offset * -1.0f;

			_screensContainer.GetComponent<RectTransform>().offsetMax = new Vector2(dimension, 0f);
		}

		void UpdateLayout (bool landscape)
		{
			for (int i = 0; i < _screensContainer.transform.childCount; i++)
			{
				RectTransform child = ((RectTransform)_screensContainer.transform.GetChild(i));
				child.sizeDelta = new Vector2(((RectTransform)transform).rect.width, ((RectTransform)transform).rect.height);
			}

			pagesScript.UpdateLayout(minPadding, minSpacing);
			Refresh();
		}

		void Update()
		{
			if (_lerp)
			{
				_screensContainer.localPosition = Vector3.Lerp(_screensContainer.localPosition, _lerp_target, 10.0f * Time.deltaTime);
				if (Vector3.Distance(_screensContainer.localPosition, _lerp_target) < CLICK_DISTANCE)
				{
					_lerp = false;
					_scroll_rect.StopMovement();
					_screensContainer.localPosition = _lerp_target;
					SetPageNumber(_pageNumber + _offset);
				}
			}

			if (_fastSwipeTimer)
				_fastSwipeCounter++;
		}

		private void Refresh ()
		{
			_pageCount = pagesScript.PageCount();
			if(paginationScript != null)
				paginationScript.SetUpPaginationToggles(_pageCount);
			OverridePageNumber(pagesScript.StartPage());
		}

		//Update pageNumber after lerping
		private void SetPageNumber(int aPageNumber)
		{
			_pageNumber = aPageNumber;
			bool firstPage = _pageNumber == 0;
			bool lastPage = _pageNumber == (_pageCount - 1);
			if(PrevButton != null)
				PrevButton.interactable = !firstPage;
			if(NextButton != null)
				NextButton.interactable = !lastPage;

			if(firstPage)
				_currentScreen = 0;
			else if(lastPage && _pageCount > 2)
				_currentScreen = 2;
			else
				UpdatePages (1);

			if(PageChangeListeners != null)
				PageChangeListeners(_pageNumber);
		}

		public void OverridePageNumber(int aPageNumber)
		{
			SetPageNumber(aPageNumber);
			if(_pageNumber == 0)
				UpdatePages(0);
			else if(_pageNumber == (_pageCount - 1) && _pageCount > 2)
				UpdatePages(2);
			ChangeBulletsInfo(_pageNumber);
		}

		public int GetPageNumber()
		{
			return _pageNumber;
		}

		//Update content of pages
		private void UpdatePages(int newCenter)
		{
			_currentScreen = newCenter;
			pagesScript.UpdatePage(newCenter, _pageNumber);
			_screensContainer.localPosition = _positions[newCenter];
			if (newCenter > 0)
				pagesScript.UpdatePage(newCenter - 1, _pageNumber - 1);
			if (newCenter < _screens - 1)
				pagesScript.UpdatePage(newCenter + 1, _pageNumber + 1);
		}

		private void AdjustScreen(int offset)
		{
			int newPosition = _currentScreen + offset;
			if(newPosition > Mathf.Min(_pageCount - 1, _screens - 1))
				newPosition =  Mathf.Min(_pageCount - 1, _screens - 1);
			else if(newPosition < 0)
				newPosition = 0;

			_lerp = true;
			_offset = newPosition - _currentScreen;
			_lerp_target = _positions[newPosition];

			ChangeBulletsInfo(_pageNumber + _offset);
		}

		public void NextScreen()
		{
			AdjustScreen(1);
		}

		public void PreviousScreen()
		{
			AdjustScreen(-1);
		}

		//changes the bullets on the bottom of the page - pagination
		private void ChangeBulletsInfo(int pageNumber)
		{
			if (paginationScript != null)
			{
				for (int i = 0; i < paginationScript.transform.childCount; i++)
					paginationScript.transform.GetChild(i).GetComponent<Toggle>().isOn = (pageNumber == i) ? true : false;
			}
		}

		#region Interfaces
		public void OnDrag(PointerEventData eventData)
		{
			_lerp = false;
			if (_startDrag)
			{
				_startDrag = false;
				OnBeginDrag(eventData);
			}
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			_startPosition = _screensContainer.localPosition;
			_fastSwipeCounter = 0;
			_fastSwipeTimer = true;
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			_startDrag = true;
			if (UseFastSwipe)
			{
				fastSwipe = false;
				_fastSwipeTimer = false;
				if (_fastSwipeCounter <= _fastSwipeTarget)
				{
					if (Mathf.Abs(_startPosition.x - _screensContainer.localPosition.x) > FastSwipeThreshold)
						fastSwipe = true;
				}

				if (fastSwipe)
				{
					if (_startPosition.x - _screensContainer.localPosition.x > 0)
						NextScreen();
					else
						PreviousScreen();
				}
				else
					MoveToClosestPosition();
			}
			else
				MoveToClosestPosition();
		}
		#endregion

		private void MoveToClosestPosition ()
		{
			int newTargetIndex = -1;
			Vector3 target = FindClosestFrom(_screensContainer.localPosition, _positions);
			for(int i = 0; i < _positions.Length; ++i)
			{
				if(_positions[i] == target)
				{
					newTargetIndex = i;
					break;
				}
			}

			AdjustScreen(newTargetIndex - _currentScreen);
		}

		//find the closest point to the releasing point
		private Vector3 FindClosestFrom(Vector3 start, Vector3[] positions)
		{
			Vector3 closest = Vector3.zero;
			float distance = Mathf.Infinity;

			foreach (Vector3 position in _positions)
			{
				if (Vector3.Distance(start, position) < distance)
				{
					distance = Vector3.Distance(start, position);
					closest = position;
				}
			}

			return closest;
		}
	}
}