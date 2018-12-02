using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneSpawner : MonoBehaviour {
	public GameObject player;
	public GameObject[] zoneToSpawn;

	Queue<GameObject> zoneQueue;
	ulong lastX;

	void Start () {
		zoneQueue = new Queue<GameObject>();
		for (int i = 0; i < 5; ++i) 
			zoneQueue.Enqueue(Instantiate(zoneToSpawn[Random.Range(0, zoneToSpawn.Length)], new Vector3(125 + 250 * i, 0, 0), Quaternion.identity));
		lastX = 250 * 4 + 125;
	}

	void Update () {
		if (zoneQueue.Peek().transform.position.x <= player.transform.position.x - 250){
			Destroy(zoneQueue.Dequeue());
			zoneQueue.Enqueue(Instantiate(zoneToSpawn[Random.Range(0, zoneToSpawn.Length)], new Vector3(lastX += 250, 0, 0), Quaternion.identity));
		}
	}
}
