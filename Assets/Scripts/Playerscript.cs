using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public bool IsAlive = true;
    public Rigidbody2D rb2D;
    public float Movementspeed = 10;
    private Animator anim;

    public LogicScript logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
  //      anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void OnCollisionEnter2D(Collision2D bird)
    {
   //     die();
    }

    public void die()
    {
        IsAlive = false;
        Destroy(gameObject);
        Debug.Log("Bird is dead");
//        logic.gameOver();
    }

    public void OnJump()
    {
        if (IsAlive)
        {
 //           anim.Play("Jumping", 0, 0.25f);
            rb2D.linearVelocity = Vector2.up * Movementspeed;
        }
    }
}
