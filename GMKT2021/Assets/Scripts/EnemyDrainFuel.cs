using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrainFuel : MonoBehaviour
{
    public GameObject fuelContainerGameObject;

    private FuelController fuelController;

    void Start() {
        fuelController = fuelContainerGameObject.GetComponent<FuelController>();
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag == "Enemy") {
            fuelController.fuel -= other.gameObject.GetComponent<EnemyController>().fuelDrainAmount;
            other.gameObject.GetComponent<EnemyController>().kill(false);
        }
    }
}
