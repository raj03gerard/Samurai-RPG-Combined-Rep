using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleOrbs : MonoBehaviour
{
    [SerializeField]
    int XP_to_add;
    [SerializeField]
    CollectibleObjectsManager.CollectibleType collectibleType;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Increase player XP");
            CollectibleObjectsManager.IncreasePlayerXP(XP_to_add, collectibleType);
            Destroy(this.gameObject);
        }
    }
}
