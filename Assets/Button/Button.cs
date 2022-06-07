using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Button : MonoBehaviour
{
    public GameObject GameController;
    GameText gameText;
    string text = "\nSome <i>Doors</i> Open.\n\n<size=20><color=grey>Press 'N' Next</color></size>";
    // Start is called before the first frame update
    void Start()
    {
        gameText = GameController.GetComponent<GameText>();
    }
    public GameObject doorObject1;
    public GameObject doorObject2;
    bool open = false;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Player")
        {
            Destroy(doorObject1);
            if (doorObject2 != null)
                Destroy(doorObject2);
            gameText.ChangeText(text);
            open = true;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (open && Input.GetKeyUp(KeyCode.N))
        {
            gameText.ChangeText("");
            open = false;
        }   
    }
}
