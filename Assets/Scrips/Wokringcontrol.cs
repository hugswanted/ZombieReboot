using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wokringcontrol : MonoBehaviour
{

    // ========= MOVEMENT =================
    public float speed = 20;
    public int Jumps = 0;
    public int JumpMax = 1;

    
    // =========== MOVEMENT ==============
    Rigidbody2D rigidbody2d;
    Vector2 currentInput;

    Vector2 lookDirection = new Vector2(1, 0);
    
    float horizontal;
    float vertical;
    bool ground;
    bool mirror;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        // =========== MOVEMENT ==============
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // ============== MOVEMENT ======================
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
                
        Vector2 move = new Vector2(horizontal, vertical);
        currentInput = move;

        if(Input.GetKeyDown(KeyCode.Space) && ground == true)
        {
                rigidbody2d.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                Debug.Log("jumps");
                anim.SetTrigger("Jump");
                ground = false;

        }  
        
        if(Input.GetKeyDown(KeyCode.LeftArrow) && ground == true)
        {   
         mirror = true;
        anim.SetTrigger("Run");
        anim.ResetTrigger("Idle");
        Debug.Log("left");
        }

       if(Input.GetKeyUp(KeyCode.LeftArrow) || (Input.GetKeyUp(KeyCode.RightArrow))  && ground == true)
        { 
            anim.ResetTrigger("Run");
            anim.SetTrigger("Idle");
        }

         if(Input.GetKeyDown(KeyCode.RightArrow)  && ground == true)
        {   
         mirror = false;
          anim.SetTrigger("Run");
          Debug.Log("right");
          anim.ResetTrigger("Idle");
        }

          if(mirror == true)
         {
             transform.localRotation = Quaternion.Euler(0, 180, 0);
         }
         if(mirror == false)
         {
             transform.localRotation = Quaternion.Euler(0, 0, 0);
         }

    }
 void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        
        rigidbody2d.velocity = new Vector2(horizontal * speed, rigidbody2d.velocity.y);

    }
void OnCollisionEnter2D(Collision2D col)
{ 
 if(col.gameObject.CompareTag("Hitbox"))
 {
    Debug.Log("Ground");
    ground = true;
    anim.ResetTrigger("Jump");
    anim.SetTrigger("Idle");
 }
    if(col.gameObject.CompareTag("Hurtbox"))
 {
    anim.SetTrigger("Hurt");
     Destroy(this.gameObject);
 }  
 
}



}
