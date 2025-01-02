using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(InputManager), typeof(PlayerMovement))]
public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;

    private InputManager inputManager;
    private PlayerMovement playerMovement;
    private PlayerAnimatorManager playerAnimatorManager;

    private bool isPlayerGrounded;

    private void OnEnable()
    {
        playerMovement.OnJumpAnimationAction += OnJumpAnimation;
    }

    private void OnDisable()
    {
        playerMovement.OnJumpAnimationAction -= OnJumpAnimation;
    }

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerMovement = GetComponent<PlayerMovement>();
        playerAnimatorManager = new PlayerAnimatorManager(playerAnimator);
    }

    private void Update()
    {
        playerAnimatorManager.SetFloat(PlayerAnimationParameter.SpeedFloat, Mathf.Abs(playerMovement.MoveDirection.x));

        if (isPlayerGrounded != playerMovement.IsPlayerGrounded)
        {
            isPlayerGrounded = playerMovement.IsPlayerGrounded;

            if (isPlayerGrounded)
            {
                playerAnimatorManager.SetBool(PlayerAnimationParameter.GroundedBool, true);
            }
            else
            {
                playerAnimatorManager.SetBool(PlayerAnimationParameter.GroundedBool, false);
            }
        }
    }

    private void OnJumpAnimation()
    {
        playerAnimatorManager.SetTrigger(PlayerAnimationParameter.JumpTrigger);
    }
}
