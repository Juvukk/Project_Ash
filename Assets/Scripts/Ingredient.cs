using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public string ingredientCode;
    public int index;

    private void OnDisable()
    {
        if (EventManager.clearcount != null)
        {
            EventManager.clearcount(index);
        }
    }
}