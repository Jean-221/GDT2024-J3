using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// depending on the gamefeel we might want to use physics someday, in that case Move should be an interface and TranslateMove and PhysicsMove should inherit from it

public class Move : MonoBehaviour
{

    #region Members

        /// <summary>
        /// Direction in which the entity will move
        /// </summary>
        [SerializeField]
        Vector3 m_vDir          = default;

        /// <summary>
        /// speed of the entity
        /// </summary>
        [SerializeField]
        float               m_fVelocity     = 1.0f;

        // at some point coordinate to reach with a pathfinding could be a good idea

    #endregion


    #region Unity methods


        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (m_vDir.magnitude != 0.0f)
            {
                // this may need to use the normal from the ground someday
                transform.position += m_vDir.normalized * m_fVelocity * Time.deltaTime;
            }
        }

    #endregion


    #region Public Members

        public void InputDir(Vector3 _vDir)
        {
            m_vDir = _vDir;
        }

    #endregion
}
