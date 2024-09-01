using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Input and Ai could have a common base class

public class BasicAI : MonoBehaviour
{
    #region Members

    [SerializeField]
    private float m_speed = 0.0f;

    [SerializeField]
    private float m_angularspeed = 0.0f;

    [SerializeField]
    private float m_friction = 0.0f;

    [SerializeField]
    private float m_aimingDuration = 0.0f;

    [SerializeField]
    private float m_startupDuration = 0.0f;

    [SerializeField]
    private float m_recoveryDuration = 0.0f;

    [SerializeField]
    private float m_minSpeed = 0.0f; //below this speed the AI stops

    private Vector3 m_currentVelocity = Vector3.zero;

    enum STATE
    {
        AIMING,
        STARTUP,
        MOVING,
        RECOVERY
    }

    private STATE m_currentState = STATE.AIMING;

    private float m_timeForNextState = 0.0f;

    private float m_timeToAllowBounce = 0.0f;
    #endregion


    #region Unity Methods

    void Start()
    {
        m_currentState = STATE.AIMING;
        m_timeForNextState = Time.time + m_aimingDuration;
    }

    void FixedUpdate()
    {
        GameObject player = BadTimeSavingGameManager.m_cInstance.m_goPlayer;

        if (player)
        {
            switch(m_currentState)
            {
                case STATE.AIMING:
                    Vector3 toPlayer = player.transform.position - transform.position;
                    Vector2 toPlayer2d = new Vector2(toPlayer.z, toPlayer.x).normalized;
                    Vector2 frontVec2d = new Vector2(transform.forward.z, transform.forward.x).normalized;
                    float AngleBetweenVec = Vector2.SignedAngle(frontVec2d, toPlayer2d);
                    float AngleToApply = m_angularspeed * Time.fixedDeltaTime > Mathf.Abs(AngleBetweenVec) ? AngleBetweenVec : m_angularspeed * Time.fixedDeltaTime * Mathf.Sign(AngleBetweenVec);
                    transform.Rotate(Vector3.up, AngleToApply);
                    if(Time.time > m_timeForNextState)
                    {
                        m_currentState = STATE.STARTUP;
                        m_timeForNextState = Time.time + m_startupDuration;
                    }
                    break;
                case STATE.STARTUP:
                    if (Time.time > m_timeForNextState)
                    {
                        m_currentState = STATE.MOVING;
                        m_currentVelocity = transform.forward * m_speed;
                    }
                    break;
                case STATE.MOVING:
                    transform.position += m_currentVelocity * Time.fixedDeltaTime;
                    m_currentVelocity *= (1 - m_friction * Time.fixedDeltaTime);
                    if (m_currentVelocity.magnitude < m_minSpeed)
                    {
                        m_currentState = STATE.RECOVERY;
                        m_timeForNextState = Time.time + m_recoveryDuration;
                    }
                    break;
                case STATE.RECOVERY:
                    if (Time.time > m_timeForNextState)
                    {
                        m_currentState = STATE.AIMING;
                        m_timeForNextState = Time.time + m_aimingDuration;
                    }
                    break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //bounce
        if (other.gameObject.CompareTag("Wall"))
        {
            if(Time.time > m_timeToAllowBounce)
            {
                Vector3 wallRight = other.gameObject.transform.right;
                float AngleBetweenVec = Vector3.SignedAngle(transform.forward, wallRight, Vector3.up);
                m_currentVelocity = Quaternion.AngleAxis(AngleBetweenVec, Vector3.up) * wallRight * m_currentVelocity.magnitude;
                transform.Rotate(Vector3.up, AngleBetweenVec * 2.0f);
                m_timeToAllowBounce = Time.time + 0.1f;
            }
        }
    }

    #endregion
}
