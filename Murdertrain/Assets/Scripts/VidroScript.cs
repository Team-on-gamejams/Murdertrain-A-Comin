using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidroScript : MonoBehaviour {
	public bool needToOpen = false;
	public float timeToAnim = 10;
	public Transform obj;
	Quaternion end;

	public void OpenGate() {
		needToOpen = true;
		end = new Quaternion();
		end.Set(obj.rotation.x + 10, obj.rotation.y, obj.rotation.z, obj.rotation.w);
	}

	void Update() {
		if (needToOpen) {
			if (Vector3.Distance(obj.eulerAngles, end.eulerAngles) <= 1)
				needToOpen = false;
			
			obj.Rotate(new Vector3(50, 0, 0) * Time.deltaTime);
		}
	}
}
