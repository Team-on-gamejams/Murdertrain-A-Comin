using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWheelsMain : MonoBehaviour {
	public float MaxSpeed = 0;
	public GameObject[] wheels;
    public List<WheelCollider> wheelsCol = new List<WheelCollider>();
    Rigidbody rg;
    public float speed = 0;
    public string state = "";
    void Start() {
		rg = GetComponent<Rigidbody>();
        foreach (var wheel in wheels) {
            wheelsCol.Add(wheel.GetComponent<WheelCollider>());
        }
    }

	void Update() {

	}
    private float GetSmoothRPM() {
        float rpm = 0;
        for (int i = 0; i < wheelsCol.Count-1; i++)
            rpm += wheelsCol[i].rpm;
        return Mathf.Abs(rpm / wheelsCol.Count);
    }

    Vector3 mLastPosition = Vector3.zero;
    void FixedUpdate() {
        speed = (transform.position - this.mLastPosition).magnitude / Time.deltaTime;
        this.mLastPosition = transform.position;

		if (speed < MaxSpeed && MaxSpeed != 0 && FuelController.FuelLeft > 0) {
            state = "ГАЗУЕМ";            
            foreach (var wheel in wheelsCol) {                
                wheel.motorTorque = 500;
                wheel.brakeTorque = 0;
            }
        } else {
            state = "ТОРМОЗИМ";            
            foreach (var wheel in wheelsCol) {
                wheel.motorTorque = 0;
                wheel.brakeTorque = 200;
            }
        }
    }
}
