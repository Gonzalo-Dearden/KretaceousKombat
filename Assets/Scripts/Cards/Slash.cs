using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : Card
{
    public override void ApplyEffect()
    {
        GameObject.FindGameObjectWithTag("BattleManager").GetComponent<Battle>().EnemyHealth -= 10;
    }

    public override void Start()
    {
        damageType = DamageType.All;
        Description = "Always applies 10 damage to the enemy";
    }
}
