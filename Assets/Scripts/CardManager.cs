﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CardManager : MonoBehaviour
{
    public List<Card> DrawPile;
    public List<Card> DiscardPile;
    public List<Card> Hand;
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
        for (int i = 0; i < DrawPile.Count; i++)
        {
            int rnd = Random.Range(0, DrawPile.Count);
            Card temp = DrawPile[rnd];
            DrawPile[rnd] = DrawPile[i];
            DrawPile[i] = temp;
        }
    }

    public void ResetCards()
    {
        DrawPile = AllCards.ToList<Card>();
        ShuffleDeck();
    }

    public void Draw()
    {
        if (DrawPile.Count < HandSize)
        {
            ResetCards();
        }

        for (int i = 0; i < HandSize; i++)
        {
            ShownCards.Add(DrawPile[0]);
            DrawPile.RemoveAt(0);
        }
    }

    public void Clear()
    {
        DiscardPile.AddRange(ShownCards);
        ShownCards.Clear();
    }

    public void ShowCards()
    {
        foreach (Card card in ShownCards)
        {
            Destroy(card.gameObject);
        }

        for (int i = 0; i < HandSize; i++)
        {
            Card card = Instantiate(DrawPile[i], Vector3.zero, Quaternion.identity, canvas.transform);
            card.GetComponent<RectTransform>().position = CardPositions[i].GetComponent<RectTransform>().position;
            card.GetComponent<Button>().onClick.AddListener(card.Choose);
            ShownCards.Add(card);
        }

    }
}