using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float maxWidth = 10f;
    [SerializeField] private float maxZoom = 1.25f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 newPosition = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, 0f, 0f);
        newPosition.x = Mathf.Clamp(newPosition.x, 0, maxWidth);

        float zoomInput = Input.GetAxis("Vertical");
        float newZoom = Mathf.Clamp(transform.position.z + zoomInput * movementSpeed * Time.deltaTime, 0f, maxZoom);

        transform.position = new Vector3(newPosition.x, newPosition.y, newZoom);
    }
}
