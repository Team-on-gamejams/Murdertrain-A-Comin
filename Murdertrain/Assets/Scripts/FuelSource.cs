using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelSource : MonoBehaviour {
	void Start() {

	}

	void Update() {

	}


	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Char") {
			FuelController.inst.AddFuel();
			other.gameObject.GetComponent<Explosion>().burn();
		}
	}

}
