using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontGetBurntPlayerController : DontGetBurntController
{

    public CharacterController controller;

    MinigamePlayerControls inputActions;

    private Vector3 moveVector;
    private float ySpeed;

    #region Awake/Start/Update
    protected override void Awake()
    {
        base.Awake();
        inputActions = new MinigamePlayerControls();
        inputActions.DontGetBurnt.Move.performed += ctx =>
        {
            Vector2 _ = ctx.ReadValue<Vector2>();
            moveVector = new Vector3(_.x, moveVector.y, _.y);
        };
        inputActions.DontGetBurnt.Move.canceled += _ => moveVector = Vector2.zero;
        inputActions.DontGetBurnt.Jump.performed += _ => Jump();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        
    }

    private void FixedUpdate()
    {
        if (controller != null)
        {
            float magnitude = Mathf.Clamp01(moveVector.magnitude) * speed;
            moveVector.Normalize();

            ySpeed += Physics.gravity.y * Time.deltaTime;

            if (ySpeed < 0f && IsGrounded())
            {
                ySpeed = Vector3.kEpsilon;
                playerCharacter.animManager.ator.SetBool("InAir", false);
            }

            Vector3 velocity = moveVector * magnitude;
            velocity.y = ySpeed;

            if (playerCharacter != null) playerCharacter.animManager.ator.SetFloat("Speed", moveVector.magnitude);

            //Debug.Log(velocity);

            controller.Move(velocity * Time.deltaTime);

            if(velocity.magnitude > Vector3.kEpsilon) transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(moveVector), rotationSpeed * Time.deltaTime);
        }
    }
    #endregion

    public override void Initialize()
    {
        base.Initialize();
        if (!gameObject.TryGetComponent(out controller))
        {
            controller = gameObject.AddComponent<CharacterController>();
            controller.center = Vector3.up;
        }
    }

    public void Jump()
    {
        if(controller != null && IsGrounded())
        {
            ySpeed = jumpForce;
            if (playerCharacter != null) playerCharacter.animManager.ator.SetBool("InAir", true);
        }
    }

    private bool IsGrounded()
    {
        bool isGrounded = Physics.CheckSphere(transform.position, 0.2f, 1 << LayerMask.NameToLayer("MapStatic"));
        return isGrounded;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        inputActions.Enable();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        inputActions.Disable();
    }
}