using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Camera mainCam;
    Vector3 newPos;

    void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit = new RaycastHit();
            if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out raycastHit))
            {
                //if (raycastHit.collider.tag == "waypoint")
                //{
                //    //gameObject.transform.position = raycastHit.collider.transform.position;
                //    //newPos 

                //    //newPos = raycastHit.collider.transform.position;
                //}

                newPos = raycastHit.point;
            }
        }

        // Move to new point
        var dt = Time.deltaTime;
        var oldPos = gameObject.transform.position;
        gameObject.transform.position = Vector3.MoveTowards(oldPos, newPos, 2 * dt);
    }
}
