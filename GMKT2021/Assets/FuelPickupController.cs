using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPickupController : MonoBehaviour
{
    public float timeToLive = 25f;
    public float fuel = 250;

    private bool isFloatingUp = false;
    private float floatingSpeed = .5f;
    private float lifeTimer = 0f;


    void Start(){}

    void Update()
    {
        if(lifeTimer > timeToLive) {
            Destroy(gameObject);
        }
    }

    void FixedUpdate() {
        lifeTimer += Time.fixedDeltaTime;
        floatingSpeed = 3 * (lifeTimer/timeToLive);

        floatUpAndDown();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag.Equals("Player")) {
            other.gameObject.GetComponent<FuelController>().addFuel(fuel);
            // todo - make this prettier
            Destroy(gameObject);
        }
    }

    private void floatUpAndDown() {
        if (isFloatingUp) {
            if (transform.position.y < .75) {
                transform.position += new Vector3(0, floatingSpeed * Time.fixedDeltaTime, 0);
            } else {
                isFloatingUp = false;
            }
        } else {
            if (transform.position.y > .1) {
                transform.position -= new Vector3(0, floatingSpeed * Time.fixedDeltaTime, 0);
            } else {
                isFloatingUp = true;
            }
        }
    }
}
