using UnityEngine;
using UnityEngine.UI;

public class backgroundScript : MonoBehaviour
{
    public GameObject Dino;
    public float backgroundSpeed;

    [SerializeField]
    private Renderer bgRenderer;

    void Start()
    {
        Dino = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        // Update and implement the code below when ready
        //player_script birdoScript = Birdo.GetComponent<player_script>();
        //if (birdoScript != null && birdoScript.birdIsAlive)
        
        bgRenderer.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime, 0);
    }
}
