using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passive : Card
{
    public override void ApplyEffect(Player player)
    {
        if (player == Player.Player)
        {
            GameObject.FindGameObjectWithTag("BattleManager").GetComponent<Battle>().PlayerHealth += 5;
        }
        else if (player == Player.Enemy)
        {
            GameObject.FindGameObjectWithTag("BattleManager").GetComponent<Battle>().EnemyHealth += 5;
        }
    }
}
