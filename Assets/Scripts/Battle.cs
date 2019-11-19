using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class Battle : MonoBehaviour
{
    public GameObject enemy;

    [Header("Health bars")]
    public Slider PlayerHealthBar;
    public Slider EnemyHealthBar;

    [Header("Maximum healths")]
    public int PlayerHealth;
    public int MaxPlayerHealth;
    public int EnemyHealth;
    public int MaxEnemyHealth;

    [Header("Enemy Cards")]
    public Card[] EnemyCards;

    [Space]
    public Button ProceedButton;

    [Space]
    public DamageType nextPlayerDamageType;
    public DamageType nextEnemyDamageType;

    [Space]
    public CardManager cardManager;

    [Space]
    public Card NextPlayerCard;
    public Card NextEnemyCard;

    [Header("Endgame Overlays")]
    public GameObject WonOverlay;
    public GameObject LossOverlay;

    [Header("Boss Taunts")]
    public int TauntLength;
    public TextMeshProUGUI tauntText;

    private GlobalGameManager manager;


    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalGameManager>();
        if (manager == null)
        {
            Debug.LogError("Global game manager not found. This game needs to be started from the \"Menu\" scene to work properly");
        }

        switch (manager.BossOrder[manager.CurrentBoss])
        {
            case Bosses.Vinnie:
                EnemyCards = manager.VinnieCards;
                break;
            case Bosses.Rex:
                EnemyCards = manager.RexCards;
                break;
            case Bosses.BlockNess:
                EnemyCards = manager.BlockNessCards;
                break;
        }

        cardManager.AllCards = manager.GlobalHand.ToArray();

        PlayerHealth = MaxPlayerHealth;
        EnemyHealth = MaxEnemyHealth;
        PlayerHealthBar.value = PlayerHealth / MaxPlayerHealth;
        EnemyHealthBar.value = EnemyHealth / MaxEnemyHealth;

        NextEnemyCard = EnemyCards[Random.Range(0, EnemyCards.Length)];

        cardManager.ResetCards();
        cardManager.ShowCards();
    }

    public void Turn(DamageType PlayerCard)
    {

        nextEnemyDamageType = NextEnemyCard.damageType;
        nextPlayerDamageType = NextPlayerCard.damageType;
        

        switch (nextEnemyDamageType)
        {
            case DamageType.Hit:
                switch (nextPlayerDamageType)
                {
                    case DamageType.Hit:
                        //no winner
                        break;
                    case DamageType.Block:
                        NextPlayerCard.ApplyEffect(Player.Player);
                        break;
                    case DamageType.Grab:
                        NextEnemyCard.ApplyEffect(Player.Enemy);
                        break;
                }
                break;
            case DamageType.Block:
                switch (nextPlayerDamageType)
                {
                    case DamageType.Hit:
                        NextEnemyCard.ApplyEffect(Player.Enemy);
                        break;
                    case DamageType.Block:
                        //no winner
                        break;
                    case DamageType.Grab:
                        NextPlayerCard.ApplyEffect(Player.Player);
                        break;
                }
                break;
            case DamageType.Grab:
                switch (nextPlayerDamageType)
                {
                    case DamageType.Hit:
                        NextPlayerCard.ApplyEffect(Player.Player);
                        break;
                    case DamageType.Block:
                        NextEnemyCard.ApplyEffect(Player.Enemy);
                        break;
                    case DamageType.Grab:
                        //no winner
                        break;
                }
                break;
        }

        if (PlayerHealth <= 0)
        {
            LossOverlay.SetActive(true);
        }
        if (EnemyHealth <= 0)
        {
            WonOverlay.SetActive(true);
        }

        PlayerHealthBar.value = (float)PlayerHealth / MaxPlayerHealth;
        EnemyHealthBar.value = (float)EnemyHealth / MaxEnemyHealth;

        ProceedButton.interactable = false;

        NextEnemyCard = EnemyCards[Random.Range(0, EnemyCards.Length)];
        NextPlayerCard = null;

        cardManager.ShowCards();

        foreach (Card card in cardManager.ShownCards)
        {
            card.GetComponent<Button>().interactable = true;
        }

        switch (manager.BossOrder[manager.CurrentBoss])
        {
            case Bosses.Vinnie:
                StartCoroutine(ShowTaunt(manager.VinnieTaunts[Random.Range(0, manager.VinnieTaunts.Length-1)]));
                break;
            case Bosses.Rex:
                StartCoroutine(ShowTaunt(manager.RexTaunts[Random.Range(0, manager.RexTaunts.Length-1)]));
                break;
            case Bosses.BlockNess:
                StartCoroutine(ShowTaunt(manager.BlockNessTaunts[Random.Range(0, manager.BlockNessTaunts.Length-1)]));
                break;
        }

    }

    public void CommenceRound()
    {
        Turn(nextPlayerDamageType);
    }

    IEnumerator ShowTaunt(string Taunt)
    {
        tauntText.text = Taunt;
        tauntText.gameObject.SetActive(true);
        yield return new WaitForSeconds(TauntLength);
        tauntText.gameObject.SetActive(false);
    }
}
