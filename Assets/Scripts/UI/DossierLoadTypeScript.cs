using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class DossierLoadTypeScript : MonoBehaviour {

	float originalBottomMargin;

	void Start ()
	{
		Delegates.Instance.ScreenSelectListeners += UpdateDisplay;
		originalBottomMargin = ((RectTransform)transform).offsetMin.y;
	}

	void OnDestroy ()
	{
		if(Delegates.Instance != null)
			Delegates.Instance.ScreenSelectListeners -= UpdateDisplay;
	}

	public void UpdateDisplay (Delegates.ScreenType screenType)
	{
		if(screenType == Delegates.ScreenType.DOSSIER) {
			gameObject.transform.GetChild(0).GetComponent<Carousel>().PrepareForPresentation();

			Vector2 offsetMin = ((RectTransform)transform).offsetMin;
			offsetMin.y = GameManager.Instance.levelLoaded ? 0 : originalBottomMargin;
			((RectTransform)transform).offsetMin = offsetMin;
		}
	}
}
