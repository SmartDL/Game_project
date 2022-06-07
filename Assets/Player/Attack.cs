using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject HammorObject;
    public GameObject SwordObject;
    public bool Hammor_get = false;//if get the hammor?
    bool Hammor_On = false;
    bool Sword_On = true;
    WieldHammor Hammor;
    WieldSword Sword;
    public int Pattack = 2;
    float Timer = 0;
    GameText gameText;
    public bool finish_get = false;//used to delete the text
    // Start is called before the first frame update
    void Start()
    {
        Hammor = HammorObject.GetComponent<WieldHammor>();
        Sword = SwordObject.GetComponent<WieldSword>();
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameText = gameControllerObject.GetComponent<GameText>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z) && Hammor_On)
        {
            Sword_On = true;
            SwordObject.SetActive(true);
            Hammor_On = false;
            HammorObject.SetActive(false);
        }
        if (Input.GetKey(KeyCode.X))
        {
            if (Hammor_get && Sword_On)
            {
                Sword_On = false;
                SwordObject.SetActive(false);
                Hammor_On = true;
                HammorObject.SetActive(true);
            }
        }
        if (Timer > 0.3)
        {
            if (Input.GetKeyDown(KeyCode.E) && Hammor_On)
            {
                Hammor.Wield();
                Timer = 0;
            }
            if (Input.GetKeyDown(KeyCode.F) && Sword_On)
            {
                Sword.Wield(Pattack);
                Timer = 0;
            }
        }
        if (Input.GetKeyUp(KeyCode.E) && Hammor_On)
            Hammor.Wieldback();
        if (Input.GetKeyUp(KeyCode.F) && Sword_On)
            Sword.Wieldback();
        else
            Timer += Time.deltaTime;
        //Debug.Log(Timer);
        if (finish_get)
            if (Input.GetKeyUp(KeyCode.N))//Only the first time to do this
            {
                gameText.ChangeText("");
                finish_get = false;
            }
    }
}
