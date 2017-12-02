using UnityEngine;
using System.Collections;

public class ShowScreenScript : MonoBehaviour 
{
	public Delegates.ScreenType screenType = Delegates.ScreenType.HOME;

	public void ShowScreen()
	{
		Delegates.Instance.ScreenSelectListeners(screenType);
	}
}