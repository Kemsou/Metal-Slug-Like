using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Manager : MonoBehaviour {
	

	public void GameStart(string scenename)
	{
		//mettre dans le string le nom de la scene du level à charger
		SceneManager.LoadScene("Level Elric");
	}
}
