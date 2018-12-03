using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
	static public ScoreController inst;

	public Text scoreText;

	float score = 0;

	void Start() {
		inst = this;
	}

	void Update() {
		if (TrainController.inst.IsAlive)
			score += Time.deltaTime;
		scoreText.text = "Score:"+((int)(score)).ToString();
	}

	public void AddToScore(float _score){
		score += _score;
	}
}
