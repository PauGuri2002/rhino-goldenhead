using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorController : MonoBehaviour
{
    public Vector3 speed = new Vector3 (1,1,1);
    public Vector3 randomStartAngle;

    void Start (){
        transform.Rotate(randomStartAngle.x * Random.Range(0, 180), randomStartAngle.y * Random.Range(0, 180), randomStartAngle.z * Random.Range(0,180));
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(speed * Time.deltaTime );
    }
}
