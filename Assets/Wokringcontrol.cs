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
                ground = false;

        }  
        
        if(Input.GetKeyDown(KeyCode.LeftArrow));
        {   
         mirror = true;
        anim.SetTrigger("Run");
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow));
        {   
         mirror = true;
          anim.SetTrigger("Run");
        }

       if(Input.GetKeyUp(KeyCode.LeftArrow) && (Input.GetKeyUp(KeyCode.RightArrow)));
        { 
            anim.ResetTrigger("Run");
        }

         if(Input.GetKeyDown(KeyCode.DownArrow));
        {   
         mirror = true;
          anim.SetTrigger("Run");
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
    ground = true;
 }
}

}
