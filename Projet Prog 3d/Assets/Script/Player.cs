using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public int lifeCount = 3;
    public float speed = 6f;
    public bool isRunning = true;/*false*/
    public new string name = "Dave";
  
    public Vector3 startposition = new Vector3(0.0f, 1f, 0.0f);
    public Transform playerTransform;

    


    // Use this for initialization
    private void Start()
    {
        GameObject myGameObject = new GameObject("Test Object");     //Make it a go
        Rigidbody gameObjectsRigidBody = myGameObject.AddComponent<Rigidbody>(); // Add The Rigidbody
        gameObjectsRigidBody.mass = 5;

        playerTransform.position = startposition;
        #region commentaire    
        //int
        // lifeCount = 3
        // lifeCount = lifeCount + 2;
        // lifeCount = lifeCount + 3 * 3;
        //lifeCount++;

        //float
        //speed = 5.5f;
        //speed += 0.5f;
        //speed -= 6.0f;

        //bool
        //isRunning = false;
        //isRunning = true;
        //isRunning = ! isRunning;

        // string
        //name = "Jerry";
        //name += "Nymare";
    }
    #endregion

    // Update is called once per frame
    void Update()
    {
        float tempSpeed;
        tempSpeed = speed;
        // Si leftshift est enfoncé, assigne la valeur de tempspeed
        if (Input.GetKey(KeyCode.LeftShift))
        if (isRunning)
        {
            tempSpeed = 11.0f;
        }
        // comment faire bouger avec des touches de clavier
        if (Input.GetKey("a"))
        {
            playerTransform.position += new Vector3(-tempSpeed, 0, 0) * Time.deltaTime;
        }
        else if (Input.GetKey("d"))
        {
            playerTransform.position += new Vector3(tempSpeed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey("w"))
        {
            playerTransform.position += new Vector3(0, 0, tempSpeed) * Time.deltaTime;
        }
        else if (Input.GetKey("s"))
        {
            playerTransform.position += new Vector3(0,0, -tempSpeed) * Time.deltaTime;
        }
        if (Input.GetKeyDown("space"))
        {
  transform.Translate(Vector3.up * 260 * Time.deltaTime, Space.World);
          }
        //Mur virtuel a -5
        if (playerTransform.position.x < -5)
        {
            playerTransform.position = new Vector3(-5f, 0f, 0f);

        }
        //else if player is beyons 35x, move him to 35x
        else if (playerTransform.position.x > 35f)
        {
            playerTransform.position = new Vector3(35f, 0f, 0f);
        }
    }
}
        // else, he is free to move !
                
            //Move
        
        
    

