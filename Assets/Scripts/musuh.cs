using UnityEngine;
using System.Collections;

public class musuh : MonoBehaviour {

	public GameObject enemy;
	private Transform myTransform;
	public float minSpeed = 10.0f;
	public float maxSpeed = 25.0f;
	int x,y,z;
	public float currentSpeed;
	private int horizontalBound = 5;
	
	// Use this for initialization
	void Start () {
		y = 8;
		z = 1;
		x = Random.Range (-horizontalBound, horizontalBound);
		myTransform = transform;
		myTransform.position = new Vector3 (x, y, z);
		currentSpeed = Random.Range (minSpeed,maxSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		x = Random.Range (-horizontalBound, horizontalBound);
		myTransform.Translate (-Vector3.up * currentSpeed * Time.deltaTime);
		if (myTransform.position.y < -10) {
			myTransform.position = new Vector3(x,y,z);
			currentSpeed = Random.Range(minSpeed,maxSpeed);
		}
	}

	void OnTriggerEnter	(Collider collider){
		// kalo torpedo kena enemy, enemy hancur
		if (collider.gameObject.){
			Destroy (this.gameObject);
		}

	}
}
