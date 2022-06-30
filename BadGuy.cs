using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuy : MonoBehaviour
{
    public int health = 100; // Determines the amount of health

    public GameObject deathEffect; // Place to store the DeathEffect prefab

    public GameObject PointEffect; // Place to store the DeathEffect prefab

    public Animator animator; // Provide Access for the Animator

    [SerializeField] private Material flashMaterial; //Location to store Material to flash 

    [SerializeField] private float duration; // Determines duration for flash

    private SpriteRenderer spriteRenderer; // Access to SpriteRenederer

    private Material originalMaterial; // Shows the Original Material of the sprite

    private Coroutine flashRoutine; // Access to this field

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Grabs the SpriteRenederer of the GameObject

        originalMaterial = spriteRenderer.material; // Asign the Original Material of the GameObject
    }

    private IEnumerator FlashRoutine() // Preforms a flash of the GameObject
    {
        spriteRenderer.material = flashMaterial; // Asigns the flash Material

        yield return new WaitForSeconds(duration); // How long the flash will be before returning to Original Material

        spriteRenderer.material = originalMaterial; // Asigns the Original Material again

        flashRoutine = null; // Refrences the Routine as Null
    }

    public void Flash() // Tells the FlashRoutine to Stop
    {
        if (flashRoutine != null) // Sees When flash Routine is Null
        {
            StopCoroutine(flashRoutine); // Stops the Routine 
        }

        flashRoutine = StartCoroutine(FlashRoutine()); // Will Start the Routine Again

    }

    public void TakeDamage (int damage) // Allows the Enemy to take Damage and Communicate with the GameObjects Health
    {
        health -= damage; // Will Subtract Damage int from GameObjects Health 

        flashRoutine = StartCoroutine(FlashRoutine()); // Will Start the FlashRoutine

        if (health <= 0) // Looks to see if GameObject Health is Zero
        {
            Die(); // Runs void Die

            animator.SetBool("Deatheffect", false); // Sets Deatheffect false
        }
    }

    void Die () // Performs all actions after Death 
    {
        Score.scoreValue += 10; // Adds 10 Score to Player
        
        animator.SetBool("Deatheffect", true); // Sets Deatheffect true Plays Effect
       
        animator.SetBool("PointEffect", true); // Sets Pointeffect true Plays Effect
        
        Instantiate(deathEffect, transform.position, Quaternion.identity); // Spawns the DeathEffect and Where to Spwan
        
        Instantiate(PointEffect, transform.position, Quaternion.identity); // Spawns the DeathEffect and Where to Spwan

        Destroy(gameObject); // Deletes the GameObject
    }
}
