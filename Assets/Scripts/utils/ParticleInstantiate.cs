using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleInstantiate : MonoBehaviour
{
    public GameObject ParticleEmitter;
    public GameObject ExplodeParticle;

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            Instantiate(ExplodeParticle, ParticleEmitter.transform.position, Quaternion.identity);
            // Destroy(this.gameObject);
        }
    }
}