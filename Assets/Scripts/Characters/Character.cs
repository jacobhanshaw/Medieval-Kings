using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character {

	public enum CharacterEnum {
		YourAdvisor,
		LordByron,
		LordMontesque,
		ViscountPhilip,
		LadyMcKrombles,
		LordKevin,
		Size
	}

	public enum CharacterState {
		Enemy,
		Neutral,
		Friend,
		Size
	}

	public string name { get; private set; }
	public string shortName { get; private set; }
	public string imageName { get; private set; }
	public float loyalty { get; private set; }
	public string lands { get; private set; }
	public string knownFor { get; private set; }
	public string motto { get; private set; }
	public string religion { get; private set; }
	public int armySize { get; private set; }

	public string quickInfo { get { return QuickInfo(); } }
	public string dossierInformation;
	public List<Dialogue> dialogues;

	public CharacterState characterState { get { return loyalty > 0.5 ? CharacterState.Friend : (loyalty > -0.5 ? CharacterState.Neutral : CharacterState.Enemy); }}

	public Character(CharacterEnum characterEnum) {
		CharacterTemplate characterInfo = Character.GetCharacterClass(characterEnum);

		name = characterInfo.Name();
		shortName = characterInfo.ShortName();
		imageName = characterInfo.ImageName();
		loyalty = characterInfo.InitialLoyalty();
		lands = characterInfo.Lands();
		knownFor = characterInfo.KnownFor();
		motto = characterInfo.Motto();
		religion = characterInfo.Religion();
		armySize = characterInfo.ArmySize();
		dossierInformation = characterInfo.DossierInformation();
		dialogues = characterInfo.Dialogues();
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

	string QuickInfo() {
		string quickInfo = "Name: " + name;
		quickInfo += "\n\nLands: " + lands;
		quickInfo += "\n\nKnown for: " + knownFor;
		quickInfo += "\n\nMotto: " + motto;
		quickInfo += "\n\nReligion: " + religion;
		quickInfo += "\n\nArmy: " + armySize.ToString("N0") + " soldiers";
		return quickInfo;
	}

	private static CharacterTemplate GetCharacterClass(CharacterEnum characterEnum) {
		switch(characterEnum) {
		case CharacterEnum.YourAdvisor:
			return new YourAdvisor();
		case CharacterEnum.LordByron:
			return new LordByron();
		case CharacterEnum.LordMontesque:
			return new LordMontesque();
		case CharacterEnum.ViscountPhilip:
			return new ViscountPhilip();
		case CharacterEnum.LadyMcKrombles:
			return new LadyMcKrombles();
		case CharacterEnum.LordKevin:
			return new LordKevin();
		default:
			throw new UnityException("WRONG");
		}
	}
}
