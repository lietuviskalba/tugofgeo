using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	private GameObject readyButton;
	private GameObject[] activeShapes;
	private GameObject[] coverShapes;

	private Shapes[] shapes;
	private LevelManager levelManager;
	private Player1 p1;
	private Player2 p2;

	private bool isPlayer1Ready = false;
	private bool isPlayer2Ready = false;

	public static bool isRoundActive  = false;

	void Start () {
		readyButton = GameObject.Find ("ReadyButton");
		shapes = GameObject.FindObjectsOfType<Shapes> ();
		activeShapes = GameObject.FindGameObjectsWithTag ("Shapes");
		coverShapes = GameObject.FindGameObjectsWithTag ("CoverShapes");
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		p1 = GameObject.FindObjectOfType<Player1> ();
		p2 = GameObject.FindObjectOfType<Player2> ();

		SetUpCoverShapes (false);
	}

	void Update(){
		CheckForActiveShapes ();
		if (isRoundActive) {RoundStart ();}
		PlayerWins ();
	}

	public void Player1IsReady(){

		if (isPlayer1Ready == true) {isPlayer2Ready = true;} // makes p2 ready when p1 is

		if (isPlayer1Ready == true && isPlayer2Ready == true) {RoundStart ();}

		SetUpCoverShapes (true);
		isPlayer1Ready = true; // this will make the first if pass when button is clicked twice
	}

	void SetUpCoverShapes(bool isCoverActive){
		foreach (GameObject coverShape in coverShapes) {
			coverShape.SetActive (isCoverActive);// disables or enables cover shapes
		}
	}

	void RoundStart(){
		
		//Makes all the shapes move when the button is pressed
		foreach (Shapes geoShape in shapes) {
			geoShape.ShapesStartMovement();
		}
		//Disable ready button
		readyButton.SetActive(false);
		SetUpCoverShapes (false);
		isRoundActive = true;
	}
	void CheckForActiveShapes(){
		int countInActive = 0;

		foreach (GameObject activeObject in activeShapes) {
			if (activeObject.activeSelf == false) {countInActive++;}// counts for for disabled shapes
		}
		if (countInActive >= 6) {ResetRound ();}//Once all 6 shapes are disabled new round starts
	}

	void ResetRound(){
		isRoundActive = false;
		readyButton.SetActive(true);
		isPlayer1Ready = false;
		isPlayer2Ready = false;
		foreach (Shapes geoShape in shapes) {
			geoShape.TidyUp ();
		}
	}
	#region One of the players wins code
	void PlayerWins (){
		if (p1.getPoints() <= 0) {	WhichPlayerWinsScreen ("Player 2 Wins");}
		//Checks whos points reached 0 first, sends a string to which scene to load
		if (p2.getPoints() <= 0) {	WhichPlayerWinsScreen ("Player 1 Wins");}
	}

	void WhichPlayerWinsScreen(string levelName){
		p1.setPoints (10);
		p2.setPoints (10);
		isRoundActive = false;
		levelManager.loadLevel (levelName);
	}
	#endregion
}
