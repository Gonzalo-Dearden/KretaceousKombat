using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public enum Player { Player, Enemy};

public enum DamageType { Hit, Block, Grab };
//hit < block < grab < hit

public abstract class Card : MonoBehaviour
{
    public DamageType damageType;
    public string Description;
    public string Title;
    public Sprite DisplayImage;
    public int MonetaryValue;



    public abstract void ApplyEffect(Player player);

    public void Start()
    {
        GetComponent<Button>().image.sprite = DisplayImage;

        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener((data) => { MouseOn(); });
        trigger.triggers.Add(entry);

        EventTrigger.Entry exit = new EventTrigger.Entry();
        exit.eventID = EventTriggerType.PointerExit;
        exit.callback.AddListener((data) => { MouseOff(); });
        trigger.triggers.Add(exit);

        GetComponentInChildren<TextMeshProUGUI>().text = Title + "\n" + Description;

        
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

    public void MouseOn()
    {
        transform.localScale = new Vector3(4, 4, 4);
        transform.SetAsLastSibling();
    }

    public void MouseOff()
    {
        transform.localScale = new Vector3(2, 2, 2);
    }
}
