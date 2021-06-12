using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleYBasedOnFuel : MonoBehaviour
{
    public GameObject fuelContainerGameObject;
    public float maxScale = 1;

    private FuelController fuelController;
    private Renderer rend;

    void Start(){
        fuelController = fuelContainerGameObject.GetComponent<FuelController>();
        rend = gameObject.GetComponent<Renderer>();
    }

    void Update(){

        if (fuelController.fuel <= 0 && rend.enabled) {
            gameObject.GetComponent<Renderer>().enabled = false;
        }

        if(fuelController.fuel > 0 && !rend.enabled) {
            rend.enabled = true;
        }

        Vector3 fuelTransform = gameObject.transform.localScale;
        fuelTransform.y = (fuelController.fuel / fuelController.maxFuel) * maxScale;
        gameObject.transform.localScale = fuelTransform;
    }
}
