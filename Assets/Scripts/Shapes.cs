using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Shapes : MonoBehaviour {

	private SpriteRenderer sr;
	private Clicker clicker;

	public Vector2 startingPos;

	private int nextShapeIndex = 0;

	public float shapeSpeed = 2.5f;

	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		clicker = GameObject.FindObjectOfType<Clicker> ();

		startingPos = transform.position;
	}
		
	#region Dealing with movement
	public void  ShapesStartMovement(){
		
		//Regulates the direction
		if (this.gameObject.name == "Shape1" || this.gameObject.name == "Shape2" || this.gameObject.name == "Shape3" && gameObject.activeSelf == true) {
			Movement (1f);
		} else if(this.gameObject.name == "ShapeA" || this.gameObject.name == "ShapeB" || this.gameObject.name == "ShapeC" && gameObject.activeSelf == true)  {
			Movement (-1);
		}
		
	}

	void Movement(float direction){
		//Movement itself
		Vector2 moveDirection = new Vector2 (direction, 0);
		transform.Translate (moveDirection * shapeSpeed * Time.deltaTime);
	}
	#endregion

	void Update(){
		MyShapeChange ();
	}

	private void MyShapeChange(){
		string whatShape = clicker.RayCast2D ();

		if (whatShape.Equals (this.name) && Input.GetMouseButtonDown(0) && !GameManager.isRoundActive) {
			sr.sprite = clicker.threeShapes [nextShapeIndex];
			nextShapeIndex++;
			if(nextShapeIndex == 3){ nextShapeIndex = 0;}
		}

	}

	public void TidyUp(){
		transform.position = startingPos;
		gameObject.SetActive (true);
	}
		
	void OnCollisionEnter2D(Collision2D col){

		string enemy = col.gameObject.GetComponent<SpriteRenderer> ().sprite.name;
		string me = sr.sprite.name;

		ShapeRulesForCounters (enemy, me, col);
	}

	void ShapeRulesForCounters(string enemy, string me, Collision2D col){

		string c = "Circle";
		string t = "Triangle";
		string s = "Square";

		if 		 (enemy == c && me == t){
			Debug.Log ("Circle loses to triangle"); 
			col.gameObject.SetActive(false);
		}else if (enemy == c && me == s){
			Debug.Log ("Circle beats square"); 
			gameObject.SetActive(false);
		}else if (enemy == c && me == c){
			Debug.Log ("Both cicrle looses"); 
			gameObject.SetActive(false);
			col.gameObject.SetActive(false);
			//SECTION 1========================
		}else if (enemy == s && me == t){
			Debug.Log ("Square beats triangle"); 
			gameObject.SetActive(false);
		}else if (enemy == s && me == s){
			Debug.Log ("Both square looses"); 
			gameObject.SetActive(false);
			col.gameObject.SetActive(false);
		}else if (enemy == s && me == c){
			Debug.Log ("Circle beats square"); 
			col.gameObject.SetActive(false);
			//SECTION 2========================
		}else if (enemy == t && me == t){
			Debug.Log ("Both triangles looses"); 
			gameObject.SetActive(false);
			col.gameObject.SetActive(false);
		}else if (enemy == t && me == s){
			Debug.Log ("Triangle looses to square"); 
			col.gameObject.SetActive(false);
		}else if (enemy == t && me == c){
			Debug.Log ("Triangle beats circle"); 
			gameObject.SetActive(false);
			//SECTION 3========================
		}
	}
}
