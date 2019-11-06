using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Card : MonoBehaviour
{
    public DamageType damageType;
    public string Description;
    public Sprite DisplayImage;

    public abstract void Start();
    public abstract void ApplyEffect();
}
