using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletBehavior : MonoBehaviour
{
    
    private Rigidbody2D rb;
    public int BulletSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.right * BulletSpeed);
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" ||
        collision.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
          // StartCoroutine(playHitAnimation());
        }
        else if(collision.gameObject.tag == "Wall") {
            Destroy(gameObject);
        }
    }
    private IEnumerator playHitAnimation()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
       // bulletAnimator.Play("BulletHit");
        Destroy(gameObject);
        yield return null; //new WaitForSeconds(0.13f);
    }
}
