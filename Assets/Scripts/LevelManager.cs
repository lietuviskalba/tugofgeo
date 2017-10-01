using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	private int currentLevelIndex;

	public float splashScreenIntro;

	void Start(){
		currentLevelIndex = SceneManager.GetActiveScene ().buildIndex;

		loadSpashScreen ();
	}

	public void loadLevel(string sceneName){
		SceneManager.LoadScene (sceneName);
	}

	public void quiteRequest(){
		Application.Quit ();
	}

 	void loadSpashScreen(){
		if (currentLevelIndex == 0) {
			Invoke ("autoLoadNextLevel", splashScreenIntro);
		}
	}

	void autoLoadNextLevel(){
		SceneManager.LoadScene (currentLevelIndex + 1);
	}
}
