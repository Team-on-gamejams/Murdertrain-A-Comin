using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFlush : MonoBehaviour {
	public void Flush() {
		Color img = gameObject.GetComponent<Image>().color;
		img.b = Mathf.Lerp(img.b, 0, Time.deltaTime);
		img.g = Mathf.Lerp(img.g, 0, Time.deltaTime);
		gameObject.GetComponent<Image>().color = img;
	}
}
