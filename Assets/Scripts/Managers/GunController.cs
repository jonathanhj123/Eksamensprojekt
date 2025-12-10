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

        
        Bullet = DeagleBullet;
        GunScript = gun.GetComponent<GunScript>();


    }
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - gunPos.position;

        gunPos.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));
    }


    public void OnShoot()
    {

        if(CharacterEquipmentData.Instance.weaponTier == 0)
        {
            Bullet = GlockBullet;
        } else if (CharacterEquipmentData.Instance.weaponTier == 1)
        {
            Bullet = DeagleBullet;
        }
    Instantiate(Bullet,Shootpos.position,Shootpos.rotation);
    Debug.Log("Pew pew");
    GunScript.Shoot();
    }
}
