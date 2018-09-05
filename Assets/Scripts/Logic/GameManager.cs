using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {
	public GameObject giveUpButton;
	public GameObject toBattleButton;
	public GameObject toVictoryButton;

	[HideInInspector]
	public Character[] characters = null;
	[HideInInspector]
	public Character advisor = new Character(Character.CharacterEnum.YourAdvisor);

	public bool introductionShown = false;
	public int constantEnemyArmy = 12000;

	private Character.CharacterEnum[] enums = { 
		Character.CharacterEnum.LordMontesque,
		Character.CharacterEnum.ViscountPhilip,
		Character.CharacterEnum.LadyMcKrombles,
		Character.CharacterEnum.LordKevin
	};

	public int friendTotalArmy { 
		get {
			int total = 0;
			if(characters == null)
				return total;

			foreach(Character character in characters) {
				if(character.characterState == Character.CharacterState.Friend)
					total += character.armySize;
			}
			return total;
		}
	}

	public int enemyTotalArmy { 
		get {
			int total = constantEnemyArmy;
			if(characters == null)
				return total;

			foreach(Character character in characters) {
				if(character.characterState == Character.CharacterState.Enemy)
					total += character.armySize;
			}
			return total;
		}
	}

	void Start() {
		Delegates.Instance.ConversationOverListeners += CheckForGameOver;
		ResetButtons();
	}

	void OnDestroy() {
		if (Delegates.Instance != null)
			Delegates.Instance.ConversationOverListeners -= CheckForGameOver;
	}

	public void SetDifficulty(int difficulty) {
		if (difficulty == 2) {
			constantEnemyArmy = 3000;
			enums = new Character.CharacterEnum[] { 
				Character.CharacterEnum.LordMontesque,
				Character.CharacterEnum.LordKevin
			};
		} else if (difficulty == 3) {
			constantEnemyArmy = 7000;
			enums = new Character.CharacterEnum[] { 
				Character.CharacterEnum.LordMontesque,
				Character.CharacterEnum.ViscountPhilip,
				Character.CharacterEnum.LadyMcKrombles
			};

		} else if (difficulty == 4) {
			constantEnemyArmy = 12000;
			enums = new Character.CharacterEnum[] { 
				Character.CharacterEnum.LordMontesque,
				Character.CharacterEnum.ViscountPhilip,
				Character.CharacterEnum.LadyMcKrombles,
				Character.CharacterEnum.LordKevin
			};
		}
	}

	public void CheckForGameOver(Character lastCharacter) {
		// Quit if all negative locked in and all others are positive
		// If all friendly give option to quit
		// If winning give option for better ending

		if(lastCharacter.name == advisor.name)
			return;

		bool allFriendly = true;
		bool allLockedIn = true;

		bool addGiveUpOption = false;
		bool addWinOption = friendTotalArmy > enemyTotalArmy;

		foreach(Character character in characters) {
			allFriendly &= character.characterState == Character.CharacterState.Friend;
			allLockedIn &= character.dialogues.Count == 0;
			addGiveUpOption |= character.characterState == Character.CharacterState.Enemy;				
		}

		addGiveUpOption |= allLockedIn;

		giveUpButton.SetActive(addGiveUpOption);
		toBattleButton.SetActive(addWinOption && !allFriendly);
		toVictoryButton.SetActive(allFriendly);
	}

	public void Reset() {
		characters = null;
		ResetButtons();
		Delegates.Instance.ArmyChangedListeners(null, Character.CharacterState.Size);
	}

	void ResetButtons() {
		giveUpButton.SetActive(false);
		toBattleButton.SetActive(false);
		toVictoryButton.SetActive(false);
	}

	public void LoadCharacters() {
		characters = new Character[enums.Length];
		for(int i = 0; i < characters.Length; ++i) {
			characters[i] = new Character(enums[i]);
		}
		Delegates.Instance.CharactersLoadedListeners(characters);
	}
}
