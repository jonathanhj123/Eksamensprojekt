using UnityEngine;
using System.Collections;

public class NormalLaser : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private Animator bulletAnimator;

    [SerializeField] private float bulletSpeed = 12f;
    //[SerializeField] private bulletDamage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ballAnimator = this.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 20f);
        }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = transform.up * bulletSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Meteor" ||
        collision.gameObject.tag == "Enemy")
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
