using Data;
using UnityEngine;

public class BbtCollectibleBehaviour : MonoBehaviour
{
    public BbtCollectibles bbtCollectible = BbtCollectibles.Invalid;

    /// <summary>
    /// Strictly return the underlying BbtCollectibles storied
    /// </summary>
    /// <returns>A BbtCollectibles</returns>
    public Data.BbtCollectibles callCollect()
    {
        return bbtCollectible;
    }
}