using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarchingCubesSphere : MonoBehaviour
{
    public int resolution = 32;
    public float radius = 5.0f;
    public Material material;

    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = material;

        Mesh mesh = GenerateMarchingCubesSphere();
        meshFilter.mesh = mesh;
    }

    private Mesh GenerateMarchingCubesSphere()
    {
        Mesh mesh = new Mesh();
        int width = resolution;
        int height = resolution;
        int depth = resolution;
        float step = 2.0f * radius / resolution;
        Vector3[,,] vertices = new Vector3[width, height, depth];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                for (int z = 0; z < depth; z++)
                {
                    float posX = x * step - radius;
                    float posY = y * step - radius;
                    float posZ = z * step - radius;
                    float distance = Mathf.Sqrt(posX * posX + posY * posY + posZ * posZ);

                    if (distance <= radius)
                    {
                        vertices[x, y, z] = new Vector3(posX, posY, posZ);
                    }
                    else
                    {
                        vertices[x, y, z] = Vector3.zero;
                    }
                }
            }
        }

        mesh.vertices = Flatten3DArray(vertices);
        mesh.triangles = MarchingCubesAlgorithm.GenerateTriangles(vertices, 0.5f);
        mesh.RecalculateNormals();

        return mesh;
    }

    private Vector3[] Flatten3DArray(Vector3[,,] array3D)
    {
        int width = array3D.GetLength(0);
        int height = array3D.GetLength(1);
        int depth = array3D.GetLength(2);

        Vector3[] array1D = new Vector3[width * height * depth];
        int index = 0;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                for (int z = 0; z < depth; z++)
                {
                    array1D[index++] = array3D[x, y, z];
                }
            }
        }

        return array1D;
    }
}

