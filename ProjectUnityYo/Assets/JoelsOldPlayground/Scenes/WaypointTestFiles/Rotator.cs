using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    public float rotSpeed = 10;

	// Use this for initialization
	void Start () {

        rotSpeed = Random.Range(1, 20);
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        gameObject.transform.Rotate(0, rotSpeed * Time.deltaTime, 0);
	}
}
