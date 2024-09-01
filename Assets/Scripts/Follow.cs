using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    #region members

        [SerializeField]
        GameObject              m_goTarget                  = null;

        [SerializeField]
        Vector3                 m_vOffset                   = Vector3.zero;

        [SerializeField]
        float                   m_fTopSpeed                 = 0.0f;

        [SerializeField]
        float                   m_fMinSpeed                 = 0.0f;

        private Vector3 m_vTargetPosition = Vector3.zero;
        private Vector3 m_fCurrentSpeed = Vector3.zero;

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Todo add delay and lerp for smooth acceleration and deceleration
        m_vTargetPosition = m_goTarget.transform.position + m_vOffset;

        Vector3 toTarget = m_vTargetPosition - transform.position;

        m_fCurrentSpeed = toTarget / 0.8f;
        if(m_fCurrentSpeed.magnitude > m_fTopSpeed)
            m_fCurrentSpeed = m_fCurrentSpeed.normalized * m_fTopSpeed;

        if (m_fCurrentSpeed.magnitude < m_fMinSpeed)
            m_fCurrentSpeed = m_fCurrentSpeed.normalized * m_fMinSpeed;

        transform.position += m_fCurrentSpeed * Time.fixedDeltaTime;
        transform.position = new Vector3(transform.position.x, m_vTargetPosition.y, transform.position.z);

    }
}
