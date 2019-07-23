using System.Collections;
using UnityEngine;

namespace Data
{
    public enum BbtCollectibles { Invalid, Pearls, Sugar, Milk, Tea };
}

public class BbtCollectibleEventHandler : MonoBehaviour
{
    public bool collectEnabled = true;

    /// <summary>
    /// Given an ingredient and an ArrayList representing an inventory,
    /// query if collection is enabled and add it to the inventory if so
    /// </summary>
    /// <param name="ingredient">The ingredient for the event</param>
    /// <param name="inventory">The target inventory as an ArrayList atm</param>
    public bool handleCollectableEvent(Data.BbtCollectibles ingredient, ArrayList inventory)
    {
        if (collectEnabled)
        {
            inventory.Add(ingredient);
        }
        return true;
    }


}
