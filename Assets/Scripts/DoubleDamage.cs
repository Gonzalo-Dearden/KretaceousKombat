using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDamage : Card
{
    public override void Start()
    {
        damageType = DamageType.All;
        Description = "Doubles the player damage for the rest of the match";
    }

    public override void ApplyEffect()
    {
        GameObject.FindGameObjectWithTag("BattleManager").GetComponent<Battle>().PlayerDamage = 10;
    }

    
}
