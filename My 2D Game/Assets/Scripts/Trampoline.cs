using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] float _bounceForce = 25f;
    [SerializeField] bool _canBounce = true;

    Animator _myAnim;

    private void Start()
    {
        _myAnim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && _canBounce)
        {
            _canBounce = false;
            _myAnim.SetTrigger("Bounce");
            Rigidbody2D playerRb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
            playerRb.velocity = new Vector2(playerRb.velocity.x, _bounceForce); 
        }
        else
        {
            _canBounce = true;
        }
    }
}
