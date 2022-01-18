using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
	public bool manualControl;
	
	protected float horsePower;
	protected float turnSpeed;
	protected int health;
	protected int maxHealth;
	protected Rigidbody vehicleRb;
	
    void Start()
    {
        vehicleRb = GetComponent<Rigidbody>();
    }
	
    void Update()
    {
        if (manualControl && (vehicleRb != null))
		{
			ManualMove(); // ABSTRACTION
		}
    }
	
	protected virtual void ManualMove()
	{
		vehicleRb.AddForce(transform.forward * horsePower * Input.GetAxis("Vertical"));
		transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
	}
}
