using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BackButtonScript : MonoBehaviour 
{
	bool subscribed;
	bool isBackClick;
	Button backButton;
	List<Delegates.ScreenType> screenQue;

	void Start () 
	{
		backButton = GetComponent<Button>();
		backButton.interactable = false;

		screenQue = new List<Delegates.ScreenType>();
		screenQue.Add(Delegates.ScreenType.HOME);

		Delegates.Instance.ScreenSelectListeners += UpdateQue;
	}

	public void ResetQue() {
		Delegates.ScreenType currentScreen = screenQue[screenQue.Count - 1];
		screenQue = new List<Delegates.ScreenType>();
		screenQue.Add(Delegates.ScreenType.HOME);
		screenQue.Add(currentScreen);
	}

	void OnDestroy ()
	{
		if(Delegates.Instance != null)
			Delegates.Instance.ScreenSelectListeners -= UpdateQue;
	}

	public void OnClick ()
	{
		isBackClick = true;
		Delegates.ScreenType prevScreen = screenQue[screenQue.Count - 2];
		screenQue.RemoveAt(screenQue.Count - 1);
		if(prevScreen == Delegates.ScreenType.HOME)
			backButton.interactable = false;
		
		Delegates.Instance.ScreenSelectListeners(prevScreen);
	}

	void UpdateQue (Delegates.ScreenType screenType)
	{
		if(isBackClick)
			isBackClick = false;
		else
		{
			screenQue.Add(screenType);
			backButton.interactable = true;
		}
	}
}