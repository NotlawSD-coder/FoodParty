using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCatcherPlayerController : FoodCatcherController
{

    MinigamePlayerControls inputActions;

    #region Awake/Start/Update
    protected override void Awake()
    {
        base.Awake();

        inputActions = new MinigamePlayerControls();
        inputActions.FoodCatcher.Move.performed += ctx =>
        {
            //Debug.Log(ctx.valueType);
            float _ = ctx.ReadValue<float>();
            //Debug.Log(_);
            moveVector = new Vector3(-_, moveVector.y, moveVector.z);
        };
        inputActions.FoodCatcher.Move.canceled += _ => moveVector = Vector2.zero;
        inputActions.FoodCatcher.Jump.performed += _ => Jump();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    #endregion

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
