using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BanditHealth : MonoBehaviour
{
    public int maxHealth = 100; // The enemy's maximum health
    public int currentHealth; // The enemy's current health
    public Animator animator;
    public HealthBar healthBar;

    void Start()
    {
        // Initialize the enemy's health
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }

    // Function to take damage
    public void TakeDamage(int damage)
    {
        // Subtract the damage from the enemy's health
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        animator.SetTrigger("Hurt");
        // If the enemy's health is less than or equal to 0
        if (currentHealth <= 0)
        {
            // Destroy the enemy game object
            Die();
        }
    }

    public void Die() 
    {
        animator.SetBool("Death", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        StartCoroutine(Invisible());

        
       
    }
    IEnumerator Invisible() 
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
