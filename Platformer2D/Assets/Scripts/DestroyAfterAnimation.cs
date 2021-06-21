using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterAnimation : MonoBehaviour
{
    public void DestroyAfterAnim(GameObject gameObject, Animator animator)
    {
        StartCoroutine(WhaitForAnimation(gameObject, animator));
    }
    IEnumerator WhaitForAnimation(GameObject gameObject, Animator animator)
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);
    }
}
