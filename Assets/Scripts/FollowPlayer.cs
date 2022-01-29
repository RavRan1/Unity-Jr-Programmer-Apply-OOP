using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
	[SerializeField] private float z_offset;
	
	private GameObject player;
	
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
		if (player == null)
		{
			player = GameObject.FindWithTag("Player");
			
			if (player == null)
			{
				Debug.LogWarning("The transporting vehicle cannot be found in the scene!");
				return;
			}
		}
		
		transform.position = new Vector3(0, transform.position.y, player.transform.position.z + z_offset);
    }
}
