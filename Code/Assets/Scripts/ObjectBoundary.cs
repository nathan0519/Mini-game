using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBoundary : MonoBehaviour
{
    // Start is called before the first frame update
    /// <summary>
    /// This is a function to destroy all the object that is outside of the screen
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Rock" || other.tag == "Cone")
        {
            Obstacle obstacle = other.GetComponent<Obstacle>();
            obstacle.SelfDestruct();
        }
        else if (other.tag == "Heart" || other.tag == "Ammo" || other.tag == "Snail")
        {
            Power power = other.GetComponent<Power>();
            power.SelfDestruct();
        }
    }
}
