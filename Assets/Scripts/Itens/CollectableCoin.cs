using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCoin : CollectableBase
{
    public Collider collider;

    protected override void OnCollect()
    {
        base.OnCollect();
        CollectableManager.Instance.AddCoins();
        collider.enabled = false;
        
        

    }


}
