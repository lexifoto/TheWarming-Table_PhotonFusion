using UnityEngine;

public class FoodTouchUI : MonoBehaviour
{
    public GameObject uiPanel;  // UI 面板

    private void Start()
    {
        if (uiPanel != null)
        {
            uiPanel.SetActive(false); // 默认隐藏 UI
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("food"))  // 只检测 food 标签
        {
            ShowUI();
        }
    }

    private void ShowUI()
    {
        if (uiPanel != null)
        {
            uiPanel.SetActive(true);  // 显示 UI
        }
    }
}
