using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Transform myTransform;
	private Transform movePlayer;
	public int playerSpeed = 5;
	private int horizontalBound = 6;
	private int verticalBoundBottom = -3;
	private int verticalBoundTop = 10;

	// variable for reusable prefab (gameobject)
	public GameObject Torpedo; 

	// Use this for initialization
	void Start () {
	
		myTransform = transform; 
		// spawn point
		// position at (-3,-3,-1)
		myTransform.position = new Vector3 (-3, -3, 1);

	}
	
	// Update is called once per frame
	void Update () {
		// move the player
		myTransform.Translate (Vector3.right *playerSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
		myTransform.Translate (Vector3.up * playerSpeed * Input.GetAxis ("Vertical") * Time.deltaTime);

		// make an infinite plane of x
		// the player goes to more than x = 10 pos, it will endup in x = -10
		// and vice versa
		if (myTransform.position.x < -horizontalBound) {
			myTransform.position = new Vector3 (horizontalBound, myTransform.position.y, myTransform.position.z);
		} else if (myTransform.position.x > horizontalBound) {
			myTransform.position = new Vector3 (-horizontalBound, myTransform.position.y, myTransform.position.z);
		}

		if (myTransform.position.y < verticalBoundBottom) {
			myTransform.position = new Vector3 (myTransform.position.x, verticalBoundBottom, myTransform.position.z);
		} else if (myTransform.position.y > verticalBoundTop){
			myTransform.position = new Vector3(myTransform.position.x, verticalBoundTop, myTransform.position.z);
		}

		// shoot the peluru if space bar pressed
		if (Input.GetKeyDown ("space")) {

			// set initial position of peluru
			Vector3 peluruPos = new Vector3(myTransform.position.x, myTransform.position.y, myTransform.position.z);

			// instantiate reusable game object
			Instantiate(Torpedo, peluruPos, Quaternion.identity); 
		}
	}
}
