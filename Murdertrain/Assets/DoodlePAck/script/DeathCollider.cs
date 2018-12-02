using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Paravoz") {
            Debug.Log("DEAD");
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
