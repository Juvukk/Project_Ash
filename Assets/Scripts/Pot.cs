using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Pot : MonoBehaviour
{
    [SerializeField] private string ingredientOne;
    [SerializeField] private string ingredientTwo;
    [SerializeField] private string ingredientThree;
    [SerializeField] private string ingredientFour;
    [SerializeField] private RecipeList List;
    [SerializeField] private string mixed;

    // Start is called before the first frame update
    private void Start()
    {
        List = GetComponent<RecipeList>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void SendMixed()
    {
        List.CheckRecipe(mix());
    }

    public string mix()
    {
        mixed = ingredientOne + ingredientTwo + ingredientThree + ingredientFour;

        ingredientOne = string.Empty;
        ingredientTwo = string.Empty;
        ingredientThree = string.Empty;
        ingredientFour = string.Empty;

        return mixed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object") && other.GetComponent<SpawnedTimer>().hasRecentlySpawned == false)
        {
            string code = other.GetComponent<Ingredient>().ingredientCode;

            if (ingredientOne == string.Empty)
            {
                ingredientOne = code;
            }
            else if (ingredientTwo == string.Empty)
            {
                ingredientTwo = code;
            }
            else if (ingredientThree == string.Empty)
            {
                ingredientThree = code;
            }
            else if (ingredientFour == string.Empty)
            {
                ingredientFour = code;
            }
            else
            {
                SendMixed();
            }

            other.GetComponent<Grab>().isGrabbed = false;
            other.gameObject.transform.position = transform.position;
            other.gameObject.SetActive(false);
        }
    }
}