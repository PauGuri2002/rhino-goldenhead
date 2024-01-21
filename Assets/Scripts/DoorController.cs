using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private bool opening = false;
    public GameObject text;
    public float openSpeed = 1;

    void Update(){
        if(opening){
            transform.Translate(0, -openSpeed * Time.deltaTime , 0);
        }
    }

    public void Open(){
        opening = true;
        text.SetActive(false);
    }
}
