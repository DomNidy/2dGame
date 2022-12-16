using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimate : MonoBehaviour
{
    PlayerMovement player_movement;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        player_movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        // Animate attack
        if(Input.GetMouseButtonDown(0))
        {
            AnimateAttack();
        }

        // Animate walk
        AnimateWalk(player_movement.IsWalking());
    }

    private void AnimateAttack()
    {
        animator.SetTrigger("Attack");
    }

    private void AnimateWalk(bool isWalking)
    {
        animator.SetBool("Walk", isWalking);
    }
}
