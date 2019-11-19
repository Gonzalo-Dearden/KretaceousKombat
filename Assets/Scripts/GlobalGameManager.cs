using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Bosses {Vinnie, Rex, BlockNess}
public class GlobalGameManager : MonoBehaviour
{
    [Header("Boss Order")]
    [Tooltip("Each boss should be placed into this list, in order. When all bosses have been fought, the game is won")]
    //boss order
    public List<Bosses> BossOrder;
    public int CurrentBoss;

    [Header("Boss Cards")]
    //boss cards
    public Card[] VinnieCards;
    public Card[] RexCards;
    public Card[] BlockNessCards;

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

    [Header("Taunts")]
    [Tooltip("Lists of taunts for each of the bosses")]
    public string[] VinnieTaunts;
    public string[] RexTaunts;
    public string[] BlockNessTaunts;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}