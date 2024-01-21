using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmatosteSystem : MonoBehaviour
{
    public Transform emitterTransform;
    public GameObject bullet;
    public float fireSpeed = 3000;

    public void Fire(){
        GameObject bulletInstance = Instantiate(bullet,emitterTransform.position,emitterTransform.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * fireSpeed);
    }
}
