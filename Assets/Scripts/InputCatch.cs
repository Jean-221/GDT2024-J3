using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Bas solution, there are existing solution that might be better
// Input and Ai could have a common base class

public class InputCatch : MonoBehaviour
{
    #region Members

    Move            m_cMoveComponent            = null;
    WallPower       m_cWallPowerComponent       = null;

    PlayerControls m_playerControls;
    InputAction m_moveAction;

    #endregion


    #region Unity Methods

    private void Awake()
    {
        m_cMoveComponent = gameObject.GetComponent<Move>();
        m_cWallPowerComponent = gameObject.GetComponent<WallPower>();
        m_playerControls = new PlayerControls(); 
    }

    private void OnEnable()
    {
        m_moveAction = m_playerControls.Player.Move;
        m_moveAction.Enable();
        m_playerControls.Player.Fire.performed += OnFire;
        m_playerControls.Player.Fire.Enable();
    }

    private void OnDisable()
    {
        m_moveAction.Disable();
        m_playerControls.Player.Fire.performed -= OnFire;
        m_playerControls.Player.Fire.Disable();
    }

    private void OnFire(InputAction.CallbackContext context)
    {
        Debug.Log("fireInput");
        m_cWallPowerComponent.SpawnWall();
    }

    void FixedUpdate()
    {
        Vector2 moveDir = m_moveAction.ReadValue<Vector2>();

        m_cMoveComponent.InputDir(new Vector3(moveDir.x, 0.0f, moveDir.y));
    }

    #endregion
}
