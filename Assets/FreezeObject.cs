using UnityEngine;

public class FreezeObject : MonoBehaviour
{
    public Material normalMaterial;  // 原来的材质
    public Material frozenMaterial;  // 冰冻的材质
    private MeshRenderer meshRenderer;
    private bool isFrozen = false;  // 是否被冻结

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

        // 切换材质
        if (meshRenderer != null)
        {
            meshRenderer.material = isFrozen ? frozenMaterial : normalMaterial;
        }

        // 切换 Tag
        gameObject.tag = isFrozen ? "Untagged" : "Food";

        Debug.Log(gameObject.name + " is now " + (isFrozen ? "Frozen" : "Unfrozen"));
    }
}
