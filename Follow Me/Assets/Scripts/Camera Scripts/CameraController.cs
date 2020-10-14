using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; //make sure to drag player into target slot on under camera script
    //make sure to add pixelsnap material to material in tilemap renderer for pixel art/grid.  
    public float smoothing;
    public Vector2 minPosition;
    public Vector2 maxPosition;

    private float zoffset;
    void Start()
    {
        zoffset = transform.position.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, zoffset);

            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);


            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
