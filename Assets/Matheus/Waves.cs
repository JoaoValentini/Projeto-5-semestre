using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    Mesh myMesh;
    Vector3[] vertices;
    Vector3[] normals;
    [SerializeField] float freq, vel, amp, minimizador;

    // Start is called before the first frame update
    void Start()
    {
        myMesh = GetComponent<MeshFilter>().mesh;
        vertices = myMesh.vertices;
        normals = myMesh.normals;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time * vel;
        Quaternion rotation = Quaternion.AngleAxis(100, Vector3.up);
        for (int i = 0; i < myMesh.vertices.Length; i++)
        {
            vertices[i].y += Mathf.Sin((Time.time * vel) + vertices[i].x * freq) * amp * minimizador;
        }
        myMesh.vertices = vertices;
    }
}
