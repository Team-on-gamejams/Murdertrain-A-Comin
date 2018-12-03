using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneSpawner : MonoBehaviour {
	public GameObject player;
    public GameObject startZone;
    public GameObject[] zoneToSpawn;
    public GameObject[] hardToSpawn;


    Queue<GameObject> zoneQueue = new Queue<GameObject>();
	ulong lastX;
    int swapnCount;

    void Start () {
		//Reload();
	}

	void Update () {
		var obj = zoneQueue.Peek();
		if (obj != null && obj.transform.position.x <= player.transform.position.x - 250){
			Destroy(zoneQueue.Dequeue());
            if (swapnCount > 8) {
                zoneQueue.Enqueue(Instantiate(hardToSpawn[Random.Range(0, hardToSpawn.Length)], new Vector3(lastX += 250, 0, 0), Quaternion.identity));
                swapnCount++;
            } else {
                zoneQueue.Enqueue(Instantiate(zoneToSpawn[Random.Range(0, zoneToSpawn.Length)], new Vector3(lastX += 250, 0, 0), Quaternion.identity));
                swapnCount++;
            }
        }
	}


	public void Reload() {
		while (zoneQueue.Count != 0)
			Destroy(zoneQueue.Dequeue());
		for (int i = 0; i < 5; ++i)
			if (i == 0) {
				zoneQueue.Enqueue(Instantiate(startZone, new Vector3(125 + 250 * i, 0, 0), Quaternion.identity));
				swapnCount++;
			}
			else {
				zoneQueue.Enqueue(Instantiate(zoneToSpawn[Random.Range(0, zoneToSpawn.Length)], new Vector3(125 + 250 * i, 0, 0), Quaternion.identity));
				swapnCount++;
			}
		lastX = 250 * 4 + 125;
	}
}
