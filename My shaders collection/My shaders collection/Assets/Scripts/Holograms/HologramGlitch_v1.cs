using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HologramGlitch_v1 : MonoBehaviour
{
    [SerializeField] private float glitchIntensity = 0.02f;
    [SerializeField] private float glitchSpeed = 0.3f;

    private Vector3[] originalVertices;
    private Mesh mesh;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        originalVertices = mesh.vertices;
    }

    void Update()
    {
        Vector3[] vertices = mesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = originalVertices[i] + Random.insideUnitSphere * glitchIntensity;
        }

        if (GetComponent<MeshCollider>())
        {
            GetComponent<MeshCollider>().sharedMesh = mesh;
        }

        float offset = Mathf.PingPong(Time.time * glitchSpeed, 1f);
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = Vector3.Lerp(originalVertices[i], vertices[i], offset);
        }

        mesh.vertices = vertices;
    }
}
