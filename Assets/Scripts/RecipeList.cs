using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public class RecipeList : MonoBehaviour
{
    public string[] recipes;

    public Spawner spawn;

    public void CheckRecipe(string recipe)
    {
        if (recipes.Contains(recipe))
        {
            for (int i = 0; i < recipes.Length; i++)
            {
                if (recipes[i].Contains(recipe))
                {
                    Debug.Log("should spawn");
                    SpawnObject(i);
                }
            }
        }
        else
        {
            Debug.Log("reject");
        }
    }

    private void SpawnObject(int index)
    {
        spawn.SpawnObjects(index);
        EventManager.recipeUnlock(index);
    }
}