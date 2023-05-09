using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 2;
    
    private int count, count2;
    private float movementX;
    private float movementY;

    public GameObject winTextObject;

    public GameObject scene;
    public GameObject scene2;
    public TextMeshProUGUI countText;

    bool level = true;
   
    public GameObject pickups;
    // Start is called before the first frame update
    void Start()
    {
        pickups.SetActive(false);
        scene2.SetActive(false);
        count = 0;
        count2 = 0;
        rb = GetComponent<Rigidbody>();

        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue){
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

        void SetCountText()
	{
		countText.text = "Count: " + count.ToString();

		if (count >= 12) 
		{
                    // Set the text value of your 'winText'
                    winTextObject.SetActive(true);
                    
                    Levels();
		}
	}
        void Levels(){
          
            if(count >=12){
                
                winTextObject.SetActive(false);
                scene2.SetActive(true);
                scene.SetActive(false);
                pickups.SetActive(true);
                level = false;
                
            }
           
           
        }

    void FixedUpdate(){
        
        if(level == true){
            countText.text = "Count: " + count.ToString(); 
        }
        else if(level == false){
            countText.text = "Count: " + count2.ToString(); 
        }

        Vector3 movement = new Vector3 (movementX, 0.0f ,movementY);
        rb.AddForce(movement * speed);
        SetCountText();
    }
    private void OnTriggerEnter(Collider other){
        

        if (other.gameObject.CompareTag("PickUp")){
            
            other.gameObject.SetActive(false);
            count++ ;
            
        }
        else if(other.gameObject.CompareTag("PickUp2")){
            other.gameObject.SetActive(false);
            count2++ ;
        }

    }
}
