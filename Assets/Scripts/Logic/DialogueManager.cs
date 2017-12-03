using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour {

	Character selectedCharacter;
	Dialogue selectedDialogue;
	int momentIndex;

	void Start () {
		Delegates.Instance.CharacterPickedListeners += UpdateSelectedCharacter;
		Delegates.Instance.ContinueDialogueListeners += ContinueDialoguePicked;
	}

	void OnDestroy ()
	{
		if(Delegates.Instance != null) {
			Delegates.Instance.CharacterPickedListeners -= UpdateSelectedCharacter;
			Delegates.Instance.ContinueDialogueListeners -= ContinueDialoguePicked;
		}
	}

	public void UpdateSelectedCharacter(Character character) {
		selectedCharacter = character;
		selectedDialogue = character.dialogues[0];
		selectedCharacter.dialogues.RemoveAt(0);
		momentIndex = 0;
		Delegates.Instance.LoadDialogueMomentListeners(selectedCharacter, selectedDialogue.dialogMoments[momentIndex]);
	}

	public void ContinueDialoguePicked(DialogueMoment followUpMoment) {
		if(followUpMoment != null) {
			Delegates.Instance.LoadDialogueMomentListeners(selectedCharacter, followUpMoment);
			return;
		}

		++momentIndex;
		DialogueMoment nextMoment = null;
		if(momentIndex < selectedDialogue.dialogMoments.Length) {
			nextMoment = selectedDialogue.dialogMoments[momentIndex];
		}
		Delegates.Instance.LoadDialogueMomentListeners(selectedCharacter, nextMoment);
	}

	public void DialogResponsePicked(int responseIndex) {
		DialogueResponse dialogueResponse = ((ResponseDialogueMoment)selectedDialogue.dialogMoments[momentIndex]).responses[responseIndex];
		float loyaltyChange = dialogueResponse.loyaltyEffect;
		if (loyaltyChange != 0) {
			selectedCharacter.UpdateLoyalty(selectedCharacter.loyalty + loyaltyChange);
		}

		DialogueMoment followUpMoment = dialogueResponse.followUpMoment;
		Delegates.Instance.ContinueDialogueListeners(followUpMoment);
	}
}
