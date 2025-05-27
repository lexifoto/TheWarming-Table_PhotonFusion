using UnityEngine;

public class FoodTouchUI : MonoBehaviour
{
    public GameObject uiPanel;  // UI ���

    private void Start()
    {
        if (uiPanel != null)
        {
            uiPanel.SetActive(false); // Ĭ������ UI
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("food"))  // ֻ��� food ��ǩ
        {
            ShowUI();
        }
    }

    private void ShowUI()
    {
        if (uiPanel != null)
        {
            uiPanel.SetActive(true);  // ��ʾ UI
        }
    }
}
