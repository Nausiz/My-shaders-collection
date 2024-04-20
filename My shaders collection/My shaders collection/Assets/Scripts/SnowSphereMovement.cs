using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowSphereMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float radius = 0.5f;

    private float angle = 0f;
    private float objectY = 0f; 

    private void Start()
    {
        objectY = gameObject.transform.position.y;
    }

    void Update()
    {
        angle += speed * Time.deltaTime;

        float newX = Mathf.Cos(angle) * radius;
        float newZ = Mathf.Sin(angle) * radius;

        transform.position = transform.parent.position + new Vector3(newX, objectY, newZ);
    }

}