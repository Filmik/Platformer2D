using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomAnimationController : MonoBehaviour
{
    Animator animator;
    int runingHash;
    int deadHash;
    int getHitHash;
    EnemyPatrol enemyPatrol;
    bool run=false;
    void Awake()
    {
        animator = GetComponent<Animator>();
        runingHash = Animator.StringToHash("Runing");
        deadHash = Animator.StringToHash("Dead");
        getHitHash = Animator.StringToHash("GetHit");
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
                mushroomRun(run);
            }
        }
    }

    public void mushroomDie() => animator.SetBool(deadHash, true);
    public void mushroomGetHit() => animator.SetTrigger(getHitHash);
    public void mushroomRun(bool runing) => animator.SetBool(runingHash, runing);

}
