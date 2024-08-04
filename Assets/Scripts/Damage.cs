using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO prevent friendly fire

public class Damage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Damageable>())
        { 
            Destroy(other.gameObject);
            Debug.Log("go : " + gameObject + " kills : " + other.gameObject);
        }
    }
}
