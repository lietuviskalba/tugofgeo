using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	private GameObject readyButton;
	private ShapesMove[] shapesMove;

	void Start () {
		shapesMove = GameObject.FindObjectsOfType<ShapesMove> ();
		readyButton = GameObject.Find ("ReadyButton");
	}

	public void RoundStart(){
		//Makes all the shapes move when the button is pressed
		foreach (ShapesMove geoShape in shapesMove) {
			geoShape.ShapesStartMovement();
		}
		//Disable ready button
		readyButton.SetActive(false);
	}
}
