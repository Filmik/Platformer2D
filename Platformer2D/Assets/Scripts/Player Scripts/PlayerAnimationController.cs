using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D _rigidbody2D;
    [SerializeField]
    float timeToResetAttackTrigger = 0.2f;
    int runingHash;
    int attackHash;
    int deadHash;
    int getHitHash;
    int jumpUpHash;
    int jumpDownHash;

    void Awake()
    {
        animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        runingHash = Animator.StringToHash("Runing");
        attackHash = Animator.StringToHash("Attack");
        deadHash = Animator.StringToHash("Dead");
        getHitHash = Animator.StringToHash("GetHit");
        jumpUpHash = Animator.StringToHash("JumpUp");
        jumpDownHash = Animator.StringToHash("JumpDown");

    }
    void Update()
    {
        CheckIfPlayerIsFalling();
    }

    public void playerDie()=>animator.SetBool(deadHash, true);
    public void playerGetHit()=>animator.SetTrigger(getHitHash);
    public void playerAttack() 
    {
        animator.SetTrigger(attackHash);
        StartCoroutine(ResetTriggerAfterTime(attackHash, timeToResetAttackTrigger));
    }
    public void playerRun()=>animator.SetBool(runingHash, true);
    public void playerStopRuning()=>animator.SetBool(runingHash, false);
    public void playerJumpUp(bool state)=>animator.SetBool(jumpUpHash, state);
    public void playerJumpDown(bool state)=>animator.SetBool(jumpDownHash, state);


    void CheckIfPlayerIsFalling()
    {
        if (_rigidbody2D.velocity.y != 0 )
            playerJumpDown(true);
        if (_rigidbody2D.velocity.y == 0)
        {
            playerJumpDown(false);
            playerJumpUp(false);
        }
    }
    IEnumerator ResetTriggerAfterTime(int animation, float time)
    {
        yield return new WaitForSeconds(time);
        animator.ResetTrigger(animation);
    }
}
