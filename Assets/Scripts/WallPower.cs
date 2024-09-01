using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPower : MonoBehaviour
{
    [SerializeField]
    private float m_cooldown = 0.0f;

    [SerializeField]
    private GameObject m_wallPrefab;

    private float m_timeToAllowSpawn = 0.0f;

    public void SpawnWall()
    {
        if(Time.time > m_timeToAllowSpawn)
        {
            Debug.Log("spawnWall");
            Instantiate(m_wallPrefab, transform.position + transform.forward * 2.5f, Quaternion.FromToRotation(Vector3.forward, transform.forward));
            m_timeToAllowSpawn = Time.time + m_cooldown;
        }
    }
}
