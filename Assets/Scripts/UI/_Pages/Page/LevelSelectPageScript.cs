using UnityEngine;
/*
public sealed class LevelSelectPageScript : PageScript 
{
	public override void UpdatePage (int pageNumber)
	{
		base.UpdatePage(pageNumber);

		int levelCount = GameManager.GetMaxLevelAvailable ();
		int startIndex = pageNumber * cellsPerPage;
		int endIndex = startIndex + cellsPerPage;
		int maxLevelUnlocked = GameManager.GetMaxLevelUnlocked();

		int pageLimit = Mathf.Min(endIndex, levelCount);
		for(int i = startIndex; i < pageLimit; ++i)
			cellScripts [i - startIndex].gameObject.SetActive(true);
		int inActiveStartIndex = Mathf.Max(pageLimit, startIndex);
		for(int i = inActiveStartIndex; i < endIndex; ++i)
			cellScripts [i - startIndex].gameObject.SetActive(false);

		if(maxLevelUnlocked < startIndex)
			maxLevelUnlocked = startIndex - 1;

		for (int i = startIndex; i < Mathf.Min(pageLimit, maxLevelUnlocked); ++i)
			((LevelSelectCellScript)cellScripts [i - startIndex]).UpdateWithIndexDelegateAndName (i, LevelSelectButtonAtIndexPressed, null, "", true);

		if(maxLevelUnlocked >= startIndex && maxLevelUnlocked < pageLimit)
			((LevelSelectCellScript)cellScripts [maxLevelUnlocked - startIndex]).UpdateWithIndexDelegateAndName (maxLevelUnlocked, LevelSelectButtonAtIndexPressed, null, (maxLevelUnlocked + 1).ToString(), false);

		for (int i = maxLevelUnlocked + 1; i < pageLimit; ++i)
			((LevelSelectCellScript)cellScripts [i - startIndex]).UpdateWithIndexDelegateAndName (i, null, null, (i + 1).ToString(), false);
	}

	public void LevelSelectButtonAtIndexPressed (int index)
	{
		Level levelToLoad = LevelsList.LoadLevel (index);
		GameManager.LoadLevel (levelToLoad);
	}
}
*/