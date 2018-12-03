using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour {
	Rigidbody rg;

	void Start () {
		rg = GetComponent<Rigidbody>();
	}
	
	void Update () {
		
	}

	public void MoveRock(){
		rg.AddForce(new Vector3(0, 0, 100000));
	}
}
