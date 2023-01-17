using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroControler : MonoBehaviour
{
    public Transform attackPos;
    public Transform groundCheck;
    public LayerMask enemyLayers;
    public LayerMask groundLayer;
    Animator animator;   
    public Rigidbody2D rb;    
    public bool isTouchingGround = true;
    public int attackDamage1 = 10; // The amount of damage the player will do when it attacks
    public int attackDamage2 = 20; // The amount of damage the player will do when it attacks
    public float groundCheckRadius;
    public float jumpSpeed = 12f;
    public float attackRange = 10f;
    public float attackRate = 2f;
    public float nextAttackTime = 0f;
    float dirX;
    float moveSpeed;
    void Start() 
    {
        animator = GetComponent<Animator>();
        moveSpeed = 5f;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Jump();

        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + dirX, transform.position.y);
        if (dirX > 0f && !animator.GetCurrentAnimatorStateInfo(0).IsName("attack-hero") && isTouchingGround)
        {
            transform.localScale = new Vector2(0.5f, 0.5f);
            animator.SetBool("isWalk", true);
        }
        else if (dirX < 0f && !animator.GetCurrentAnimatorStateInfo(0).IsName("attack-hero") && isTouchingGround)
        {
            transform.localScale = new Vector2(-0.5f, 0.5f);
            animator.SetBool("isWalk", true);
        }
        else
        {
            animator.SetBool("isWalk", true);
        }
        if (dirX != 0 && !animator.GetCurrentAnimatorStateInfo(0).IsName("attack2-hero") && isTouchingGround)
        {
            animator.SetBool("isWalk", true);
        }
        else
        {
            animator.SetBool("isWalk", false);
        }

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKey(KeyCode.Mouse0) && !animator.GetCurrentAnimatorStateInfo(0).IsName("attack2-hero"))
            {
                animator.SetBool("isWalk", false);
                animator.SetTrigger("Attack1");

                nextAttackTime = Time.time + 2f / attackRate;
            }
        }
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKey(KeyCode.Mouse1) && !animator.GetCurrentAnimatorStateInfo(0).IsName("attack-hero"))
            {
                animator.SetBool("isWalk", false);
                animator.SetTrigger("Attack2");

                nextAttackTime = Time.time + 2f / attackRate;
            }

        }


    }
    private void OnDrawGizmosSelected()
    {
        if (attackPos == null)
            return;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    public void Jump() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && isTouchingGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);


        }
    }
    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<BanditHealth>().TakeDamage(attackDamage1);

        }
    }
    public void Attack2()
    {

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<BanditHealth>().TakeDamage(attackDamage2);
        }
    }

}
