using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameStart : MonoBehaviour
{
    public GameObject GameController;
    GameObject player;
    GameText gameText;
    // Start is called before the first frame update
    string text1 = "Dear Friend,\n\nYou are a <i>Warrior</i> here to save your <i>Princess</i>.\n" +
            "She has been taken into this <i>Ruin</i> by the enemy for a day.\n<color=red>No time to waste!</color>\n" + 
            "<size=20><color=grey>Press 'N' Next</color></size>";
    string text2 = "Press 'W', 'A', 'S', 'D' to move\n\nPress 'F' to attack by sword\n\n" + 
        "<size=20><color=grey>Press 'N' Next</color></size>";
    string text3 = "\nYou saved your Princess!\n\n<size=20><color=grey>Press 'N' Restart the game</color></size>";
    string text4 = "DIED\n\n<size=20><color=grey>Press 'N' Restart the game</color></size>";
    int i = 0;
    public int PlayerHP = 10;
    void Start()
    {
        gameText = GameController.GetComponent<GameText>();
        player = GameObject.FindWithTag("Player");
        Cursor.lockState = CursorLockMode.Locked;
        gameText.ChangeText(text1);
        i = 1;
    }
    bool won = false;
    bool die = false;
    public GameObject WonButton1;
    // Update is called once per frame
    void Update()
    {
        GameObject Boss1 = GameObject.FindWithTag("Boss");
        if(WonButton1.GetComponent<WonButton>().won)
            if (!Boss1)
            {
                gameText.ChangeText(text3);
                won = true;
                Time.timeScale = 0;
            }
        if (PlayerHP <= 0)
        {
            gameText.ChangeText(text4);
            die = true;
            Time.timeScale = 0;
        }
        if (Input.GetKey(KeyCode.N) && (won || die))
            SceneManager.LoadScene(0);
        if (i < 3)
            if (Input.GetKeyUp(KeyCode.N) && i == 1)
            {
                gameText.ChangeText(text2);
                i++;
            }
            else if (Input.GetKeyUp(KeyCode.N) && i == 2)
            {
                gameText.ChangeText("");
                i++;
            }
    }
}
