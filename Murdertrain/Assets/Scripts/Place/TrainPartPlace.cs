using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainPartPlace : MonoBehaviour {
	public GameObject trainPart;

	public byte spawnChance;

	void Start () {
		foreach (Transform child in transform)
			Destroy(child.gameObject);

        if (Random.Range(0, 100) <= spawnChance)
            Instantiate(trainPart, new Vector3(0, 0, 0) + this.transform.position, Quaternion.identity).transform.eulerAngles = this.transform.eulerAngles + new Vector3(0, -90, 0);
	}
	
	void Update () {
		
	}
}
