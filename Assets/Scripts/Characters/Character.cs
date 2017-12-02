using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character {
	public string information = "My liege, our advance scouts report that the Hordes of Hidlegaard the Dread are again threatening our borders!\n{Oh no! What should I do?}\nAs your forebears have done, you must assume the mantle of Imperator and assemble an army to repeal the barbarian queen and her invasion force.\n{But our country has no standing army! How can we levy troops?}\nYou must call a War Council with your sworn allies and gain their support. If you can persuade them to join in our cause they will raise troops to supplement our army.\n{That sounds easy enough…}\nBut be warned! The loyalty of these great lords and ladies is .. precarious .. and if you offend them they could decide you are an unworthy ally and pledge their support to Hildegaard’s invasion force.\n{That’s terrible! But also, I don’t know these people. How will I know what to say or not to say?}\nI have put together these dossiers on each of your guests .. read them carefully! They should help you navigate the difficult waters of high-stakes dinner diplomacy .. \n{Thank you, my loyal advisor.}\nAnd remember – you only need enough soldiers to defeat the invading army! You can opt to not talk with anyone at the table, which will leave them neutral in the upcoming battle.\n{Alright alright, I get it. Show me these dossiers already!}";

	public Character(int pageNumber) {

		string numberString = pageNumber.ToString();
		numberString += numberString;
		numberString += numberString;
		numberString += numberString;
		numberString += numberString;
		numberString += numberString;

		information = numberString + information;
	}
}
