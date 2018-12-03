using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelController : MonoBehaviour {
	static public FuelController inst;

	public Image LowFuelImage;
	public Text fuelText;

	public bool IsConsumeFuel = true;
	public float FuelMax = 100;
	public float FuelRemove = 1;
	public float FuelAdd = 10;

	static public float FuelLeft { get { return fuelLeft; } }
	static float fuelLeft;

	public int SecToDie = 5;
	float endFuelTime;
	bool isImageOpacityIncrease;
	float imageOpacity;

	void Start() {
		fuelLeft = FuelMax;
		imageOpacity = 0;
		isImageOpacityIncrease = true;
		inst = this;

		Color c = LowFuelImage.color;
		c.a = 0;
		LowFuelImage.color = c;
		LowFuelImage.enabled = false;
	}

	void LateUpdate() {
		if (IsConsumeFuel) {
			if (fuelLeft <= 0) {
				Color c = LowFuelImage.color;
				if (isImageOpacityIncrease)
					c.a = (imageOpacity += Time.deltaTime);
				else
					c.a = (imageOpacity -= Time.deltaTime);
				LowFuelImage.color = c;

				if (imageOpacity >= 1)
					isImageOpacityIncrease = false;
				else if (imageOpacity <= 0)
					isImageOpacityIncrease = true;


				if (endFuelTime < Time.fixedTime)
					TrainController.inst.DestroyTrain();
				return;
			}

			fuelLeft -= FuelRemove * Time.deltaTime;
			if (fuelLeft <= 0) {
				fuelLeft = 0;
				endFuelTime = Time.fixedTime + SecToDie;
				LowFuelImage.enabled = true;
			}
			else if (LowFuelImage.enabled) {
				LowFuelImage.enabled = false;
				imageOpacity = 0;
				isImageOpacityIncrease = true;
			}

			Print();
		}
	}


	public void AddFuel() {
		fuelLeft += FuelAdd;
		if (fuelLeft > FuelMax)
			fuelLeft = FuelMax;
		Print();
	}

	void Print() {
		fuelText.text = string.Format("{0}%", (int)fuelLeft);
	}
}
