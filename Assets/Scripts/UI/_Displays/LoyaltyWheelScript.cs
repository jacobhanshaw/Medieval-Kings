using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoyaltyWheelScript : MonoBehaviour {

	public Transform pointerHolder;
	private Character character;

	const float SPEED = 1f;
	const float MIN_ANGLE =  90;
	const float MAX_ANGLE = 270;
	const float TOTAL_DISTANCE = MAX_ANGLE - MIN_ANGLE;

	const float OVERKILL_MAX_ANGLE = 15;
	const float MAX_OVERKILL = OVERKILL_MAX_ANGLE/TOTAL_DISTANCE;

	const float CONVERSION_RELATED_THRESHOLD = 0.01f;
	const float LOYALTY_DIFF_THRESHOLD = 0.1f;
	const int RICOCHET_COUNT = 0;

	int currentRicochetCount = 0;
	float t = 0.0f;
	float startLoyalty = 0f;
	float finalLoyalty = 0f;
	float goalLoyalty = 0f;
	float overkill = 0;

	bool ricochet = false;

	float currentLoyalty { get { return angleToLoyalty(pointerHolder.eulerAngles.z); } }

	bool done = true;

	void OnDestroy ()
	{
		if(Delegates.Instance != null)
			Delegates.Instance.LoyaltyChangedListeners -= LoyaltyChanged;
	}

	public void SetCharacter(Character aCharacter) {
		character = aCharacter;
		SetLoyalty(character.loyalty);

		Delegates.Instance.LoyaltyChangedListeners += LoyaltyChanged;
	}

	public void LoyaltyChanged(Character aCharacter, float loyaltyChange) {
		if(aCharacter == character) {
			SetLoyalty(character.loyalty);
		}
	}

	void SetLoyalty(float loyalty) {
		finalLoyalty = loyalty;
		startLoyalty = currentLoyalty;
		overkill = (finalLoyalty - startLoyalty) * MAX_OVERKILL;
		goalLoyalty = finalLoyalty + overkill;
		currentRicochetCount = RICOCHET_COUNT;
		ricochet = false;
		t = 0;

		done = false;
	}

	void Update ()
	{
		if(done)
			return;

		// Note: intentional easing as using current angle instead of start angle in lerp
		if (Mathf.Abs(currentLoyalty - goalLoyalty) >= CONVERSION_RELATED_THRESHOLD) {
			t += SPEED * Time.deltaTime;

			float nextLoyalty = 0;
			if (ricochet)
				nextLoyalty = Mathf.Lerp(startLoyalty, goalLoyalty, t);
			else
				nextLoyalty = Helpers.EaseInQuad(startLoyalty, goalLoyalty, t);
			
			if (Mathf.Abs(goalLoyalty - nextLoyalty) < LOYALTY_DIFF_THRESHOLD) {
				nextLoyalty = goalLoyalty;
			}

			pointerHolder.eulerAngles = new Vector3(0, 0, loyaltyToAngle(nextLoyalty));
		} else {
			if (currentRicochetCount > 0) {
				t = 0;
				startLoyalty = currentLoyalty;
				--currentRicochetCount;
				overkill *= -0.75f;
				ricochet = true;

				goalLoyalty = finalLoyalty + overkill;
			} else {
				if (goalLoyalty != finalLoyalty)
					goalLoyalty = finalLoyalty;
				else
					done = true;
			}
		}
	}

	float angleToLoyalty(float angle) {
		float zeroedAngle = angle-MIN_ANGLE;
		float fractionOfMax = 2f * (zeroedAngle/TOTAL_DISTANCE);
		return -fractionOfMax + 1f;
	}

	float loyaltyToAngle(float loyalty) {
		return -(loyalty - 1f)/2f * TOTAL_DISTANCE + MIN_ANGLE;
	}
}
