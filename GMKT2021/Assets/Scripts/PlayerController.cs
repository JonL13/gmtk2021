using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private FuelController playerFuelController;

    public float movementSpeed = 5;
    public int joinDistance = 3;
    //public float fuel = 5000;

    public List<GameObject> linkedObjects = new List<GameObject>();

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerFuelController = GetComponent<FuelController>();
    }

    private void Update() {
        if(linkedObjects.Count > 0) {
            GetComponent<Renderer>().material.color = Color.green;
        } else {
            GetComponent<Renderer>().material.color = Color.blue;
        }
    }

    void FixedUpdate() {
        controlMovement();
        transferFuel();

    }

    private void controlMovement() {
        if (playerFuelController.fuel > 0) {
            Vector3 force = new Vector3(-movementSpeed * Input.GetAxis("Vertical"), 0, movementSpeed * Input.GetAxis("Horizontal"));
            rb.AddForce(force);

            playerFuelController.fuel -= force.magnitude;
        } else {
            playerFuelController.fuel = 0;
        }

    }

    private void transferFuel() {
        if(linkedObjects.Count == 0) {
            return;
        }

        // give fuel to objects
        if (Input.GetButton("Fire1")) {
            foreach (GameObject linkedObject in linkedObjects) {
                FuelController linkedFuelContainer = linkedObject.GetComponent<FuelController>();
                if (linkedFuelContainer != null) {
                    linkedFuelContainer.transferFuelFrom(playerFuelController, 10f);
                    Debug.Log("playerFuel: " + playerFuelController.fuel + "linkedFuel: " + linkedFuelContainer.fuel);
                } else {
                    Debug.Log("linkedFuelContainer is NULL!");
                }
            }
        }

        // take fuel from linked objects
        else if (Input.GetButton("Fire2")) {
            foreach (GameObject linkedObject in linkedObjects) {
                FuelController linkedFuelContainer = linkedObject.GetComponent<FuelController>();
                if (linkedFuelContainer != null) {
                    playerFuelController.transferFuelFrom(linkedFuelContainer, 10f);
                    Debug.Log("playerFuel: " + playerFuelController.fuel + "linkedFuel: " + linkedFuelContainer.fuel);
                } else {
                    Debug.Log("linkedFuelContainer is NULL!");
                }
            }
        }
    }
}
