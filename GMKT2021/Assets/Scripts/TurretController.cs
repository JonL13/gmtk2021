using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public Rigidbody projectile;
    public Transform turretBase;
    public Transform turretEnd;
    public GameObject rangeCylinder;
    public AudioSource turretShot;

    public float shootingRange;
    public float shootingCooldown = 3f;
    public float fuelPerShot = 10f;

    private FuelController fuelController;
    private float shootingTimer;
    public GameObject target; // target will be set by the TurretTargeter script



    void Start(){
        fuelController = GetComponent<FuelController>();
        rangeCylinder.transform.localScale = new Vector3(shootingRange, 1, shootingRange);
    }

    // Update is called once per frame
    void FixedUpdate(){
        if(target != null) {
            turretBase.transform.LookAt(target.transform);
        }

        if(shootingTimer < shootingCooldown) {
            shootingTimer += Time.fixedDeltaTime;
        }else if (target != null && fuelController.fuel >= fuelPerShot) {
            shootTarget();
            shootingTimer = 0;
        }
    }

    void shootTarget() {
        fuelController.fuel -= fuelPerShot;
        turretShot.Play();

        Rigidbody projectileInstance;
        projectileInstance = Instantiate(projectile, turretEnd.position, turretEnd.rotation) as Rigidbody;
        projectileInstance.AddForce(turretEnd.forward * 1500);
        projectileInstance.gameObject.transform.parent = gameObject.transform;
    }
}
