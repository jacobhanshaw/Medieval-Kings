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
	public delegate void CharacterPicked (Character character);
	public CharacterPicked CharacterPickedListeners;

	// Load Dialogue Option Delegate
	public delegate void LoadDialogueMoment (Character selectedCharacter, DialogueMoment dialogueMoment);
	public LoadDialogueMoment LoadDialogueMomentListeners;

	// Continue Dialogue Delegate
	public delegate void ContinueDialogue (DialogueMoment followUpMoment);
	public ContinueDialogue ContinueDialogueListeners;

	// Option Picked Delegate
	public delegate void DialogResponsePicked (int responseIndex);
	public DialogResponsePicked DialogResponsePickedListeners;

	// Loyalty Changed Delegate
	public delegate void LoyaltyChanged (Character character);
	public LoyaltyChanged LoyaltyChangedListeners;

	// Army Changed Delegate
	public delegate void ArmyChanged (Character character, Character.CharacterState oldState);
	public ArmyChanged ArmyChangedListeners;
}