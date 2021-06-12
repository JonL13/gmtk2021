using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrainFuel : MonoBehaviour
{
    public GameObject fuelContainerGameObject;
    public float fuelDrainRate = 100f;


    private FuelController fuelController;

    void Start() {
        fuelController = fuelContainerGameObject.GetComponent<FuelController>();
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag == "Enemy") {
            fuelController.fuel -= other.gameObject.GetComponent<EnemyController>().fuelDrainRate * Time.deltaTime;
        }
    }
}
