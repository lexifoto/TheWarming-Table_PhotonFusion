using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 100, 0); // ��ת�ٶ� (X, Y, Z)

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime); // ������ת
    }
}
