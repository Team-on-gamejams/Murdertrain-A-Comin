using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	public float cubeSize = 0.2f;
	public int cubesInRow = 5;

	float cubesPivotDistance;
	Vector3 cubesPivot;

	public float explosionForce = 50f;
	public float explosionRadius = 4f;
	public float explosionUpward = 0.4f;
	public GameObject obj;

	private Renderer rend;
	// Use this for initialization
	void Start() {

		rend = GetComponent<Renderer>();

		//calculate pivot distance
		cubesPivotDistance = cubeSize * cubesInRow / 2;
		//use this value to create pivot vector)
		cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);

	}

	// Update is called once per frame
	void Update() {

	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Killer")) {
			explode();
		}

	}

	public void explode() {
		//make object disappear
		gameObject.SetActive(false);
		TraineAudioController.instant.PlaySoud(TraineAudioController.SoundPack.Crush);
		//loop 3 times to create 5x5x5 pieces in x,y,z coordinates
		for (int x = 0; x < cubesInRow; x++) {
			for (int y = 0; y < cubesInRow; y++) {
				for (int z = 0; z < cubesInRow; z++) {
					createPieceBlood(x, y, z);
				}
			}
		}

		//get explosion position
		Vector3 explosionPos = transform.position;
		//get colliders in that position and radius
		Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
		//add explosion force to all colliders in that overlap sphere
		foreach (Collider hit in colliders) {
			//get rigidbody from collider object
			Rigidbody rb = hit.GetComponent<Rigidbody>();
			if (rb != null) {
				//add explosion force to this body with given parameters
				rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
			}
		}
		Destroy(obj);
	}

	public void explodeOnLandmine() {
		//make object disappear
		gameObject.SetActive(false);
		TraineAudioController.instant.PlaySoud(TraineAudioController.SoundPack.Crush);
		//loop 3 times to create 5x5x5 pieces in x,y,z coordinates
		for (int x = 0; x < cubesInRow; x++) {
			for (int y = 0; y < cubesInRow; y++) {
				for (int z = 0; z < cubesInRow; z++) {
					createPieceBlood(x, y, z);
				}
			}
		}

		//get explosion position
		Vector3 explosionPos = transform.position;
		//get colliders in that position and radius
		Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
		//add explosion force to all colliders in that overlap sphere
		foreach (Collider hit in colliders) {
			//get rigidbody from collider object
			Rigidbody rb = hit.GetComponent<Rigidbody>();
			if (rb != null) {
				//add explosion force to this body with given parameters
				rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
			}
		}
		Destroy(obj);
	}

	public void burn() {
		//make object disappear
		gameObject.SetActive(false);
		TraineAudioController.instant.PlaySoud(TraineAudioController.SoundPack.Crush);
		//loop 3 times to create 5x5x5 pieces in x,y,z coordinates
		for (int x = 0; x < 2; x++) {
			for (int y = 0; y < 2; y++) {
				for (int z = 0; z < 2; z++) {
					createPieceFire(x, y, z);
				}
			}
		}

		//get explosion position
		Vector3 explosionPos = transform.position;
		//get colliders in that position and radius
		Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
		//add explosion force to all colliders in that overlap sphere
		foreach (Collider hit in colliders) {
			//get rigidbody from collider object
			Rigidbody rb = hit.GetComponent<Rigidbody>();
			if (rb != null) {
				//add explosion force to this body with given parameters
				rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
			}
		}
		Destroy(obj);
	}

	void createPieceBlood(int x, int y, int z) {
		//create piece
		GameObject piece;
		piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
		Renderer rend2 = piece.GetComponent<Renderer>();
		rend2.material = rend.material;

		//set piece position and scale
		piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
		piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

		//add rigidbody and set mass
		piece.AddComponent<Rigidbody>();
		piece.GetComponent<Rigidbody>().mass = cubeSize * 0.2f;
		piece.AddComponent<TimeKiller>();
	}

	void createPieceFire(int x, int y, int z) {
		//create piece
		GameObject piece;
		piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
		Renderer rend2 = piece.GetComponent<Renderer>();
		rend2.material = rend.material;
		if (Random.Range(0, 10) == 0)
			rend2.material.SetColor("_Color", new Color(0, 0, 0));
		else
			rend2.material.SetColor("_Color", new Color(100, 100, 0));

		//set piece position and scale
		piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
		piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

		//add rigidbody and set mass
		piece.AddComponent<Rigidbody>();
		piece.GetComponent<Rigidbody>().mass = cubeSize * 0.2f;
		piece.AddComponent<TimeKiller>();
	}
}