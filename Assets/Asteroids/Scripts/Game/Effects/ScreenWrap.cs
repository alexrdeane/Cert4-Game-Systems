using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    //Padding around the screen
    public float padding = 3f;
    //Colour of gizmos
    public Color debugColor = Color.blue;

    //Reference to sprite renderer
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        //Gets reference to the sprite renderer
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnDrawGizmos()
    {
        //Gets bounds around the cameras + padding
        Bounds camBounds = Camera.main.GetBounds(padding);
        //Then Draw the Camera Bounds
        Gizmos.color = debugColor;
        Gizmos.DrawWireCube(camBounds.center, camBounds.size);
    }

    void UpdatePosition()
    {

        //Get camera dimensions using padding
        Bounds camBounds = Camera.main.GetBounds(padding);
        //Store position and size in a shorter variable name
        Vector3 pos = transform.position;
        //Store min and max vectors
        Vector3 min = camBounds.min;
        Vector3 max = camBounds.max;
        //Check left
        if(pos.x < min.x)
        {
            pos.x = max.x;
        }
        //Check right
        if (pos.x > max.x)
        {
            pos.x = min.x;
        }
        //Check up
        if (pos.y < min.y)
        {
            pos.y = max.y;
        }
        //Check down
        if (pos.y > max.y)
        {
            pos.y = min.y;
        }
        //Apply position
        transform.position = pos;
    }

    private void LateUpdate()
    {
        UpdatePosition();
    }
}
