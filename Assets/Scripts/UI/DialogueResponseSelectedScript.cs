using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueResponseSelectedScript : MonoBehaviour {

	public int responseIndex;

	public void onClick() {
		Delegates.Instance.DialogResponsePickedListeners(responseIndex);
	}
}
