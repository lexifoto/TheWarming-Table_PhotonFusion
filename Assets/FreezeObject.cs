using UnityEngine;

public class FreezeObject : MonoBehaviour
{
    public Material normalMaterial;  // ԭ���Ĳ���
    public Material frozenMaterial;  // �����Ĳ���
    private MeshRenderer meshRenderer;
    private bool isFrozen = false;  // �Ƿ񱻶���

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer == null)
        {
            Debug.LogError("Missing MeshRenderer on " + gameObject.name);
        }
    }

    public void ToggleFreeze()
    {
        isFrozen = !isFrozen;

        // �л�����
        if (meshRenderer != null)
        {
            meshRenderer.material = isFrozen ? frozenMaterial : normalMaterial;
        }

        // �л� Tag
        gameObject.tag = isFrozen ? "Untagged" : "Food";

        Debug.Log(gameObject.name + " is now " + (isFrozen ? "Frozen" : "Unfrozen"));
    }
}
