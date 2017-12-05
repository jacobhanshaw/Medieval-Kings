using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScreenStartButtonScript : MonoBehaviour {

	public void OnClick() {
		if(GameManager.Instance.introductionShown) {
			// TODO: Move this to after character selection
			GameManager.Instance.LoadCharacters();
			Delegates.Instance.ScreenSelectListeners(Delegates.ScreenType.DOSSIER);
		}
		else {
			GameManager.Instance.introductionShown = true;
			Delegates.Instance.ScreenSelectListeners(Delegates.ScreenType.INTRODUCTION);
		}
	}
}
