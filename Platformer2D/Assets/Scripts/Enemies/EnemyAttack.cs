using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    Transform enemyTransform;
    [SerializeField]
    float attackDistance = 1;
    [SerializeField]
    LayerMask ignoreLayer;
    EnemyAnimationController animationController;
    [SerializeField]
    float pushBackForce = 2;
    [SerializeField]
    float timeBetweenAttacks = 1f;
    bool attackPhase = false;
    void Awake() 
    {
        animationController = GetComponent<EnemyAnimationController>();
        enemyTransform = GetComponent<Transform>(); 
    }
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, enemyTransform.right, attackDistance,~ignoreLayer);
        if (hit && !attackPhase)
        {
            if (hit.collider.gameObject.layer == 8)//Player layer
            {
                attackPhase = true;
                animationController.Attack();
                PushBackPlayer(hit.collider.transform,hit.collider.GetComponent<Rigidbody2D>());
                hit.collider.GetComponent<PlayerLifeManager>().PlayerGetHit();
                StartCoroutine(WaitBeforeNextAttack());
            }
        }
    }

    void PushBackPlayer(Transform playerTransform,Rigidbody2D playerRigidBody2D)
    {
        if ((playerTransform.position.x - transform.position.x) < 0)
            playerRigidBody2D.AddForce(new Vector2(-pushBackForce, pushBackForce), ForceMode2D.Impulse);
        else if ((playerTransform.position.x - transform.position.x) > 0)
            playerRigidBody2D.AddForce(new Vector2(pushBackForce, pushBackForce), ForceMode2D.Impulse);
    }
    IEnumerator WaitBeforeNextAttack()
    {
        yield return new WaitForSeconds(timeBetweenAttacks);
        attackPhase = false;
    }
}
