using UnityEngine;
using UnityEngine.UI;
/*
public sealed class LevelSelectPagesScript : PagesScript 
{
	public Text titleText;

	bool sentEvent;

	public void SetPuzzleDifficulty (int aPuzzleDifficulty)
	{
		if(GameManager.GetLaunchCount() == 1 && !sentEvent)
		{
			sentEvent = true;
			AnalyticsHandler.SendAnalyticsEvent("FirstPuzzleDifficultyOpened", new System.Collections.Generic.Dictionary<string, object> { { "difficulty", aPuzzleDifficulty } });
		}

		titleText.text = " All Levels";

		if(ContentUpdatedListeners != null)
			ContentUpdatedListeners ();
	}

	public override int PageCount ()
	{
		int cellsPerPage = pages[0].cellsPerPage;
		if(cellsPerPage <= 0)
			return 0;

		int levelCount = GameManager.GetMaxLevelAvailable ();
		return Mathf.CeilToInt((float)levelCount/(float)cellsPerPage);
	}

	public override int StartPage ()
	{
		int currentLevel = Mathf.Min(GameManager.GetMaxLevelUnlocked(), GameManager.GetMaxLevelAvailable() - 1);
		return Mathf.FloorToInt((float)currentLevel/(float)pages[0].cellsPerPage);
	}

}
*/