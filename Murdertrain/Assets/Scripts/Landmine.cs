using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landmine : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Char")){
            Destroy(this.gameObject);
            other.GetComponent<Explosion>().explodeOnLandmine();
		}
	}

}
