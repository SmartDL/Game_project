using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameText : MonoBehaviour
{
    public GameObject gameController;
    public GameObject player;
    public GameObject TextObject;
    public GameObject TextObjectHP;
    int HP;
    int ATK;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ChangeText(string text)
    {
        TextObject.GetComponent<TMP_Text>().text = text;
    }
    // Update is called once per frame
    void Update()
    {
        HP = gameController.GetComponent<GameStart>().PlayerHP;
        ATK = player.GetComponent<Attack>().Pattack;
        string texthp = "HP: " + HP.ToString() + "\nATK: " + ATK.ToString();
        TextObjectHP.GetComponent<TMP_Text>().text = texthp;
    }
}
