using UnityEngine;

// The below code rewritten based on the tutorial by Kyle Andrews
// source code https://github.com/codewithkyle/Unity-Tutorials

// This script controls the movement of water-like waves on a mesh using Perlin noise.
public class WaterMovement : MonoBehaviour
{
    // Power of the wave movement (height multiplier for the vertices)
    public float power = 3;

    // Scale of the wave's texture; controls the "tightness" or "spread" of the waves
    public float scale = 1;

    // Time scale to control the speed of wave movement
    public float timeScale = 1;

    // Offsets to create movement over time (to shift the wave pattern)
    private float xOffset;
    private float yOffset;

    // MeshFilter component to access and modify the mesh
    private MeshFilter mf;

    // Start is called before the first frame update
    private void Start()
    {
        // Getting the MeshFilter component attached to the same GameObject
        mf = GetComponent<MeshFilter>();
        // Calling the MakeNoise function to apply initial noise effect
        MakeNoise();
    }

    // Update is called once per frame
    private void Update()
    {
        // Continuously apply noise to update the wave effect
        MakeNoise();

        // Increment the x and y offsets to animate the wave pattern
        xOffset += Time.deltaTime * timeScale;
        yOffset += Time.deltaTime * timeScale;
    }

    // MakeNoise updates the mesh vertices to apply wave effects based on Perlin noise
    void MakeNoise()
    {
        // Get all the vertices of the mesh
        Vector3[] verticies = mf.mesh.vertices;

        // Iterate through each vertex and update its y-position based on Perlin noise
        for (int i = 0; i < verticies.Length; i++)
        {
            // Calculate the new y-position using Perlin noise and apply the power multiplier
            verticies[i].y = CalculateHeight(verticies[i].x, verticies[i].z) * power;
        }

        // Apply the modified vertex positions back to the mesh
        mf.mesh.vertices = verticies;
    }

    // CalculateHeight computes the height (y) for a given x, y position using Perlin noise
    float CalculateHeight(float x, float y)
    {
        // Adjust x and y coordinates with scale and offset to get varying Perlin noise values
        float xcord = x * scale + xOffset;
        float yCord = y * scale + yOffset;

        // Use Perlin noise to calculate a smooth "height" value
        return Mathf.PerlinNoise(xcord, yCord);
    }
}
