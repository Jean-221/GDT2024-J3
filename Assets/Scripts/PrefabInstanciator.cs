using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabInstanciator : MonoBehaviour
{
    public GameObject           m_cToInst               = null;
    
    [SerializeField]
    protected float             m_fTimeToSpawn          = 1;

    protected float             m_fCountDown            = -1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_fCountDown < 0.0f)
        {
            if (m_cToInst)
            {
                GameObject.Instantiate(m_cToInst, transform.position, transform.rotation);
            }
            m_fCountDown = m_fTimeToSpawn;
        }
        else
        {
            m_fCountDown -= Time.deltaTime;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.2f);
    }
}
