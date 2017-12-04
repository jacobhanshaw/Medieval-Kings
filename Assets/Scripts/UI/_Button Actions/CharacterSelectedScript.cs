using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectedScript : MonoBehaviour {

	Character character;

	public void SetCharacter(Character aCharacter) {
		character = aCharacter;
	}

	public void OnClick() {
		Delegates.Instance.CharacterSelectedListeners(character);
	}
}
