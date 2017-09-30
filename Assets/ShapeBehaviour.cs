using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeBehaviour : MonoBehaviour {

	public GameObject[] shapes;

	void Start () {
		
	}
	
	void FixedUpdate () {
		ChangeShape ();
	}

	public void ChangeShape(){
		//make an array for each shape once cliked incrament

		if (Input.GetMouseButtonDown (0)) {
			Debug.Log(" I am pressed, should change shape ");
			GameObject current = shapes [1];
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		Destroy (gameObject);
		Debug.Log("I " +this.name+ " collided with: "+col.gameObject.name);
	}
}
