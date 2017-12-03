using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTextSelectedScript : MonoBehaviour {

	public void onClick() {
		Delegates.Instance.ContinueDialogueListeners(null);
	}
}
