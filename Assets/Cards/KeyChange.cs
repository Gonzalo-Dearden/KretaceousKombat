using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyChange : Card
{
    public override void ApplyEffect(Player player)
    {
        if (player == Player.Player)
        {
            if (Random.Range(0f, 1f) > 0.5)
            {
                GameObject.FindGameObjectWithTag("BattleManager").GetComponent<Battle>().EnemyHealth -= 10;
            }            
        }
        else if (player == Player.Enemy)
        {
            if (Random.Range(0f, 1f) > 0.5)
            {
                GameObject.FindGameObjectWithTag("BattleManager").GetComponent<Battle>().PlayerHealth -= 10;
            }
        }        
    }
}
