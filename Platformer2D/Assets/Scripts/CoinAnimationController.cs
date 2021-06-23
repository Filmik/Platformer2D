using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAnimationController : MonoBehaviour
{
    Animator animator;
    int collectedHash;

    void Awake()
    {
        animator = GetComponent<Animator>();
        collectedHash = Animator.StringToHash("Collected");
    }

    public void CoinIsCollected() => animator.SetBool(collectedHash,true);
}
