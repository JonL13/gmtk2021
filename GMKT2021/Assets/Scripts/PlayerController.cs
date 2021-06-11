using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    public float movementSpeed = 5;
    public int joinDistance = 3;
    public float fuel = 5000;


    public List<GameObject> linkedObjects = new List<GameObject>();

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        if(linkedObjects.Count > 0) {
            GetComponent<Renderer>().material.color = Color.green;
        } else {
            GetComponent<Renderer>().material.color = Color.blue;
        }

        Debug.Log(linkedObjects.Count);
        foreach (GameObject gameObject in linkedObjects) {
            Debug.Log(gameObject.name);
        }
    }

    void FixedUpdate() {
        controlMovement();
    }

    private void controlMovement() {
        if (fuel > 0) {
            Vector3 force = new Vector3(-movementSpeed * Input.GetAxis("Vertical"), 0, movementSpeed * Input.GetAxis("Horizontal"));
            rb.AddForce(force);

            fuel -= force.magnitude;
        } else {
            fuel = 0;
        }

        Debug.Log("Player fuel: " + fuel);
    }
}
