using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapesMove : MonoBehaviour {

	private Rigidbody2D rb;

	public float shapeSpeed = 2.5f;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	public void  ShapesStartMovement(){
		//Regulates the direction
		if (this.tag == "Player1Shapes") {
			Movement (1f);
		} else if(this.tag == "Player2Shapes")  {
			Movement (-1);
		}
	}

	void Movement(float direction){
		//Movement itself
		Vector2 moveDirection = new Vector2 (direction, 0f);
		rb.velocity = moveDirection * shapeSpeed;
	}
}
