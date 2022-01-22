using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
	[SerializeField] private float speed = 100.0f;
	private float xRange = 40.0f;
	private float zRange = 5100.0f;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
		
		if (transform.position.x > xRange || transform.position.x < -xRange)
		{
			Destroy(gameObject);
		} else if (transform.position.z > zRange || transform.position.z < -zRange)
		{
			Destroy(gameObject);
		}
    }
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy"))
		{
			other.transform.parent.gameObject.SetActive(false);
			Destroy(gameObject);
		}
	}
}
