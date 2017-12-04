using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadTextScript : MonoBehaviour {

	Text textBox;

	void Start () {
		textBox = GetComponent<Text>();
	}
	
	public void LoadText(string text) {
		textBox.text = text;
	}
}
