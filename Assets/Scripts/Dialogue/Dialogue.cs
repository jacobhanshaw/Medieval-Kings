using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue {
	public DialogueMoment[] dialogMoments { get; private set; }

	public Dialogue(DialogueMoment[] aDialogueMoments) {
		dialogMoments = aDialogueMoments;
	}
}