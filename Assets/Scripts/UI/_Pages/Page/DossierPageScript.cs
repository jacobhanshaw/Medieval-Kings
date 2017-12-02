using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DossierPageScript : PageScript {

	public override void UpdatePage (int pageNumber)
	{
		base.UpdatePage(pageNumber);

		if (pageNumber < GameManager.Instance.characters.Length)
			((DossierCellScript)cellScripts[0]).LoadWithCharacterIndex(pageNumber);
	}

	public override void UpdateLayout(GameObject cellPrefab, Vector2 minPadding, Vector2 minSpacing) {
		int newCellsPerPage = 1;
		int cellDifference = newCellsPerPage - cellsPerPage;
		cellsPerPage = newCellsPerPage;
		AdjustCellCount(cellPrefab, cellDifference);
	}

	protected override void AdjustCellCount(GameObject cellPrefab, int difference)
	{
		base.AdjustCellCount(cellPrefab, difference);

		for(int i = 0; i < cellScripts.Count; ++i) {
			GameObject cell = cellScripts[i].gameObject;
			((RectTransform)cell.transform).offsetMin = new Vector2(0,  30);
			((RectTransform)cell.transform).offsetMax = new Vector2(0, -10);
		}
	}
}
