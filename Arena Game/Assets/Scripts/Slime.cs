using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Slime : MonoBehaviour
{
    private int maxHealth = 3;
    private float speed = .5f;
    private int currentHealth;
    public Transform slime;
    public LayerMask playerLayer;
    private float lastHit = 0f;
    private float knockback = .8f;
    private float stun = .25f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // Finds Player
        Vector2 playerPos = GameObject.Find("Player").transform.position;
        Vector2 currentPos = transform.position;
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
        if (Time.time > lastHit + stun) { transform.Translate(new Vector2(nextX, nextY)); }

        // Checking collision
        currentPos.x += .06f;
        currentPos.y += .05f;
        Vector2 oppositeCorner = new Vector2(currentPos.x - .16f, currentPos.y - .12f); // Hardcoded values for height and width of hitbox
        Collider2D playerHit = Physics2D.OverlapArea(currentPos, oppositeCorner, playerLayer, float.NegativeInfinity, float.PositiveInfinity);
        if (playerHit != null)
        {
            playerHit.GetComponent<Movement>().Damage();
        }
    }

    public void Damage(float hitCoolDown)
    {
        // Checks cooldown
        if (Time.time > lastHit + hitCoolDown)
        {
            // Sets cooldown time
            lastHit = Time.time;
            currentHealth--;

            // Knockback
            Vector2 playerPos = GameObject.Find("Player").transform.position;
            Vector2 currentPos = transform.position;
            Vector2 diff = new Vector2(currentPos.x - playerPos.x, currentPos.y - playerPos.y);
            float scaleX = Math.Abs(diff.x / diff.magnitude) * knockback;
            float scaleY = Math.Abs(diff.y / diff.magnitude) * knockback;
            transform.Translate(new Vector2(diff.x * scaleX, diff.y * scaleY));

            // Die?
            if (currentHealth <= 0)
            {
                GetComponent<Collider2D>().enabled = false;
                this.enabled = false;
                Destroy(this.gameObject);
            }
        }
    }
}
