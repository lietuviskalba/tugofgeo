using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Clicker : MonoBehaviour {

	public Sprite[] threeShapes;

	public String RayCast2D(){
		if (Input.GetMouseButtonDown (0)) {
			try{
				RaycastHit2D whatDidIHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero );
				String objectClicked = whatDidIHit.transform.gameObject.name;
				return objectClicked;
			}catch(NullReferenceException ){}
		}
		return " ";
	}
}
