using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public float fuel = 0;

    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log("Home fuel: " + fuel);
    }
}
