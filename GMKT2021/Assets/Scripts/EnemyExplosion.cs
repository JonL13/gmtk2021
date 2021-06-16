using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour
{

    public ParticleSystem enemyExplosionParticleSystem;
    public float timeToLive = 5;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > timeToLive) {
            Destroy(gameObject);
        }
    }
}
