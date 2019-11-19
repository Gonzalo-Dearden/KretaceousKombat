using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailSlap : Card
{
    public override void ApplyEffect(Player player)
    {
        if (player == Player.Player)
        {
            GameObject.FindGameObjectWithTag("BattleManager").GetComponent<Battle>().EnemyHealth -= 10;
        }
        else if (player == Player.Enemy)
        {
            GameObject.FindGameObjectWithTag("BattleManager").GetComponent<Battle>().PlayerHealth -= 10;
        }
    }
}
