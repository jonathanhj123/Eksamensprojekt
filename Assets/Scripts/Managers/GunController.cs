using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GunController : MonoBehaviour
{
    [SerializeField] private Transform gun;
    [SerializeField] private Animator gunAnim;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - gun.position;

        gun.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));
    }


    public void OnShoot()
    {
   //    gunAnim.SetTrigger("Shoot"); 
       Debug.Log("Pew pew");
    }
}
