using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : Card
{
    public override void ApplyEffect()
    {
        GameObject.FindGameObjectWithTag("BattleManager").GetComponent<Battle>().EnemyHealth -= 10;
    }
}
