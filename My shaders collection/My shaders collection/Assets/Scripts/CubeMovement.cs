using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1.5f;
    [SerializeField] private float minY = -1.75f;
    [SerializeField] private float maxY = 0.25f;

    private int direction = 1;

    void Update()
    {
        float newY = transform.localPosition.y + direction * movementSpeed * Time.deltaTime;

        if (newY <= minY || newY >= maxY)
        {
            direction *= -1;
            newY = Mathf.Clamp(newY, minY, maxY);
        }

        transform.localPosition = new Vector3(transform.localPosition.x, newY, transform.localPosition.z);
    }
}
