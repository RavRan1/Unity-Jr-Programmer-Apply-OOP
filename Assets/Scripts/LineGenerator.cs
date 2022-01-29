using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{
	[SerializeField] private GameObject linePrefab;
	[SerializeField] private Vector3 firstPosition = new Vector3(3, -3, 40);
	[SerializeField] private Vector3 posInterval = new Vector3(0, 0, 0);
	[SerializeField] private bool alternateX = false;
	private float maxZ = 4960; // ENCAPSULATION
	
    // Start is called before the first frame update
    void Start()
    {
		Vector3 linePos = firstPosition;
		
        if (linePrefab != null)
		{
			while (linePos.z <= maxZ)
			{
				GameObject line = Instantiate(linePrefab, linePos, linePrefab.transform.rotation);
				line.transform.parent = transform;
				linePos = linePos + posInterval;
				
				if (alternateX)
				{
					linePos.x *= -1;
				}
			}
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
