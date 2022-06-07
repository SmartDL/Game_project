using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atk : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Attack>().Pattack += 2; 
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
