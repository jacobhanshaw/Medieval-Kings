using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BackButtonScript : MonoBehaviour 
{
	bool subscribed;
	bool isBackClick;
	Button backButton;
	List<Delegates.ScreenType> screenQueue;

	void Start () 
	{
		backButton = GetComponent<Button>();
		backButton.interactable = false;

		screenQueue = new List<Delegates.ScreenType>();
		screenQueue.Add(Delegates.ScreenType.HOME);

		Delegates.Instance.ScreenSelectListeners += UpdateQueue;
	}

	void OnDestroy ()
	{
		if(Delegates.Instance != null)
			Delegates.Instance.ScreenSelectListeners -= UpdateQueue;
	}

	public void OnClick ()
	{
		isBackClick = true;
		Delegates.ScreenType prevScreen = screenQueue[screenQueue.Count - 2];
		screenQueue.RemoveAt(screenQueue.Count - 1);
		if(prevScreen == Delegates.ScreenType.HOME)
			backButton.interactable = false;
		
		Delegates.Instance.ScreenSelectListeners(prevScreen);
	}

	void UpdateQueue (Delegates.ScreenType screenType)
	{
		if(isBackClick)
			isBackClick = false;
		else
		{
			screenQueue.Add(screenType);
			backButton.interactable = true;
		}
	}
}