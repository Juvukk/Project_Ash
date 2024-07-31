using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Events : MonoBehaviour
{
    [SerializeField] private string correctIngredientCode;
    [SerializeField] private UnityEvent Event;

    private void Start()
    {
        if (Event == null)
            Event = new UnityEvent();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.GetComponent<Ingredient>().ingredientCode == correctIngredientCode)
            {
                Event.Invoke();
            }
        }
    }
}