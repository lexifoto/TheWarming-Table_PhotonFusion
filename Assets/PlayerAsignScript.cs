using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAsignScript : MonoBehaviour
{

    public static PlayerAsignScript Instance { get; private set; }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow)) SetAsFoodManager();
        if(Input.GetKeyDown(KeyCode.UpArrow)) SetAsTimeManager();
        if(Input.GetKeyDown(KeyCode.RightArrow)) SetAsHubMamager();
        if(Input.GetKeyDown(KeyCode.DownArrow)) SetAsInventoryManager();
    }

    public UnityEvent onPlayerTypeChanged;
    
    public void SetAsHubMamager()
    {
        PlayerManager.Instance.CurrentPlayerType = PlayerType.HubManager;
        onPlayerTypeChanged?.Invoke();
    }
    public void SetAsFoodManager()
    {
        PlayerManager.Instance.CurrentPlayerType = PlayerType.FoodManager;
        onPlayerTypeChanged?.Invoke();
    }
    public void SetAsTimeManager()
    {
        PlayerManager.Instance.CurrentPlayerType = PlayerType.TimeManager;
        onPlayerTypeChanged?.Invoke();
    }
    public void SetAsInventoryManager()
    {
        PlayerManager.Instance.CurrentPlayerType = PlayerType.InventoryManager;
        onPlayerTypeChanged?.Invoke();
    }
}
