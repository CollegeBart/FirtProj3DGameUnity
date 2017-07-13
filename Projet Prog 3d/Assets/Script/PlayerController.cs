using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
    private CharacterController controller;
    public bool isRunning = true;
    private float verticalVelocity = 6f;
    private float gravity = 14.0f;
    private float jumpForce = 10.0f;
    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;

    void Start ()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";

    }


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 18) 
        {
            winText.text = "You Win"; 
        }
    }
    private void Update()
    {

        float tempSpeed;
        tempSpeed = verticalVelocity;


       

        if (controller.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        // moveVector.x/y/z = bouger sur les axe // *5.0f = vitesses
        Vector3 moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis("Horizontal") * 5.0f;
        moveVector.y = tempSpeed;
        moveVector.z = Input.GetAxis("Vertical") * 5.0f;
        controller.Move(moveVector * Time.deltaTime);

    }
}
