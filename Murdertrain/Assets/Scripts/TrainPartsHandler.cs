using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainPartsHandler : MonoBehaviour {
	static public int partsCnt = 0;

	void Start() {
	}


	void Update() {

	}

	void OnCollisionEnter(Collision collision) {
		if (
			collision.gameObject.tag == "TrainPart" &&
			(GetComponent<FixedJoint>() == null || GetComponent<FixedJoint>().connectedBody != this || collision.gameObject.GetComponent<FixedJoint>() == null || collision.gameObject.GetComponent<FixedJoint>().connectedBody != this)
		) {
			++partsCnt;
			var gameObject = collision.gameObject;

			Destroy(gameObject.GetComponent<Drag>());
			//gameObject.GetComponent<MoveWheels>().MaxSpeed = GetComponent<MoveWheels>().MaxSpeed;

			var sp = gameObject.AddComponent<FixedJoint>();
			sp.connectedBody = GetComponent<Rigidbody>();

			//Destroy(gameObject.GetComponent<MoveWheels>());
			//for (int i = 0; i < gameObject.transform.childCount; ++i)
			//	if (gameObject.transform.GetChild(i).name.Contains("Wheel"))
			//		Destroy(gameObject.transform.GetChild(i));
			//this.gameObject.transform.localPosition = collision.transform.localPosition;
			//sp.connectedAnchor = Vector3.zero;
			//sp.anchor = Vector3.zero;
			//sp.maxDistance = 5;
			//sp.minDistance = 1;
			//sp.damper = 100;
			//sp.spring = 100;
		}
	}
}
