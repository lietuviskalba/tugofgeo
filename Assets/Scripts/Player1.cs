using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1 : MonoBehaviour {

	public Text player1Points;

	static int p1Points = 10;
		
	public void setPoints(int points){
		p1Points = points;
	}

	public int getPoints(){
		return p1Points;
	}

	void DealDemage(int demage){
		
		p1Points -= demage;
	}

	void OnCollisionEnter2D(Collision2D col){

		DealDemage (1);
		player1Points.text = "10/" + p1Points.ToString ();
		col.gameObject.SetActive (false);
	}
}
