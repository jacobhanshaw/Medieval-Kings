using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public AudioSource winningClip;
	public AudioSource neutralClip;
	public AudioSource losingClip;

	void Start () {
		Delegates.Instance.ArmyChangedListeners += EnemiesChanged;

		winningClip.mute = true;
		neutralClip.mute = false;
		losingClip.mute = true;

		winningClip.Play();
		neutralClip.Play();
		losingClip.Play();
	}
	
	void OnDestroy () {
		if(Delegates.Instance != null)
			Delegates.Instance.ArmyChangedListeners -= EnemiesChanged;
	}

	public void EnemiesChanged(Character character, Character.CharacterState oldState) {
		
		int enemyTotal = GameManager.Instance.enemyTotalArmy;
		int friendTotal = GameManager.Instance.friendTotalArmy;

		bool winning = friendTotal > enemyTotal;
		bool neutral = !winning && friendTotal >= (enemyTotal - GameManager.Instance.constantEnemyArmy);
		bool losing = !winning && !neutral;

		winningClip.mute = !winning;
		neutralClip.mute = !neutral;
		losingClip.mute = !losing;
	}
}
