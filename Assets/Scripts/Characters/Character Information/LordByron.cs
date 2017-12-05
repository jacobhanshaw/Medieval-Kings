using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LordByron : CharacterTemplate {
	public override string Name() {
		return "Lord Byron";
	}

	public override string ShortName() {
		return "Lord Byron";
	}

	public override string ImageName() {
		return "YourAdvisor";
	}

	public override float InitialLoyalty() {
		return 0.4f;
	}

	public override string Lands() {
		return "Wherever the Light Touches";
	}

	public override string KnownFor() {
		return "Holding Hands";
	}

	public override string Motto() {
		return "Get It Done Now";
	}

	public override string Religion() {
		return "\"Whichever has the Best Perks\"";
	}

	public override int ArmySize() {
		return 50000;
	}

	public override string DossierInformation() {
		return "I'm Lord Byron. BLAH BLAH. I think I'm all that and what not.";
	}

	public override List<Dialogue> Dialogues() {
		List<Dialogue> dialogues = new List<Dialogue>();
		DialogueResponse[] options = null;

		List<DialogueMoment> dialogueMomentsList = null;

		dialogueMomentsList = new List<DialogueMoment>();
		dialogueMomentsList.Add(new TextDialogueMoment("Hi and stuff"));
		dialogues.Add(new Dialogue(dialogueMomentsList.ToArray()));

		dialogueMomentsList = new List<DialogueMoment>();
		dialogueMomentsList.Add(new TextDialogueMoment("What do you think of me?"));
		options = new DialogueResponse[]{ new DialogueResponse("You suck", -0.8f, "How dare you!?"), new DialogueResponse("Not much", -0.2f, "I see..."), new DialogueResponse("You're the best!", 0.5f) };
		dialogueMomentsList.Add(new ResponseDialogueMoment(options));
		dialogues.Add(new Dialogue(dialogueMomentsList.ToArray()));

		dialogueMomentsList = new List<DialogueMoment>();
		dialogueMomentsList.Add(new TextDialogueMoment("What do you think of me?"));
		options = new DialogueResponse[]{ new DialogueResponse("You suck", -0.8f, "How dare you!?"), new DialogueResponse("Not much", -0.2f, "I see..."), new DialogueResponse("You're the best!", 0.5f) };
		dialogueMomentsList.Add(new ResponseDialogueMoment(options));
		dialogues.Add(new Dialogue(dialogueMomentsList.ToArray()));

		dialogueMomentsList = new List<DialogueMoment>();
		dialogueMomentsList.Add(new TextDialogueMoment("What do you think of me?"));
		options = new DialogueResponse[]{ new DialogueResponse("You suck", -0.8f, "How dare you!?"), new DialogueResponse("Not much", -0.2f, "I see..."), new DialogueResponse("You're the best!", 0.5f) };
		dialogueMomentsList.Add(new ResponseDialogueMoment(options));
		dialogues.Add(new Dialogue(dialogueMomentsList.ToArray()));

		dialogueMomentsList = new List<DialogueMoment>();
		dialogueMomentsList.Add(new TextDialogueMoment("What do you think of me?"));
		options = new DialogueResponse[]{ new DialogueResponse("You suck", -0.8f, "How dare you!?"), new DialogueResponse("Not much", -0.2f, "I see..."), new DialogueResponse("You're the best!", 0.5f) };
		dialogueMomentsList.Add(new ResponseDialogueMoment(options));
		dialogues.Add(new Dialogue(dialogueMomentsList.ToArray()));

		return dialogues;
	}
}
