using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleYBasedOnFuel : MonoBehaviour
{
    public GameObject fuelContainerGameObject;
    public float maxScale = 1;
    private FuelController fuelController;

    void Start(){
        fuelController = fuelContainerGameObject.GetComponent<FuelController>();
    }

    // Update is called once per frame
    void Update(){
        Vector3 fuelTransform = gameObject.transform.localScale;
        fuelTransform.y = Mathf.Max((fuelController.fuel / fuelController.maxFuel) * maxScale, .1f);
        gameObject.transform.localScale = fuelTransform;
    }
}
