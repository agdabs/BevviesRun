using UnityEngine;
using System.Collections;

/// <summary>
/// It is called an Actor as it will call behaviours and act upon the result through event handlers.
/// This essential is the processing line for events
/// </summary>
public class PlayerActor : MonoBehaviour
{
    public IngredientCollectibleEventHandler handler = new IngredientCollectibleEventHandler();
    public ArrayList inventory = new ArrayList();

    /// <summary>
    /// the default handler for trigger events
    /// </summary>
    /// <param name="other">Collider that has is trigger on</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("triggerEnter");

        IngredientCollectibleBehaviour behaviour = other.gameObject.GetComponent<IngredientCollectibleBehaviour>() as IngredientCollectibleBehaviour;
        if (behaviour != null)
        {
            Data.IngredientCollectibles test = behaviour.callCollect();
            bool result = handler.handleCollectableEvent(test, inventory);
            Debug.Log(string.Format("ingredient {0} was triggered with collection as {1}", test, result));
            
            if (result) {
                DestroyableBehaviour destroyableBehaviour = other.gameObject.GetComponent<DestroyableBehaviour>() as DestroyableBehaviour;
                destroyableBehaviour.callDestroy();
            }
        }
        else 
        {
            Debug.Log("trigger did not contain the ingredient collectable behaviour");
        }
    }
}
