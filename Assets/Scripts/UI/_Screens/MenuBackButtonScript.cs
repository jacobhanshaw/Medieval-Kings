using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MenuBackButtonScript : MonoBehaviour 
{
	bool subscribed;
	bool isBackClick;
	Button backButton;
	List<Delegates.MenuScreenType> screenQueue;

	void Start () 
	{
		backButton = GetComponent<Button>();
		backButton.interactable = false;

		screenQueue = new List<Delegates.MenuScreenType>();
		screenQueue.Add(Delegates.MenuScreenType.HOME);

		Delegates.Instance.MenuScreenSelectListeners += UpdateQueue;
	}

	void OnDestroy ()
	{
		if(Delegates.Instance != null)
			Delegates.Instance.MenuScreenSelectListeners -= UpdateQueue;
	}

	public void OnClick ()
	{
		isBackClick = true;
		Delegates.MenuScreenType prevScreen = screenQueue[screenQueue.Count - 2];
		screenQueue.RemoveAt(screenQueue.Count - 1);
		if(prevScreen == Delegates.MenuScreenType.HOME)
			backButton.interactable = false;
		
		Delegates.Instance.MenuScreenSelectListeners(prevScreen);
	}

	void UpdateQueue (Delegates.MenuScreenType screenType)
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