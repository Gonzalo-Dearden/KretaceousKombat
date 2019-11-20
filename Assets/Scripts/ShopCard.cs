using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopCard : MonoBehaviour
{
    public Card CardStorage;
    public int Value;

    public Image RockImage;
    public Image PaperImage;
    public Image ScissorsImage;

    public void SetCard(Card card)
    {
        CardStorage = card;
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = CardStorage.Title + "\n" + CardStorage.Description + "\n" + CardStorage.MonetaryValue + " gold";
        gameObject.GetComponent<Button>().onClick.AddListener(Buy);

        switch (CardStorage.damageType)
        {
            case DamageType.Hit:
                // ScissorsImage.gameObject.SetActive(true);
                GetComponent<Button>().image.sprite = ScissorsImage.sprite;
                break;
            case DamageType.Block:
                //RockImage.gameObject.SetActive(true);
                GetComponent<Button>().image.sprite = RockImage.sprite;
                break;
            case DamageType.Grab:
                //PaperImage.gameObject.SetActive(true);
                GetComponent<Button>().image.sprite = PaperImage.sprite;
                break;
        }

    }

    public void Buy()
    {
        if (GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalGameManager>().money >= CardStorage.MonetaryValue)
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalGameManager>().GlobalHand.Add(CardStorage);
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalGameManager>().money -= CardStorage.MonetaryValue;
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
}
