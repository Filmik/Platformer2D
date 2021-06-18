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

    Rigidbody2D _rigidbody2D;


    int movement = 0;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //transform.position += new Vector3(movement, 0,0) * Time.deltaTime * movementSpeed;

        
        //if (Mathf.Abs(_rigidbody2D.velocity.y) < 0.001f)//jump
           // _rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        Vector2 inputMovement = value.ReadValue<Vector2>();
        //rawInputMovement = new Vector2(inputMovement.x, 0);
        Debug.Log("marcin: "+ inputMovement);

        if (!Mathf.Approximately(0, inputMovement.x))//change rotation
            transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
    }

    public void OnAttack(InputAction.CallbackContext value)
    {
        if (value.started)
            Debug.Log("attack");
           // playerAnimationBehaviour.PlayAttackAnim();
        
    }
}
