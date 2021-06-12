using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FuelController : MonoBehaviour
{
    public float fuel = 0;
    public float maxFuel = 1000;
    public TextMeshProUGUI fuelDisplay;
    public string fuelDisplayName = "";

    public void transferFuelFrom(FuelController fromFuelController, float amount) {
        if (fuel >= maxFuel) {
            return;
        }

        if(fromFuelController.fuel <= 0) {
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

    public void addFuel(float amount) {
        fuel += amount;
        if(fuel > maxFuel) {
            fuel = maxFuel;
        }
    }
}
