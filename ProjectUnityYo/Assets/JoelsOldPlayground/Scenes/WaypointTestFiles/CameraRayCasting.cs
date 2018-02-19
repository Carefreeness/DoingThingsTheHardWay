using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRayCasting : MonoBehaviour
{
    //Ingen aning varför unity tycker man skall ha "new" framför Camera
    public new Camera camera;
    public GameObject waypointObject;
    public GameObject rayHitVisualizer;
    public GameObject pawnObject;
    static public bool useSpammingSpawn;

    private Ray ray;
    private RaycastHit hit;
    private Vector3 pointHit;
    private IEnumerator coroutine;
    public IEnumerator Coroutine
    {
        get
        {
            return coroutine;
        }

        set
        {
            coroutine = value;
        }
    }

    //Coolt
    private Transform cameraPos;
    public Transform CameraPos
    {
        get
        {
            return cameraPos;
        }

        set
        {
            cameraPos = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        Coroutine = InputUpdate(0.0f);
        StartCoroutine(Coroutine);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            pointHit = hit.point;
            CameraPos = camera.transform;

           // Debug.DrawLine(cameraPos.position, pointHit, Color.green, 100, true);
            Instantiate(rayHitVisualizer).transform.position = pointHit;
        }
    }

    // every 2 seconds perform the print()
    private IEnumerator InputUpdate(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            InputUpdate();
        }
    }

    void InputUpdate()
    {
        if (Input.GetMouseButtonDown(0))    //Left Mouse Button Down
        {
            Vector3 temp = pointHit;
            temp.y += 1;
            Instantiate(waypointObject).transform.position = temp;
        }
        //Calculate closest waypoint to raycast hit location and remove it.
        else if (Input.GetMouseButtonDown(1) && WaypointScript.s_wayPointTransform.Count != 0)   //Right Mouse Button Down and List not empty
        {
            float minDist = Mathf.Infinity;
            Vector3 currentPos = pointHit;
            int waypointNumber = 0;

            for (int i = 0; i < WaypointScript.s_wayPointTransform.Count; i++)
            {
                float dist = Vector3.Distance(WaypointScript.s_wayPointTransform[i].transform.position, currentPos);

                if (dist < minDist)
                {
                    waypointNumber = i;
                    minDist = dist;
                }
            }

            Destroy(WaypointScript.s_wayPointTransform[waypointNumber].gameObject);
        }
        else if((Input.GetKeyDown(KeyCode.Space) && !useSpammingSpawn) || ((Input.GetKey(KeyCode.Space) && useSpammingSpawn)))
        {
            Vector3 temp = pointHit;
            temp.y += 1;
            Instantiate(pawnObject).transform.position = temp;
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            for (int i = 0; i < MoveToWaypoint.pawnList.Count; i++)
            {
                Destroy(MoveToWaypoint.pawnList[i].gameObject);
            }
            MoveToWaypoint.pawnList.Clear();
        }
    }
}
