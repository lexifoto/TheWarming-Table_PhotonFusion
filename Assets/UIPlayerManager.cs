using System;
using UnityEngine;

public class UIPlayerManager : MonoBehaviour
{
      public GameObject[] playerFoodManagerUIElements;
      public GameObject[] playerTimeManagerUIElements;
      public GameObject[] playerHubManagerUIElements;
      public GameObject[] playerInventoryManagerUIElements;

      public void Awake()
      {
          
          DeactivateAllUIElements();
      }

      public void Start()
      {
          PlayerAsignScript.Instance.onPlayerTypeChanged.AddListener(UpdateUI);
      }

      public void UpdateUI()
      {
          if(PlayerManager.Instance.CurrentPlayerType == PlayerType.None) 
          {
              DeactivateAllUIElements();
          }
          
          if(PlayerManager.Instance.CurrentPlayerType == PlayerType.FoodManager)
          {
              SetActiveUIElements(playerFoodManagerUIElements);
          }
          else if(PlayerManager.Instance.CurrentPlayerType == PlayerType.TimeManager)
          {
              SetActiveUIElements(playerTimeManagerUIElements);
          }
          else if(PlayerManager.Instance.CurrentPlayerType == PlayerType.HubManager)
          {
              SetActiveUIElements(playerHubManagerUIElements);
          }
          else if(PlayerManager.Instance.CurrentPlayerType == PlayerType.InventoryManager)
          {
              SetActiveUIElements(playerInventoryManagerUIElements);
          }
      }

      void SetActiveUIElements(GameObject[] elements)
      {
            // Deactivate all UI elements first
            DeactivateAllUIElements();
    
            // Activate the specified UI elements
            foreach (GameObject element in elements)
            {
                if (element != null)
                {
                    element.SetActive(true);
                }
            }
          
      }
      
        void DeactivateAllUIElements()
        {
            foreach (GameObject element in playerFoodManagerUIElements)
            {
                if (element != null)
                {
                    element.SetActive(false);
                }
            }
            foreach (GameObject element in playerTimeManagerUIElements)
            {
                if (element != null)
                {
                    element.SetActive(false);
                }
            }
            foreach (GameObject element in playerHubManagerUIElements)
            {
                if (element != null)
                {
                    element.SetActive(false);
                }
            }
            foreach (GameObject element in playerInventoryManagerUIElements)
            {
                if (element != null)
                {
                    element.SetActive(false);
                }
            }
        }
      
}

public enum PlayerType
{
    FoodManager,
    TimeManager,
    HubManager,
    InventoryManager,
    None
}
