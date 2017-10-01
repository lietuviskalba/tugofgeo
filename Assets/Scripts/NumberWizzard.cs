using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberWizzard : MonoBehaviour {

	public Text guessedNumber;
	private LevelManager levelManager;

	int max ;
	int min ;
	int guess ;
	int attempts;
	int maxAttempts;

	bool isItGameOver;

	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		resetValuesToDefault ();
	}

	void findAllNeededComponents(){
	}

	public void startGame (){

		gameOver();
	}

	void gameOver(){
		if (isItGameOver) {
		resetValuesToDefault (); 
		}
	}

	void resetValuesToDefault(){
		max = 1000;
		min = 1;
		attempts = 0;
		maxAttempts = 10;
		max = max +1;
		guess = Random.Range (min, max);;
		isItGameOver=false;
	}

	public void higherNumber (){
		min = guess;
		nextGuess();
	}

	public void lowerNumber (){
		max = guess;
		nextGuess();
	}

	void nextGuess (){
		guess = (max + min) / 2;
		maxAttempts -= 1;
		guessedNumber.text = guess.ToString();
		antiCheatAttempts ();
		startGame();
		if (maxAttempts <= 0) {
			levelManager.loadLevel ("Win");
		}
	}

	void antiCheatAttempts(){
		if (guess != 1000 && guess != 1) {
			attempts += 1;
		}
	}

	public void correctNumber(){
			isItGameOver = true;
	}


}
