using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCreator : MonoBehaviour
{
    public GameObject mainMenuObject;
    private static GameObject mainMenu;

	// Use this for initialization
	void Start ()
    {
        if(mainMenu == null)
            mainMenu = Instantiate(mainMenuObject);
	}

}
