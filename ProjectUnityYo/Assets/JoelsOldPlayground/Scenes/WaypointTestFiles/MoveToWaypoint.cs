using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToWaypoint : MonoBehaviour {
    public static List<MoveToWaypoint> pawnList = new List<MoveToWaypoint>();
    public static List<Transform> wpPos = new List<Transform>();
    public Transform currentWaypoint;

    public float speed = 20;
    public float lifeSpan = 0;
    public bool ezDeath = false;
    public bool allowSingle;
    public static bool singleWaypointAllowed = true;
    
    private int currentPoint = 0;

	// Use this for initialization
	void Start ()
    {
        allowSingle = singleWaypointAllowed;

        speed = Random.Range(20, 50);

        if(pawnList == null)
            pawnList = new List<MoveToWaypoint>();

        pawnList.Add(this);
        UpdateWaypoints();

        if (wpPos.Count != 0)
        {
            currentWaypoint = wpPos[currentPoint];

            SetWaypointToFollow();
        }

        
        
    }

	// Update is called once per frame
	void FixedUpdate ()
    {
        singleWaypointAllowed = allowSingle;

        lifeSpan += Time.fixedDeltaTime;

        if (wpPos.Count != WaypointScript.s_wayPointTransform.Count)
        {
            UpdateWaypoints();
        }

        if (wpPos.Count != 0)
        {
            MoveTowardsWaypoint();

            if (transform.position == currentWaypoint.position)
            {
                ReachedWaypoint();
            }
        }
	}

    private void OnDestroy()
    {
        pawnList.Remove(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(ezDeath)
        if(collision.gameObject.tag == gameObject.tag && collision.gameObject.GetComponent<MoveToWaypoint>().lifeSpan > 5)
            Destroy(this.gameObject);
    }

    void MoveTowardsWaypoint()
    {
        float step = speed * Time.deltaTime;
        if((currentWaypoint != null) && (WaypointScript.s_wayPointTransform.Count > 1 || singleWaypointAllowed))
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, step);
        else
            ReachedWaypoint();

    }

    void ReachedWaypoint()
    {
        if(currentPoint == wpPos.Count - 1)
            currentPoint = 0;
        else
            currentPoint++;

        if (currentPoint > wpPos.Count)
            currentPoint = 0;

        SetWaypointToFollow();
    }

    /// <summary>
    /// Sets waypoint to the current waypoint from wpPos using currentPoint as index.
    /// </summary>
    /// <param name="myBool">Parameter value to pass.</param>
    void SetWaypointToFollow() 
    {
        currentWaypoint = wpPos[currentPoint];
    }
    /// <summary>
    /// Sets waypoint to the current waypoint from wpPos using currentPoint as index.
    /// </summary>
    /// <param name="wpPosIndex">Index value of a list with transforms.</param>
    void SetWaypointToFollow(int wpPosIndex)
    {
        currentWaypoint = wpPos[wpPosIndex];
    }
    /// <summary>
    /// Sets waypoint to the current waypoint from wpPos using currentPoint as index.
    /// </summary>
    /// <param name="transform">Pass a transform value and its' position will be the target to follow.</param>
    void SetWaypointToFollow(Transform transform)
    {
        currentWaypoint = transform;
    }

    //Update our waypoints to make up for new waypoints or waypoints that gets deleted
    void UpdateWaypoints()
    {
        wpPos.Clear();
        for (int i = 0; i < WaypointScript.s_wayPointTransform.Count; i++)
        {
            wpPos.Add(WaypointScript.s_wayPointTransform[i]);
        }

        for (int i = 0; i < wpPos.Count; i++)
        {
            wpPos[i].gameObject.GetComponent<TextMesh>().text = "" + i;
        }
    }
}
