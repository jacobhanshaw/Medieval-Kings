using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delegates : Singleton<Delegates> {

	// Screen Select Delegate
	public delegate void ScreenSelect (ScreenType enuScreenType);
	public ScreenSelect ScreenSelectListeners;

	[SerializeField]
	public enum ScreenType
	{
		HOME,
		INTRODUCTION,
		DOSSIER,
		GAME,
		SIZE
	}

	// Characters Loaded Delegate
	public delegate void CharactersLoaded (Character[] characters);
	public CharactersLoaded CharactersLoadedListeners;

	// Character Picked Delegate
	public delegate void CharacterSelected (Character character);
	public CharacterSelected CharacterSelectedListeners;

	// Load Dialogue Option Delegate
	public delegate void LoadDialogueMoment (Character selectedCharacter, DialogueMoment dialogueMoment, bool newDialogue);
	public LoadDialogueMoment LoadDialogueMomentListeners;

	// Continue Dialogue Delegate
	public delegate void ContinueDialogue (DialogueMoment followUpMoment);
	public ContinueDialogue ContinueDialogueListeners;

	// Option Picked Delegate
	public delegate void DialogResponsePicked (int responseIndex);
	public DialogResponsePicked DialogResponsePickedListeners;

	// Loyalty Changed Delegate
	public delegate void LoyaltyChanged (Character character, float loyaltyChange);
	public LoyaltyChanged LoyaltyChangedListeners;

	// Conversation Over Delegate
	public delegate void ConversationOver(Character character);
	public ConversationOver ConversationOverListeners;

	// Army Changed Delegate
	public delegate void ArmyChanged (Character character, Character.CharacterState oldState);
	public ArmyChanged ArmyChangedListeners;
}