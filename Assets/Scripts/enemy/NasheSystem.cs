using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NasheSystem : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        anim.Play("Main.Headbutt");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
