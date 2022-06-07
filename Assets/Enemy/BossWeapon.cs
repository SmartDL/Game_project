using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    public GameObject gameControllerObject;
    // Start is called before the first frame update
    void Start()
    {

    }
    public int BossAtk = 5;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameStart gamestart = gameControllerObject.GetComponent<GameStart>();
            gamestart.PlayerHP -= BossAtk;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
