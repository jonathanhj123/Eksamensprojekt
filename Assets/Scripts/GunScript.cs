using UnityEngine;

public class GunScript : MonoBehaviour
{

    [SerializeField] private Animator anim;
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
     anim.Play("gunAnim",0,0.25f);   

    }
}
