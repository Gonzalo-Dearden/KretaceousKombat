using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public DamageType damageType;
    public string Description;
    public Sprite DisplayImage;

    public void Start()
    {
        GetComponentInChildren<Image>().sprite = DisplayImage;
    }
}
