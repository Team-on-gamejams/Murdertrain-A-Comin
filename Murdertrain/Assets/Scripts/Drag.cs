using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour {
	//public float yLvl = 0;

	//Vector3 screenPoint, offset;
	//Rigidbody rg;

	//void Start() {
	//	rg = GetComponent<Rigidbody>();
	//}

	//void Update() {

	//}

	//void OnMouseDown() {
	//	screenPoint = Camera.main.WorldToScreenPoint(transform.position);
	//	offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	//}

	//void OnMouseDrag() {
	//	Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
	//	Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
	//	curPosition.y = yLvl;
	//	transform.position = curPosition;
	//}

	private Vector3 screenPoint;
	private Vector3 offset;
	public Camera cam;
	private bool isMove = false;
	public GameObject _objToMove;
	Transform objToMove;
	public Plane plane;

	private Vector3 cursorPosition;
	private Vector3 markerOfset;
	private Rigidbody rBod;
	private float min = -1.0f;
	private float cury = 0;
	private Collider col;

	void Start() {
		cam = Camera.main;
		plane = new Plane(Vector3.up, Vector3.zero);
        if (_objToMove == null) { Destroy(this); return; }
		objToMove = _objToMove.transform;
		rBod = objToMove.GetComponent<Rigidbody>();
		markerOfset = objToMove.position - transform.position;
		col = transform.GetComponent<Collider>();
	}
	void OnMouseDown() {
		if (plane.Equals(null)) return;
		cury = 0;
		plane.SetNormalAndPosition(Vector3.up, Vector3.zero + new Vector3(0, objToMove.position.y, 0));
		screenPoint = cam.WorldToScreenPoint(objToMove.transform.position);
		offset = objToMove.transform.position - cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		isMove = true;
	}

	void OnMouseDrag() {
		Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		cursorPosition = cam.ScreenToWorldPoint(cursorPoint) + offset;
	}

	void LateUpdate() {		
		if (!isMove) return;
        transform.position = objToMove.position + markerOfset;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		float distance;
		if (objToMove.position.y > min) {
			cury -= 2f * Time.deltaTime;
		}
		if (plane.Raycast(ray, out distance)) {
			Vector3 pointalongplane = ray.origin + (ray.direction * distance) + new Vector3(0, cury, 0);
            objToMove.position = Vector3.Lerp(objToMove.position, pointalongplane, 5f * Time.deltaTime);
		}
	}

	void OnMouseUp() {
		cury = 0;
		isMove = false;
	}
}
