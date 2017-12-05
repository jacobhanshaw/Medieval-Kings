using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LordKevin : CharacterTemplate {
	public override string Name() {
		return "Lord Kevin Jeff III, Prince of the Hill People";
	}

	public override string ShortName() {
		return "Lord Kevin";
	}

	public override string ImageName() {
		return "LordKevin";
	}

	public override float InitialLoyalty() {
		return -0.3f;
	}

	public override string Lands() {
		return "Nova Bama";
	}

	public override string KnownFor() {
		return "Lumber and Whiskey";
	}

	public override string Motto() {
		return "Y’all come back now, y’hear?";
	}

	public override string Religion() {
		return "Radical Reformed Jeffism";
	}

	public override int ArmySize() {
		return 4500;
	}

	public override string DossierInformation() {
		string dossierInformation = "Family History: The isolated lands of Nova Bama are located in the hot and humid equatorial region of the Western Continent. Surrounded by almost impossible swamps, Nova Bamans have little regular contact with the rest of the Continent and, as a result, have developed several peculiar habits.\nNot least of which is the literal deification of the ruling Jeff family by the locals when Cooper Jeff (the founder of the Jeff dynasty) wrassled a dire-crocodile into submission and, so the story of the miracle goes, was able to feed the starving Bamans sweet croc meat for months.\nBeing an isolated and having few profitable exports, the Jeff family is often considered the poorest of the ruling families. Though distasteful, a tit for tat offer of specie in return for their commitment to our cause could be strong play.";
		dossierInformation += "\n\n\n";
		dossierInformation += "Personality: You can never trust a man with two first names .. at least .. you can’t trust him to be normal. Kevin III has embraced his ‘godhood’ far more than any of his ancestors, reforming not just the religion but the very language of Nova Bama.. my understanding is that it is probably a good idea to bring a rhyming dictionary with you, since verse is now the basis of their speech.";
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
		prompt = "Dang ol I tell you hwat mang but I am just pleased as a scoundrel that y’all would invite me out here for your Great War Council.";
		dialogueMomentsList.Add(new TextDialogueMoment(prompt));
		optionText = "It wouldn’t think of hosting a War Council without calling upon our old allies in Nova Bama. It is in times like these that all of us must band together – Hildegaard is a threat to the very foundations of our culture.";
		optionResponse = "Well now ain’t this just the height of insult – did you not prepare for our consult? When you address Lord Kevin, he most high, you must rhyme your words, or expect no reply";
		option0 = new DialogueResponse(optionText, -0.4f, optionResponse);
		optionText = "I thank you for making the trip .. it must have been a long journey, please have some refreshment.";
		optionResponse = "Well now ain’t this just the height of insult – did you not prepare for our consult? When you address Lord Kevin, he most high, you must rhyme your words, or expect no reply!";
		option1 = new DialogueResponse(optionText, -0.4f, optionResponse);
		optionText = "We see ourselves blessed to host such a guest. [offer him some fresh sheep meat]";
		optionResponse = "It pleases me that you honor paradigm, that when you speak it is in rough rhyme so you can expect my support when it comes wartime.";
		option2 = new DialogueResponse(optionText, 0.4f, optionResponse);
		options = new DialogueResponse[]{ option0, option1, option2 };
		dialogueMomentsList.Add(new ResponseDialogueMoment(options));
		dialogues.Add(new Dialogue(dialogueMomentsList.ToArray()));

		dialogueMomentsList = new List<DialogueMoment>();
		prompt = "Though I am not proud of it, I’ll tell you true .. things are getting kind of rough out in the bayou. But I can promise that if can make it worthwhile me and mine then you and yours will end up just fine.";
		dialogueMomentsList.Add(new TextDialogueMoment(prompt));
		optionText = "(Lie) Oh? Oh! Right of course.. certainly if you pledge your support to my cause I will personally make sure you are amply rewarded with as much gold as you can carry.";
		optionResponse = "ell now ain’t this just the height of insult – did you not prepare for our consult? When you address Lord Kevin, he most high, you must rhyme your words, or expect no reply!";
		option0 = new DialogueResponse(optionText, -0.4f, optionResponse);
		optionText = "(Truth) I must appeal to your sense of honor, and take the risk I’ll be a goner .. for at this time we have no gold to spare and all I can promise is my support in any future warfare.";
		optionResponse = "I appreciate the rhyme, I’ll give you that .. but I need an offer of gold if you want help skinning this cat.  ";
		option1 = new DialogueResponse(optionText, 0f, optionResponse);
		optionText = "(Lie) Name your price in silver or gold, and you have my word you’ll be rich till yer old!";
		optionResponse = "I’m glad we could come to an understanding, it’ll help me clear all my debts outstanding.";
		option2 = new DialogueResponse(optionText, 0.6f, optionResponse);
		optionText = "Ahh I must apologize …  please excuse me, while I attend to my other guests.";
		optionResponse = "";
		option3 = new DialogueResponse(optionText, 0.0f, optionResponse);
		options = new DialogueResponse[]{ option0, option1, option2, option3 };
		dialogueMomentsList.Add(new ResponseDialogueMoment(options));
		dialogues.Add(new Dialogue(dialogueMomentsList.ToArray()));

		dialogueMomentsList = new List<DialogueMoment>();
		prompt = "Well it seems this evening is coming to a close, and things have gone well as far as that goes. But before I depart and head back to my lands, could you to tell me where your plan stands?";
		dialogueMomentsList.Add(new TextDialogueMoment(prompt));
		optionText = "The plan is to ride out and meet Hildegaard head in the field .. with a little luck and noble allies at my side, we’ll take the day and crush the barbarian invaders.";
		optionResponse = "Well now ain’t this just the height of insult – did you not prepare for our consult? When you address Lord Kevin, he most high, you must rhyme your words, or expect no reply!";
		option0 = new DialogueResponse(optionText, -0.4f, optionResponse);
		optionText = "I will unite my allies and bring them to the field. Then we’ll all fight together, and make Hildegaard yield!";
		optionResponse = "I appreciate the rhyme, I’ll give you that .. but I need an offer of gold if you want help skinning this cat.  ";
		option1 = new DialogueResponse(optionText, 0f, optionResponse);
		optionText = "(Lie) My allies and I will march to battle and we’ll stomp out Hildegaard’s rabble. And I promise to you that my allies so bold will find their pockets heavy, laden with gold.";
		optionResponse = "If golds on offer, you can count me in. And when I fight for money I usually win.";
		option2 = new DialogueResponse(optionText, 0.2f, optionResponse);
		optionText = "Ahh I must apologize …  please excuse me, while I attend to my other guests.";
		optionResponse = "";
		option3 = new DialogueResponse(optionText, 0.0f, optionResponse);
		options = new DialogueResponse[]{ option0, option1, option2, option3 };
		dialogueMomentsList.Add(new ResponseDialogueMoment(options));
		dialogues.Add(new Dialogue(dialogueMomentsList.ToArray()));

		return dialogues;
	}
}
