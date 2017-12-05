using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YourAdvisor : CharacterTemplate {
	public override string Name() {
		return "Your Loyal Advisor";
	}

	public override string ShortName() {
		return "Your Loyal Advisor";
	}

	public override string ImageName() {
		return "YourAdvisor";
	}

	public override float InitialLoyalty() {
		return 0.9f;
	}

	public override string Lands() {
		return "None";
	}

	public override string KnownFor() {
		return "Wisdom";
	}

	public override string Motto() {
		return "Knowledge is Power";
	}

	public override string Religion() {
		return "None";
	}

	public override int ArmySize() {
		return 0;
	}

	public override string DossierInformation() {
		return "I'm your loyal advisor.";
	}

	public override List<Dialogue> Dialogues() {
		List<Dialogue> dialogues = new List<Dialogue>();
		List<DialogueMoment> dialogueMomentsList = new List<DialogueMoment>();

		dialogueMomentsList.Add(new TextDialogueMoment("My liege, our advance scouts report that the Hordes of Hidlegaard the Dread are again threatening our borders!"));
		dialogueMomentsList.Add(new TextDialogueMoment("Oh no! What should I do?", true));

		dialogueMomentsList.Add(new TextDialogueMoment("As your forebears have done, you must assume the mantle of Imperator and assemble an army to repeal the barbarian queen and her invasion force."));
		dialogueMomentsList.Add(new TextDialogueMoment("But our country has no standing army! How can we levy troops?", true));

		dialogueMomentsList.Add(new TextDialogueMoment("You must call a War Council with your sworn allies and gain their support. If you can persuade them to join in our cause they will raise troops to supplement our army."));
		dialogueMomentsList.Add(new TextDialogueMoment("That sounds easy enough…", true));

		dialogueMomentsList.Add(new TextDialogueMoment("But be warned! The loyalty of these great lords and ladies is .. precarious .. and if you offend them they could decide you are an unworthy ally and pledge their support to Hildegaard’s invasion force."));
		dialogueMomentsList.Add(new TextDialogueMoment("That’s terrible! But also, I don’t know these people. How will I know what to say or not to say?", true));

		dialogueMomentsList.Add(new TextDialogueMoment("I have put together these dossiers on each of your guests .. read them carefully! They should help you navigate the difficult waters of high-stakes dinner diplomacy."));
		dialogueMomentsList.Add(new TextDialogueMoment("Thank you, my loyal advisor.", true));

		dialogueMomentsList.Add(new TextDialogueMoment("And remember – you only need enough soldiers to defeat the invading army! You can opt to not talk with anyone at the table, which will leave them neutral in the upcoming battle."));
		dialogueMomentsList.Add(new TextDialogueMoment("Alright alright, I get it. Show me these dossiers already!", true));

		dialogues.Add(new Dialogue(dialogueMomentsList.ToArray()));

		return dialogues;
	}
}
