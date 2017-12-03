using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePanelScript : MonoBehaviour {

	public FadeCanvasGroupScript textPanel;
	public FadeCanvasGroupScript responsesPanel;
	public FadeCanvasGroupScript[] characterPanels;
	public LoadImageScript[] loadImageScripts;
	public LoadTextScript[] loadTextScripts;

	public Text textBox;
	public Text[] buttonTexts;

	int characterPanelIndex = 0;
	string defaultText;

	void Start () {
		defaultText = textBox.text;

		Delegates.Instance.LoadDialogueMomentListeners += LoadDialogueMoment;
	}

	void OnDestroy ()
	{
		if(Delegates.Instance != null)
			Delegates.Instance.LoadDialogueMomentListeners -= LoadDialogueMoment;
	}

	public void LoadDialogueMoment(Character selectedCharacter, DialogueMoment dialogueMoment) {
		SwapCharacterPanels(selectedCharacter, dialogueMoment.userMoment);

		if(dialogueMoment is TextDialogueMoment) {
			textBox.text = ((TextDialogueMoment)dialogueMoment).text;
		} else if(dialogueMoment is ResponseDialogueMoment) {
			DialogueResponse[] dialogueResponses = ((ResponseDialogueMoment)dialogueMoment).responses;
			for(int i = 0; i < buttonTexts.Length; ++i) {
				if(i < dialogueResponses.Length) {
					buttonTexts[i].transform.parent.gameObject.SetActive(true);
					buttonTexts[i].text = dialogueResponses[i].text;
				} else
					buttonTexts[i].transform.parent.gameObject.SetActive(false);
			}
		}
	}

	void SwapCharacterPanels(Character character, bool isUser) {
		characterPanels[characterPanelIndex].Show(false);
		++characterPanelIndex;
		if (characterPanelIndex >= characterPanels.Length)
			characterPanelIndex = 0;
		string fileName = isUser ? "" :  character.imageFileName ;
		loadImageScripts[characterPanelIndex].LoadImage(fileName);
		string characterName = isUser ? "You" : character.name;
		loadTextScripts[characterPanelIndex].LoadText(name);

		characterPanels[characterPanelIndex].Show(true);
	}
}

/*
		if(TextDialogueMoment textDialogueMoment = dialogueMoment as TextDialogueMoment) {
			textBox.text = textDialogueMoment.text;
		} else if(ResponseDialogueMoment responseDialogueMoment = dialogueMoment as ResponseDialogueMoment) {
			for(int i = 0; i < buttonTexts.Length; ++i) {
				if(i < responseDialogueMoment.)
			}
			responseDialogueMoment
			textBox.text = textDialogueMoment.text;
		} 
		*/