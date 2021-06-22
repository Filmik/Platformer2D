using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreatureLifeManager : DestroyAfterAnimation
{
    [SerializeField]
    int life = 2;
    MushroomAnimationController animationController;
    Animator animator;
    void Awake()
    {
        animationController = GetComponent<MushroomAnimationController>();
        animator = GetComponent<Animator>();
    }

    public void EnemyGetHit(int damage)
    {
        life -= damage;
        if (life <= 0)
            KillEnemy();
        else animationController.mushroomGetHit();
    }
    void KillEnemy()
    {
        animationController.mushroomDie();
        DestroyAfterAnim(gameObject, animator);
    }
}
