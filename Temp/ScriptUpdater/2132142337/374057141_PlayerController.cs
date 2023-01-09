using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int allyHealth = 1;
    int jumpCount = 0;
    int jumpMax = 1;
    public Vector2 playerSpeed;  //allows us to be able to change speed in Unity
    public Vector2 jumpHeight;
    public Vector2 DashSpeed;

     float maxVelocity = 10;

    // Use this for initialization
    void Start()
    {
        Debug.Log(jumpCount);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody2D>().AddForce(playerSpeed, ForceMode2D.Force);  //makes player run Right 
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().AddForce(-playerSpeed, ForceMode2D.Force);  //makes player run left
        }
        if (Input.GetKeyDown(   KeyCode.UpArrow) && jumpCount < jumpMax)  //makes player jump
        {
            GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
            jumpCount += 1;
            Debug.Log(jumpCount+" jump");
        }

        if (Input.GetKeyDown(KeyCode.Space))  //makes player dash
        {
            GetComponent<Rigidbody2D>().AddForce(DashSpeed, ForceMode2D.Impulse);

        }

        {
 GetComponent<Rigidbody2D>().velocity = Vector2.ClampMagnitude(GetComponent<Rigidbody2D>().velocity.magnitude, maxVelocity);
 }
        
    }


    //Resets Arial mobility on touching the ground
    void ResetAerial()
    {
        jumpCount = 0;
        Debug.Log(jumpCount + " Reset");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log (jumpCount);
        if (other.gameObject.tag != "Ground")
        {
            ResetAerial();
        }
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