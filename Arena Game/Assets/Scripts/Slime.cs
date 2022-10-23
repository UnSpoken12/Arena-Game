using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public int maxHealth = 3;
    private float speed = .5f;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // Input
        Vector2 playerPos = GameObject.Find("Player").transform.position;
        Vector2 currentPos = this.transform.position;
        Vector2 displacement = new Vector2((playerPos.x - currentPos.x) * Time.deltaTime, (playerPos.y - currentPos.y) * Time.deltaTime);
        if (Math.Abs(displacement.magnitude) < speed * Time.deltaTime)
        {
            double angle = Vector2.Angle(playerPos, currentPos);
            float nextX = (float)Math.Cos(angle) * speed * Time.deltaTime;
            float nextY = (float)Math.Sin(angle) * speed * Time.deltaTime;
            displacement = new Vector2(nextX, nextY);
        }
        //Vector2 targetPos = Vector2.MoveTowards(this.transform.position, new Vector2(playerPos.x, playerPos.y), speed);
        //double angle = Vector2.Angle(new Vector2(playerPos.x, playerPos.y), this.transform.position);

        // Movement
        //float totalHoriMovement = targetPos.x * Time.deltaTime;
        //float totalVertMovement = targetPos.y * Time.deltaTime;
        //transform.Translate(new Vector2(totalHoriMovement, totalVertMovement));
        transform.Translate(displacement);

        // Transition to walking animation
        //animator.SetFloat("Speed", Mathf.Abs(horizontalInput + verticalInput));

        // Change the direction it's facing
        /*if (horizontalInput > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }*/
    }

    public void Damage()
    {
        currentHealth--;
        //Knockback, animation
        if (currentHealth <= 0)
        {
            // Slime die
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
            Destroy(this.gameObject);
        }
    }
}
