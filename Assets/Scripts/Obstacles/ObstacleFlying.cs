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


    // Update is called once per frame
    void Update()
    {
       
       if (!isDiving)
        {
            // Flyver til venstre
            transform.Translate(Vector2.left * flySpeed * Time.deltaTime);

            // Raycast til at tjekke for spilleren og sænker lige raycasten en smule.
            RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.down * 4f, Vector2.down, rayLength, playerLayer);

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
        }
    }

        // Gør raycast synlig i editoren for debugging
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * rayLength);
    }
}

