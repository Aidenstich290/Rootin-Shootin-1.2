using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f; // Determines the speed of the Bullet
   
    public int damage = 40; // How much Damage the bullet inflicts 
   
    public Rigidbody2D rb; // the Physics of the Bullet
    
    public GameObject hitEffect; // Provides the hitEffect
    
    public Animator animator; // Provides the Animator to control the bullets Animation

    void Update()
    {
        rb.velocity = transform.right * speed; // Determines the Bullets Physics
    }

    void OnTriggerEnter2D (Collider2D hitInfo) // Preforms Actions when the Bullet hits something
    {
        BadGuy BadGuy = hitInfo.GetComponent<BadGuy>(); // References the Badguy Script
        
        if (BadGuy != null) // References the Object as Null
        {
            BadGuy.TakeDamage(damage); // Talls the Badguy Script to inflict Damage

            animator.SetBool("hitEffect", false); // Sets the hitEffect not to play
        }

        animator.SetBool("hitEffect", true); // Sets the hitEffect to Play
        
        Instantiate(hitEffect, transform.position, Quaternion.identity); // Tells When and Where to Spawn the hitEffect
       
        Destroy(gameObject); // Deletes the GameObject

    }
}
