using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown("f1")) {
            Debug.Log("Quitting Application");
            Application.Quit();
        }
    }
}
