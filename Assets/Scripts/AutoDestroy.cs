using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField]
    private float m_duration = 1.0f;

    private float m_timeToDestroy = 0.0f;
    void Start()
    {
        m_timeToDestroy = Time.time + m_duration;
    }


    void Update()
    {
        if(Time.time > m_timeToDestroy)
        {
            Destroy(gameObject);
        }
    }
}
