using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAnimationController : MonoBehaviour
{
    Animator animator;
    bool collectedState;
    int collectedHash;

    void Awake()
    {
        animator = GetComponent<Animator>();
        collectedHash = Animator.StringToHash("Collected");
        collectedState = animator.GetBool(collectedHash);
    }

    public void CoinIsCollected() => animator.SetBool(collectedHash,true);
}
