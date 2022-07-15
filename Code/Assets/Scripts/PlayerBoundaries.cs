using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a function to prevent the player to move out of the screen
/// </summary>
public class PlayerBoundaries : MonoBehaviour
{
    public Camera MainCamera;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    // Use this for initialization
    void Start()
    {
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y + 1.5f; //extents = size of height / 2
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = viewPos;
    }
}
