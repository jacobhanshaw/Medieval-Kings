using UnityEngine;
using System.Collections;

public class ShowScreenScript : MonoBehaviour 
{
	public Delegates.MenuScreenType screenType = Delegates.MenuScreenType.HOME;

	public void ShowScreen()
	{
		Delegates.Instance.MenuScreenSelectListeners(screenType);
	}
}