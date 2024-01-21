using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject explosionParticle;

    void Update(){
        if(transform.position.y < -20){
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Killer")){
            Destroy(other.gameObject);
        }
        Instantiate(explosionParticle,transform.position,Quaternion.identity);
        Destroy(this.gameObject);
    }
}
