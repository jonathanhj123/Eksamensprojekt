using UnityEngine;

public class Obstaclescript : MonoBehaviour
{
    public GameObject player;
    public float movementspeed = 10;
    public float deadZone = -12;
    private PlayerScript playerscript;

    public float rayLength;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void awake()
    {

    }
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerscript = player.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        playerscript = player.GetComponent<PlayerScript>();
       if (playerscript.IsAlive)
        {
            transform.position = transform.position + (Vector3.left * movementspeed) * Time.deltaTime;
        }
        if (transform.position.x < deadZone)
        {
            DestroyObject();
        }

        if(checkForPlayer())
        {
            killPlayer();
        }
        Debug.DrawRay(transform.position, Vector2.up * rayLength, Color.red);

    }

    private void DestroyObject()
    {
        Debug.Log("Pipe Destroyed");
        Destroy(gameObject);
    }

    private bool checkForPlayer()
    {
        return Physics2D.Raycast(transform.position, Vector2.up, rayLength, LayerMask.GetMask("Player"));
    }

    private void killPlayer()
    {
        // Dræb spiller

        DestroyObject(player);
    }
}
