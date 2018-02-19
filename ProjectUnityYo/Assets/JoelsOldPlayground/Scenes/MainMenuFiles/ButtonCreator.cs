using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCreator : MonoBehaviour {

    public GameObject buttonObject;

    public GameObject mainMenuObject;

	// Use this for initialization
	void Start ()
    {
        mainMenuObject = FindObjectOfType<MainMenu>().gameObject;

        for (int i = 0; i < mainMenuObject.GetComponent<MainMenu>().SceneNames.Count; i++)
        {
            GameObject temp;
            temp = Instantiate(buttonObject);
            temp.transform.SetParent(transform);
            temp.GetComponentInChildren<Text>().text = mainMenuObject.GetComponent<MainMenu>().SceneNames[i];
        }
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
