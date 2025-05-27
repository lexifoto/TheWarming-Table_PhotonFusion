using UnityEngine;
using UnityEngine.UI;

public class FoodController : MonoBehaviour
{
    public Button freezeButton;
    public Button unfreezeButton;
    private GameObject currentFood;

    public Material frozenMaterial;
    public Material normalMaterial;

    void Start()
    {
        freezeButton.onClick.AddListener(FreezeFood);
        unfreezeButton.onClick.AddListener(UnfreezeFood);
    }

    public void SetCurrentFood(GameObject food)
    {
        currentFood = food;
    }

    void FreezeFood()
    {
        if (currentFood != null)
        {
            currentFood.tag = "Untagged";
            currentFood.GetComponent<MeshRenderer>().material = frozenMaterial;
        }
    }

    void UnfreezeFood()
    {
        if (currentFood != null)
        {
            currentFood.tag = "Food";
            currentFood.GetComponent<MeshRenderer>().material = normalMaterial;
        }
    }
}
