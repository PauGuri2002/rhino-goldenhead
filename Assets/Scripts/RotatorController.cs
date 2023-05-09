using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorController : MonoBehaviour
{
    private float rndm ;
    public Vector3 speed = new Vector3 (1,1,1);

    void Start (){
        rndm = Random.Range(1.0f,5.0f);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(speed * rndm * Time.deltaTime );
    }
}
