using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SmoothCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float damp = 1;
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -10);

    private Vector3 currentVel = Vector3.zero;
    void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref currentVel, damp);
    }
}
