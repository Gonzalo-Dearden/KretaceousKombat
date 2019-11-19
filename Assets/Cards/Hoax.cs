using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoax : Card
{
    public override void ApplyEffect(Player player)
    {
        if (player == Player.Player)
        {
            if (GameObject.FindGameObjectWithTag("BattleManager").GetComponent<Battle>().PlayerHealth < GameObject.FindGameObjectWithTag("BattleManager").GetComponent<Battle>().MaxPlayerHealth * 0.15f)
            {
                GameObject.FindGameObjectWithTag("BattleManager").GetComponent<Battle>().PlayerHealth = (int)(GameObject.FindGameObjectWithTag("BattleManager").GetComponent<Battle>().MaxPlayerHealth * 0.5f);
            }
            
        }
        else if (player == Player.Enemy)
        {
            if (GameObject.FindGameObjectWithTag("BattleManager").GetComponent<Battle>().EnemyHealth < GameObject.FindGameObjectWithTag("BattleManager").GetComponent<Battle>().MaxEnemyHealth * 0.15f)
            {
                GameObject.FindGameObjectWithTag("BattleManager").GetComponent<Battle>().EnemyHealth = (int)(GameObject.FindGameObjectWithTag("BattleManager").GetComponent<Battle>().MaxEnemyHealth * 0.5f);
            }
        }
    }
}
