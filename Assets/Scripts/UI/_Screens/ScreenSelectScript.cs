using UnityEngine;
using System.Collections;

public class ScreenSelectScript : MonoBehaviour
{
	public Delegates.ScreenType activateType;

	FadeCanvasGroupScript fadeCanvasGroupScript;

	void Start ()
	{
		fadeCanvasGroupScript = gameObject.AddComponent<FadeCanvasGroupScript> ();
		Delegates.Instance.ScreenSelectListeners += Display;

	}

	void OnDestroy ()
	{
		if(Delegates.Instance != null)
			Delegates.Instance.ScreenSelectListeners -= Display;
	}

	public void Display (Delegates.ScreenType screenType)
	{
		fadeCanvasGroupScript.Show(screenType == activateType);
	}
}
