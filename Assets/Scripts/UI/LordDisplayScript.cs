using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LordDisplayScript : MonoBehaviour {

	public Image lordImage;
	public LoyaltyWheelScript loyaltyWheelScript;

	public void UpdateWithLord(Character lord) {
		
	}

	public void UpdateLoyalty(float loyalty) {
		loyaltyWheelScript.SetLoyalty(loyalty);
	}
}
