using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : HealthManager
{
    // Start is called before the first frame update 
    public override void OnObjectDestroy()
    {
        GetComponent<LootBag>().InstantiateLoot(transform.position);
        base.OnObjectDestroy();
    }
}
