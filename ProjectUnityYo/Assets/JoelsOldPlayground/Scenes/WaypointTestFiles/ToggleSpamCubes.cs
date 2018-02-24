using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSpamCubes : MonoBehaviour {


    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(SpamToggling);
        gameObject.GetComponentInChildren<Text>().text = "T: Spamming = " + CameraRayCasting.useSpammingSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            SpamToggling();
    }

    void SpamToggling()
    {
        CameraRayCasting.useSpammingSpawn = !CameraRayCasting.useSpammingSpawn;

        gameObject.GetComponentInChildren<Text>().text = "T: Spamming = " + CameraRayCasting.useSpammingSpawn;
    }

}
