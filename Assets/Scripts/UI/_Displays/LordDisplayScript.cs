using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LordDisplayScript : MonoBehaviour {

	Character lord;

	public GameObject doneImage;
	public Button lordSelectButton;
	public LoadImageScript loadImageScript;
	public LoyaltyWheelScript loyaltyWheelScript;
	public CharacterSelectedScript characterSelectedScript;

	void Start() {
		Delegates.Instance.CharacterSelectedListeners += ConversationStarted;
		Delegates.Instance.ConversationOverListeners += ConversationOver;
	}

	void OnDestroy() {
		if(Delegates.Instance != null) {
			Delegates.Instance.CharacterSelectedListeners -= ConversationStarted;
			Delegates.Instance.ConversationOverListeners -= ConversationOver;
		}
	}

	public void ConversationStarted(Character aLord) {
		lordSelectButton.interactable = false;
	}

	public void ConversationOver(Character aLord) {
		bool noDialogueOptionsLeft = lord.dialogues.Count == 0;
		lordSelectButton.interactable = !noDialogueOptionsLeft;
		doneImage.SetActive(noDialogueOptionsLeft);
	}

	public void UpdateWithLord(Character aLord) {
		lord = aLord;
		doneImage.SetActive(false);
		loadImageScript.LoadCharacterImage(lord.imageFileName);
		loyaltyWheelScript.SetCharacter(lord);
		characterSelectedScript.SetCharacter(lord);
	}
}