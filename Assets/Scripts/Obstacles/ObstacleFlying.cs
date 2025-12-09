using UnityEngine;
using UnityEngine.InputSystem;

public class ObstacleFlying : MonoBehaviour
{
    // Variable for speed for bevægelse til højre og dyk.
    public float flySpeed = 3f;
    public float diveSpeed = 7f;

    // Hvor langt raycasten kan tjekke for spiller.
    public float rayLength = 10f;

    // Layermask for at identificere spilleren.
    public LayerMask playerLayer;

    // Bool til at sikre, at den ikke starter med at dykke.
    private bool isDiving = false;

    //Variable til animator
    Animator animator;

    //Variabel til Partikkel effect
    public GameObject splatterEffect;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
       if (!isDiving)
        {
            // Flyver til venstre
            transform.Translate(Vector2.left * flySpeed * Time.deltaTime);
            //Laver animationen til flve
            animator.SetBool("isDiving", false);

            // Raycast til at tjekke for spilleren og sænker lige raycasten en smule.
            Vector3 offset = Vector3.right * 2f;
            RaycastHit2D hit = Physics2D.Raycast(transform.position + offset, Vector2.down, rayLength, playerLayer);

            Debug.Log("Ray hit: " + hit.collider);


            // Hvis raycasten rammer spilleren, skift til dyk-tilstand
            if (hit.collider != null)
            {
               isDiving = true;
            }
        }
        else
        {
            // Dykker nedad
            transform.Translate(Vector2.down * diveSpeed * Time.deltaTime);
            //Laver animationen til dykke
            animator.SetBool("isDiving", true);
        }
    }

        // Gør raycast synlig i editoren for debugging
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Vector3 offset = Vector3.right * 2f;
        Gizmos.DrawLine(transform.position + offset, transform.position + offset + Vector3.down * rayLength);
    }

     public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "GlockBullet" || collision.gameObject.tag == "DeagleBulelt")
        {
            
             // Spiller partikkel effekten når ptaradactle bliver ramt og inden den bliver destroyed
            if (splatterEffect != null)
            {
                Instantiate(splatterEffect, transform.position, Quaternion.identity);
            }
            
            Destroy(gameObject);

        }
    }
}

