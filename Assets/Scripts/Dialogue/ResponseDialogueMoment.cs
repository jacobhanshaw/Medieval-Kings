using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseDialogueMoment : DialogueMoment {
	public DialogueResponse[] responses { get; private set; }

	public ResponseDialogueMoment(DialogueResponse[] aResponses) {
		userMoment = true;
		responses = aResponses;
	}
}
