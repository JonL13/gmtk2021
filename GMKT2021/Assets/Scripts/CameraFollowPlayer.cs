using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    //public Transform target;

    private GameObject player;
    private void Start() {
        player = GameObject.Find("Player");
        
    }


    void Update()
    {
        transform.LookAt(player.transform);
    }
}
