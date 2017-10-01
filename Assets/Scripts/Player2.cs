using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2 : MonoBehaviour {

	public Text player2Points;

	static int p2Points = 10;

	public void setPoints(int points){
		p2Points = points;
	}

	public int getPoints(){
		return p2Points;
	}

	void DealDemage(int demage){

		p2Points -= demage;
	}

	void OnCollisionEnter2D(Collision2D col){

		DealDemage (1);
		player2Points.text = "10/" + p2Points.ToString ();
		col.gameObject.SetActive (false);
	}
}
