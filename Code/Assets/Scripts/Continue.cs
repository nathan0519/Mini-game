using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{
    // Update is called once per frame
    // Load the scene that register the player's score when the player hits the spacebar key
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene("Record");
        }
    }
}
