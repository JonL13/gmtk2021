using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelController : MonoBehaviour
{
    public float fuel = 0;
    public float maxFuel = 1000;

    public void transferFuelFrom(FuelController fromFuelController, float amount) {
        if (fuel >= maxFuel) {
            Debug.Log("FuelController is already at max fuel!");
            return;
        }

        if(fromFuelController.fuel <= 0) {
            Debug.Log("fromFuelController is out of fuel!");
            return;
        }

        if(fuel + amount > maxFuel) {
            amount = maxFuel - fuel;
        }

        if(fromFuelController.fuel < amount) {
            amount = fromFuelController.fuel;
        }

        fuel += amount;
        fromFuelController.fuel -= amount;
    }
}
