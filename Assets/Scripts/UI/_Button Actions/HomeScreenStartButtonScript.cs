using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScreenStartButtonScript : MonoBehaviour {

	bool clickedBefore;

	public void OnClick() {
		if(clickedBefore) {
			// TODO: Move this to after character selection
			GameManager.Instance.LoadCharacters();
			Delegates.Instance.ScreenSelectListeners(Delegates.ScreenType.DOSSIER);
		}
		else
			Delegates.Instance.ScreenSelectListeners(Delegates.ScreenType.INTRODUCTION);

		clickedBefore = true;
	}
}
