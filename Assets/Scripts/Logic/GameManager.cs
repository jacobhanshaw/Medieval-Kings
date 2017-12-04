using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {
	[HideInInspector]
	public Character[] characters = null;

	public Character advisor = new Character(Character.CharacterEnum.Advisor);

	public int constantEnemyArmy = 20000;

	private Character.CharacterEnum[] enums = { 
		Character.CharacterEnum.LordByron,
		Character.CharacterEnum.LordByron,
		Character.CharacterEnum.LordByron
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

	public void Reset() {
		characters = null;
		Delegates.Instance.ArmyChangedListeners(null,Character.CharacterState.Size);
	}

	public void LoadCharacters() {
		characters = new Character[enums.Length];
		for(int i = 0; i < characters.Length; ++i) {
			characters[i] = new Character(enums[i]);
		}
		Delegates.Instance.CharactersLoadedListeners(characters);
	}
}
