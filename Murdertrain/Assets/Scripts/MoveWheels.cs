using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWheels : MonoBehaviour {
	public float MaxSpeed = 0;
	public GameObject[] wheels;
    public List<WheelCollider> wheelsCol = new List<WheelCollider>();
    Rigidbody rg;
    public float speed = 0;
    
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
        /*
        if (speed > MaxSpeed) {
			foreach (var wheel in wheelsCol)
				wheel.motorTorque = -MaxSpeed;
		}*/

		if (FuelController.FuelLeft <= 0)
			return;
/*
        if (speed < MaxSpeed && MaxSpeed != 0) {
            foreach (var wheel in wheelsCol) {
                rg.velocity = Vector3.zero;
                wheel.motorTorque = MaxSpeed;
                wheel.brakeTorque = 0;
            }
        } else {
            
            foreach (var wheel in wheelsCol) {
                wheel.motorTorque = 0;
                wheel.brakeTorque = 1000;
            }
        }*/
    }
}
