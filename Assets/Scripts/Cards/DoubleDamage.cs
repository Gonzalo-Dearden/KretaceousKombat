using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDamage : Card
{

    public override void ApplyEffect()
    {
        GameObject.FindGameObjectWithTag("BattleManager").GetComponent<Battle>().PlayerDamage = 10;
    }

    
}
