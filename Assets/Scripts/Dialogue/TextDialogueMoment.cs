using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDialogueMoment : DialogueMoment {
	public string text { get; private set; }

	public TextDialogueMoment(string aText, bool aUserMoment = false) {;
		text = aText;
		userMoment = aUserMoment;
	}
}
