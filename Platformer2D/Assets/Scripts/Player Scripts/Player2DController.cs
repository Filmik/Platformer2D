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

    PlayerAnimationController animationController;
    Rigidbody2D _rigidbody2D;

    float runMovement;


    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        animationController = GetComponent<PlayerAnimationController>();
    }

    void Update()
    {
        transform.position += new Vector3(runMovement, 0,0) * Time.deltaTime * movementSpeed;//player movement
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        Vector2 inputMovement = value.ReadValue<Vector2>();
        runMovement = inputMovement.x;

        if (!Mathf.Approximately(0, inputMovement.x))//change rotation
            transform.rotation = inputMovement.x < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;

        if(runMovement!=0)
            animationController.playerRun();
        else
            animationController.playerStopRuning();

    }

    public void OnAttack(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            animationController.playerAttack();
        }
    } 
    public void OnJump(InputAction.CallbackContext value)
    {
        if (Mathf.Abs(_rigidbody2D.velocity.y) < 0.001f)
        {
            _rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            animationController.playerJumpUp(true);
        }
    }
}
