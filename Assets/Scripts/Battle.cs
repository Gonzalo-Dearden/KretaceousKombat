using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



public class Battle : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;

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

    [Header("Boss Images")]
    public Image RexImage;
    public Image BlockNessImage;
    public Image VinnieImage;

    private GlobalGameManager manager;


    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController")?.GetComponent<GlobalGameManager>();
        if (manager == null)
        {
            Debug.LogError("Global game manager not found. This game needs to be started from the \"Menu\" scene to work properly");
        }

        switch (manager.BossOrder[manager.CurrentBoss])
        {
            case Bosses.Vinnie:
                EnemyCards = manager.VinnieCards;
                VinnieImage.gameObject.SetActive(true);
                break;
            case Bosses.Rex:
                EnemyCards = manager.RexCards;
                RexImage.gameObject.SetActive(true);
                break;
            case Bosses.BlockNess:
                EnemyCards = manager.BlockNessCards;
                BlockNessImage.gameObject.SetActive(true);
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
                        player.GetComponent<Animation>().Play();
                        break;
                    case DamageType.Grab:
                        NextEnemyCard.ApplyEffect(Player.Enemy);
                        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
                        {
                            enemy.GetComponent<Animation>().Play();
                        }
                        break;
                }
                break;
            case DamageType.Block:
                switch (nextPlayerDamageType)
                {
                    case DamageType.Hit:
                        NextEnemyCard.ApplyEffect(Player.Enemy);
                        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
                        {
                            enemy.GetComponent<Animation>().Play();
                        }
                        break;
                    case DamageType.Block:
                        //no winner
                        break;
                    case DamageType.Grab:
                        NextPlayerCard.ApplyEffect(Player.Player);
                        player.GetComponent<Animation>().Play();
                        break;
                }
                break;
            case DamageType.Grab:
                switch (nextPlayerDamageType)
                {
                    case DamageType.Hit:
                        NextPlayerCard.ApplyEffect(Player.Player);
                        player.GetComponent<Animation>().Play();
                        break;
                    case DamageType.Block:
                        NextEnemyCard.ApplyEffect(Player.Enemy);
                        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
                        {
                            enemy.GetComponent<Animation>().Play();
                        } 
                        break;
                    case DamageType.Grab:
                        //no winner
                        break;
                }
                break;
        }

        StopAllCoroutines();

        if (PlayerHealth <= 0)
        {
            LossOverlay.SetActive(true);
            StartCoroutine(Lose());
        }
        if (EnemyHealth <= 0)
        {
            WonOverlay.SetActive(true);
            StartCoroutine(Win());
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

    IEnumerator Win()
    {
        manager.money += 20;
        manager.CurrentBoss += 1;
        WonOverlay.SetActive(true);
        yield return new WaitForSeconds(2);
        Debug.Log("Loading hub");
        SceneManager.LoadScene("Hub", LoadSceneMode.Single);
        Debug.Log("Loaded hub");

    }

    IEnumerator Lose()
    {
        LossOverlay.SetActive(true);
        yield return new WaitForSeconds(2);
        Debug.Log("Loading hub");
        SceneManager.LoadScene("Hub", LoadSceneMode.Single);
        Debug.Log("Loaded hub");
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

//#7582 happy birthday! ♥
