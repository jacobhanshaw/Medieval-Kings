﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePanelScript : MonoBehaviour {

	bool inIntroduction = true;

	public FadeCanvasGroupScript textPanel;
	public FadeCanvasGroupScript responsesPanel;
	public FadeCanvasGroupScript[] characterPanels;
	public LoadImageScript[] loadImageScripts;
	public LoadTextScript[] loadTextScripts;

	public Text textBox;
	public Button textButton;

	public Text[] buttonTexts;

	int characterPanelIndex = 0;
	string advisorAdvice;

	void Start () {
		advisorAdvice = textBox.text;

		Delegates.Instance.ScreenSelectListeners += ScreenChanged;
		Delegates.Instance.LoadDialogueMomentListeners += LoadDialogueMoment;
		Delegates.Instance.LoyaltyChangedListeners += LoyaltyChanged;

		textPanel.Show(true);
		characterPanels[characterPanelIndex].Show(true);
	}

	void OnDestroy ()
	{
		if(Delegates.Instance != null) {
			Delegates.Instance.ScreenSelectListeners += ScreenChanged;
			Delegates.Instance.LoadDialogueMomentListeners -= LoadDialogueMoment;
			Delegates.Instance.LoyaltyChangedListeners -= LoyaltyChanged;
		}
	}

	// Load default message
	public void ScreenChanged(Delegates.ScreenType newScreen) {
		if(newScreen == Delegates.ScreenType.INTRODUCTION) {
			inIntroduction = true;
			advisorAdvice = "Sir? SIR! Please click the screen to at least show me you're paying some attention.";
		} else if(newScreen == Delegates.ScreenType.GAME) {
			inIntroduction = false;
			advisorAdvice = "Good evening sir. The guests have all arrived.\n\nYou'll be addressing each individually. \n\nSelect one and do be careful. Our kingdom depends on you.";
			LoadAdvisorText();
		}
	}

	public void LoyaltyChanged(Character aCharacter, float loyaltyChange) {
		if(loyaltyChange > 0)
			advisorAdvice = "That helped!";
		else if(loyaltyChange < 0)
			advisorAdvice = "Hm... Maybe that wasn't the best thing to say.";
		else
			advisorAdvice = "That didn't appear to shift opinion one way or the other";

		advisorAdvice += "\n\nTry again or perhaps try to persuade another characer to join your cause.";
	}

	public void LoadDialogueMoment(Character selectedCharacter, DialogueMoment dialogueMoment, bool newDialogue) {
		if(newDialogue) {
			textButton.interactable = true;
			advisorAdvice = "Now that the formalities are out of the way. Let's get down to business.";
			advisorAdvice += "\n\nTalk to a character and try to persuade them to join your cause.";
		}

		if(dialogueMoment == null) {
			LoadAdvisorText();
			return;
		}

		SwapCharacterPanels(selectedCharacter, dialogueMoment.userMoment);
		bool isTextMoment = dialogueMoment is TextDialogueMoment;
		bool isResponseMoment = dialogueMoment is ResponseDialogueMoment;

		if(isTextMoment) {
			textBox.text = ((TextDialogueMoment)dialogueMoment).text;
		} else if(isResponseMoment) {
			DialogueResponse[] dialogueResponses = ((ResponseDialogueMoment)dialogueMoment).responses;
			for(int i = 0; i < buttonTexts.Length; ++i) {
				if(i < dialogueResponses.Length) {
					buttonTexts[i].transform.parent.gameObject.SetActive(true);
					buttonTexts[i].text = dialogueResponses[i].text;
				} else
					buttonTexts[i].transform.parent.gameObject.SetActive(false);
			}
		}

		textPanel.Show(isTextMoment);
		responsesPanel.Show(isResponseMoment);
	}

	void SwapCharacterPanels(Character character, bool isUser) {
		characterPanels[characterPanelIndex].Show(false);
		++characterPanelIndex;
		if (characterPanelIndex >= characterPanels.Length)
			characterPanelIndex = 0;
		Character imageCharacter = isUser ? null :  character;
		loadImageScripts[characterPanelIndex].LoadCharacterImage(imageCharacter);
		string characterName = isUser ? "You" : character.shortName;
		loadTextScripts[characterPanelIndex].LoadText(characterName);

		characterPanels[characterPanelIndex].Show(true);
	}

	void LoadAdvisorText() {
		textBox.text = advisorAdvice;
		loadImageScripts[characterPanelIndex].LoadCharacterImage(GameManager.Instance.advisor);
		loadTextScripts[characterPanelIndex].LoadText(GameManager.Instance.advisor.shortName);
		textButton.interactable = false;

		textPanel.Show(true);
		responsesPanel.Show(false);
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