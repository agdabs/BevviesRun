using UnityEngine;

public class DestroyableBehaviour : MonoBehaviour
{
    public bool enableDestroy = true;

    /// <summary>
    /// Given some internal logic, destroy the gameObject for this behaviour
    /// </summary>
    /// <returns>bool representing whether the object was succesfully destroyed</returns>
    public bool callDestroy()
    {
        if (enableDestroy)
        {
            Debug.Log(string.Format("destroying {0}", this.gameObject.name));
            Destroy(this.gameObject);
        }
        return enableDestroy;
    }
}
