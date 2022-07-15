using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Player : MonoBehaviour
{
    /// <summary>
    /// Declare all variable and it's data type
    /// </summary>
    public float speed = 10f;
    public float obstacleSpeed;
    public Transform firePoint;
    public GameObject bulletPrefab;
    private float movement = 0f;
    private Rigidbody2D rb;
    public Text scoreText;
    private int score = 0;
    public Text lifeText;
    public int chances;
    public Text bulletText;
    public int bullets;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScore(score);
        UpdateChance(chances);
        UpdateBullet(bullets);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(rb.velocity.x, movement * speed);
        if (chances != 0)
        {
            AddScore(1);
        }
        Shooting();
        IncreaseSpeed(score);
    }
    // Create a bullet 
    public void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    // Run the shooting function if the player hits spacebar and the bullets is more than 0
    public void Shooting()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (bullets > 0)
            {
                Shoot();
                bullets -= 1;
                UpdateBullet(bullets);
                SoundManagerScript.PlaySound("laser");
            }
        }
    }
    /// <summary>
    /// To check if the car collide with other object
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Decrease the player's chances by 1 if they hit an obstacle
        if (other.tag == "Rock" || other.tag == "Cone")
        {
            if (chances > 1)
            {
                chances -= 1;
                UpdateChance(chances);
                SoundManagerScript.PlaySound("crash");
            }
            // If the player chances has been used up, the game over scene will load
            else
            {
                string path = Application.streamingAssetsPath + "/curScore" + ".txt";
                string finalScore = score.ToString();
                File.WriteAllText(path, finalScore);
                UpdateChance(chances);
                SceneManager.LoadScene("GameOver");
            }
        }
        // Increase the player chance by 1 if the player pick up the heart
        else if (other.tag == "Heart")
        {
            Power power = other.GetComponent<Power>();
            int amount = power.AddStat("life");
            power.SelfDestruct();
            AddChance(amount);
        }
        // Increase the player's bullet by 5 if he picks up the ammo
        else if (other.tag == "Ammo")
        {
            Power power = other.GetComponent<Power>();
            int amount = power.AddStat("ammo");
            power.SelfDestruct();
            AddBullet(amount);
        }
        // Decrease the obstacle's speed if the player picks up the snail
        else if (other.tag == "Snail")
        {
            Power power = other.GetComponent<Power>();
            int amount = power.AddStat("snail");
            power.SelfDestruct();
            DecreaseSpeed(amount);
        }
    }
    // Update the value of the score
    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }
    // Increase the player's score then update it
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore(score);
    }
    // Update the value of the player's chance
    public void UpdateChance(int newChanceValue)
    {
        lifeText.text = ": " + newChanceValue;
    }
    // Increase the player's chance and update it
    public void AddChance(int amount)
    {
        chances += amount;
        UpdateChance(chances);
    }
    // Update the amount of player's bullet
    public void UpdateBullet(int newBulletAmount)
    {
        bulletText.text = ": " + newBulletAmount;
    }
    // Increase the player's bullet and update it
    public void AddBullet(int amount)
    {
        bullets += amount;
        UpdateBullet(bullets);
    }
    // Increase the speed of the obstacle depending on the player's score
    public void IncreaseSpeed(int score)
    {
        if (score == 2000)
        {
            obstacleSpeed += 3.0f;
        }
        else if (score == 4000)
        {
            obstacleSpeed += 3.0f;
        }
        else if (score == 6000)
        {
            obstacleSpeed += 3.0f;
        }
        else if (score == 8000)
        {
            obstacleSpeed += 3.0f;
        }
        else if (score == 10000)
        {
            obstacleSpeed += 3.0f;
        }
    }
    // Decreae the obstacle's speed
    public void DecreaseSpeed(int amount)
    {
        obstacleSpeed -= amount;
    }
    // This is the propery of the obstacle's speed
    public float ObstacleSpeed()
    {
        return obstacleSpeed;
    }
    // This is the property of the player's score
    public int Score()
    {
        return score;
    }
}
