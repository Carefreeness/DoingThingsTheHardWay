﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour {


    private Button button;

	// Use this for initialization
	void Start ()
    {
        button = gameObject.GetComponent<Button>();

        button.onClick.AddListener(TaskOnClick);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}


    void TaskOnClick()
    {
        SceneManager.LoadScene(gameObject.GetComponentInChildren<Text>().text, LoadSceneMode.Single);
    }


}
