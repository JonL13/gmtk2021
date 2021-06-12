using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTargeter : MonoBehaviour
{
    public GameObject turret;
    private TurretController turretController;

    void Start() {
        turretController = turret.GetComponent<TurretController>();
    }

    void OnTriggerStay(Collider other) {
        if(turretController.target == null && other.tag == "Enemy") {
            turretController.target = other.gameObject;
        }
        
    }

    void OnTriggerExit(Collider other) {
        if(turretController.target != null && other.gameObject == turretController.target) {
            turretController.target = null;
        }
    }
}
