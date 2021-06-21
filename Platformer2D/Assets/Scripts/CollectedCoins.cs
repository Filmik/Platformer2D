using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectedCoins : MonoBehaviour
{
    [SerializeField]
    Text coinsText;
    [SerializeField]
    string textToDisplay="Coins- ";
    int coins=0;

    void Start()
    {
        DisplayCoinNumber();
    }

    void DisplayCoinNumber()
    {
        coinsText.text = textToDisplay + coins.ToString();
    }

    public void AddCoin()
    {
        coins++;
        DisplayCoinNumber();
    }
}
