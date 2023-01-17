using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditWeapon : MonoBehaviour
{











	public int ozljeda = 20;

	public GameObject player;
	public Vector3 attackOffset;
	public float attackRange = 1f;
	public LayerMask attackMask;
	public Animator animator;
	public PlayerHealth helt;
	public BanditRun run;
	



    private void Update()
    {
        if(helt.health <=0) 
		{
			this.GetComponent<BanditWeapon>().enabled = false;
			this.GetComponent<BanditRun>().stopRun = false;
		}
    }
    public void Attack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D collInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (collInfo != null)
		{
			
			
				collInfo.GetComponent<PlayerHealth>().TakeDamage(ozljeda);
			
			if (player.GetComponent<PlayerHealth>().health <= 0)
			{
				animator.SetTrigger("Idle");
			}


		}

	}

	private void OnDrawGizmos()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;
		Gizmos.DrawWireSphere(pos, attackRange);
	}


	


















}