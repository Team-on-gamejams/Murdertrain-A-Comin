using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollider : MonoBehaviour {
	void Start() {

	}
	private void OnTriggerEnter(Collider other) {
		if (this.enabled)
			if (other.gameObject.CompareTag("Killer")) {                
				TrainController.inst.DestroyTrain();
			}
	}
}
