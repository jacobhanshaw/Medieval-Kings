using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerReset : MonoBehaviour {

	void Start ()
	{
		Delegates.Instance.ScreenSelectListeners += ResetGameManager;
	}

	void OnDestroy ()
	{
		if(Delegates.Instance != null)
			Delegates.Instance.ScreenSelectListeners -= ResetGameManager;
	}

	public void ResetGameManager (Delegates.ScreenType screenType)
	{
		if(screenType == Delegates.ScreenType.HOME) {
			GameManager.Instance.Reset();
		}
	}
}
