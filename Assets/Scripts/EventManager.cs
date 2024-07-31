using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void OnraycastEvent(GameObject hitObj);

    public static OnraycastEvent onraycast;

    public delegate void onRecipeUnlock(int index);

    public static onRecipeUnlock recipeUnlock;

    public delegate void clearItemCount(int index);

    public static clearItemCount clearcount;
}