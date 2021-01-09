using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
        _animator.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));
        _animator.SetBool("IsRunning", Input.GetKey("left shift"));
        _animator.SetBool("IsJumping", Input.GetKey("space"));
        _animator.SetBool("IsCrouching", Input.GetKey("left ctrl"));
    }
}
