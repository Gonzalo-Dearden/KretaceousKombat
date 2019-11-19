using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggressiveRetaliation : Card
{
    public override void ApplyEffect(Player player)
    {
        if (player == Player.Player)
        {
            GameObject.FindGameObjectWithTag("BattleManager").GetComponent<Battle>().EnemyHealth -= 12;
            GameObject.FindGameObjectWithTag("BattleManager").GetComponent<Battle>().PlayerHealth -= 2;
        }
        else if (player == Player.Enemy)
        {
            GameObject.FindGameObjectWithTag("BattleManager").GetComponent<Battle>().PlayerHealth -= 12;
            GameObject.FindGameObjectWithTag("BattleManager").GetComponent<Battle>().EnemyHealth -= 2;
        }
    }
}
