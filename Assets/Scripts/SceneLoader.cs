using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	public void OpenScene(int sceneNumber) // ABSTRACTION
	{
		// This function is used especially for button OnClick listeners
		SceneManager.LoadScene(sceneNumber);
	}
}
