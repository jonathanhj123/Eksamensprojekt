using UnityEngine;

public class Obstaclescript : MonoBehaviour
{
    public GameObject player;
    public float movementspeed = 10;
    public float deadZone = -12;
    private BirdScript birdscript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void awake()
    {
    //    bird = GameObject.FindWithTag("Bird");
    }
    void Start()
    {
//        birdscript = bird.GetComponent<BirdScript>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Bird");
        birdscript = player.GetComponent<BirdScript>();
        if (birdscript.IsAlive)
        {
            transform.position = transform.position + (Vector3.left * movementspeed) * Time.deltaTime;
        }
        if (transform.position.x < deadZone)
        {
            DestroyObject();
        }


    }

    void DestroyObject()
    {
        Debug.Log("Pipe Destroyed");
        Destroy(gameObject);
    }

}
