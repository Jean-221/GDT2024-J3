using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Input and Ai could have a common base class

public class BasicAI : MonoBehaviour
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
            GameObject player = BadTimeSavingGameManager.m_cInstance.m_goPlayer;

            if (player)
            {
                m_vInputs = player.transform.position - transform.position;
                m_cMoveComponent.InputDir(m_vInputs);
            }
        }

    #endregion
}
