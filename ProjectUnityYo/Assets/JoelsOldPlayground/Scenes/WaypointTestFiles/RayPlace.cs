using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayPlace : MonoBehaviour {

    public static List<GameObject> s_rayPoints = new List<GameObject>();

    // Use this for initialization
    void Start ()
    {
        s_rayPoints.Add(gameObject);
        if(s_rayPoints.Count > 1)
        {
            Destroy(s_rayPoints[0]);
            s_rayPoints.RemoveAt(0);
        }
	}
}
