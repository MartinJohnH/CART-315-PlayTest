using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float speed;

    void FixedUpdate()
    {
        transform.Rotate(0, speed, 0);
    }
}
