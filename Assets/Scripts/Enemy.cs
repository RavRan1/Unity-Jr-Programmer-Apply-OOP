using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] private GameObject leftWing;
	[SerializeField] private GameObject rightWing;
	
	private float wingRotSpeed = 360.0f;
	private float initWingRot = 30.0f;
	private float wingRotRange = 15.0f;
	private float currentWingRot;
	private bool turnDirection = false;
	
    // Start is called before the first frame update
    void Start()
    {
        currentWingRot = initWingRot;
    }

    // Update is called once per frame
    void Update()
    {
        if (leftWing != null && rightWing != null)
		{
			if (!turnDirection)
			{
				leftWing.transform.Rotate(Vector3.up * Time.deltaTime * -wingRotSpeed);
				rightWing.transform.Rotate(Vector3.up * Time.deltaTime * wingRotSpeed);
				currentWingRot -= Time.deltaTime * wingRotSpeed;
				
				if (currentWingRot <= initWingRot - wingRotRange)
				{
					turnDirection = true;
				}
			} else
			{				
				leftWing.transform.Rotate(Vector3.up * Time.deltaTime * wingRotSpeed);
				rightWing.transform.Rotate(Vector3.up * Time.deltaTime * -wingRotSpeed);
				currentWingRot += Time.deltaTime * wingRotSpeed;
				
				if (currentWingRot >= initWingRot + wingRotRange)
				{
					turnDirection = false;
				}
			}
		}
    }
}
