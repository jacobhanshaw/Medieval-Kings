using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character {

	public enum CharacterEnum {
		LordByron,
		Size
	}

	public enum CharacterState {
		Enemy,
		Neutral,
		Friend,
		Size
	}

	public string name { get; private set; }
	public float loyalty { get; private set; }
	public int armySize { get; private set; }

	public string dossierInformation;
	public List<Dialogue> dialogues;

	public CharacterState characterState { get { return loyalty > 0.5 ? CharacterState.Friend : (loyalty > -0.5 ? CharacterState.Neutral : CharacterState.Enemy); }}
	public string imageFileName { get { return name.Replace(" ", ""); }}

	public Character(CharacterEnum characterEnum) {
		name = GetName(characterEnum);
		loyalty = GetInitialLoyalty(characterEnum);
		armySize = GetArmySize(characterEnum);
		dossierInformation = GetDossierInformation(characterEnum);
		dialogues = GetDialogues(characterEnum);
	}

	public void UpdateLoyalty(float aLoyalty) {
		CharacterState oldState = characterState;
		loyalty = aLoyalty;
		Delegates.Instance.LoyaltyChangedListeners(this);
		if(oldState != characterState)
			Delegates.Instance.ArmyChangedListeners(this, oldState);
	}

	string GetName(CharacterEnum characterEnum) {
		switch(characterEnum) {
		case CharacterEnum.LordByron:
			return "Lord Byron";
		default:
			throw new UnityException("WRONG");
		}
	}

	int GetArmySize(CharacterEnum characterEnum) {
		switch(characterEnum) {
		case CharacterEnum.LordByron:
			return LordByron.ArmySize();
		default:
			throw new UnityException("WRONG");
		}
	}

	float GetInitialLoyalty(CharacterEnum characterEnum) {
		switch(characterEnum) {
		case CharacterEnum.LordByron:
			return LordByron.InitialLoyalty();
		default:
			throw new UnityException("WRONG");
		}
	}

	string GetDossierInformation(CharacterEnum characterEnum) {
		switch(characterEnum) {
		case CharacterEnum.LordByron:
			return LordByron.DossierInformation();
		default:
			throw new UnityException("WRONG");
		}
	}

	List<Dialogue> GetDialogues(CharacterEnum characterEnum) {
		switch(characterEnum) {
		case CharacterEnum.LordByron:
			return LordByron.Dialogues();
		default:
			throw new UnityException("WRONG");
		}
	}
}
