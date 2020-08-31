using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public GetItems getItems;
    public Text Diamonds_amount;
    public Text Cherries_amount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Diamonds_amount.text = getItems.diamonds.ToString();
        Cherries_amount.text = getItems.cherry.ToString();
        
    }
}
