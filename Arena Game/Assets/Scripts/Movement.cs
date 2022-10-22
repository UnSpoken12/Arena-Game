using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed = 1.5f;
    private float lastAttacked = 0;
    private float attackInterval = 1f;
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    private void Update()
    {
        // Input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Movement
        float totalHoriMovement = horizontalInput * Time.deltaTime * speed;
        float totalVertMovement = verticalInput * Time.deltaTime * speed;
        transform.Translate(new Vector2(totalHoriMovement, totalVertMovement));

        // Transition to walking animation
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput + verticalInput));

        // Change the direction it's facing
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }

        // Attacking and attack interval/animation
        if (Input.GetMouseButtonDown(0) && Time.time > lastAttacked + attackInterval)
        {
            animator.SetTrigger("Attack");
            lastAttacked = Time.time;

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            foreach(Collider2D enemy in hitEnemies)
            {
                Debug.Log("We hit " + enemy.name);
            }
        }
    }
}
