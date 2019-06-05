using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public static Vector3 GetRandomPosOnBounds(this Bounds bounds)
    {
        //Result to return at the end of this function
        Vector3 result = Vector3.zero;
        //Smaller variable name for bounds min & max
        Vector3 min = bounds.min;
        Vector3 max = bounds.max;
        //50% chance to spawn top or bottom/ or left or right
        bool topOrBottom = Random.Range(0, 2) > 0;
        //50% chance its top or bottom
        bool top = Random.Range(0, 2) > 0;
        //50% chance its right or left
        bool right = Random.Range(0, 2) > 0;
        //top or bottom
        if (topOrBottom)
        {
            //Get random rand on x
            result.x = Random.Range(min.x, max.x);
            //Top or bottom
            result.y = top ? max.y : min.y;

        }
        //left or right
        else
        {
            result.x = right ? max.x : min.x;
            result.y = Random.Range(min.y, max.y);
        }
        return result;
    }
    //Calculate and return camera bounds with given padding (default to 1f)
    public static Bounds GetBounds(this Camera cam, float padding = 1f)
    {
        //Define camera dimensions float
        float camHeight, camWidth;
        //Get position of camera
        Vector3 camPos = cam.transform.position;
        //Callculate height and width of camera
        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;
        //Apply padding
        camHeight += padding;
        camWidth += padding;
        //Create a camera bounds from above information
        return new Bounds(camPos, new Vector3(camWidth, camHeight, 100));
    }
}
