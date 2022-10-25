using System.Diagnostics;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed = 1.5f;
    private float lastAttacked = 0;
    private float attackInterval = 1f;
    private float attackRange = 0.25f;
    private float attackDuration = .1f;
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public int currentHealth;
    private int maxHealth = 3;
    private float hitCooldown = 1f;
    private float lastHit = 0f;

    void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        // Input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        #region // Movement
        float totalHoriMovement = horizontalInput * Time.deltaTime * speed;
        float totalVertMovement = verticalInput * Time.deltaTime * speed;
        transform.Translate(new Vector2(totalHoriMovement, totalVertMovement));

        // Walking animation
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput + verticalInput));

        // Change the direction player is facing
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        #endregion

        #region // Combat
        // Checks attack cooldown
        if (Input.GetMouseButtonDown(0) && Time.time > lastAttacked + attackInterval)
        {
            animator.SetTrigger("Attack");
            lastAttacked = Time.time;
            lastHit = Time.time - hitCooldown + .5f;
        }

        // Does the attack for a duration
        if (Time.time < lastAttacked + attackDuration)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Slime>().Damage(hitCooldown);
            }
        }
        #endregion
    }

    public void Damage()
    {
        // Checks cooldown
        if (Time.time > lastHit + hitCooldown)
        {
            // Resets cooldown
            lastHit = Time.time;
            currentHealth--;

            // Takes damage and checks for death
            GameObject.Find("Hearts").GetComponent<HeartHandler>().Damage();
            if (currentHealth <= 0)
            {
                Death();
            }
        }
    }

    private void Death()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        this.enabled = false;
    }
}
