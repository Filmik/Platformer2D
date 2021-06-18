using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLifeManager : MonoBehaviour
{
    [SerializeField]
    GameObject lifeContainer;
    [SerializeField]
    Sprite heart;
    [SerializeField]
    Sprite emptyHeart;
    PlayerInput playerInput;
    PlayerAnimationController animationController;


    [SerializeField]
    List<GameObject> lifes;

    void Awake()
    {
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
                break; 
            }
        }
    }

    void KillPlayer()
    {
        playerInput.enabled=false;
        animationController.playerDie();
    }
}
