using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{
	[SerializeField] private GameObject linePrefab;
	private Vector3 firstPosition = new Vector3(3, -3, 40); // ENCAPSULATION
	private float posInterval = 40;                         // ENCAPSULATION
	private float maxZ = 4960;                              // ENCAPSULATION
	
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
				linePos = new Vector3(linePos.x, linePos.y, linePos.z + posInterval);
			}
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
