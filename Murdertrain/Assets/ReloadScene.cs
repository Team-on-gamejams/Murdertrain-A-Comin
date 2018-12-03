using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadScene : MonoBehaviour {
	static public ReloadScene inst;

	public GameObject playerPrefab;
	public ZoneSpawner zoneSpawner;
	GameObject playerObj;

	void Start () {
		inst = this;
		Reload();
	}

	public void Reload(){
		foreach (GameObject o in Object.FindObjectsOfType<GameObject>()) 
			if(o.tag != "Immortal")
				Destroy(o);

		playerObj = Instantiate(playerPrefab, new Vector3(-28, 29, 0), Quaternion.Euler(36.095f, 89.913f, 0));
		zoneSpawner.player = playerObj.transform.Find("MainTrain").transform.Find("parovotest1").gameObject;
		zoneSpawner.Reload();
	}
}
