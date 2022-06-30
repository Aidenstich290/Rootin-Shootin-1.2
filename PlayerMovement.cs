using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public CharacterController2D controller; // Asigns the Controller 

    public Animator animator; // Asigns the Animator and controls the Animations 

    public int maxHealth = 1000; // Sets the Max health at 1000 

    public int currentHealth; // Shows what the current health is 

    public HealthBar healthBar; // Asigns the Health Bar 

    float horizontalMove = 0f; // Shows movement on the horizontal axis

    bool jump = false; // Shows jump as false not happening

    bool crouch = false; // Shows crouch as false not happening

    [SerializeField] private Material flashMaterial; // Location to store Material to flash

    [SerializeField] private float duration; // Determines duration for flash

    private SpriteRenderer spriteRenderer; // Access to SpriteRenederer

    private Material originalMaterial; // Shows the Original Material of the sprite

    private Coroutine flashRoutine; // Access to this field


    void Start()
    {
        currentHealth = maxHealth; // shows the health of the player

        spriteRenderer = GetComponent<SpriteRenderer>(); // Grabs the SpriteRenederer of the GameObject

        originalMaterial = spriteRenderer.material; // Asign the Original Material of the GameObject

    }

    public float runSpeed = 40f; // Sets the run speed

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed; // Tells the player how to move through the level

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove)); // Shows the animation for running

        if (Input.GetButtonDown("Jump"))
        {
            jump = true; // Shows jump as true
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit(); // Quits the Game
        }

        if(Input.GetButtonDown("Crouch"))
        {
            crouch = true; // Shows crouch as true 
            
            animator.SetBool("isCrouching", true); // Shows to play the crouch animaiton
        } 
        
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false; // shows crouch as false
            
            animator.SetBool("isCrouching", false); // // Shows to stop the crouch animaiton
        }
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);

        jump = false; // Shows jump as false
    }

    private IEnumerator FlashRoutine()
    {
        spriteRenderer.material = flashMaterial; // Asigns the flash Material

        yield return new WaitForSeconds(duration); // How long the flash will be before returning to Original Material

        spriteRenderer.material = originalMaterial; // Asigns the Original Material again

        flashRoutine = null; // Refrences the Routine as Null
    }

    public void Flash()
    {
        if (flashRoutine != null) // Tells the FlashRoutine to Stop
        {
            StopCoroutine(flashRoutine); // Sees When flash Routine is Null
        }

        flashRoutine = StartCoroutine(FlashRoutine()); // Stops the Routine

    }

    public GameObject deathEffect; // Asigns DeathEffect prefab 

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Takes health away from the current health 

        healthBar.SetHealth(currentHealth); // Sets the Health bar slider

        flashRoutine = StartCoroutine(FlashRoutine()); // Starts the FlashRoutine 

        if (currentHealth <= 0)
        {
            Die(); // Starts the void Die line of code
        }
    }

    

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity); // When and where to spwan the Deatheffect
        
        Destroy(gameObject); // Deletes the GameObject
        
        FindObjectOfType<GameManager>().EndGame(); // References the Game Manager
    }
}
