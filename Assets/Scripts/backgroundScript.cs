using UnityEngine;
using UnityEngine.UI;

public class backgroundScript : MonoBehaviour
{
    private PlayerScript Player;
    public float backgroundSpeed;

    [SerializeField]
    private Renderer bgRenderer;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    void Update()
    {
        if (Player != null && Player.IsAlive == true)
        {
            bgRenderer.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime, 0);
        }
    }
}
