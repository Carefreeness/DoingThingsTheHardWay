using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointScript : MonoBehaviour
{
    public static List<Transform> s_wayPointTransform = new List<Transform>();

	// Use this for initialization
	void Start ()
    {
        s_wayPointTransform.Add(transform);
	}

    private void OnDestroy()
    {
        s_wayPointTransform.Remove(this.transform);
    }
}
