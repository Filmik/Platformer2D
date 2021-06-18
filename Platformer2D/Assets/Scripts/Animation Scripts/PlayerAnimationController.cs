using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator animator;
    bool runingState;
    bool attackState;
    bool deadState;
    int runingHash;
    int attackHash;
    int deadHash;

    void Awake()
    {
        animator = GetComponent<Animator>();
        runingHash = Animator.StringToHash("Runing");
        attackHash = Animator.StringToHash("Attack");
        deadHash = Animator.StringToHash("Dead");
        runingState = animator.GetBool(runingHash);
        attackState = animator.GetBool(attackHash);
        deadState = animator.GetBool(deadHash);

    }


    public void playerDie()=>animator.SetBool(deadHash, true);
}
