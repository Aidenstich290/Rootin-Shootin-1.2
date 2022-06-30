using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadguyBullet : MonoBehaviour
{
    
    GameObject target; // Asigns GameObject Target
    
    public float speed; // Speed of the Bullet Prefab
    
    Rigidbody2D bulletRB; // Grabs Phisyic of the Bullet
    
    public int damage = 40; // How Much Damage the Bullet inflicks
    
    public Animator animator; // Asigns GameObjects Animator 
    
    public GameObject hitEffect; // Asigns GameObjects hitEffect

    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>(); // Takes Phisyic of the Bullet

        target = GameObject.FindGameObjectWithTag("Player"); // Asigns the Player as the GameObject
        
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed; // Finds the movement of the Target
        
        bulletRB.velocity = transform.right * new Vector2(moveDir.x, moveDir.y); // Moves the Bullet        
    }

    void OnTriggerEnter2D(Collider2D hitInfo) // Perfrom Actions When bullet hits 
    {
        PlayerMovement PlayerMovement = hitInfo.GetComponent<PlayerMovement>(); // References The Playermovement scrpit to allow the Player to take Damage
        
        if (PlayerMovement != null) // Tell the playermovement script to inflick damage on the Player
        {
            PlayerMovement.TakeDamage(damage); // Tells How much Damage to inflick
            
            animator.SetBool("hitEffect", false); // Shows hitEffect not to Play
        }
       
        animator.SetBool("hitEffect", true); // Shows hitEffect to Play
        
        Destroy(gameObject); // Deletes GameObject 
    }
}
