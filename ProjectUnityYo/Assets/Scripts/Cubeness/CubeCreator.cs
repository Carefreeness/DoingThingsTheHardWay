using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CubeCreator : MonoBehaviour {

    public Vector3[] newVertices;
    public int[] newTriangles;
    Mesh mesh;
    
    void Start()
    {

        
        //gameObject.AddComponent<MeshFilter>();
        //gameObject.AddComponent<MeshRenderer>();
        mesh = GetComponent<MeshFilter>().sharedMesh;

        mesh.Clear();

        // make changes to the Mesh by creating arrays which contain the new values
        //newVertices = mesh.vertices; //= new Vector3[] { new Vector3(0, 0, 0), new Vector3(0, 1, 0), new Vector3(1, 1, 0) };
        //newTriangles = mesh.triangles; //= new int[] { 0, 1, 2 };


        Vector3Int triangle;

    }

    void Update()
    {

        mesh.vertices = newVertices;

        List<Vector2> autoUVCoords = new List<Vector2>();
        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            autoUVCoords.Add(new Vector2(mesh.vertices[i].x, mesh.vertices[i].y));
        }

        mesh.uv = autoUVCoords.ToArray();
        autoUVCoords.Clear();

        //mesh.uv = newUV;
        if (mesh.vertices.Length < newTriangles.Length)
            mesh.triangles = newTriangles;


        /*Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        Vector3[] normals = mesh.normals;
        int i = 0;
        while (i < vertices.Length)
        {
            vertices[i] += normals[i] * Mathf.Sin(Time.time);
            i++;
        }
        mesh.vertices = vertices;*/
    }
}
