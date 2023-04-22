using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : HealthManager
{
    // Start is called before the first frame update 
    public override void OnObjectDestroy()
    {
        //this make sure the enemy wait death animation before deactivate collisions. It prevents death bodies passing through walls.
        GetComponent<HealthManager>().Targetable = false;

        //this call the loot drop on death over the death position
        GetComponent<LootBag>().InstantiateLoot(transform.position);

        // this destroy the enemy. Maybe in a far future will be pool managed?
        base.OnObjectDestroy();
    }
}
