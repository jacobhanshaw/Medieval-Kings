using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class ToggleCorrectionScript : MonoBehaviour 
{
	void Awake () 
	{
		Toggle toggleComp = GetComponent<Toggle>();
		toggleComp.targetGraphic = GetComponent<UICircle>();
		toggleComp.graphic = transform.GetChild(0).GetComponent<UICircle>();
	}
}