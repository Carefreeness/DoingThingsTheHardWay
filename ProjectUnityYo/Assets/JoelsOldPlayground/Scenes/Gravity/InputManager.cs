using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public GameObject bodies;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        Vector3 nicePosition = Camera.main.transform.position
            + (Camera.main.transform.forward * 100)
            + (Camera.main.transform.right * Random.Range(-100, 100)
            + (Camera.main.transform.up * Random.Range(-100, 100)));


        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bodies).transform.position = nicePosition;
        }


	}
}
