using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField]
    float patrolTime=2;
    [SerializeField]
    float patrolPoint1;
    [SerializeField]
    float patrolPoint2;
    bool onPatrol;
    Lerp lerp=new Lerp();
    float timeStartedLerping;
    float time;
    void Awake()
    {
        if (patrolPoint1!= 0 && patrolPoint1!=0)
            onPatrol = true;
    }
    void Start()
    {
        timeStartedLerping = Time.time;
    }

    void Update()
    {
        if(onPatrol)
            Patrol();
    }

    void Patrol()
    {
        
        time = Time.deltaTime;
        if(patrolTime>=time)
            transform.position= lerp.Lerping(transform.position,new Vector3(patrolPoint1,transform.position.y,transform.position.z), timeStartedLerping, patrolTime);
    }
}
