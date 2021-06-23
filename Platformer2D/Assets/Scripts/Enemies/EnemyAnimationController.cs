using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    Animator animator;
    int runingHash;
    int deadHash;
    int getHitHash;
    int AttackHash;
    EnemyPatrol enemyPatrol;
    bool run = false;
    void Awake()
    {
        animator = GetComponent<Animator>();
        runingHash = Animator.StringToHash("Runing");
        deadHash = Animator.StringToHash("Dead");
        getHitHash = Animator.StringToHash("GetHit");
        AttackHash = Animator.StringToHash("Attack");
        if (GetComponent<EnemyPatrol>() != null)
            enemyPatrol = GetComponent<EnemyPatrol>();


    }
    void Update()
    {
        if (enemyPatrol != null)
        {
            if (run != enemyPatrol.onPatrol)
            {
                run = enemyPatrol.onPatrol;
                Run(run);
            }
        }
    }

    public void Die() => animator.SetBool(deadHash, true);
    public void GetHit() => animator.SetTrigger(getHitHash);
    public void Run(bool runing) => animator.SetBool(runingHash, runing);
    public void Attack() => animator.SetTrigger(AttackHash);

    IEnumerator ResetTriggerAfterTime(int animation, float time)
    {
        yield return new WaitForSeconds(time);
        animator.ResetTrigger(animation);
    }
}
