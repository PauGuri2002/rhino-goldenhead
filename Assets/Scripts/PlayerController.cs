using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 2;
    public float rotateSpeed = 5;
    public float bobbingStrength = 1;
    public float bobbingSpeed = 4;
    private float currentSpeed;
    public float jumpHeight = 2;
    public bool doorGoal = false;
    Vector2 movementVector;
    
    private int count;
    private bool isGrounded;
    private bool isMoving = false;
    private float currentAngle;
    private int pickupCount;

    public GameObject winTextObject;
    public TextMeshProUGUI countText;
    public GameObject pickups;
    public GameObject door;
    public GameObject ParticleEmitter;
    public GameObject DeathParticle;
    
    void Start()
    {
        
        winTextObject.SetActive(false);
        pickups.SetActive(true);
        pickupCount = pickups.transform.childCount;
        count = 0;
        currentAngle = transform.rotation.eulerAngles.y;
        
        rb = GetComponent<Rigidbody>();
        SetCountText();
    }

    void FixedUpdate()
    {
        countText.text = "Count: " + count.ToString();

        if(gameObject.CompareTag("DeadPlayer")) { return; }

        Vector3 movement3D = transform.localPosition;
        if(isMoving){
            currentSpeed = speed;
            float eulerY = Quaternion.LookRotation(new Vector3(movementVector.x, 0.0f, movementVector.y)).eulerAngles.y;
            if(Mathf.Abs(Mathf.DeltaAngle(currentAngle, eulerY)) > 1){
                if(Mathf.DeltaAngle(currentAngle, eulerY) < 0){
                    float tryRotate = currentAngle - rotateSpeed;
                    if(Mathf.DeltaAngle(tryRotate,eulerY) < 0){
                        currentAngle = tryRotate;
                    } else {
                        currentAngle = eulerY;
                    }
                } else if(Mathf.DeltaAngle(currentAngle, eulerY) > 0){
                    float tryRotate = currentAngle + rotateSpeed;
                    if(Mathf.DeltaAngle(tryRotate,eulerY) > 0){
                        currentAngle = tryRotate;
                    } else {
                        currentAngle = eulerY;
                    }
                }
            } else {
                currentAngle = eulerY;
            }

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, currentAngle, Mathf.Sin(Time.time*bobbingSpeed) * bobbingStrength); // apply rotation


        } else { // ease out mamahuevo
            currentSpeed *= 0.8f;
        }
        movement3D.x += movementVector.x * Time.deltaTime * currentSpeed;
        movement3D.z += movementVector.y * Time.deltaTime * currentSpeed;
        transform.localPosition = movement3D;
        
        if (transform.position.y <= -20) // se caio
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        SetCountText();
    }

    void OnMove(InputValue movementValue){
        Vector2 tempVector = movementValue.Get<Vector2>();
        if(tempVector.x != 0 || tempVector.y != 0) {
            movementVector = tempVector;
            isMoving = true;
        } else {
            isMoving = false;
        }
    }

    void OnJump()
    {
        if (isGrounded)
        {
            rb.AddForce(new Vector3(0, 1, 0) * jumpHeight);
        }
    }

    void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
        if(count >= pickupCount){
            if(!doorGoal){
                // Set the text value of your 'winText'
                winTextObject.SetActive(true);
                StartCoroutine(NextLevel());
            } else {
                door.GetComponent<DoorController>().Open();
            }
        }
	}

    IEnumerator NextLevel(){
        yield return new WaitForSeconds(2);
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Level" + (int.Parse(currentScene[currentScene.Length-1].ToString()) + 1));
    }

    IEnumerator Die()
    {
        Instantiate(DeathParticle, ParticleEmitter.transform.position, Quaternion.identity);
        gameObject.tag = "DeadPlayer";
        rb.AddTorque(999, 999, 999);
        rb.AddForce(new Vector3(0, 1, 0) * 200);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter(Collider other){
        

        if (other.gameObject.CompareTag("PickUp") && other != null){

            other.transform.parent.gameObject.SetActive(false);
            Destroy(other.transform.parent.gameObject);
            count++ ;
            
        } else if (other.gameObject.CompareTag("Killer")){
            StartCoroutine(Die());
        }
    }
}
