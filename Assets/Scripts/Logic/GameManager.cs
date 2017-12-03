using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {
	public bool levelLoaded { get { return lordDisplayScripts != null; }}
	[HideInInspector]
	public Character[] characters = null;
	[HideInInspector]
	private Character.CharacterEnum[] enums = { 
		Character.CharacterEnum.LordByron,
		Character.CharacterEnum.LordByron,
		Character.CharacterEnum.LordByron
	};

	LordDisplayScript[] lordDisplayScripts = null;

	public void Reset() {
		characters = null;
		lordDisplayScripts = null;
	}

	public void LoadLevel() {
		characters = new Character[enums.Length];
		for(int i = 0; i < characters.Length; ++i) {
			characters[i] = new Character(enums[i]);
		}
	}

	public void SetLordDisplayScripts(LordDisplayScript[] aLordDisplayScripts) {
		lordDisplayScripts = aLordDisplayScripts;
	}
}
