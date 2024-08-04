using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBulletAi : MonoBehaviour
{
    #region Members

        Move m_cMoveComponent = null;

        Vector3 m_vInputs = Vector3.zero;

    #endregion


    #region Unity Methods

        // Start is called before the first frame update
        void Start()
        {
            m_cMoveComponent = gameObject.GetComponent<Move>();
        }

        // Update is called once per frame
        void Update()
        {
            m_vInputs = transform.forward;
            m_cMoveComponent.InputDir(m_vInputs);

            // Bad need cleaning
            if ((BadTimeSavingGameManager.m_cInstance.m_goPlayer.transform.position - transform.position).magnitude > 50)
            {
                Destroy(gameObject);
            }
        }

    #endregion
}
