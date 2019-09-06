using System.Collections;

public class Data
{
    public enum IngredientCollectibles { Invalid, Pearls, Sugar, Milk, Tea };
}
/// <summary>
/// This class/Script component is designed to separately handle the event of when an ingredient is "collected".
/// With this, we can separate the act of "picking up" an ingredient from an ingredient being added to the underlying inventory.
/// </summary>
public class IngredientCollectibleEventHandler
{
    public bool collectEnabled = true;

    /// <summary>
    /// Given an ingredient and an ArrayList representing an inventory,
    /// query if collection is enabled and add it to the inventory if so
    /// </summary>
    /// <param name="ingredient">The ingredient for the event</param>
    /// <param name="inventory">The target inventory as an ArrayList atm</param>
    public bool handleCollectableEvent(Data.IngredientCollectibles ingredient, ArrayList inventory)
    {
        if (collectEnabled)
        {
            inventory.Add(ingredient);
        }
        return collectEnabled;
    }


}
