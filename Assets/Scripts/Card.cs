using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Player { Player, Enemy};

public enum DamageType { Hit, Block, Grab };
//hit < block < grab < hit

public abstract class Card : MonoBehaviour
{
    public DamageType damageType;
    public string Description;
    public string Title;
    public Sprite DisplayImage;

    public abstract void ApplyEffect(Player player);

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
        GameObject.FindGameObjectWithTag("BattleManager").GetComponent<Battle>().NextPlayerCard = this;
        GameObject.FindGameObjectWithTag("BattleManager").GetComponent<Battle>().ProceedButton.interactable = true;
    }
}
