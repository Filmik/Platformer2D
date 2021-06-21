using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLifeManager : DestroyAfterAnimation
{
    [SerializeField]
    GameObject lifeContainer;
    [SerializeField]
    Sprite heart;
    [SerializeField]
    Sprite emptyHeart;
    PlayerInput playerInput;
    PlayerAnimationController animationController;
    Animator animator;

    [SerializeField]
    List<GameObject> lifes;

    void Awake()
    {
        animator=GetComponent<Animator>();
        animationController = GetComponent<PlayerAnimationController>();
        playerInput =GetComponent<PlayerInput>();
        foreach (Transform child in lifeContainer.transform)
            lifes.Add(child.gameObject);
    }
    public void PlayerGetHit()
    {
        for (int i = lifes.Count-1; i >= 0; i--)
        {
            if (lifes[i].GetComponent<SpriteRenderer>().sprite == heart)
            {
                lifes[i].GetComponent<SpriteRenderer>().sprite = emptyHeart;
                if (i == 0)
                    KillPlayer();
                else animationController.playerGetHit();
                break; 
            }
        }
    }
    void KillPlayer()
    {
        playerInput.enabled=false;
        animationController.playerDie();
        DestroyAfterAnim(gameObject,animator);
    }
}
