using UnityEngine;

public class GunScript : MonoBehaviour
{

    [SerializeField] private Animator anim;
    [SerializeField] private int glock;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
     Debug.Log("GunScriptOnShoot");

        if (glock == 1 )
        {
        anim.Play("glockAnim",0,0.25f);              
        }else
        {
            anim.Play("gunAnim",0,0.25f);
        }


    }
}
