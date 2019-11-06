using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Card : MonoBehaviour
{
    public DamageType damageType;
    public string Description;
    public Sprite DisplayImage;

    public abstract void ApplyEffect();

    public void Start()
    {
        GetComponent<Button>().image.sprite = DisplayImage;
    }

    public void Choose()
    {
        foreach (Card card in GameObject.FindGameObjectWithTag("CardManager").GetComponent<CardManager>().ShownCards)
        {
            card.GetComponent<Button>().interactable = true;
        }

        GetComponent<Button>().interactable = false;
        GameObject.FindGameObjectWithTag("BattleManager").GetComponent<Battle>().NextCard = this;        
    }
}
