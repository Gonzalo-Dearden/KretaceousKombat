using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



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


    void Start()
    {
        PlayerHealth = MaxPlayerHealth;
        EnemyHealth = MaxEnemyHealth;
        PlayerHealthBar.value = PlayerHealth / MaxPlayerHealth;
        EnemyHealthBar.value = EnemyHealth / MaxEnemyHealth;

        NextEnemyCard = EnemyCards[Random.Range(0, EnemyCards.Length)];

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
            Debug.Log("Player whited out!");
        }
        if (EnemyHealth <= 0)
        {
            Debug.Log("You won!");
        }

        PlayerHealthBar.value = (float)PlayerHealth / MaxPlayerHealth;
        EnemyHealthBar.value = (float)EnemyHealth / MaxEnemyHealth;

        ProceedButton.interactable = false;

        NextEnemyCard = EnemyCards[Random.Range(0, EnemyCards.Length)];
        NextPlayerCard = null;

        foreach (Card card in cardManager.ShownCards)
        {
            card.GetComponent<Button>().interactable = true;
        }

    }

    public void CommenceRound()
    {
        Turn(nextPlayerDamageType);
    }
}
