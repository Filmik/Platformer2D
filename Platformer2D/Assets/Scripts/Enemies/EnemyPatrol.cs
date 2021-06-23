using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField]
    float patrolTime=2;// travel time from patrolStartPos to currentdestination
    [SerializeField]
    float patrolPoint1;
    [SerializeField]
    float patrolPoint2;
    Vector3 patrolStartPos;
    Vector3 currentdestination;
    bool firstPoint=true;
    [HideInInspector]
    public bool onPatrol=false;
    Lerp lerp=new Lerp();
    float timeStartedLerping;
    float time;
    float waitTime = 0.5f;//wait before enemy fall on ground
    
    void Awake()
    {
        if (patrolPoint1 != 0 || patrolPoint2 != 0 )
        {
           StartCoroutine(WaitForSecond(waitTime));
        }
    }
    void StartPatrol() {
        SetCurrentDestination();
        onPatrol = true;
        timeStartedLerping = Time.time;
        patrolStartPos = transform.position;
    }

    void Update()
    {
        if(onPatrol)
            Patrol();
    }

    void Patrol()
    {
        time += Time.deltaTime;
        if (patrolTime >= time)
            transform.position = lerp.Lerping(patrolStartPos, currentdestination, timeStartedLerping, patrolTime);
        else PatrolResetValues();
    }

    void PatrolResetValues()
    {
        firstPoint = !firstPoint;
        patrolStartPos = transform.position;
        SetCurrentDestination();
        transform.rotation = currentdestination.x < transform.position.x ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        time = 0;
        timeStartedLerping = Time.time;
    }
    void SetCurrentDestination()
    {
        currentdestination = transform.position;
        if (firstPoint)
            currentdestination.x = patrolPoint1;
        else currentdestination.x = patrolPoint2;
    }
    IEnumerator WaitForSecond(float duration)
    {
        yield return new WaitForSeconds(duration);
        StartPatrol();
    }
}
