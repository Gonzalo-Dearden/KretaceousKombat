using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopCard : MonoBehaviour
{
    public Card CardStorage;
    public int Value;

    public void SetCard(Card card)
    {
        CardStorage = card;
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = CardStorage.Title + "\n" + CardStorage.Description;
        gameObject.GetComponent<Button>().onClick.AddListener(Buy);

    }

    public void Buy()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalGameManager>().GlobalHand.Add(CardStorage);
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalGameManager>().money -= CardStorage.MonetaryValue;
        gameObject.GetComponent<Button>().interactable = false;
    }
}
