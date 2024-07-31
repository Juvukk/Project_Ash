using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockRecipe : MonoBehaviour
{
    [SerializeField] private List<int> unlocked;
    [SerializeField] private List<GameObject> buttons;

    private void OnEnable()
    {
        EventManager.recipeUnlock += CheckRecipeUnlock;
    }

    private void OnDisable()
    {
        EventManager.recipeUnlock -= CheckRecipeUnlock;
    }

    private void CheckRecipeUnlock(int index)
    {
        if (!unlocked.Contains(index))
        {
            RecipeUnlock(index);
        }
    }

    private void RecipeUnlock(int index)
    {
        unlocked.Add(index);
        buttons[index].SetActive(true);
    }
}