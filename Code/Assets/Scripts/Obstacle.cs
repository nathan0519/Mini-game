using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a child class of Object, which is Obstacle
/// </summary>
public class Obstacle : Object
{
    /// <summary>
    /// declare all variable and it's data type
    /// </summary>
    private float speed;
    private Rigidbody2D rb;
    public Player player;

    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.GetComponent<Player>();
        }
        speed = player.ObstacleSpeed();
        rb.velocity = new Vector2(-speed, 0);
    }

    // Update is called once per frame
    /// <summary>
    /// Update the speed of the obstacle 
    /// </summary>
    void Update()
    {
        speed = player.ObstacleSpeed();
        rb.velocity = new Vector2(-speed, 0);
    }

    /// <summary>
    /// Add score to the player if he destroy the obstacle
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public override int AddStat(string type)
    {
        int score = 0;
        if(type == "rock")
        {
            score = 100;
        }
        else if(type == "cone")
        {
            score = 200;
        }
        return score;
    }
}
