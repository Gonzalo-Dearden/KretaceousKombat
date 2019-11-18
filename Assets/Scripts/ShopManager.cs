using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    public GlobalGameManager manager;
    public ShopCard shopCardPrefab;
    public GameObject CardHolder;
    // Start is called before the first frame update

    public Card[] AvailableCards;
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalGameManager>();
        GetCards();
    }


    public void GetCards()
    {
        //work out what bosses have been beaten by comparing the boss order from the global manager with the current boss level
        int currentLevel = manager.CurrentBoss;
        List<Bosses> BossOrder = manager.BossOrder;
        List<Bosses> BeatenBosses = BossOrder.GetRange(0, currentLevel + 1);

        List<Card> PossibleCards = new List<Card>();

        //add all the possible cards to the shoppable cards
        foreach (Bosses boss in BeatenBosses)
        {
            switch (boss)
            {
                case Bosses.Vinnie:
                    PossibleCards.AddRange(manager.VinnieCards);
                    break;
                case Bosses.Rex:
                    PossibleCards.AddRange(manager.RexCards);
                    break;
                case Bosses.BlockNess:
                    PossibleCards.AddRange(manager.BlockNessCards);
                    break;
            }
        }

        //shuffle the cards
        for (int i = 0; i < PossibleCards.Count; i++)
        {
            int rnd = Random.Range(0, PossibleCards.Count);
            Card temp = PossibleCards[rnd];
            PossibleCards[rnd] = PossibleCards[i];
            PossibleCards[i] = temp;
        }

        //display some of the cards
        foreach (Card card in PossibleCards.GetRange(0, 5))
        {
            ShopCard newCard = Instantiate(shopCardPrefab, CardHolder.transform);
            newCard.SetCard(card);
        }

    }

    public void Back()
    {
        SceneManager.LoadScene("Hub");
    }
}
