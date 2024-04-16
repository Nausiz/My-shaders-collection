using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HologramGlitch_v2 : MonoBehaviour
{
    [SerializeField] private float glitchIntensity = 0.04f;

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
            vertices[i] = originalVertices[i];
        }

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] += Random.insideUnitSphere * glitchIntensity;
        }

        mesh.vertices = vertices;

        if (GetComponent<MeshCollider>())
        {
            GetComponent<MeshCollider>().sharedMesh = mesh;
        }
    }
}
