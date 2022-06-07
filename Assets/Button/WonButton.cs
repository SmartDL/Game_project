using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WonButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public bool won = false;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            won = true;
        } 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
