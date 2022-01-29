using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
	using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
	private string playerSelection; // ENCAPSULATION
	
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void SetPlayerSelection(string selected)
	{
		playerSelection = selected;
	}
	
	public void StartGame()
	{
		SceneManager.LoadScene(1);
		StartCoroutine(SelectVehicle());
	}
	
	public void ExitGame()
	{
		#if UNITY_EDITOR
			EditorApplication.ExitPlaymode();
		#else
			Application.Quit();
		#endif
	}
	
	private IEnumerator SelectVehicle()
	{
		yield return new WaitForSeconds(Time.deltaTime);
		
		GameObject selectedUnit = GameObject.Find(playerSelection);
		if (selectedUnit != null)
		{
			Vehicle selectedVh = selectedUnit.GetComponent<Vehicle>();
			if (selectedVh != null)
			{
				selectedVh.manual = true;
			}
		}
		
		Destroy(gameObject);
	}
}
