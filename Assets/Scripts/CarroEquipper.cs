using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarroEquipper : MonoBehaviour
{

    public GameObject rinocoche;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && other != null)
        {
            rinocoche.SetActive(true);
            rinocoche.transform.position = other.gameObject.transform.position;
            rinocoche.transform.rotation = other.gameObject.transform.rotation;
            this.gameObject.SetActive(false);
            other.gameObject.SetActive(false);
        }
        
    }
}
