using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private GameObject player;
    private Camera cam;

    private void Start() {
        player = GameObject.Find("Player");
        cam = gameObject.GetComponent<Camera>();
    }


    void Update()
    {
        transform.LookAt(player.transform);

        float mouseScrollDelta = Input.mouseScrollDelta.y;
        if (mouseScrollDelta != 0) {
            if(cam.fieldOfView >= 20 && mouseScrollDelta > 0){
                cam.fieldOfView -= 1;
            }
            if (cam.fieldOfView <= 70 && mouseScrollDelta < 0) {
                cam.fieldOfView += 1;
            }
        }
    }
}
