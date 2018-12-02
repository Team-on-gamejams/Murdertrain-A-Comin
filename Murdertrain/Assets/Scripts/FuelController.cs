using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelController : MonoBehaviour {
	static public FuelController inst;

	public UnityEngine.UI.Text fuelText;

	public float FuelMax = 100;
	public float FuelRemove = 1;
	public float FuelAdd = 10;

	static public float FuelLeft { get { return fuelLeft; } }
	static float fuelLeft;

	void Start() {
		fuelLeft = FuelMax;
		inst = this;
	}

	void LateUpdate() {
		if (fuelLeft <= 0)
			return;
		fuelLeft -= FuelRemove * Time.deltaTime;
		if (fuelLeft < 0)
			fuelLeft = 0;
		Print();
	}


	public void AddFuel(){
		fuelLeft += FuelAdd;
		if (fuelLeft > FuelMax)
			fuelLeft = FuelMax;
		Print();
	}

	void Print(){
		fuelText.text = string.Format("{0}/{1}", fuelLeft, FuelMax);
	}
}
