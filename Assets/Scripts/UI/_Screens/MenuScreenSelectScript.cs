using UnityEngine;
using System.Collections;

public class MenuScreenSelectScript : MonoBehaviour
{
	public Delegates.MenuScreenType activateType;

	FadeCanvasGroupScript fadeCanvasGroupScript;

	void Start ()
	{
		fadeCanvasGroupScript = gameObject.AddComponent<FadeCanvasGroupScript> ();
		Delegates.Instance.MenuScreenSelectListeners += Display;

	}

	void OnDestroy ()
	{
		if(Delegates.Instance != null)
			Delegates.Instance.MenuScreenSelectListeners -= Display;
	}

	public void Display (Delegates.MenuScreenType screenType)
	{
		fadeCanvasGroupScript.Show(screenType == activateType);
	}
}
