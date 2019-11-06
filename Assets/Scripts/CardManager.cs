using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public Card[] Deck;
    public int HandSize;
    public List<Card> ShownCards;

    [Space]
    public GameObject[] CardPositions;

    [Space]
    [Tooltip("Add all of the card prefabs to this list")]
    public Card[] AllCards;

    [Space]
    public Canvas canvas;

    public void ShuffleDeck()
    {
        for (int i = 0; i < Deck.Length; i++)
        {
            int rnd = Random.Range(0, Deck.Length);
            Card temp = Deck[rnd];
            Deck[rnd] = Deck[i];
            Deck[i] = temp;
        }
    }

    public void ShowCards()
    {
        foreach (Card card in ShownCards)
        {
            Destroy(card.gameObject);
        }

        for (int i = 0; i < HandSize; i++)
        {
            Card card = Instantiate(Deck[i], Vector3.zero, Quaternion.identity, canvas.transform);
            card.GetComponent<RectTransform>().position = CardPositions[i].GetComponent<RectTransform>().position;
            card.GetComponent<Button>().onClick.AddListener(card.Choose);
            ShownCards.Add(card);
        }

    }
}
