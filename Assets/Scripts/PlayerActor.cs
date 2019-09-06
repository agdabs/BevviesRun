using UnityEngine;
using System.Collections;
using Ingredient = Data.IngredientCollectibles;

/// <summary>
/// It is called an Actor as it will call behaviours and act upon the result through event handlers.
/// This essential is the processing line for events
/// </summary>
public class PlayerActor : MonoBehaviour
{
    public ArrayList inventory = new ArrayList();

    /// <summary>
    /// the default handler for trigger events
    /// </summary>
    /// <param name="other">Collider that has is trigger on</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("triggerEnter on a PlayerActor");

        if (other.gameObject.CompareTag("Ingredient"))
        {
            HandleIngredientCollection(other.gameObject);
        }
    }

    private void HandleIngredientCollection(GameObject gameObject)
    {
        IngredientCollectibleBehaviour ingredientBehaviour = gameObject.GetComponent<IngredientCollectibleBehaviour>();
        if (ingredientBehaviour != null)
        {
            Ingredient ingredient = ingredientBehaviour.getIngredient();
            inventory.Add(ingredient); 
            Debug.Log(string.Format("Ingredient {0} was added", gameObject.name));
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log(string.Format("gameObject {0} did not contain {1}", gameObject.name, ingredientBehaviour.name));
        }
    }
}
