using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueResponse {
	public string text { get; private set; }
	public float loyaltyEffect { get; private set; }
	public DialogueMoment followUpMoment { get; private set; }

	public DialogueResponse(string aText, float aLoyaltyEffect, string followUpText = "") {
		text = aText;
		loyaltyEffect = aLoyaltyEffect;
		if (followUpText.Length > 0)
			followUpMoment = new TextDialogueMoment(followUpText);
	}
}
