using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViscountPhilip : CharacterTemplate {
	public override string Name() {
		return "The Right Honorable Viscount Philip du Conneaut, First Elector and Lord Protector of the Order of the Sacred Flame";
	}

	public override string ShortName() {
		return "Viscount Philip du Conneaut";
	}

	public override string ImageName() {
		return "ViscountPhilip";
	}

	public override float InitialLoyalty() {
		return 0.0f;
	}

	public override string Lands() {
		return "Viscounty of Bergiminy";
	}

	public override string KnownFor() {
		return "Sweet wines and delicious cheeses";
	}

	public override string Motto() {
		return "Life is here for the Living";
	}

	public override string Religion() {
		return "Agnostic Hedonist / Lapsed Orthodox Dominionist";
	}

	public override int ArmySize() {
		return 6000;
	}

	public override string DossierInformation() {
		string dossierInformation = "Family History: The Viscounty of Bergiminy is a rich and fertile land in the interior of the Western Continent. Reliable harvests and blessed with many natural resources, the relatively easy life for those in Bergiminy has imbued a habit of .. shall we say .. pleasure seeking in the denizens of the land.\nThe du Conneaut family has only recently come to power and they are considered new comers in the ranks of the Western Continents ruling aristocracy. Philip’s grandfather started life as a lowly cheese-monger but, through devious strategy and (it is rumored) a non-trivial number of murders, was able to remove the ailing Leveritt Dynasty and place his own family in power. \nThough they admittedly live up to the stereotype of indulgence that comes with being from Bergiminy, the du Conneaut’s are neither lazy nor stupid. Many have underestimated them, thinking them complacent, and those many have ended up floating upside down in some river or another while the du Conneaut’s remain in control of Bergiminy’s treasury and legal system.";
		dossierInformation += "\n\n\n";
		dossierInformation += "Personality: Philip likes to live the good life and you should be sure to show him every courtesy in this regard. Though a jovial person by nature, he is quite sensitive about any slight – imagined or otherwise .. so be sure to extend him every possible respect and treat him like the old guard, royal aristocrat he imagines himself to be.";
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
		prompt = "Ahh yes it is very good to be here, no? I am very pleased to have been invited to talk alliances with such a noble and august family as yours. ";
		dialogueMomentsList.Add(new TextDialogueMoment(prompt));
		optionText = "I am very grateful you could attend.";
		optionResponse = "Oh well now my young prince ..  is this what you call hospitality? I am truly astonished you think it beneath you offer me some refreshment. If you don’t have the foresight to know something as simple as “your noble guests require your attention” I don’t know how you expect me to trust that you can know the much more complicated and deadly business of War.";
		option0 = new DialogueResponse(optionText, -0.5f, optionResponse);
		optionText = "It is my great pleasure to be able to host you at this meeting of my War Council. [offer him some water]";
		optionResponse = "What is this? Water? My dear prince, I am no common farmer and am frankly astonished you would treat me as such. You surely must know a noble guest requires a noble drink.";
		option1 = new DialogueResponse(optionText, -0.5f, optionResponse);
		optionText = "It is my great pleasure to be able to host you at this meeting of my War Council. [offer him some fine wine]";
		optionResponse = "Ahh thank you! My my this is a fine vintage you have .. it pairs nicely with the boiled sheep your chef has prepared.";
		option2 = new DialogueResponse(optionText, 0.2f, optionResponse);
		options = new DialogueResponse[]{ option0, option1, option2 };
		dialogueMomentsList.Add(new ResponseDialogueMoment(options));
		dialogues.Add(new Dialogue(dialogueMomentsList.ToArray()));

		dialogueMomentsList = new List<DialogueMoment>();
		prompt = "But enough about hospitality .. let us move on to the more pressing matter of War. What are your plans for the coming engagement?";
		dialogueMomentsList.Add(new TextDialogueMoment(prompt));
		optionText = "I have a most cunning plan that will lure Hildegaard’s barbarian horde into a deadly trap. While I can’t reveal the details until you’ve committed your forces, I can say its deviousness would make even your storied grandfather proud.";
		optionResponse = "Oh well I certainly must have no idea what you mean by that comment! My grandfather was a most noble man .. not some lowborn common who engages in the kind of illicit or ‘devious’ behavior.. why I never!";
		option0 = new DialogueResponse(optionText, -0.5f, optionResponse);
		optionText = "With your help, most honorable Viscount Philip, we will ride out with superior numbers and crush the barbarian invaders in honorable and noble combat.";
		optionResponse = "I suppose that would work if you have the numbers .. though it pains me to remind you really ought to refer to me by my full and proper title .. the First Elector and Lord Protector of the Order of the Sacred Flame isn’t some trivial string of words that we added to the family name for no reason!";
		option1 = new DialogueResponse(optionText, -0.5f, optionResponse);
		optionText = "The plan is hardly important .. with The Right Honorable Viscount Philip du Conneaut, First Elector and Lord Protector of the Order of the Sacred Flame riding into the fray at my right hand, there is no way Fate would allow us to fail!";
		optionResponse = "Ahh such bravado! How wonderful! Lesser men might think war just a numbers game but you seem to realize the true importance of noble intention and in determining an event’s outcome!";
		option2 = new DialogueResponse(optionText, 0.6f, optionResponse);
		optionText = "Ahh I must apologize …  please excuse me, while I attend to my other guests.";
		optionResponse = "";
		option3 = new DialogueResponse(optionText, 0.0f, optionResponse);
		options = new DialogueResponse[]{ option0, option1, option2, option3 };
		dialogueMomentsList.Add(new ResponseDialogueMoment(options));
		dialogues.Add(new Dialogue(dialogueMomentsList.ToArray()));

		dialogueMomentsList = new List<DialogueMoment>();
		prompt = "But enough of this talk of war .. you really must share your secret for this delicious meal! I don’t think I’ve ever had boiled sheep and skewered peppers this good before in my life .. and I say this as a man who has enjoyed all the delights Bergiminy has to offer..";
		dialogueMomentsList.Add(new TextDialogueMoment(prompt));
		optionText = "[summon the chef to explain how the meal was prepared]";
		optionResponse = "Oh dear me .. do you .. do you really expect me to talk with a servant about cooking? Clearly I meant to have your chef speak with my chef, my dear prince .. honestly I don’t know what kind of person you take me for but I am not one who sullies himself with the common drudgery of cooking!";
		option0 = new DialogueResponse(optionText, -0.5f, optionResponse);
		optionText = "You know .. I really couldn’t say why it’s so good, as I don’t bother myself with going-ons of my lowly kitchen servants. But I am glad you like it .. the First Elector and Lord Protector of the Order of the Sacred Flame deserves no less.";
		optionResponse = "Ahh then perhaps it is best left a mystery .. still though .. if your chef should suddenly go missing .. don’t be too upset if it turns out I kidnapped them! Hahahaa of course I am joking .. I would never do something so tawdry as that.";
		option1 = new DialogueResponse(optionText, 0f, optionResponse);
		optionText = "I will be sure to have my chef speak with yours before your party departs .. and that you don’t leave without a cask of our finest wine.";
		optionResponse = "Oh how kind! You certainly know how a man of ancient and noble lineage such as myself deserves to be treated.";
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
