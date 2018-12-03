using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placer : MonoBehaviour {
	public GameObject obj;

	public byte spawnChance;


	void Start() {
		foreach (Transform child in transform)
			Destroy(child.gameObject);

		if (Random.Range(0, 100) <= spawnChance)
			Instantiate(obj, this.transform.position, Quaternion.identity);
	}
}
