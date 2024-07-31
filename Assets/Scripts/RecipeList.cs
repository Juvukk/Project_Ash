using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public class RecipeList : MonoBehaviour
{
    public string[] recipes;
    public string[] Altrecipes;
    public Spawner spawn;
    [SerializeField] private GameObject ps;
    [SerializeField] private GameObject smoke;

    public void CheckRecipe(string recipe)
    {
        if (recipes.Contains(recipe) || Altrecipes.Contains(recipe))
        {
            for (int i = 0; i < recipes.Length; i++)
            {
                if (recipes[i] == recipe || Altrecipes[i] == recipe)
                {
                    Debug.Log(i);
                    SpawnObject(i);
                }
            }
        }
        else
        {
            ps.SetActive(true);
        }

        smoke.SetActive(true);
    }

    private void SpawnObject(int index)
    {
        spawn.SpawnObjects(index);
        EventManager.recipeUnlock(index);
    }
}