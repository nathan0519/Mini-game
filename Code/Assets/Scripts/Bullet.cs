using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    /// <summary>
    /// Declare all variable and it's data type
    /// </summary>
    public float speed = 20f;
    public Rigidbody2D bulletRB;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        // Control the speed of the bullet
        bulletRB.velocity = transform.right * speed;
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.GetComponent<Player>();
        }
    }
    /// <summary>
    /// To check whether the bullet collide any object or not
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Destroy the bullet if it collide with the boundary
        if (collision.tag == "Boundary")
        {
            Destroy(gameObject);
        }
        else if (collision.tag == "Rock" || collision.tag == "Cone")
        {
            Obstacle obstacle = collision.GetComponent<Obstacle>();
            // Add the player score if the bullets hits a rock and destroy the bullet and rock on collision
            if (obstacle.tag == "Rock")
            {
                obstacle.SelfDestruct();
                Destroy(gameObject);
                int amount = obstacle.AddStat("rock");
                player.AddScore(amount);
            }
            // Add the player score if the bullets hits a cone and destroy the bullet and cone on collision
            else if (obstacle.tag == "Cone")
            {
                obstacle.SelfDestruct();
                Destroy(gameObject);
                int amount = obstacle.AddStat("cone");
                player.AddScore(amount);
            }
        }
    }
}
