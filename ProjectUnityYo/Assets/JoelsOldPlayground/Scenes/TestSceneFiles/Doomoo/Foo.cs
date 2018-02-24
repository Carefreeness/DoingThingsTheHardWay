using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foo : MonoBehaviour {

    public bool testBool = false;
    public string info;

    void OnGUI()
    {
        //--> Label that servers as a "console"
        GUI.Label(new Rect(0, 0, 500, 500), info);

        //--> Button for thread 1
        if (GUI.Button(new Rect(50, 50, 100, 50), "Thread T1"))
        {
            testBool = !testBool;
            info = testBool.ToString();
        }
    }
}
