using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainController : MonoBehaviour {
	static public TrainController inst;

	public bool IsAlive = true;
	public Image DieImage;

	void Start() {
		inst = this;
		Color c = DieImage.color;
		c.a = 0;
		DieImage.color = c;
	}

	void Update() {
		if(!IsAlive){
			if (DieImage.color.a < 1) {
				Color c = DieImage.color;
				c.a += Time.deltaTime;
				DieImage.color = c;
			}
		}
	}

	public void DestroyTrain() {
		GetComponent<MoveWheelsMain>().MaxSpeed = 0;
		GetComponent<FuelController>().IsConsumeFuel = false;
		IsAlive = false;
		FuelController.inst.LowFuelImage.enabled = false;

		Debug.Log("Train die");
	}
}
