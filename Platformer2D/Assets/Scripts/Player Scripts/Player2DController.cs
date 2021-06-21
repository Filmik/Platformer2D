using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2DController : MonoBehaviour
{
    [SerializeField]
    float movementSpeed = 1;
    [SerializeField]
    float jumpForce = 5;
    [SerializeField]
    PlayerInput playerInput;

    PlayerAttack playerAttack;
    Rigidbody2D _rigidbody2D;


    //int movement = 0;
    float runMovement;
    float jumpMovement;


    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    void Update()
    {
        transform.position += new Vector3(runMovement, 0,0) * Time.deltaTime * movementSpeed;
       // if(runMovement==0)
            //disable anim
        //if (Mathf.Abs(_rigidbody2D.velocity.y) < 0.001f)//jump
           // _rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        Vector2 inputMovement = value.ReadValue<Vector2>();
        runMovement = inputMovement.x;

        if (!Mathf.Approximately(0, inputMovement.x))//change rotation
            transform.rotation = inputMovement.x < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;

        //run animation
    }

    public void OnAttack(InputAction.CallbackContext value)
    {
        if (value.started)
            playerAttack.Attack();
            Debug.Log("attack");
           // playerAnimationBehaviour.PlayAttackAnim();
        
    } 
    public void OnJump(InputAction.CallbackContext value)
    {
        if (value.started)
            Debug.Log("jump");
        // playerAnimationBehaviour.PlayAttackAnim();
        if (Mathf.Abs(_rigidbody2D.velocity.y) < 0.001f)
            _rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
}
