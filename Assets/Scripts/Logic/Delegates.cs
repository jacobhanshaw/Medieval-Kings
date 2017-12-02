using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delegates : Singleton<Delegates> {

	// Screen Select Delegate
	public delegate void ScreenSelect (ScreenType enuScreenType);
	public ScreenSelect ScreenSelectListeners;

	[SerializeField]
	public enum ScreenType
	{
		HOME,
		INTRODUCTION,
		DOSSIER,
		GAME,
		SIZE
	}


}