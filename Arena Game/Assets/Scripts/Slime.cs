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

        float targetX = playerPos.x - currentPos.x;
        float targetY = playerPos.y - currentPos.y;
        float nextX, nextY;
        
        // Finds quandrant that it should be moving in
        if (targetX > 0 && targetY > 0) // Q1
        {
            double angle = Math.Atan2(targetY, targetX);
            nextX = (float)Math.Cos(angle) * speed * Time.deltaTime;
            nextY = (float)Math.Sin(angle) * speed * Time.deltaTime;
        }
        else if (targetY > 0) // Q2
        {
            double angle = Math.Atan2(targetY, -1 * targetX);
            nextX = -1 * (float)Math.Cos(angle) * speed * Time.deltaTime;
            nextY = (float)Math.Sin(angle) * speed * Time.deltaTime;
        }
        else if (targetX < 0) // Q3
        {
            double angle = Math.Atan2(-1 * targetY, -1 * targetX);
            nextX = -1 * (float)Math.Cos(angle) * speed * Time.deltaTime;
            nextY = -1 * (float)Math.Sin(angle) * speed * Time.deltaTime;
        }
        else //Q4
        {
            double angle = Math.Atan2(-1 * targetY, targetX);
            nextX = (float)Math.Cos(angle) * speed * Time.deltaTime;
            nextY = -1 * (float)Math.Sin(angle) * speed * Time.deltaTime;
        }

        // Movement
        transform.Translate(new Vector2(nextX, nextY));

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
