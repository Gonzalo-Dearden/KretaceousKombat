using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrestle : Card
{
    public override void ApplyEffect(Player player)
    {
        if(player == Player.Player)
        {
            GameObject.FindGameObjectWithTag("BattleManager").GetComponent<Battle>().EnemyHealth -= 3;
            GameObject.FindGameObjectWithTag("BattleManager").GetComponent<Battle>().PlayerHealth -= 1;
        }
        else if(player == Player.Enemy)
        {
            GameObject.FindGameObjectWithTag("BattleManager").GetComponent<Battle>().PlayerHealth -= 3;
            GameObject.FindGameObjectWithTag("BattleManager").GetComponent<Battle>().EnemyHealth -= 1;
        }
    }
}
