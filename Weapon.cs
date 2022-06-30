using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint; // Asigns the Firepoint where the bullet prefab will be instantiated
   
    public GameObject bulletPrefab; // Asigns the Bullet Prefab
   
    public Animator animator; // Asigns the Animator to control the Animations
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))           //Calls the void shooting command
        {
            Shoot();
            animator.SetBool("IsShooting", true);   //Performs the shooting animation
        }
        else
        {
            animator.SetBool("IsShooting", false);  //Stops the shooting animation
        }
    }
        

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); //Generates the bulletPrefab and its shooting postion to generates form  
    }
     
}

