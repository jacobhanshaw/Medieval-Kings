using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour {

	Character selectedCharacter;
	Dialogue selectedDialogue;
	int momentIndex;

	void Start () {
		Delegates.Instance.CharactersLoadedListeners += CharactersLoaded;
		Delegates.Instance.CharacterSelectedListeners += UpdateSelectedCharacter;
		Delegates.Instance.ContinueDialogueListeners += ContinueDialoguePicked;
		Delegates.Instance.DialogResponsePickedListeners += DialogResponsePicked;

		UpdateSelectedCharacter(new Character(Character.CharacterEnum.Advisor));
	}

	void OnDestroy ()
	{
		if(Delegates.Instance != null) {
			Delegates.Instance.CharactersLoadedListeners -= CharactersLoaded;
			Delegates.Instance.CharacterSelectedListeners -= UpdateSelectedCharacter;
			Delegates.Instance.ContinueDialogueListeners -= ContinueDialoguePicked;
			Delegates.Instance.DialogResponsePickedListeners -= DialogResponsePicked;
		}
	}

	public void CharactersLoaded(Character[] characters) {
		selectedCharacter = null;
		selectedDialogue = null;
		momentIndex = 0;
	}

	public void UpdateSelectedCharacter(Character character) {
		selectedCharacter = character;
		selectedDialogue = character.dialogues[0];
		selectedCharacter.dialogues.RemoveAt(0);
		momentIndex = 0;
		Delegates.Instance.LoadDialogueMomentListeners(selectedCharacter, selectedDialogue.dialogMoments[momentIndex], true);
	}

	public void ContinueDialoguePicked(DialogueMoment followUpMoment) {
		// Happens on initial load
		if (selectedDialogue == null)
			return;

		if(followUpMoment != null) {
			Delegates.Instance.LoadDialogueMomentListeners(selectedCharacter, followUpMoment, false);
			return;
		}

		++momentIndex;
		DialogueMoment nextMoment = null;
		if(momentIndex < selectedDialogue.dialogMoments.Length) {
			nextMoment = selectedDialogue.dialogMoments[momentIndex];
		}
		Delegates.Instance.LoadDialogueMomentListeners(selectedCharacter, nextMoment, false);

		if(nextMoment == null) {
			// Finished with conversation with loyal advisor
			if(Delegates.Instance.ConversationOverListeners == null) {
				// TODO: Move load characters to character select
				GameManager.Instance.LoadCharacters();
				Delegates.Instance.ScreenSelectListeners(Delegates.ScreenType.DOSSIER);
			} else 
				Delegates.Instance.ConversationOverListeners(selectedCharacter);
		}
	}

	public void DialogResponsePicked(int responseIndex) {
		DialogueResponse dialogueResponse = ((ResponseDialogueMoment)selectedDialogue.dialogMoments[momentIndex]).responses[responseIndex];
		float loyaltyChange = dialogueResponse.loyaltyEffect;
		selectedCharacter.ChangeLoyalty(loyaltyChange);

		DialogueMoment followUpMoment = dialogueResponse.followUpMoment;
		Delegates.Instance.ContinueDialogueListeners(followUpMoment);
	}
}
