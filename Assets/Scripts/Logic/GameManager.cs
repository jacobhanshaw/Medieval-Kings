using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {
	public bool levelLoaded { get { return characters == null; }}
	[HideInInspector]
	public Character[] characters = null;
	[HideInInspector]
	private string[] names = { "Jacob", "Jingle", "Heimer", "Schmidt" };

	LordDisplayScript[] lordDisplayScripts = null;

	public void Reset() {
		characters = null;
	}

	public void LoadLevel() {
		characters = new Character[names.Length];
		for(int i = 0; i < characters.Length; ++i) {
			characters[i] = new Character(i);
		}
	}

	public void SetLordDisplayScripts(LordDisplayScript[] aLordDisplayScripts) {
		lordDisplayScripts = aLordDisplayScripts;
	}
}
