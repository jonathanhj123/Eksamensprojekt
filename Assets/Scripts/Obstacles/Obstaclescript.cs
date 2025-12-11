using UnityEngine;

public class Obstaclescript : MonoBehaviour
{
    public GameObject player;
    public float movementspeed = 0;
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
    if(!GameData.Instance.GameRunning) return;
    
    playerscript = player.GetComponent<PlayerScript>();
       if (playerscript.IsAlive)
        {
            transform.position = transform.position + (Vector3.left * movementspeed) * Time.deltaTime;
        }
        if (transform.position.x < deadZone)
        {
            DestroyObject();
        }


    }

    private void DestroyObject()
    {
        Debug.Log("Pipe Destroyed");
        Destroy(gameObject);
    }
    
}
