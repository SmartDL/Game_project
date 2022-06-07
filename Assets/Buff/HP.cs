using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public GameObject GameController;
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            GameStart gamestart = GameController.GetComponent<GameStart>();
            gamestart.PlayerHP += 5;
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
