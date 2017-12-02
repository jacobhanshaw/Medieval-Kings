using UnityEngine;
using System.Collections;

public class RotationUpdater : Singleton<RotationUpdater> 
{
	const float ROTATION_DELAY = 0.1f;

	//Rotation Delegates
	bool landscape = Screen.width > Screen.height;
	public delegate void RotationChanged(bool isLandscape);
	public RotationChanged RotationChangedListeners;

	void Update ()
	{
		bool newLandscape = Screen.width > Screen.height;
		if(newLandscape != landscape)
		{
			landscape = newLandscape;
			StartCoroutine(RotateAfterDelay());
		}
	}

	IEnumerator RotateAfterDelay()
	{
		yield return new WaitForSeconds(ROTATION_DELAY);

		if(RotationChangedListeners != null)
			RotationChangedListeners(landscape);
	}

}