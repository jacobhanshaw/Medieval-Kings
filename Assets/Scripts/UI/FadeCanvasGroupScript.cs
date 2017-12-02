using UnityEngine;
using System.Collections;

public class FadeCanvasGroupScript : MonoBehaviour 
{
	public delegate void FadeComplete(bool show);
	public FadeComplete FadeCompleteListeners;

	enum Fade
	{
		NONE,
		IN,
		OUT,
		SIZE
	}

	CanvasGroup canvasGroup;

	Fade fade;
	float lerpProgress = 1.0f;
	float startAlpha;
	float endAlpha;
	float startScale;
	float endScale;
	float duration;

	const float FADE_IN_TIME = 0.2f;
	const float FADE_OUT_TIME = 0.2f;

	const float START_SCALE = 0.9f;

	void Start ()
	{
		canvasGroup = gameObject.GetComponent<CanvasGroup> ();
		if(canvasGroup.alpha != 1f)
			gameObject.transform.localScale = Vector2.one * START_SCALE;
	}

	void Update ()
	{
		if(fade > Fade.NONE)
		{
			if (lerpProgress < 1.0f)
				lerpProgress += Time.deltaTime/duration;
			else
			{
				fade = Fade.NONE;
				if(endAlpha == 0.0f)
					canvasGroup.blocksRaycasts = false;
				else if(endAlpha == 1.0f)
					canvasGroup.interactable = true;
				if(FadeCompleteListeners != null)
					FadeCompleteListeners(endAlpha == 1.0f);
			}

			canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, lerpProgress);
			gameObject.transform.localScale = Vector2.one * Mathf.Lerp(startScale, endScale, lerpProgress);
		}
	}

	public void Show (bool show)
	{
		// Skip already fading properly or already shown/hidden properly
		if(canvasGroup != null && ((show && (fade == Fade.IN || canvasGroup.interactable)) || (!show && (fade == Fade.OUT || !canvasGroup.blocksRaycasts))))
			return;

		startAlpha = canvasGroup.alpha;
		startScale = gameObject.transform.localScale.x;
		if(show)
		{
			fade = Fade.IN;
			canvasGroup.blocksRaycasts = true;
			duration = FADE_IN_TIME * lerpProgress;
			endAlpha = 1f;
			endScale = 1f;
		}
		else
		{
			fade = Fade.OUT;
			canvasGroup.interactable = false;
			duration = FADE_OUT_TIME * lerpProgress;
			endAlpha = 0.0f;
			endScale = START_SCALE;
		}
		lerpProgress = 0.0f;

		if(duration == 0f)
			duration = 0.05f;
	}
}
