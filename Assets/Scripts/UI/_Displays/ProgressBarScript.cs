using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarScript : MonoBehaviour {

	public RectTransform enemyBar;
	public RectTransform friendBar;

	public Text enemyArmyText;
	public Text friendArmyText;

	float initialEnemyBarWidth;
	float initialFriendBarWidth;

	void Start () {
		Delegates.Instance.ArmyChangedListeners += EnemiesChanged;
		Delegates.Instance.CharactersLoadedListeners += CharactersLoaded;
	}
	
	void OnDestroy () {
		if(Delegates.Instance != null) {
			Delegates.Instance.ArmyChangedListeners -= EnemiesChanged;
			Delegates.Instance.CharactersLoadedListeners -= CharactersLoaded;
		}
	}

	public void CharactersLoaded(Character[] characters) {
		EnemiesChanged(null, Character.CharacterState.Neutral);
	}

	public void EnemiesChanged(Character character, Character.CharacterState oldState) {
		int enemyArmySize = GameManager.Instance.enemyTotalArmy;
		int friendArmySize = GameManager.Instance.friendTotalArmy;
		int total = enemyArmySize + friendArmySize;

		enemyArmyText.text = enemyArmySize + " in enemy army";
		friendArmyText.text = friendArmySize + " joined your cause";

		Vector2 enemySizeDelta = enemyBar.sizeDelta;
		enemySizeDelta.x = ((float)enemyArmySize/(float)total) * Screen.width;
		enemyBar.sizeDelta = enemySizeDelta;

		Vector2 friendSizeDelta = friendBar.sizeDelta;
		friendSizeDelta.x = ((float)friendArmySize/(float)total) * Screen.width;
		friendBar.sizeDelta = friendSizeDelta;
	}
}
