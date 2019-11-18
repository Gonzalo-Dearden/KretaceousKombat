using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameManager : MonoBehaviour
{
    [Header("Boss Order")]
    [Tooltip("Each boss should be placed into this list, in order. When all bosses have been fought, the game is won")]
    //boss order
    public List<string> BossOrder;
    public int CurrentBoss;

    [Header("Boss Cards")]
    //boss cards
    public List<Card> VinnieCards;
    public List<Card> RexCards;
    public List<Card> BlockNessCards;

    [Header("Global Hand")]
    [Tooltip("This is the hand that is loaded for the player at the start of every match")]
    //global hand
    public List<Card> GlobalHand;

    [Header("Resources")]
    //money
    public int money;
    //health
    public int health;
    //cabbages
    public int cabbages;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
