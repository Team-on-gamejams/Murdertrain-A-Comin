using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainController : MonoBehaviour {
	static public TrainController inst;

	public bool IsAlive = true;
	public Image DieImage;
    public Text restartText;

    void Start() {
		inst = this;
		Color c = DieImage.color;
		c.a = 0;
		DieImage.color = c;
        restartText.enabled = false;
    }

	void Update() {
		if(!IsAlive){
			if (DieImage.color.a < 1) {
				Color c = DieImage.color;
				c.a += Time.deltaTime;
				DieImage.color = c;
			}
		}

        if(time!=0 && Time.time > time) {
            restartText.enabled = true;
            needReload = true;
        } 

        if (needReload && Input.anyKey) {
            ReloadScene.inst.Reload();
            needReload = false;
            time = 0;
        }
    }

    bool needReload = false;
    public float time = 0;
    
    public void DestroyTrain() {
		GetComponent<MoveWheelsMain>().MaxSpeed = 0;
		GetComponent<FuelController>().IsConsumeFuel = false;
		IsAlive = false;
		FuelController.inst.LowFuelImage.enabled = false;				        
        time = Time.time +5.5f;
    }
}
