using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PageScript : MonoBehaviour 
{
	GridLayoutGroup gridLayoutGroup;
	protected List<CellScript> cellScripts { get; private set; }

	public int cellsPerPage { get; private set; }

	void Awake ()
	{
		gridLayoutGroup = GetComponent<GridLayoutGroup> ();
		cellScripts = new List<CellScript> ();
	}

	public void UpdateLayout(GameObject cellPrefab, Vector2 minPadding, Vector2 minSpacing)
	{
		Rect pageRect = ((RectTransform)transform).rect;

		int cellsWide = ItemCount(pageRect.width,  gridLayoutGroup.cellSize.x, (int)minPadding.x, minSpacing.x);
		int cellsHigh = ItemCount(pageRect.height, gridLayoutGroup.cellSize.y, (int)minPadding.y, minSpacing.y);
		gridLayoutGroup.constraintCount = cellsWide;

		int newCellsPerPage = cellsWide * cellsHigh;
		int cellDifference = newCellsPerPage - cellsPerPage;
		cellsPerPage = newCellsPerPage;
		AdjustCellCount(cellPrefab, cellDifference);

		int paddingX = Padding(pageRect.width,  cellsWide, gridLayoutGroup.cellSize.x, (int)minPadding.x);
		int paddingY = Padding(pageRect.height, cellsHigh, gridLayoutGroup.cellSize.y, (int)minPadding.y);
		gridLayoutGroup.padding = new RectOffset(paddingX, paddingX, paddingY, paddingY);

		float spacingX = Spacing(pageRect.width,  cellsWide, gridLayoutGroup.cellSize.x, paddingX);
		float spacingY = Spacing(pageRect.height, cellsHigh, gridLayoutGroup.cellSize.y, paddingY);
		gridLayoutGroup.spacing = new Vector2(spacingX, spacingY);
	}

	private int ItemCount(float totalSpace, float itemSize, int minPadding, float minSpacing)
	{
		int itemCount = Mathf.FloorToInt(totalSpace/itemSize);
		while (totalSpace - ((float)itemCount * itemSize + (float)(itemCount - 1) * minSpacing + (float)(2 * minPadding)) < 0)
			--itemCount;

		return itemCount;
	}

	private int Padding(float totalSpace, int itemCount, float itemSize, int minPadding)
	{
		int padding;
		float leftOver = totalSpace - ((float)itemCount * itemSize);
		float evenValue = leftOver/(float)(itemCount + 1);
		if(evenValue >= minPadding)
			padding = Mathf.FloorToInt(evenValue);
		else
			padding = minPadding;

		return padding;
	}

	private float Spacing (float totalSpace, int itemCount, float itemSize, int padding)
	{
		float leftOver = totalSpace - ((float)itemCount * itemSize);
		if(itemCount <= 1)
			return 0f;
		return (leftOver - (float)(2 * padding))/(float)(itemCount - 1);
	}

	public virtual void UpdatePage(int aPageNumber)
	{
	}

	private void AdjustCellCount(GameObject cellPrefab, int difference)
	{
		while(difference > 0)
		{
			GameObject cell = Instantiate (cellPrefab) as GameObject;
			cell.transform.SetParent(transform);
			cell.transform.localScale = new Vector2(1.0f, 1.0f);
			cellScripts.Add(cell.GetComponent<CellScript> ());
			--difference;
		}

		while(difference < 0)
		{
			GameObject gameObject = cellScripts[0].gameObject;
			cellScripts.RemoveAt(0);
			Destroy(gameObject);
			++difference;
		}
	}
}
