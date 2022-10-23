using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed = 1.5f;
    private float lastAttacked = 0;
    private float attackInterval = 1f;
    private float attackRange = 0.2f;
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;

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

        #region// Combat
        if (Input.GetMouseButtonDown(0) && Time.time > lastAttacked + attackInterval)
        {
            animator.SetTrigger("Attack");
            lastAttacked = Time.time;

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            foreach(Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Slime>().Damage();
                Debug.Log("Hit");
            }
        }
        #endregion
    }
}
