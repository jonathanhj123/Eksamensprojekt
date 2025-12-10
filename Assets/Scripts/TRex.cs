using System.Threading.Tasks;
using UnityEngine;

public class TRex : MonoBehaviour
{

    private PlayerScript Player;
    [SerializeField] Animator anim;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Player != null)
            {
                anim.SetBool("isBiting", true);
            }
        }
    }

   public void biteFinished()
    {
        if (Player != null)
        {
            anim.SetBool("isBiting", false);
            Player.die(); 
        }
        
    }

}
