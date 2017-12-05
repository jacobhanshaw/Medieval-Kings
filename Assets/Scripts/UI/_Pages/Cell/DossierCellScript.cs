using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DossierCellScript : ButtonCellScript {

	public RectTransform fullPageTransform;
	public LoadImageScript dossierImageScript;
	public Text dossierQuickInfo;
	public Text dossierFullText;

	public void LoadWithCharacterIndex(int characterIndex) {
		Character dossierCharacter = GameManager.Instance.characters[characterIndex];
		string quickInfo = dossierCharacter.quickInfo;
		string dossierInfo = dossierCharacter.dossierInformation;

		Rect parentRect = ((RectTransform)gameObject.transform.parent).rect;
		float parentWidth = parentRect.width;
		float parentHeight = parentRect.height;
		RectTransform dossierImageTransform = ((RectTransform)dossierImageScript.gameObject.transform);
		RectTransform dossierQuickInfoTransform = ((RectTransform)dossierQuickInfo.gameObject.transform);
		RectTransform dossierFullTextTransform = ((RectTransform)dossierFullText.gameObject.transform);

		TextGenerator textGenerator = new TextGenerator();
		TextGenerationSettings generationSettings = dossierFullText.GetGenerationSettings(dossierFullTextTransform.rect.size); 
		float fullTextHeight = textGenerator.GetPreferredHeight(dossierInfo, generationSettings);
		fullTextHeight += dossierFullTextTransform.offsetMin.y + -dossierFullTextTransform.offsetMax.y;
		float fullImageHeight = dossierImageTransform.rect.height;
		fullImageHeight += dossierImageTransform.offsetMin.y + -dossierImageTransform.offsetMax.y;
		float fullDossierHeight = fullImageHeight + fullTextHeight;
		
		float finalHeight = Mathf.Max(fullDossierHeight, parentHeight);

		Vector2 fullPageSizeDelta = fullPageTransform.sizeDelta;
		fullPageTransform.sizeDelta = new Vector2(fullPageSizeDelta.x, finalHeight);

		float totalQuickInfoWidth = parentWidth - dossierImageTransform.offsetMin.x * 3;
		totalQuickInfoWidth -= dossierImageTransform.rect.width;

		Vector2 quickInfoSizeDelta = dossierQuickInfoTransform.sizeDelta;
		dossierQuickInfoTransform.sizeDelta = new Vector2(totalQuickInfoWidth, quickInfoSizeDelta.y);

		dossierImageScript.LoadCharacterImage(dossierCharacter);
		dossierQuickInfo.text = quickInfo;
		dossierFullText.text = dossierInfo;
	}
}
