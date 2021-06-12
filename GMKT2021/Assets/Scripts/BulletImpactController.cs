using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpactController : MonoBehaviour
{
    public float timeToLive = 15f;

    private float lifeTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeTimer += Time.deltaTime;
        if(lifeTimer > timeToLive) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Enemy") {
            other.gameObject.GetComponent<EnemyController>().kill();
            Destroy(gameObject);
        }
    }
}
