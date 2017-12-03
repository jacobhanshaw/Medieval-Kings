using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialLordSetUp : MonoBehaviour {

	const float MIN_SPACING = 20;
	const float EDGE_SPACING = 20;

	public GameObject lordPrefab;

	public void LoadLords() {

		int lordCount = GameManager.Instance.characters.Length;
		float rectWidth = ((RectTransform)transform).rect.width;
		float totalSpace = rectWidth - EDGE_SPACING;
		float lordWidth = ((RectTransform)lordPrefab.transform).rect.width;
		float scale = 1.0f;
		while((lordCount * lordWidth * scale + MIN_SPACING * (float)lordCount ) > totalSpace)
			scale -= 0.01f;

		float totalPadding = totalSpace - (lordCount * lordWidth * scale);
		float xPadding = totalPadding/((float)lordCount);

		LordDisplayScript[] lordDisplayScripts = new LordDisplayScript[lordCount];
		float currentPoint = -totalSpace/2.0f + xPadding/2.0f + (lordWidth * scale)/2.0f;
		for(int i = 0; i < lordCount; ++i) {
			GameObject lord = Instantiate (lordPrefab) as GameObject;
			lord.transform.SetParent(transform);
			lord.transform.localScale = new Vector2(scale, scale);
			Vector2 anchordPosition = ((RectTransform)lord.transform).anchoredPosition;
			anchordPosition.x = currentPoint;
			anchordPosition.y = 0;
			((RectTransform)lord.transform).anchoredPosition = anchordPosition;

			lordDisplayScripts[i] = lord.GetComponent<LordDisplayScript>();
			lordDisplayScripts[i].UpdateWithLord(GameManager.Instance.characters[i]);

			currentPoint += xPadding + (lordWidth * scale);
		}

		GameManager.Instance.SetLordDisplayScripts(lordDisplayScripts);
	}
}
