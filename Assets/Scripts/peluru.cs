using UnityEngine;
using System.Collections;

public class peluru : MonoBehaviour {

	private Transform myTransform;
	public int peluruSpeed = 7;

	// Use this for initialization
	void Start () {
		myTransform = transform;

	}
	
	// Update is called once per frame
	void Update () {
		// make lazer fired and go up
		// game object = lazer = shoot up
		myTransform.Translate (Vector3.up * peluruSpeed * Time.deltaTime);
		if (myTransform.position.y > 12) {
			DestroyObject(gameObject);
		}
	}
}
