using UnityEngine;
using UnityEngine.InputSystem;

public class ObstacleHoming : MonoBehaviour
{
    //Variable

    //Sætter objektets bevægelseshastighed til 3 enheder per sekund, men kan ændres i inspector.
    public float moveSpeed = 3f;
    
    //Definerer en Transform-variabel kaldet targetTransform, som vil blive brugt til at angive målets position.
    public Transform targetTransform;

    //Snakker med objektets Rigidbody2D-komponent.
    Rigidbody2D rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, moveSpeed * Time.deltaTime);

    }
}
