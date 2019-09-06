using Ingredient = Data.IngredientCollectibles;
using UnityEngine;

public class IngredientCollectibleBehaviour : MonoBehaviour
{
    public Ingredient ingredientCollectibles = Ingredient.Invalid;

    /// <summary>
    /// Strictly return the underlying IngredientCollectibles storied
    /// </summary>
    /// <returns>A BbtCollectibles</returns>
    public Ingredient getIngredient()
    {
        return ingredientCollectibles;
    }
}