using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
	public bool manual;
	public int health {get; protected set;}
	public int maxHealth {get; protected set;}
	
	protected float horsePower;
	protected float turnSpeed;
	protected float fireDelay;
	protected Rigidbody vehicleRb;
	
	[SerializeField] protected Transform[] guns;
	[SerializeField] protected GameObject projectilePrefab;
	
	private float timeToFire;
	private float bounceForce = 20.0f;
	private float minY = -40.0f;
	private int enemyDamage = 5;
	private bool fireReady;
	
    void Start()
    {
        vehicleRb = GetComponent<Rigidbody>();
		fireReady = true;
		timeToFire = 0;
    }
	
	protected void Update()
	{
		timeToFire -= Time.deltaTime;
		
		if (timeToFire <= 0)
		{
			timeToFire = 0;
			fireReady = true;
		}
		
		if (vehicleRb != null)
		{
			if (manual)
			{	
				ManualControl();
			} else
			{
				AutoControl();
			}
		}
		
		if (transform.position.y < minY)
		{
			DestroyEffect();
			Destroy(gameObject);
		}
	}
	
	protected virtual void AutoControl() // INHERITANCE
	{
		if (vehicleRb != null)
		{
			if (transform.rotation.eulerAngles.y <= turnSpeed * Time.deltaTime)
			{
				transform.Rotate(Vector3.down * transform.rotation.eulerAngles.y);
			} else if (transform.rotation.eulerAngles.y - 360 >= -turnSpeed * Time.deltaTime)
			{
				transform.Rotate(Vector3.down * transform.rotation.eulerAngles.y);
			} else if (180 > transform.rotation.eulerAngles.y && transform.rotation.eulerAngles.y > 0)
			{
				transform.Rotate(Vector3.down * turnSpeed * Time.deltaTime);
			} else
			{
				transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
			}
		}
		
		vehicleRb.AddForce(transform.forward * horsePower);
	}
	
	protected void Fire() // ABSTRACTION and INHERITANCE
	{
		if (projectilePrefab == null || !fireReady)
		{
			return;
		}
		
		foreach (Transform gunPos in guns)
		{
			Instantiate(projectilePrefab, gunPos.position, transform.rotation);
		}
		
		timeToFire = fireDelay;
		fireReady = false;
	}
	
	protected void TurnForwards() // ABSTRACTION and INHERITANCE
	{
		if (transform.rotation.eulerAngles.y <= turnSpeed * Time.deltaTime)
		{
			transform.Rotate(Vector3.down * transform.rotation.eulerAngles.y);
		} else if (transform.rotation.eulerAngles.y - 360 >= -turnSpeed * Time.deltaTime)
		{
			transform.Rotate(Vector3.down * transform.rotation.eulerAngles.y);
		} else if (180 > transform.rotation.eulerAngles.y && transform.rotation.eulerAngles.y > 0)
		{
			transform.Rotate(Vector3.down * turnSpeed * Time.deltaTime);
		} else
		{
			transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
		}
	}
	
	protected void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Enemy"))
		{
			health -= enemyDamage;
			Rigidbody enemyRb;
			
			if (other.gameObject.name == "Body")
			{
				enemyRb = other.transform.parent.GetComponent<Rigidbody>();
			} else
			{
				enemyRb = other.gameObject.GetComponent<Rigidbody>();
			}
			
			enemyRb.AddForce(bounceForce * (other.transform.parent.position - transform.position).normalized);
			
			if (health <= 0)
			{
				DestroyEffect();
				Destroy(gameObject);
			}
		}
	}
	
	private void ManualControl() // ABSTRACTION and ENCAPSULATION
	{
		vehicleRb.AddForce(transform.forward * horsePower * Input.GetAxis("Vertical"));
		transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
		
		if (Input.GetKey(KeyCode.Space))
		{
			Fire();
		}
	}
	
	protected virtual void DestroyEffect() // INHERITANCE and POLYMORPHISM
	{}
}
