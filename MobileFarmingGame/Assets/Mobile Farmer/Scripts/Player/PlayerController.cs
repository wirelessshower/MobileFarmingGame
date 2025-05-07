using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerAnimator))]
public class PlayerController : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private MobileJoystick joystick;
    private PlayerAnimator playerAnimator;
    private CharacterController characterController;

    [Header("Settings")]
    [SerializeField] private float moveSpeed;    

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerAnimator = GetComponent<PlayerAnimator>();
    }

    void Update()
    {
        ManageMovment();        
    }

    private void ManageMovment()
    {
        Vector3 moveVector = joystick.GetMoveVector() * moveSpeed * Time.deltaTime / Screen.width;

        moveVector.z = moveVector.y;
        moveVector.y = 0;

        characterController.Move(moveVector);

        playerAnimator.MangeAnimations(moveVector);
    }
}
