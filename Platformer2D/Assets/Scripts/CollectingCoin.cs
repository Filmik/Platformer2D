using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingCoin : MonoBehaviour
{
    CoinAnimationController animController;
    Animator animator;
    private void Awake()
    {
        animController = GetComponent<CoinAnimationController>();
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)//layer 8 -> Player
        {
            animController.CoinIsCollected();
            StartCoroutine(WhaitForCollectAnimation());
        }
    }
    IEnumerator WhaitForCollectAnimation( )
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);
    }
}
