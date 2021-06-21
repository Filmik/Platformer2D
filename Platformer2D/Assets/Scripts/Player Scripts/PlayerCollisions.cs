using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    PlayerLifeManager lifeManager;
    Rigidbody2D _rigidbody2D;

    [SerializeField]
    float pushBackForce = 2;

    void Awake()
    {
        lifeManager = GetComponent<PlayerLifeManager>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemie")
        {
            if ((transform.position.x - collision.collider.transform.position.x) < 0)
                _rigidbody2D.AddForce(new Vector2(-pushBackForce, pushBackForce), ForceMode2D.Impulse);
            else if ((transform.position.x - collision.collider.transform.position.x) > 0)
                _rigidbody2D.AddForce(new Vector2(pushBackForce, pushBackForce), ForceMode2D.Impulse);

            lifeManager.PlayerGetHit();
        }
    }
}
