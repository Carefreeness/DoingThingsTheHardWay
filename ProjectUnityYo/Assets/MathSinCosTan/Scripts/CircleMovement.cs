using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    float posX, posY;

    public float multiPl = 1;
    public bool toggleSinCos = false;
    public float secondsTrack;


	// Use this for initialization
	void Start ()
    {
        posX = transform.position.x;
        posY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update ()
    {
        secondsTrack += Time.deltaTime;
        secondsTrack = secondsTrack % 12;
        //transform.position.Set(posX, posY, 0);

        transform.position = new Vector3(posX, posY, 0);

        if(toggleSinCos || secondsTrack > 6)
        {
            posX += Mathf.Cos(Time.time * multiPl);// / (10 * multiPl);
            posY += Mathf.Sin(Time.time * multiPl);// / (10 * multiPl);
        }
        else
        {
            posX += Mathf.Sin(Time.time * multiPl);// / (10 * multiPl);
            posY += Mathf.Cos(Time.time * multiPl);// / (10 * multiPl);
        }
    }

    void asdf()
    {
        if (toggleSinCos || secondsTrack > 6)
        {
            posX = Mathf.Cos(Time.time * multiPl);// / (10 * multiPl);
            posY = Mathf.Sin(Time.time * multiPl);// / (10 * multiPl);
        }
        else
        {
            posX = Mathf.Sin(Time.time * multiPl);// / (10 * multiPl);
            posY = Mathf.Cos(Time.time * multiPl);// / (10 * multiPl);
        }
    }

    private void OnGUI()
    {
        GUI.Button(new Rect(posX+600, posY+300, 30, 30), "asdf");
    }
}
