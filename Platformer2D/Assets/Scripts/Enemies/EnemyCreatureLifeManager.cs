using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreatureLifeManager : DestroyAfterAnimation
{
    [SerializeField]
    int life = 2;
    EnemyAnimationController animationController;
    Animator animator;
    void Awake()
    {
        animationController = GetComponent<EnemyAnimationController>();
        animator = GetComponent<Animator>();
    }

    public void EnemyGetHit(int damage)
    {
        life -= damage;
        if (life <= 0)
            KillEnemy();
        else animationController.GetHit();
    }
    void KillEnemy()
    {
        animationController.Die();
        DestroyAfterAnim(gameObject, animator);
    }
}
