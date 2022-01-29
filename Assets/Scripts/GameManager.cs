using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField] private GameObject winScreen;
	[SerializeField] private GameObject loseScreen;
	[SerializeField] private Text distanceDisplay;
	[SerializeField] private Text truckHealthDisp;
	[SerializeField] private Text lightHealthDisp;
	[SerializeField] private Text heavyHealthDisp;
	
	private Truck truck;
	private LightGuard lightVh;
	private HeavyGuard heavyVh;
	private int truckMaxHealth;
	private int lightMaxHealth;
	private int heavyMaxHealth;
	
    // Start is called before the first frame update
    void Start()
    {
        truck = GameObject.FindObjectsOfType<Truck>()[0];
		lightVh = GameObject.FindObjectsOfType<LightGuard>()[0];
		heavyVh = GameObject.FindObjectsOfType<HeavyGuard>()[0];
		Time.timeScale = 1;
		StartCoroutine(AfterStart());
    }
	
	IEnumerator AfterStart()
	{
		yield return new WaitForSeconds(Time.deltaTime);
		truckMaxHealth = truck.maxHealth;
		lightMaxHealth = lightVh.maxHealth;
		heavyMaxHealth = heavyVh.maxHealth;
	}

    // Update is called once per frame
    void Update()
    {
		ShowDistance();
		UpdateHealth();
    }
	
	public void GameWon()
	{
		StopGame();
		
		if (winScreen != null)
		{
			winScreen.SetActive(true);
		}
	}
	
	public void GameOver()
	{
		StopGame();
		
		if (loseScreen != null)
		{
			loseScreen.SetActive(true);
		}
	}
	
	private void ShowDistance() // ABSTRACTION and ENCAPSULATION
	{
		if (truck != null && distanceDisplay != null)
		{
			// Display distance
			float distance = truck.transform.position.z;
			if (distance <= 0)
			{
				distanceDisplay.text = "Distance Travelled: 0.00 m / 5000.00 m";
			} else if (distance >= 5000)
			{
				distanceDisplay.text = "Distance Travelled: 5000.00 m / 5000.00 m";
				GameWon();
			} else  // 0 < distance < 5000
			{
				distanceDisplay.text = "Distance Travelled: " + distance.ToString("F2") + " m / 5000.00 m";
			}
		}
	}
	
	private void UpdateHealth() // ABSTRACTION and ENCAPSULATION
	{
		if (truckHealthDisp != null && lightHealthDisp != null && heavyHealthDisp != null)
		{
			if (truck != null)
			{
				truckHealthDisp.text = truck.health + " / " + truckMaxHealth;
			} else
			{
				truckHealthDisp.text = "0 / " + truckMaxHealth;
			}
			
			if (lightVh != null)
			{
				lightHealthDisp.text = lightVh.health + " / " + lightMaxHealth;
			} else
			{
				lightHealthDisp.text = "0 / " + lightMaxHealth;
			}
			
			if (heavyVh != null)
			{
				heavyHealthDisp.text = heavyVh.health + " / " + heavyMaxHealth;
			} else
			{
				heavyHealthDisp.text = "0 / " + heavyMaxHealth;
			}
		}
	}
	
	private void StopGame() // ABSTRACTION and ENCAPSULATION
	{
		Time.timeScale = 0;
		
		GameObject mainCamera = GameObject.FindWithTag("MainCamera");
		if (mainCamera != null)
		{
			Destroy(mainCamera.GetComponent<FollowPlayer>());
		}
	}
}
