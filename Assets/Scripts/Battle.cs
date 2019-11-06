using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum DamageType {Hit, Block, Grab, All, None};
//hit < block < grab < hit
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
    public DamageType[] EnemyCards;

    [Header("Base damage levels")]
    public int PlayerDamage = 5;
    public int EnemyDamage = 5;

    [Header("UI Buttons for attack modes")]
    public Button HitButton;
    public Button GrabButton;
    public Button BlockButton;

    [Space]
    public Button ProceedButton;

    [Space]
    public DamageType nextPlayerDamageType;
    public DamageType nextEnemyDamageType;

    [Space]
    public CardManager cardManager;

    [Space]
    public Card NextCard;


    void Start()
    {
        PlayerHealth = MaxPlayerHealth;
        EnemyHealth = MaxEnemyHealth;
        PlayerHealthBar.value = PlayerHealth / MaxPlayerHealth;
        EnemyHealthBar.value = EnemyHealth / MaxEnemyHealth;

        nextEnemyDamageType = EnemyCards[Random.Range(0, EnemyCards.Length)];

        cardManager.ShowCards();
    }

    public void Turn(DamageType PlayerCard)
    {
        NextCard.ApplyEffect();
        

        switch (nextEnemyDamageType)
        {
            case DamageType.Hit:
                switch (PlayerCard)
                {
                    case DamageType.Hit:
                        //no winner
                        break;
                    case DamageType.Block:
                        EnemyHealth -= PlayerDamage;
                        break;
                    case DamageType.Grab:
                        PlayerHealth -= EnemyDamage;
                        break;
                }
                break;
            case DamageType.Block:
                switch (PlayerCard)
                {
                    case DamageType.Hit:
                        PlayerHealth -= EnemyDamage;
                        break;
                    case DamageType.Block:
                        //no win
                        break;
                    case DamageType.Grab:
                        EnemyHealth -= PlayerDamage;
                        break;
                }
                break;
            case DamageType.Grab:
                switch (PlayerCard)
                {
                    case DamageType.Hit:
                        EnemyHealth -= PlayerDamage;
                        break;
                    case DamageType.Block:
                        PlayerHealth -= EnemyDamage;
                        break;
                    case DamageType.Grab:
                        //no win
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

        HitButton.interactable = true;
        BlockButton.interactable = true;
        GrabButton.interactable = true;

        ProceedButton.interactable = false;

        nextEnemyDamageType = EnemyCards[Random.Range(0, EnemyCards.Length)];

    }

    public void Hit()
    {
        nextPlayerDamageType = DamageType.Hit;

        HitButton.interactable = false;
        BlockButton.interactable = true;
        GrabButton.interactable = true;

        ProceedButton.interactable = true;
    }

    public void Block()
    {
        nextPlayerDamageType = DamageType.Block;

        HitButton.interactable = true;
        BlockButton.interactable = false;
        GrabButton.interactable = true;

        ProceedButton.interactable = true;
    }

    public void Grab()
    {
        nextPlayerDamageType = DamageType.Grab;

        HitButton.interactable = true;
        BlockButton.interactable = true;
        GrabButton.interactable = false;

        ProceedButton.interactable = true;
    }

    public void CommenceRound()
    {
        Turn(nextPlayerDamageType);
    }
}
