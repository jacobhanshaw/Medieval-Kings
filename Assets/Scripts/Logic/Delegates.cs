using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delegates : Singleton<Delegates> {

	// Menu Screen Select Delegate
	public delegate void MenuScreenSelect (MenuScreenType enuScreenType);
	public MenuScreenSelect MenuScreenSelectListeners;

	[SerializeField]
	public enum MenuScreenType
	{
		HOME,
		INTRODUCTION,
		SIZE
	}


}