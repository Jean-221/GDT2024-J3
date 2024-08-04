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

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Todo add delay and lerp for smooth acceleration and deceleration
        transform.position = m_goTarget.transform.position + m_vOffset;


    }
}
