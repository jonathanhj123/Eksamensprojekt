using UnityEngine;
using UnityEngine.InputSystem;

public class ObstacleHoming : MonoBehaviour
{
    //Variable

    //Sætter objektets bevægelseshastighed til 3 enheder per sekund, men kan ændres i inspector.
    public float moveSpeed = 3f;
    
    //Definerer en Transform-variabel kaldet targetTransform, som vil blive brugt til at angive målets position.
    public Transform targetTransform;

    //Definerer en Vector3-variabel kaldet fixedTargetPosition, som kan bruges til at gemme en fast position for målet.
    private Vector3 fixedTargetPosition;
    
    //Snakker med objektets Rigidbody2D-komponent.
    Rigidbody2D rb;

    //Variabel til Partikkel effect
    public GameObject breakingEffect;


    void Awake()
    {
        //Gemmer den oprindelige position af målet i fixedTargetPosition-variablen.
        targetTransform = GameObject.FindWithTag("Player").transform;
        fixedTargetPosition = targetTransform.position;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Flytter objektet mod den position målet havde, da objektet blev oprettet.
        transform.position = Vector3.MoveTowards(transform.position, fixedTargetPosition, moveSpeed * Time.deltaTime);

        //Blev brugt til at flytte meteoren mod målets live position.
        //transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, moveSpeed * Time.deltaTime);

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "GlockBullet")
        {
            
            // Spiller partikkel effekten når meteoren bliver ramt og inden den bliver destroyed
            if (breakingEffect != null)
            {
                Instantiate(breakingEffect, transform.position, Quaternion.identity);
            }
            
            Destroy(gameObject);

        }
    }
}
