using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landmine : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Char"){
			other.GetComponent<Explosion>().explodeOnLandmine();
			Destroy(this.gameObject);
		}
	}

}
