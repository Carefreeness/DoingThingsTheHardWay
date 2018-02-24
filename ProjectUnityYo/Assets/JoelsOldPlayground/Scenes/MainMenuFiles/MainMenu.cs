using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    //public static List<string> sceneNames = new List<string>();
    public List<string> SceneNames = new List<string>();

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    private void Start()
    {

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name != "MainMenu")
            {
                SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
            }
            else
                Application.Quit();
        }
    }

}
