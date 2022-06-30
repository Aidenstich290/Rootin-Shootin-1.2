using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{

    public float speed; // Speed of the Enemy
    
    public float lineOfSite; // How far the Enemy Can See
   
    public float shootingRange; // How far the Enemy Can shoot
    
    public float fireRate = 1f; // How fast the Enemy will Shoot
    
    private float nextFireTime; // The Next time the Enemy will Shoot
   
    public GameObject Bullet; // Asigns the Bullet prefab
    
    public GameObject BulletParent; // Asigns The Location of the Firepoint
   
    private Transform player; // Shows Player Location
   
    private Vector2 playerPosition; // Movement of Player Location
   
    private bool facingRight = true; // Where the Enemy is facing
   
    public Animator animator; // Asigns Animator to Control Animaiton

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Locats the tag Player
        
    }

    // Update is called once per frame
    void Update()
    {

        AttackPlayer(); // Runs the Attack Player line of code

        FlipTowardsPlayer(); // Runs the FlipTowardsPlayer line of code

    }
    

    void AttackPlayer()
    {
        playerPosition = player.position - transform.position; // Locates the player

        playerPosition.Normalize(); //  Shows the normal position of the player

        float distanceFromPlayer = Vector2.Distance(player.position, transform.position); // Shows how far the player is from the Enemy 
        
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)  
        {
            animator.SetBool("isShooting", false); // Sets shooting Animation not to play 
            
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime); // Moves Enemy towards player 
        }
        
        else if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
        {
            Instantiate(Bullet, BulletParent.transform.position, Quaternion.identity); // When and Where the Bullet will spwan

            nextFireTime = Time.time + fireRate; // Determines the Next time it should 

            animator.SetBool("isShooting", true); // Sets shooting Animation to play
        }
        
    }

    private void OnDrawGizmosSelected()
    {        
        Gizmos.color = Color.green; // Shows the LineOfSite and ShootingRange Outlines in green
        
        Gizmos.DrawWireSphere(transform.position, lineOfSite); // The area for the lineOfSite
        
        Gizmos.DrawWireSphere(transform.position, shootingRange); // The area for The ShootingRange
    }

    void FlipTowardsPlayer()
    {
        playerPosition = player.position - transform.position; // Location of the Player

        playerPosition.Normalize(); // Normal Position of the Player

        float playerDirection = player.position.x - transform.position.x; // Which Direction the Player is Moving

        if (playerDirection < 0 && facingRight) // Showing if Player is facing Right
        {
            Flip(); // Access the void Flip line of code
        }
        else if (playerDirection > 0 && !facingRight) // Showing if the Player is facing left
        {
            Flip(); // // Access the void Flip line of code
        }
    }

    public void Flip()
    {
        facingRight = !facingRight; // Sees where the player is facing
        
        transform.Rotate(0, 180, 0); // Flips the Enemy if need toward the player
    }

}