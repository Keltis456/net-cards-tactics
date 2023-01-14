using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomiseRotation2D : MonoBehaviour
{
    private void Start()
    {
        transform.Rotate(Vector3.back,Random.Range(0f, 120f));;
    }
}
