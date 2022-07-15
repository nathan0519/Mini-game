using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This is the parent class of Obstacle and Power
/// </summary>
public abstract class Object : MonoBehaviour
{
    // Destroy the obstacle
    public void SelfDestruct()
    {
        Destroy(gameObject);
    }
    public abstract int AddStat(string type);
}
