using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrestle : Card
{
    public override void ApplyEffect(Player player)
    {
        if (player == Player.Player)
        {
            GameObject.FindGameObjectWithTag("BattleManager").GetComponent<Battle>().EnemyHealth -= 15;
            GameObject.FindGameObjectWithTag("BattleManager").GetComponent<Battle>().PlayerHealth -= 5;
        }
        else if (player == Player.Enemy)
        {
            GameObject.FindGameObjectWithTag("BattleManager").GetComponent<Battle>().PlayerHealth -= 15;
            GameObject.FindGameObjectWithTag("BattleManager").GetComponent<Battle>().EnemyHealth -= 5;
        }
    }
}
