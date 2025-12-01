using UnityEngine;
using UnityEngine.UI;

public class backgroundScript : MonoBehaviour
{
    public GameObject Dino;
    public float backgroundSpeed;

    [SerializeField]
    private Renderer bgRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Dino = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Update and implement the code below when ready
        //player_script birdoScript = Birdo.GetComponent<player_script>();
        //if (birdoScript != null && birdoScript.birdIsAlive)
        
        bgRenderer.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime, 0);
    }
}
