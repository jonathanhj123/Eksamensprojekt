using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GunController : MonoBehaviour
{
    [SerializeField] private Transform gunPos;
    [SerializeField] private GameObject gun;
    private GunScript GunScript;
    public Transform Shootpos;
    public GameObject DeagleBullet;
    public GameObject GlockBullet;
    private GameObject Bullet;


    // Update is called once per frame

    void Awake()
    {
 //       if(CharacterEquipmentData.Instance.weaponTier == 0)
 //       {
 //           Bullet = GlockBullet;
 //       } else if (CharacterEquipmentData.Instance.weaponTier == 1)
//        {
 //           GlockBullet = DeagleBullet;
  //      }
        
        GunScript = gun.GetComponent<GunScript>();
        Bullet = DeagleBullet;

    }
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - gunPos.position;

        gunPos.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));
    }


    public void OnShoot()
    {
    Instantiate(Bullet,Shootpos.position,Shootpos.rotation);
    Debug.Log("Pew pew");
    GunScript.Shoot();
    }
}
