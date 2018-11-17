using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour {

	public void sceneChange (string sceneName)
	{
		Debug.Log("Changing Scene!");
		SceneManager.LoadScene(sceneName);
	}

	public void quitGame ()
	{
		Application.Quit();
	}
}
