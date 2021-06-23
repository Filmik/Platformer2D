using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Transform playerTransform;
    [SerializeField]
    float hitDistance = 1;
    [SerializeField]
    int damage = 1;
    [SerializeField]
    LayerMask ignoreLayer;

    void Awake()=> playerTransform = GetComponent<Transform>();
    
    public void Attack()//activated by Attack animation
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, playerTransform.right, hitDistance, ~ignoreLayer);
        if (hit) {
            if (hit.collider.gameObject.layer == 9)//Enemie layer
            {
                //Debug.Log("hit : " + hit.collider.name);
                hit.collider.GetComponent<EnemyCreatureLifeManager>().EnemyGetHit(damage);
            }
        }
    }
}
