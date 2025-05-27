using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 100, 0); // 旋转速度 (X, Y, Z)

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime); // 持续旋转
    }
}
