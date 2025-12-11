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

    [Header("FireRate")]
    [SerializeField] private float glockFireRate = 0.5f;
    [SerializeField] private float glockNextFireTime = 0f;
    [SerializeField] private float deagleFireRate = 0.5f;
    [SerializeField] private float deagleNextFireTime = 0f;

    void Awake()
    {

    }

    void Start() {
        StartCoroutine(FindGun());
    }

IEnumerator FindGun()
{
    yield return new WaitForSeconds(0.2f);
    foreach (Transform child in gunPos.GetComponentsInChildren<Transform>())
    {
        if (child.CompareTag("Gun"))
        {
            gun = child.gameObject;
            GunScript = gun.GetComponent<GunScript>();
        }
        else if (child.CompareTag("Shootpos")) 
        {
            Shootpos = child;
        }
    }
}

    void Update()
    {
        if(CharacterEquipmentData.Instance.weaponTier != -1) {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - gunPos.position;

        gunPos.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));
        }
    }

    public void OnShoot()
    {
        if(CharacterEquipmentData.Instance.weaponTier == 0)
        {
            Bullet = GlockBullet;
            if(Time.time >= glockNextFireTime) {
                Debug.Log("Shot glock");
                Instantiate(Bullet,Shootpos.position,Shootpos.rotation);
                GunScript.Shoot();
                glockNextFireTime = Time.time + glockFireRate;
            }
        } 
        else if (CharacterEquipmentData.Instance.weaponTier == 1)
        {
            Bullet = DeagleBullet;
             if(Time.time >= deagleNextFireTime) {
                Debug.Log("Shot deagle");
                Instantiate(Bullet,Shootpos.position,Shootpos.rotation);
                GunScript.Shoot();
                deagleNextFireTime = Time.time + deagleFireRate;
            }
        }
    }
}
