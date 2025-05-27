using NUnit.Framework;
using System.Xml.Serialization;
using UnityEngine;
using System.Collections.Generic;

// The below code rewritten based on the tutorial by Kyle Andrews
// source code https://github.com/codewithkyle/Unity-Tutorials

// This script generates a mesh for a grid-based plane, which could be used as a water surface.
public class WaterPlane : MonoBehaviour
{
    // Size of the plane (defines the overall dimensions)
    public float size = 1;

    // The resolution of the grid (how many segments in the grid)
    public int gridSize = 16;

    // MeshFilter component to hold the generated mesh
    private MeshFilter filter;

    // Start is called before the first frame update
    private void Start()
    {
        // Get the MeshFilter component attached to the current GameObject
        filter = GetComponent<MeshFilter>();

        // Generate the mesh and assign it to the MeshFilter's mesh property
        filter.mesh = GenerateMesh();
    }

    // GenerateMesh creates a grid mesh for the water plane
    private Mesh GenerateMesh()
    {
        // Create a new mesh
        Mesh m = new Mesh();

        // Lists to store the vertices, normals, and UVs of the mesh
        var verticies = new List<Vector3>();
        var normals = new List<Vector3>();
        var uvs = new List<Vector2>();

        // Generate vertices, normals, and UVs for each point on the grid
        for (int x = 0; x < gridSize + 1; x++)
        {
            for (int y = 0; y < gridSize + 1; y++)
            {
                // Calculate the position of each vertex, spread across the plane
                verticies.Add(new Vector3(
                    -size * 0.5f + size * (x / ((float)gridSize)),  // X position
                    0,  // Y position (flat at the start, will be modified later)
                    -size * 0.5f + size * (y / ((float)gridSize))   // Z position
                ));

                // Normals for each vertex, pointing upwards (default for flat plane)
                normals.Add(Vector3.up);

                // UV coordinates for texture mapping, normalized between 0 and 1
                uvs.Add(new Vector2(x / (float)gridSize, y / (float)gridSize));
            }
        }

        // List to store the triangle indices (for mesh connectivity)
        var triangles = new List<int>();

        // Vertices per row (including the first row, last row, etc.)
        var vertCount = gridSize + 1;

        // Generate the triangle indices to form the grid mesh
        for (int i = 0; i < vertCount * vertCount - vertCount; i++)
        {
            // Skip the last vertex in each row to avoid out-of-bounds errors
            if ((i + 1) % vertCount == 0)
            {
                continue;
            }

            // Add two triangles for each pair of adjacent vertices in the grid
            triangles.AddRange(new List<int>()
            {
                i + 1 + vertCount, i + vertCount, i,        // First triangle (top-right)
                i, i + 1, i + vertCount + 1                // Second triangle (bottom-left)
            });
        }

        // Apply the vertices, normals, UVs, and triangles to the mesh
        m.SetVertices(verticies);
        m.SetNormals(normals);
        m.SetUVs(0, uvs);
        m.SetTriangles(triangles, 0);

        // Return the generated mesh
        return m;
    }
}
