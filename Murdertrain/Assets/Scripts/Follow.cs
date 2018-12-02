using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {
	public GameObject followObj;

	Vector3 offset;

	void Start() {
		offset = transform.position - followObj.transform.position;
	}

	void LateUpdate() {
		//transform.position = followObj.transform.position + offset;
	}
}
