using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public bool enableDestory = true;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (enableDestory) 
        {
            Debug.Log(string.Format("detected overlap with %s, destorying %s", collision.gameObject.name, this.gameObject.name));
            Destroy(this.gameObject);
        }
    }
}
