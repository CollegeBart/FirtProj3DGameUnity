using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMotor : MonoBehaviour
{
    private Vector3 moveVector;
    private Vector3 lastMove;
    private CharacterController controller;
    public bool isRunning = true;
    private float verticalVelocity = 6f;
    private float gravity = 14.0f;
    private float jumpForce = 10.0f;
    private float speed = 8;
    public Text countText;
    public Text winText;
    public Text deadText;
    private int count;
    public Transform camTransform;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        count = 0;
        SetCountText();
        winText.text = "";

    }

         private void Update()
         { 
                 float tempSpeed;
                 tempSpeed = verticalVelocity;
                 moveVector = Vector3.zero;
                 float moveHorizontal = Input.GetAxis("Horizontal");
                 float moveVertical = Input.GetAxis("Vertical");
                 Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

                    if (controller.isGrounded)
                    {
                        verticalVelocity = -1;
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            verticalVelocity = jumpForce;
                        }          
                    }
                    else
                    {
                        verticalVelocity -= gravity * Time.deltaTime;
                        moveVector = lastMove;
                    }

                    // moveVector.x/y/z = bouger sur les axe // *5.0f = vitesses
        
                    moveVector.x = Input.GetAxis("Horizontal") * 7.5f;
                    moveVector.y = 0;
                    moveVector.Normalize();
                    moveVector *= speed;
                    moveVector.y = verticalVelocity;
                    moveVector.z = Input.GetAxis("Vertical") * 7.5f;
                    Vector3 dir = camTransform.TransformDirection(movement);
                    dir.Set(dir.x, 0, dir.z);
                    movement = dir.normalized * moveVector.magnitude;
                    movement.y = moveVector.y;
                    controller.Move(movement * Time.deltaTime);
                    lastMove = moveVector;

                    
                    }

            private void OnControllerColliderHit(ControllerColliderHit hit)
            {

                if (!controller.isGrounded && hit.normal.y < 0.1f)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                    Debug.DrawRay(hit.point, hit.normal, Color.red, 1.25f);
                    verticalVelocity = jumpForce;
                    moveVector = hit.normal * speed;

                    }
                }
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
        if (count >= 55)
        {
            winText.text = "You Win";
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
    }



}

