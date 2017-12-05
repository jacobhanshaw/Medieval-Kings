using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarScript : MonoBehaviour {

	const float SPEED = 1f;
	const float MAX_OVERKILL = 0.3f;

	const float THRESHOLD = 0.05f;
	const int RICOCHET_COUNT = 0;

	float t = 0.0f;
	bool ricochet = false;
	int currentRicochetCount = 0;
	float startFriendFraction = 0f;
	float currentFriendFraction = -1f; // To cause initial load
	float goalFriendFraction = 0f;
	float finalFriendFraction = 0f;
	float overkill = 0;
	float speed = SPEED;
	bool done = false;

	public RectTransform enemyBar;
	public RectTransform friendBar;

	public Text enemyArmyText;
	public Text friendArmyText;

	void Start () {
		Delegates.Instance.ArmyChangedListeners += EnemiesChanged;
		Delegates.Instance.CharactersLoadedListeners += CharactersLoaded;
	}

	void Update() {

		if(done)
			return;

		// Note: intentional easing as using current angle instead of start angle in lerp
		if (Mathf.Abs(currentFriendFraction - goalFriendFraction) >= THRESHOLD) {
			t += SPEED * Time.deltaTime;

			float nextFriendFraction = 0;
			if (ricochet)
				nextFriendFraction = Mathf.Lerp(startFriendFraction, goalFriendFraction, t);
			else
				nextFriendFraction = Helpers.EaseInQuad(startFriendFraction, goalFriendFraction, t);

			if (Mathf.Abs(goalFriendFraction - nextFriendFraction) < THRESHOLD) {
				nextFriendFraction = goalFriendFraction;
			}

			UpdateFractions(nextFriendFraction);
		} else {
			if (currentRicochetCount > 0) {
				t = 0;
				speed *= 0.05f;
				startFriendFraction = currentFriendFraction;
				--currentRicochetCount;
				overkill *= -0.9f;
				ricochet = true;

				goalFriendFraction = finalFriendFraction + overkill;
			} else {
				if (goalFriendFraction != finalFriendFraction)
					goalFriendFraction = finalFriendFraction;
				else {
					UpdateText();
					done = true;
				}
			}
		}
	}
	
	void OnDestroy () {
		if(Delegates.Instance != null) {
			Delegates.Instance.ArmyChangedListeners -= EnemiesChanged;
			Delegates.Instance.CharactersLoadedListeners -= CharactersLoaded;
		}
	}

	public void CharactersLoaded(Character[] characters) {
		Debug.Log("Characters LOADED");
		EnemiesChanged(null, Character.CharacterState.Neutral);
	}

	public void EnemiesChanged(Character character, Character.CharacterState oldState) {
		int enemyArmySize = GameManager.Instance.enemyTotalArmy;
		int friendArmySize = GameManager.Instance.friendTotalArmy;
		int total = enemyArmySize + friendArmySize;
		UpdateText();

		startFriendFraction = currentFriendFraction;
		finalFriendFraction  = (float)friendArmySize/(float)total;
		overkill = (finalFriendFraction - startFriendFraction) * MAX_OVERKILL;
		goalFriendFraction = finalFriendFraction + overkill;
		speed = SPEED;
		t = 0;
		done = false;
	}

	void UpdateFractions(float friendFraction) {
		UpdateEnemyFraction(1f - friendFraction);
		UpdateFriendFraction(friendFraction);
	}

	void UpdateEnemyFraction(float fractionOfTotal) {
		Vector2 enemySizeDelta = enemyBar.sizeDelta;
		enemySizeDelta.x = fractionOfTotal * Screen.width;
		enemyBar.sizeDelta = enemySizeDelta;
	}

	void UpdateFriendFraction(float fractionOfTotal) {
		currentFriendFraction = fractionOfTotal;

		Vector2 friendSizeDelta = friendBar.sizeDelta;
		friendSizeDelta.x = fractionOfTotal * Screen.width;
		friendBar.sizeDelta = friendSizeDelta;
	}

	void UpdateText() {
		int enemyArmySize = GameManager.Instance.enemyTotalArmy;
		int friendArmySize = GameManager.Instance.friendTotalArmy;
		float enemyFraction = 1f - currentFriendFraction;

		if(enemyFraction > 0.35f) {
			enemyArmyText.text = enemyArmySize.ToString("N0") + " enemy soldiers";
		} else {
			enemyArmyText.text = enemyArmySize.ToString("N0");
		}
			
		if (currentFriendFraction > 0.45f) {
			friendArmyText.text = friendArmySize.ToString("N0") + " joined your cause";
		} else if(currentFriendFraction > 0f) {
			friendArmyText.text = friendArmySize.ToString("N0");
		} else {
			friendArmyText.text = "";
		}
	}
}
