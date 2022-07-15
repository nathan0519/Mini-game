using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this is a child class of Object, which is Power
/// </summary>
public class Power : Object
{
    /// <summary>
    /// Declare all variable and its data type
    /// </summary>
    public float speed = 10.0f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Add different stats to the player depending on which power they pick up
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public override int AddStat(string type)
    {
        int amount = 0;
        // Increase the player bullet by 5 if he pick up ammo
        if(type == "ammo")
        {
            amount = 5;
        }
        // Increase the player's chance by 1 if he pick up heart
        else if (type == "life")
        {
            amount = 1;
        }
        // Decrease the obstacle's speed by 2 if he pick up the snail 
        else if(type == "snail")
        {
            amount = 2;
        }
        return amount;
    }
}
