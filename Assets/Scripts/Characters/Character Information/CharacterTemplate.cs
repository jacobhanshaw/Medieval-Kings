using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterTemplate  {
	public abstract string Name();

	public abstract string ShortName();

	public abstract string ImageName();

	public abstract float InitialLoyalty();

	public abstract string Lands();

	public abstract string KnownFor();

	public abstract string Motto();

	public abstract string Religion();

	public abstract int ArmySize();

	public abstract string DossierInformation();

	public abstract List<Dialogue> Dialogues();


	/*
	public override string DossierInformation() {
		string dossierInformation = "";
		dossierInformation += "\n\n\n";
		dossierInformation += "";
		return dossierInformation;
	}

	public override List<Dialogue> Dialogues() {
		List<Dialogue> dialogues = new List<Dialogue>();
		List<DialogueMoment> dialogueMomentsList = null;
		DialogueResponse[] options = null;
		string prompt = "";
		string optionText = "";
		string optionResponse = "";
		DialogueResponse option0 = null;
		DialogueResponse option1 = null;
		DialogueResponse option2 = null;
		DialogueResponse option3 = null;

		dialogueMomentsList = new List<DialogueMoment>();
		prompt = "";
		dialogueMomentsList.Add(new TextDialogueMoment(prompt));
		optionText = "";
		optionResponse = "";
		option0 = new DialogueResponse(optionText, -0.5f, optionResponse);
		optionText = "";
		optionResponse = "";
		option1 = new DialogueResponse(optionText, -0.5f, optionResponse);
		optionText = "";
		optionResponse = "";
		option2 = new DialogueResponse(optionText, 0.2f, optionResponse);
		options = new DialogueResponse[]{ option0, option1, option2 };
		dialogueMomentsList.Add(new ResponseDialogueMoment(options));
		dialogues.Add(new Dialogue(dialogueMomentsList.ToArray()));

		dialogueMomentsList = new List<DialogueMoment>();
		prompt = "";
		dialogueMomentsList.Add(new TextDialogueMoment(prompt));
		optionText = "";
		optionResponse = "";
		option0 = new DialogueResponse(optionText, -0.5f, optionResponse);
		optionText = "";
		optionResponse = "";
		option1 = new DialogueResponse(optionText, -0.5f, optionResponse);
		optionText = "";
		optionResponse = "";
		option2 = new DialogueResponse(optionText, 0.2f, optionResponse);
		optionText = "Ahh I must apologize …  please excuse me, while I attend to my other guests.";
		optionResponse = "";
		option3 = new DialogueResponse(optionText, 0.0f, optionResponse);
		options = new DialogueResponse[]{ option0, option1, option2, option3 };
		dialogueMomentsList.Add(new ResponseDialogueMoment(options));
		dialogues.Add(new Dialogue(dialogueMomentsList.ToArray()));

		dialogueMomentsList = new List<DialogueMoment>();
		prompt = "";
		dialogueMomentsList.Add(new TextDialogueMoment(prompt));
		optionText = "";
		optionResponse = "";
		option0 = new DialogueResponse(optionText, -0.5f, optionResponse);
		optionText = "";
		optionResponse = "";
		option1 = new DialogueResponse(optionText, -0.5f, optionResponse);
		optionText = "";
		optionResponse = "";
		option2 = new DialogueResponse(optionText, 0.2f, optionResponse);
		optionText = "Ahh I must apologize …  please excuse me, while I attend to my other guests.";
		optionResponse = "";
		option3 = new DialogueResponse(optionText, 0.0f, optionResponse);
		options = new DialogueResponse[]{ option0, option1, option2, option3 };
		dialogueMomentsList.Add(new ResponseDialogueMoment(options));
		dialogues.Add(new Dialogue(dialogueMomentsList.ToArray()));
*/

}
