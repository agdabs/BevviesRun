using Data;
using UnityEngine;

public class IngredientCollectibleBehaviour : MonoBehaviour
{
    public IngredientCollectibles ingredientCollectibles = IngredientCollectibles.Invalid;

    /// <summary>
    /// Strictly return the underlying IngredientCollectibles storied
    /// </summary>
    /// <returns>A BbtCollectibles</returns>
    public Data.IngredientCollectibles callCollect()
    {
        return ingredientCollectibles;
    }
}