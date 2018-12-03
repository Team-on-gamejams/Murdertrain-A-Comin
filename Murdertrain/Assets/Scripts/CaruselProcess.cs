using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaruselProcess : MonoBehaviour {

	public void GivePoints(int points){
		ScoreController.inst.AddToScore(points);
	}
}
