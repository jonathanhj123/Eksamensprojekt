using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GunController : MonoBehaviour
{
    [SerializeField] private Transform gunPos;
    [SerializeField] private GameObject gun;
    private GunScript GunScript;
    public Transform Shootpos;
    public GameObject Bullet;

    // Update is called once per frame

    void Awake()
    {
        
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
    Instantiate(Bullet,Shootpos.position,Shootpos.rotation);
    Debug.Log("Pew pew");
    GunScript.Shoot();
    }
}
