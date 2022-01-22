using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jolt : MonoBehaviour
{
	public float power = 0;
	public bool giveJolt = false;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (giveJolt == true)
		{
			Rigidbody objectRb = GetComponent<Rigidbody>();
			
			if (objectRb != null)
			{
				objectRb.AddForce(Vector3.forward * power, ForceMode.Impulse);
				giveJolt = false;
			}
		}
    }
}
