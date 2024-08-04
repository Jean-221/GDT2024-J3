using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bas solution, there are existing solution that might be better
// Input and Ai could have a common base class

public class InputCatch : MonoBehaviour
{
    #region Members

        Move            m_cMoveComponent            = null;

        Vector3         m_vInputs                   = Vector3.zero;                   

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
            m_vInputs.x = Input.GetAxis("Horizontal");
            m_vInputs.z = Input.GetAxis("Vertical");

            m_cMoveComponent.InputDir(m_vInputs);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit info;
            Physics.Raycast(ray, out info, 100.0f, LayerMask.GetMask("Ground"));

            transform.LookAt(info.point + Vector3.up);
        }

    #endregion
}
