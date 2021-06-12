using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float maxSpeed = 5f;
    public GameObject fuel;
    public float fuelDrainRate = 100f;

    private GameObject home;
    private Rigidbody rb;

   


    void Start()
    {
        home = GameObject.Find("Home");
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate(){
        moveTowardHome();
    }

    private void moveTowardHome() {
        transform.LookAt(home.transform);
        if (rb.velocity.magnitude < maxSpeed) {
            rb.AddForce(transform.forward);
        }
    }

    public void kill() {
        Vector3 deathPosition = gameObject.transform.position;
        Destroy(gameObject);
        Instantiate(fuel, deathPosition, Quaternion.identity);
    }
}
