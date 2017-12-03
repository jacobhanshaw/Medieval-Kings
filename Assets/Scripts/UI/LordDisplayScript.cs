using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LordDisplayScript : MonoBehaviour {

	public LoadImageScript loadImageScript;
	public LoyaltyWheelScript loyaltyWheelScript;

	public void UpdateWithLord(Character lord) {
		loadImageScript.LoadCharacterImage(lord.imageFileName);
		loyaltyWheelScript.SetCharacter(lord);
	}
}
