using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleGravity : MonoBehaviour {



	// Use this for initialization
	void Start ()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(GravityToggling);
        gameObject.GetComponentInChildren<Text>().text = "Q: Gravity = " + Gravity.useGravity;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            GravityToggling();
	}

    void GravityToggling()
    {
        Gravity.useGravity = !Gravity.useGravity;

        Debug.Log(Gravity.useGravity);

        gameObject.GetComponentInChildren<Text>().text = "Q: Gravity = " + Gravity.useGravity;
    }

}
