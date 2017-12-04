using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character {

	public enum CharacterEnum {
		Advisor,
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

	public void ChangeLoyalty(float loyaltyChange) {
		CharacterState oldState = characterState;
		loyalty += loyaltyChange;
		if(loyalty > 1f)
			loyalty = 1f;
		else if(loyalty < -1f)
			loyalty = -1f;
		
		Delegates.Instance.LoyaltyChangedListeners(this, loyaltyChange);
		if(oldState != characterState && Delegates.Instance.ArmyChangedListeners != null)
			Delegates.Instance.ArmyChangedListeners(this, oldState);
	}

	string GetName(CharacterEnum characterEnum) {
		switch(characterEnum) {
		case CharacterEnum.LordByron:
			return "Lord Byron";
		case CharacterEnum.Advisor:
			return "Your Loyal Advisor";
		default:
			throw new UnityException("WRONG");
		}
	}

	int GetArmySize(CharacterEnum characterEnum) {
		switch(characterEnum) {
		case CharacterEnum.LordByron:
			return LordByron.ArmySize();
		case CharacterEnum.Advisor:
			return Advisor.ArmySize();
		default:
			throw new UnityException("WRONG");
		}
	}

	float GetInitialLoyalty(CharacterEnum characterEnum) {
		switch(characterEnum) {
		case CharacterEnum.LordByron:
			return LordByron.InitialLoyalty();
		case CharacterEnum.Advisor:
			return Advisor.InitialLoyalty();
		default:
			throw new UnityException("WRONG");
		}
	}

	string GetDossierInformation(CharacterEnum characterEnum) {
		switch(characterEnum) {
		case CharacterEnum.LordByron:
			return LordByron.DossierInformation();
		case CharacterEnum.Advisor:
			return Advisor.DossierInformation();
		default:
			throw new UnityException("WRONG");
		}
	}

	List<Dialogue> GetDialogues(CharacterEnum characterEnum) {
		switch(characterEnum) {
		case CharacterEnum.LordByron:
			return LordByron.Dialogues();
		case CharacterEnum.Advisor:
			return Advisor.Dialogues();
		default:
			throw new UnityException("WRONG");
		}
	}
}
