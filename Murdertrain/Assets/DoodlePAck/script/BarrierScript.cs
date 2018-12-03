using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierScript : MonoBehaviour {
    public bool opened = false;
    public bool done = false;
    public float timeToAnim = 10;
    public List<Transform> objList = new List<Transform>();
    public List<Quaternion> openPosition = new List<Quaternion>();
    public List<Quaternion> closePosition = new List<Quaternion>();
    public Collider killColider;
    // Use this for initialization
    void Start() {
        
    }

    
    public void OpenGate() {
        opened = true;
        done = false;
		openAction();
	}
    void openAction() {
        killColider.enabled = false;        
    }
    void closeAction() {
		killColider.enabled = true;       
    }

    // Update is called once per frame
    void Update() {
        if (!done) {
            if (opened) {
				for (int i = 0; i < objList.Count; i++) {
					if (Vector3.Distance(objList[i].eulerAngles, closePosition [i].eulerAngles) < 1) {
                        done = true;
                        openAction();
                    }
                    objList[i].localRotation = Quaternion.Lerp(objList[i].localRotation, closePosition[i], timeToAnim * Time.deltaTime);
                }
            } else {
                for (int i = 0; i < objList.Count; i++) {
                    if (Vector3.Distance(objList[i].eulerAngles, openPosition[i].eulerAngles) < 1) {
                        done = true;
                        closeAction();
                    }
                    objList[i].localRotation = Quaternion.Lerp(objList[i].localRotation, openPosition[i], timeToAnim * Time.deltaTime);
                }
            }
        }
    }
}
