using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DossierCellScript : ButtonCellScript {

	public RectTransform fullPageTransform;
	public RectTransform textTransform;
	public Text dossierText;

	public void LoadWithCharacterIndex(int characterIndex) {
		float parentHeight = ((RectTransform)gameObject.transform.parent).rect.height;
		string fullText = GameManager.Instance.characters[characterIndex].dossierInformation;

		TextGenerator textGenerator = new TextGenerator();
		TextGenerationSettings generationSettings = dossierText.GetGenerationSettings(dossierText.rectTransform.rect.size); 
		float height = textGenerator.GetPreferredHeight(fullText, generationSettings);
		height += textTransform.offsetMin.y + -textTransform.offsetMax.y;
		height = Mathf.Max(height, parentHeight);

		Vector2 fullPageSizeDelta = fullPageTransform.sizeDelta;
		fullPageTransform.sizeDelta = new Vector2(fullPageSizeDelta.x, height);
		dossierText.text = fullText;
	}
}
