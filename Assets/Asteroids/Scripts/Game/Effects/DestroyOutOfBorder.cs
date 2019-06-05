using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBorder : MonoBehaviour
{
    public float padding = 10f;
    public Color debugColor = Color.red;

    void Update()
    {
        Bounds camBounds = Camera.main.GetBounds(padding);
        if (!camBounds.Contains(transform.position))
        {
            Destroy(gameObject);
        }
    }

    void OnDrawGizmos()
    {
        Bounds camBounds = Camera.main.GetBounds(padding);
        Gizmos.color = debugColor;
        Gizmos.DrawWireCube(camBounds.center, camBounds.size);
    }
}
