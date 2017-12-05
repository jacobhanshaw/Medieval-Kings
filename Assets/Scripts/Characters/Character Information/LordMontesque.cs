using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LordMontesque : CharacterTemplate {
	public override string Name() {
		return "Lord Davidicus Cannaberry de Montesque";
	}

	public override string ShortName() {
		return "Lord Davidicus Cannaberry de Montesque";
	}

	public override string ImageName() {
		return "LordMontesque";
	}

	public override float InitialLoyalty() {
		return 0.4f;
	}

	public override string Lands() {
		return "The Arrasque Valley";
	}

	public override string KnownFor() {
		return "Mines";
	}

	public override string Motto() {
		return "The Light of Truth the Sword of Justice";
	}

	public override string Religion() {
		return "Radical Orange Universalism";
	}

	public override int ArmySize() {
		return 5000;
	}

	public override string DossierInformation() {
		string dossierInformation = "Family History: One of the First Families, the noble de Montesque line has governed the great valley of Arrasque since the days of the first settlers arrived in the Lands of Western Continent. They have maintained their hold on the valley with a heavy military hand. The people of the Arrasque have few rights or liberties but if there’s one thing commoners love more than flashy military victories it is unflagging economic stability and it is on that strategy the Montesque’s have secured their rein.\nTheir family has been a steadfast ally of your family for generations. Several notable moments of cooperation include when your great-great grandmother helped them through a famine by giving them our entire surplus store of grain and sheep cheese. This kindness was repaid a generation later when the current Lord Cannaberry’s great-grandfather Reginaldus II came to the aid of your great-grandfather at the famed Battle of the Golden Showers. On the second day, Reginaldus executed a surprise flanking maneuver that broke the enemy lines and saved your great-grandfather from certain defeat.";
		dossierInformation += "\n\n\n";
		dossierInformation += "Personality: The current Lord Cannaberry is a stern man who revels in the glorious military successes of his ancestors. He is very proud of his family and he will expect you to be proud of them too. ";
		return dossierInformation;
	}

	public override List<Dialogue> Dialogues() {
		List<Dialogue> dialogues = new List<Dialogue>();
		DialogueResponse[] options = null;
		string prompt = "";
		string optionText = "";
		string optionResponse = "";
		DialogueResponse option0 = null;
		DialogueResponse option1 = null;
		DialogueResponse option2 = null;
		DialogueResponse option3 = null;

		List<DialogueMoment> dialogueMomentsList = null;

		dialogueMomentsList = new List<DialogueMoment>();
		dialogueMomentsList.Add(new TextDialogueMoment("Hello my old friend. I am pleased to have been invited to this Great Council of War. Could you get me something to drink?"));
		option0 = new DialogueResponse("I am very grateful you could attend. [pass him a flagon of water]", 0.0f, "");
		option1 = new DialogueResponse("We are overjoyed at your presence .. I hope to count you among friends on the battlefield [pass him a mug of beer]", 0.0f, "");
		option2 = new DialogueResponse("Our families have a long history together, I couldn’t imagine you not being here [summon a servant to take his order]", 0.0f, "");
		options = new DialogueResponse[]{ option0, option1, option2 };
		dialogueMomentsList.Add(new ResponseDialogueMoment(options));
		dialogues.Add(new Dialogue(dialogueMomentsList.ToArray()));

		dialogueMomentsList = new List<DialogueMoment>();
		dialogueMomentsList.Add(new TextDialogueMoment("It is good that you have called on me.  Of course our families have a long history of cooperation .. our allegiance in the upcoming battle will echo previous glorious events of our past."));
		optionText = "I am glad I can count on your support! This is really just another time when we can help each other - just as my family once helped your country out of times of famine you can help us defeat these dreaded barbarians.";
		optionResponse = "Oh my. Well now, I really don’t think it is appropriate of you to bring up such an embarrassing moment in our history. I do not like to be reminded of the time mismanagement and fate conspired to starve so many hundreds of my subjects and we were forced to beg for assistance.";
		option0 = new DialogueResponse(optionText, -0.5f, optionResponse);
		optionText = "Yes of course. It will be just like when your grandfather Reginaldus II lead a glorious charge against the main enemy line and saved my grandfather from almost certain doom.";
		optionResponse = "Do you really expect me to fight for someone who can’t even be bothered to remember their history correctly?? My great-grandfather rescued your family’s armies with a surprise attack from the left flank .. hardly the same thing as a frontal charge! For your own sake, I certainly hope you are less inept when the actual battle occurs!";
		option1 = new DialogueResponse(optionText, -0.5f, optionResponse);
		optionText = "Indeed our actions will echo previous events. Just as your ancestor Reginaldus II executed a surprise flanking maneuver against the enemy line, I expect you to be no less daring in the upcoming battle.";
		optionResponse = "Ha yes! A great moment in our share pasts. As every great general knows, the key to victory is knowledge of the past. I hope to supporting you similarly on the battlefield.";
		option2 = new DialogueResponse(optionText, 0.2f, optionResponse);
		optionText = "Ah, yes, of course. Please excuse me, I must attend to my other guests.";
		optionResponse = "";
		option3 = new DialogueResponse(optionText, 0.0f, optionResponse);
		options = new DialogueResponse[]{ option0, option1, option2, option3 };
		dialogueMomentsList.Add(new ResponseDialogueMoment(options));
		dialogues.Add(new Dialogue(dialogueMomentsList.ToArray()));

		dialogueMomentsList = new List<DialogueMoment>();
		prompt = "Anyway .. I hope that this will be another opportunity for me to prove myself as my forebears have .. to live up to our long standing credo..";
		dialogueMomentsList.Add(new TextDialogueMoment(prompt));
		optionText = "Of course .. you absolutely live up to your family’s famous motto: \"The flame of Truth the sword of Justice\"";
		optionResponse = "Well no that isn’t it at all.. Given your apparent disinterest in our affairs it might be time to reevaluate our family’s historic support of your rule.";
		option0 = new DialogueResponse(optionText, -0.5f, optionResponse);
		optionText = "Of course .. you absolutely live up to your familiy’s famous motto .. \"Bringing Justice with the Flaming Sword of Truth\"";
		optionResponse = "Well no that isn’t it at all.. Given your apparent disinterest in our affairs it might be time to reevaluate our family’s historic support of your rule";
		option1 = new DialogueResponse(optionText, -0.5f, optionResponse);
		optionText = "Of course .. you absolutely live up to your familiy’s famous motto .. \"The Light of Truth the Sword of Justice\"";
		optionResponse = "Ho ho yes that is it word for word! Clearly you care a great deal about my family and our alliance.";
		option2 = new DialogueResponse(optionText, 0.2f, optionResponse);
		optionText = "Ah, yes, of course. Please excuse me, I must attend to my other guests.";
		optionResponse = "";
		option3 = new DialogueResponse(optionText, 0.0f, optionResponse);
		options = new DialogueResponse[]{ option0, option1, option2, option3 };
		dialogueMomentsList.Add(new ResponseDialogueMoment(options));
		dialogues.Add(new Dialogue(dialogueMomentsList.ToArray()));

		return dialogues;
	}
}
