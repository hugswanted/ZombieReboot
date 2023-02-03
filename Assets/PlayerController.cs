using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int allyHealth = 1;
    int jumpCount = 0;
    int jumpMax = 2;
    public Vector2 playerSpeed;  //allows us to be able to change speed in Unity
    float speed = 20;
    float jumpHeight = 5;
    public Vector2 DashSpeed;
    Animator m_Animator;
    //  float maxVelocity = 10;

     Rigidbody2D playerRb;
     float horizontal;

     float vertical;

     bool rightArrow;
     bool leftArrow;
     bool upArrow;

    // Use this for initialization
    void Start()
    {
        Debug.Log(jumpCount);
        playerRb = GetComponent<Rigidbody2D>();
        m_Animator = gameObject.GetComponent<Animator>();
    }

void Update()
{
    leftArrow = Input.GetKey(KeyCode.LeftArrow);
    rightArrow = Input.GetKey(KeyCode.RightArrow);
    upArrow = Input.GetKey(KeyCode.UpArrow);
    Vector2 position = playerRb.position;
    if (rightArrow)
        {
            position.x = position.x + speed * 1 * Time.deltaTime;  //makes player run Right 
            playerRb.MovePosition(position);
            m_Animator.SetTrigger("Run");
        }

    if (leftArrow)
        {
            position.x = position.x + speed * -1 * Time.deltaTime;  //makes player run left
            playerRb.MovePosition(position);
            m_Animator.SetTrigger("Run");
            Debug.Log("sprint");
        }

    if (!rightArrow & !leftArrow)
        {
            m_Animator.ResetTrigger("Run");
            Debug.Log("idle");
        }
}

    // void Update()
    // {
    //     rightArrow = Input.GetKey(KeyCode.RightArrow);
    //     leftArrow = Input.GetKey(KeyCode.LeftArrow);
    //     upArrow = Input.GetKey(KeyCode.UpArrow);

    //     // if (upArrow && jumpCount < jumpMax)  //makes player jump
    //     //  {
    //     //     playerRb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
    //     //     jumpCount += 1;
    //     //     Debug.Log(jumpCount+" jump");
    //     //     m_Animator.SetTrigger("Jump");
    //     //  }

    // }
    // // Update is called once per frame
    // void FixedUpdate()
    // {

    //     Vector2 position = playerRb.position;
    //     // position.x = position.x + speed * Time.deltaTime;
    //     // position.y = position.y + speed * vertical * Time.deltaTime;

    //      if (upArrow && jumpCount < jumpMax)  //makes player jump
    //     {
    //         position.y = position.y + jumpHeight;  //makes player run Right 
    //         playerRb.MovePosition(position);
    //     }

    //     if (rightArrow)
    //     {
    //         position.x = position.x + speed * 1 * Time.deltaTime;  //makes player run Right 
    //         playerRb.MovePosition(position);
    //         m_Animator.SetFloat("Speed",speed);
    //     }

    //     if (leftArrow)
    //     {
    //         position.x = position.x + speed * -1 * Time.deltaTime;  //makes player run left
    //         playerRb.MovePosition(position);
    //         m_Animator.SetFloat("Speed",speed);
    //     }

    //     if ( !leftArrow && !rightArrow)
    //     {
    //         m_Animator.SetFloat("Speed",0);
    //     }





    //     if (Input.GetKeyDown(KeyCode.Space))  //makes player dash
    //     {
    //         playerRb.AddForce(DashSpeed, ForceMode2D.Impulse);

    //     }

    //     // {
    //     //     playerRb.velocity = Vector2.ClampMagnitude(playerRb.velocity.magnitude, maxVelocity);
    //     // }  

    // }


    // //Resets Arial mobility on touching the ground
    // void ResetAerial()
    // {
    //     jumpCount = 0;
    //     Debug.Log(jumpCount + " Reset");
    //     m_Animator.ResetTrigger("Jump");
    // }

    // void PlayerJump()
    // {
    //     playerRb.AddForce(jumpHeight * 2, ForceMode2D.Impulse);
    //     jumpCount += 1;
    //     Debug.Log(jumpCount+" jump");
    // }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Debug.Log (jumpCount);
        // if (other.gameObject.tag != "Ground")
        // {
        //     // ResetAerial();
        // }
        {
            Debug.Log(allyHealth);
            if (other.gameObject.tag == "Hurtbox")
            {
                allyHealth -= 1;
                if (allyHealth == 0)
                {
                    Destroy(this.gameObject);
                }
            }
        }

    }
}