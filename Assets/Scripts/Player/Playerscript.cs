using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class PlayerScript : MonoBehaviour
{
    public bool IsAlive = true;
    public Rigidbody2D rb2D;
    public float JumpForce = 10;
    private Animator anim;

    void Start()
    {
        
  //      anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, Vector2.down * 2f, Color.red);
    }

    public void die()
    {
        IsAlive = false;
        Destroy(gameObject);
        Debug.Log("Bird is dead");
    }

    private bool getIsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 2.4f, LayerMask.GetMask("Ground"));
    }

    private bool touchedObstacle()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 2f, LayerMask.GetMask("Obstacle"));
    }

    public void OnJump()
    {
        if (IsAlive && getIsGrounded())
        {
 //           anim.Play("Jumping", 0, 0.25f);
            rb2D.linearVelocity = Vector2.up * JumpForce;
        }
    }
}
