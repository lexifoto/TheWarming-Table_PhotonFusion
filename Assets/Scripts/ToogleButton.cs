using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PokeToggleUI : MonoBehaviour
{
    public GameObject uiToToggle;
    private bool isUIVisible = false;

    public void ToggleUI()
    {
        isUIVisible = !isUIVisible;
        uiToToggle.SetActive(isUIVisible);
    }
}
