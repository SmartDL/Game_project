using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//collect the hammor
public class Hammorkey : MonoBehaviour
{    
    public GameObject player;
    Attack h;
    //bool finish = false;
    GameText gameText;
    string text1 = "Press 'X' to switch to the Hammor.\n\n" +
        "Press 'Z' to switch back.\n\n"+
        "Press 'E' to use the Hammor break the fragile wall in front of you.\n\n"+
        "<size=20><color=grey>Press 'N' Next</color></size>";
    // Start is called before the first frame update
    void Start()
    {
        h = player.GetComponent<Attack>();
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameText = gameControllerObject.GetComponent<GameText>();
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            h.Hammor_get = true;
            h.finish_get = true;
            gameText.ChangeText(text1);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
