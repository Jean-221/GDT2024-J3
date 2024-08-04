using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadTimeSavingGameManager : MonoBehaviour
{
    #region Members

        public GameObject                           m_goPlayer              = null;

        public List<GameObject>                     m_goEnnemies            = new List<GameObject>();

        public static BadTimeSavingGameManager      m_cInstance             = null; 

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        m_cInstance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
