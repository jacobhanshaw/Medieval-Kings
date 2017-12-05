using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadyMcKrombles : CharacterTemplate {
	public override string Name() {
		return "Grand Duchess Hardcastle McKrombles";
	}

	public override string ShortName() {
		return "Lady McKrombles";
	}

	public override string ImageName() {
		return "LadyMcKrombles";
	}

	public override float InitialLoyalty() {
		return -0.2f;
	}

	public override string Lands() {
		return "The Northern Marches";
	}

	public override string KnownFor() {
		return "Corriedale Sheep and hard winters ";
	}

	public override string Motto() {
		return "The cold has no mercy";
	}

	public override string Religion() {
		return "Inter-Galactic Presbyterian";
	}

	public override int ArmySize() {
		return 5000;
	}

	public override string DossierInformation() {
		string dossierInformation = "Family History: The ancient house of McKrombles gained control of the lands in the Northern Marches not so much by battle or political guile but because they simply outlasted anyone who tried to usurp them. They were among the very first families that settled in the Marches and in that time have strategically managed to let winter or disease or some other hardship bought about from poor planning (usually starvation) kill off any other families that have would take their place as governors of the territory. There resilience has endeared them to the people their and they are fanatically devoted to the McKrombles.\nSince the land is generally thought to be inhospitable to the point of not being survivable, few people migrate to the Northern Marches it is sparsely populated. However hardship breads hard people and warriors from the territory are renowned for their high constitution and strength scores Additionally, despite the long winters and poor soil, sheep have flourished there spurring a bustling industry in wool and sheep meat that provides some wealth to the Marches.";
		dossierInformation += "\n\n\n";
		dossierInformation += "Personality: As a staunch Inter-Galactic Presbyterian, Hardcastle frowns upon drunkenness and other kinds of debauched personal indulgence. She is very proud of the Corriedale sheep that are raised in her lands and always wears clothes made from wool harvested at her family’s estate.";
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
		prompt = "This is a quite the magnificent fortress you have .. you must be very proud of all you have accomplished. But I didn’t make this trip to spin compliments .. let’s get down to business.";
		dialogueMomentsList.Add(new TextDialogueMoment(prompt));
		optionText = "Yes of course .. it must have been a very difficult trip. Would you care for refreshment? [offer her a mug of beer]";
		optionResponse = "Oh well I would never drink .. you must know that! How could you not know that? I will try not to judge you by this one mistake too harshly.";
		option0 = new DialogueResponse(optionText, -0.2f, optionResponse);
		optionText = "Yes I am very proud of my family’s home .. and I am very glad you were able to make it to my War Council. [offer her some wine]";
		optionResponse = "What is this? Oh well I would never drink .. you must know that! How could you not know that? I will try not to judge you by this one mistake too harshly.";
		option1 = new DialogueResponse(optionText, -0.2f, optionResponse);
		optionText = "It is my great pleasure to be able to host you at this meeting of my War Council. [offer her some water]";
		optionResponse = "Oh well thank you! You are very kind for offer a weary traveler some refreshing water. This is just the stuff to rejuvenate the mind and cleanse the spirit.";
		option2 = new DialogueResponse(optionText, 0.2f, optionResponse);
		options = new DialogueResponse[]{ option0, option1, option2 };
		dialogueMomentsList.Add(new ResponseDialogueMoment(options));
		dialogues.Add(new Dialogue(dialogueMomentsList.ToArray()));

		dialogueMomentsList = new List<DialogueMoment>();
		prompt = "I am troubled to hear of the return of Hildegaard and her barbarian army. The last time they tried to invade their propaganda about overthrowing our aristocratic dynasties and replacing them with democratic institutions that respected all people equally before the law almost saw the common people desert their divinely ordained rulers!";
		dialogueMomentsList.Add(new TextDialogueMoment(prompt));
		optionText = "The common people never know what’s best for them. It is best for everyone that enlightened nobles such as ourselves take up the burden of ruling over these lands.";
		optionResponse = "Yes everyone has their place, as decided by God.. all we can do is play our part in His Divine Plan.";
		option0 = new DialogueResponse(optionText, 0f, optionResponse);
		optionText = "Truthfully it could be in all of our best interests if we adopted some modest reforms .. for example, I think everyone knows the Divine Right of The Aristocrats is just a tool for holding on to power, rather than an actual mandate from heaven.";
		optionResponse = "How dare you utter such blasphemy! I will never know why God chooses to work through such flawed nobles as yourself.. but He has placed you in your position and it is not my place to question Him";
		option1 = new DialogueResponse(optionText, -0.5f, optionResponse);
		optionText = "Hidlegaard is a menace that threatens the legitimacy of us all. It is imperative for all of our sakes that we band together to stop her and her minions once and for all!";
		optionResponse = "Yes it would seem so .. but I put my faith in Our Divine Lord .. and less so in the plots of us mere mortals. If it is His Will than we shall be victorious.";
		option2 = new DialogueResponse(optionText, 0f, optionResponse);
		optionText = "Ahh I must apologize …  please excuse me, while I attend to my other guests.";
		optionResponse = "";
		option3 = new DialogueResponse(optionText, 0.0f, optionResponse);
		options = new DialogueResponse[]{ option0, option1, option2, option3 };
		dialogueMomentsList.Add(new ResponseDialogueMoment(options));
		dialogues.Add(new Dialogue(dialogueMomentsList.ToArray()));

		dialogueMomentsList = new List<DialogueMoment>();
		prompt = " I must say, this dinner has been wonderful. The boiled sheep is some of the best I have ever had. Tell me, what kind of sheep is it?";
		dialogueMomentsList.Add(new TextDialogueMoment(prompt));
		optionText = "You know, I honestly don’t know what kind it is .. I’ve never really been able to taste the difference between different kinds of sheep. But I imagine you can .. your lands are rich with sheep, if I am remembering my geography correctly. ";
		optionResponse = "Well of course I can tell the difference .. how can anyone not tell the difference? Really, these kinds of details are important. If I can trust you to keep up with the little things during a polite dinner party, how on earth can I trust you will keep track of the details that can win or lose a battle? You must do better, young prince.";
		option0 = new DialogueResponse(optionText, -0.3f, optionResponse);
		optionText = "(Lie) The meat is from Cotswald sheep .. the same for which your lands are famous, if I am remembering correctly.";
		optionResponse = "Cotswald? COTSWALD? HOW DARE YOU BRING UP THE HATED COTSWALD BREED! MY FAMILY WOULD NEVER BE CAUGHT RAISING SUCH AN INFERIOR KIND OF SHEEP! HARUMPH";
		option1 = new DialogueResponse(optionText, -2f, optionResponse);
		optionText = "(Lie) They meat is from Corriedale sheep .. the same for which your lands are famous, if I am remembering correctly.";
		optionResponse = "Oh you flatter an old woman.. not only do you remember about my family’s prized sheep but you honor me by serving it to us all for dinner. You are truly a clever one!";
		option2 = new DialogueResponse(optionText, 1f, optionResponse);
		optionText = "Ahh I must apologize …  please excuse me, while I attend to my other guests.";
		optionResponse = "";
		option3 = new DialogueResponse(optionText, 0.0f, optionResponse);
		options = new DialogueResponse[]{ option0, option1, option2, option3 };
		dialogueMomentsList.Add(new ResponseDialogueMoment(options));
		dialogues.Add(new Dialogue(dialogueMomentsList.ToArray()));

		return dialogues;
	}
}
