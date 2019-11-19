using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardBackground : MonoBehaviour
{

    public Image RockImage;
    public Image PaperImage;
    public Image ScissorsImage;

    // Start is called before the first frame update
    void Start()
    {
        switch (GetComponent<Card>().damageType)
        {
            case DamageType.Hit:
                ScissorsImage.gameObject.SetActive(true);
                break;
            case DamageType.Block:
                RockImage.gameObject.SetActive(true);
                break;
            case DamageType.Grab:
                PaperImage.gameObject.SetActive(true);
                break;
        }
    }
}
