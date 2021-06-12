using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5;
    public float fuelTransferRate = 300f;
    public float joinDistance = 2.5f;
    public float fuelConsumptionRate = 1f;
    public TextMeshProUGUI playerFuelDisplay;
    public TextMeshProUGUI joinedFuelDisplay;
    public List<GameObject> linkedObjects = new List<GameObject>(); // this is public because other scripts access it


    private Rigidbody rb;
    private FuelController playerFuelController;

    void Start(){
        rb = GetComponent<Rigidbody>();
        playerFuelController = GetComponent<FuelController>();
    }

    private void Update() {
        if(linkedObjects.Count > 0) {
            GetComponent<Renderer>().material.color = Color.green;
        } else {
            GetComponent<Renderer>().material.color = Color.blue;
        }

        transferFuel();
        renderFuelDisplays();
    }

    void FixedUpdate() {
        controlMovement();
    }

    private void controlMovement() {
        if(playerFuelController.fuel == 0 && (Input.GetAxis("Vertical") + Input.GetAxis("Horizontal") != 0)) {
            Debug.Log("Player is out of fuel");
        }

        if (playerFuelController.fuel > 0) {
            Vector3 force = new Vector3(-movementSpeed * Input.GetAxis("Vertical"), 0, movementSpeed * Input.GetAxis("Horizontal"));
            rb.AddForce(force);

            playerFuelController.fuel -= force.magnitude * fuelConsumptionRate;
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
                    linkedFuelContainer.transferFuelFrom(playerFuelController, fuelTransferRate * Time.deltaTime);
                }
            }
        }

        // take fuel from linked objects
        else if (Input.GetButton("Fire2")) {
            foreach (GameObject linkedObject in linkedObjects) {
                FuelController linkedFuelContainer = linkedObject.GetComponent<FuelController>();
                if (linkedFuelContainer != null) {
                    playerFuelController.transferFuelFrom(linkedFuelContainer, fuelTransferRate * Time.deltaTime);
                }
            }
        }
    }

    private void renderFuelDisplays() {
        if(linkedObjects.Count == 0 && joinedFuelDisplay.enabled) {
            joinedFuelDisplay.enabled = false;
        }else if(linkedObjects.Count > 0 && !joinedFuelDisplay.enabled) {
            joinedFuelDisplay.enabled = true;
        }

        if (playerFuelDisplay != null) {
            playerFuelDisplay.SetText("Player Fuel:\n" + Mathf.Floor(playerFuelController.fuel) + "/" + Mathf.Floor(playerFuelController.maxFuel));
        }
        if (joinedFuelDisplay.enabled) {
            FuelController linkedFuelController = linkedObjects[0].GetComponent<FuelController>();
            joinedFuelDisplay.SetText("Joined Fuel:\n" + Mathf.Floor(linkedFuelController.fuel) + "/" + Mathf.Floor(linkedFuelController.maxFuel));
        }
    }

}
