using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingCoin : DestroyAfterAnimation
{
    CoinAnimationController animController;
    Animator animator;
    CollectedCoins collectedCoins;
    private void Awake()
    {
        GameObject gameManager = GameObject.Find("GameManager");
        if (gameManager == null)
            Debug.LogError("GameManager not found");
        else collectedCoins = gameManager.GetComponent<CollectedCoins>();
        animController = GetComponent<CoinAnimationController>();
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)//layer 8 -> Player
        {
            animController.CoinIsCollected();
            collectedCoins.AddCoin();
            DestroyAfterAnim(gameObject,animator);
        }
    }
}
