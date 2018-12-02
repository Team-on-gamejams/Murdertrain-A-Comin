using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    Rigidbody rig;
	// Use this for initialization
	void Start () {
        rig = gameObject.GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void LateUpdate() {
        rig.MovePosition(gameObject.transform.position+Vector3.right*Time.deltaTime);
        //rig.AddForce(rig.velocity+Vector3.right * Time.deltaTime*10);
    }
}
