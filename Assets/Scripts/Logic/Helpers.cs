using UnityEngine;

public static class  Helpers
{
	public static void EnableCanvasGroup(CanvasGroup canvasGroup)
	{				
		canvasGroup.alpha = 1f;
		canvasGroup.interactable = true;
		canvasGroup.blocksRaycasts = true;
	}

	public static void DisableCanvasGroup(CanvasGroup canvasGroup)
	{				
		canvasGroup.alpha = 0f;
		canvasGroup.interactable = false;
		canvasGroup.blocksRaycasts = false;
	}

	public static float EaseInQuad(float start, float end, float value)
	{
		end -= start;
		return end * value * value + start;
	}
}