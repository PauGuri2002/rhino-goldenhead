using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolinga : MonoBehaviour
{
    public GameObject staticBall;
    public GameObject rollingBall;
    public GameObject player;
    private Rigidbody rb;
    public float speed = 1;
    public float range = 1000;
    private float startY;
    private bool isRolling = false;

    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if((player.transform.position - transform.position).sqrMagnitude < range){
            staticBall.SetActive(false);
            rollingBall.SetActive(true);
            rb.AddForce((new Vector3(player.transform.position.x,0,player.transform.position.z) - new Vector3(transform.position.x,0,transform.position.z))*speed);
            isRolling = true;
        } else {
            staticBall.SetActive(true);
            rollingBall.SetActive(false);
            if(isRolling){
                transform.position += new Vector3(0, 8, 0);
                isRolling = false;
            }
            rb.velocity = new Vector3(0,rb.velocity.y,0);
            transform.rotation = Quaternion.identity;
        }

        if(transform.position.y < -20){
            Destroy(this.gameObject);
        }
    }
}
