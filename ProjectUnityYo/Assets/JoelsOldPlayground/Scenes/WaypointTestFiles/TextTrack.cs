using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrack : MonoBehaviour {


    TextMesh text;

	// Use this for initialization
	void Start ()
    {
        text = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        text.text = "" + MoveToWaypoint.pawnList.Count;
	}
}
