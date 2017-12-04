using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class DossierLoadTypeScript : MonoBehaviour {

	public GameObject startButton;
	public GameObject continueButton;

	bool dossierSeenBefore;

	void Start ()
	{
		Delegates.Instance.ScreenSelectListeners += UpdateDisplay;
	}

	void OnDestroy ()
	{
		if(Delegates.Instance != null)
			Delegates.Instance.ScreenSelectListeners -= UpdateDisplay;
	}

	public void UpdateDisplay (Delegates.ScreenType screenType)
	{
		if(screenType == Delegates.ScreenType.DOSSIER) {
			gameObject.transform.GetChild(0).GetComponent<Carousel>().PrepareForPresentation();

			startButton.SetActive(!dossierSeenBefore);
			continueButton.SetActive(dossierSeenBefore);

			dossierSeenBefore = true;
		} else if(screenType == Delegates.ScreenType.HOME){
			dossierSeenBefore = false;
			startButton.SetActive(!dossierSeenBefore);
			continueButton.SetActive(dossierSeenBefore);
		}
	}
}
