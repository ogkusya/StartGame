using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Windows;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private const float GRAVITY_VALUE = -0.5f;
    private const float GROUNDED_GRAVITY_VALUE = -9.8f;

    [Header("Move Parameters")]
    [SerializeField] private float moveSpeed = 4.0f;

    [Header("Rotate Parameters")]
    [SerializeField] private float rotateSpeed = 10.0f;

    [Header("Jump Parameters")]
    [SerializeField] private float jumpForce = 10;

    [Header("Gravity Parameters")]
    [SerializeField] private float gravity = 9;

    private InputManager _inputManager;
    private CharacterController _characterController;
    private Vector3 _moveDirection = Vector3.zero;
    public Vector3 MoveDirection => _moveDirection;
    public bool IsPlayerGrounded => _characterController.isGrounded;

    public Action OnJumpAnimationAction;

    private void OnEnable()
    {
        _inputManager.OnJumpAction += OnJump;
    }

    private void OnDisable()
    {
        _inputManager.OnJumpAction -= OnJump;
    }

    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        GravityEffect();
        Move();
        Rotate();
    }

    void GravityEffect()
    {
        if (!_characterController.isGrounded)
        {
            _moveDirection.y -= gravity * Time.deltaTime;
        }
    }

    private void OnJump()
    {
        if (_characterController.isGrounded)
        {
            _moveDirection.y = jumpForce;
            OnJumpAnimationAction?.Invoke();
        }
    }

    private void Move()
    {
        _moveDirection.x = _inputManager.MoveInput.x * moveSpeed;
        _characterController.Move(MoveDirection * Time.deltaTime);
    }

    private void Rotate()
    {
        Vector3 rotateDirection = new(_moveDirection.x, 0f, 0f);

        if (rotateDirection != Vector3.zero)
        {
            gameObject.transform.forward = Vector3.Slerp(transform.forward, rotateDirection, rotateSpeed * Time.deltaTime);
        }
    }



}
