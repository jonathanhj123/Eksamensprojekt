using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class PlayerScript : MonoBehaviour
{
    public bool IsAlive = true;
    public Rigidbody2D rb2D;
    public float JumpForce = 10;
   [SerializeField] private Animator anim;


    void Start()
    {
        
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, Vector2.down * 2f, Color.red);
        Debug.DrawRay(new Vector3(transform.position.x-1,transform.position.y,transform.position.z), Vector2.down * 2f, Color.red);
        Debug.DrawRay(new Vector3(transform.position.x+1,transform.position.y,transform.position.z), Vector2.down * 2f, Color.red);
        

        if(touchedObstacle())
        {
            die();
        }
    }

    public void die()
    {
        IsAlive = false;
        Destroy(gameObject);
        Debug.Log("Dino is dead");
    }

    private bool getIsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 2.5f, LayerMask.GetMask("Ground"));
    }
    


    private bool touchedObstacle()
    {
        if(
        Physics2D.Raycast(transform.position, Vector2.down, 2.1f, LayerMask.GetMask("Obstacle")) 
        ||
        Physics2D.Raycast(new Vector3(transform.position.x-1,transform.position.y,transform.position.z), Vector2.down, 2.1f, LayerMask.GetMask("Obstacle"))
        ||
        Physics2D.Raycast(new Vector3(transform.position.x+1,transform.position.y,transform.position.z), Vector2.down, 2.1f, LayerMask.GetMask("Obstacle"))
        )
        {
            return true;
        }
        else
        {
            return false;
        }



    }

    public void OnJump()
    {
        if (IsAlive && getIsGrounded())
        { 
            anim.Play("DinoJump", 0, 0.25f);   
            rb2D.linearVelocity = Vector2.up * JumpForce;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "AirObstacle")
        {
            die();
          // StartCoroutine(playHitAnimation());
        }

    }
}
