using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerHealth : MonoBehaviour
{
	public int health = 100;

	public Animator animator;

	public HealthBar healthBar;

    private void Start() 
	
	{
		healthBar.SetHealth(health);
	}
	public void TakeDamage(int damage) 
	{
		health -= damage;
		healthBar.SetHealth(health);
		animator.SetTrigger("Hurt");

		if(health <= 0) 
		{
			animator.SetBool("Death", true);
			this.GetComponent<HeroControler>().enabled = false;
			

			StartCoroutine(DeathTime());
		}
	}


	IEnumerator DeathTime() 
	{
		yield return new WaitForSeconds(1.5f);

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}

	public void IncreaseHealth(int amount) 
	{
		if(health < 100) 
		{
			health += amount;
			healthBar.SetHealth(health);
		}
	}




	


}
