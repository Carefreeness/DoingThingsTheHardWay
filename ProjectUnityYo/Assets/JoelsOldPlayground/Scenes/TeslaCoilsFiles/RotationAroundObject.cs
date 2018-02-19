using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAroundObject : MonoBehaviour {

    public GameObject objectToRotateAround;

    private Quaternion myQuat;

	// Use this for initialization
	void Start ()
    {
        myQuat = transform.rotation;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.RotateAround(objectToRotateAround.transform.position, Vector3.forward, 10 * Time.deltaTime);

        transform.rotation = myQuat;
	}
}
