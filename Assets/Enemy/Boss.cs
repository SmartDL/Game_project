using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public enum BossState
{
    stay,
    crash,
    attack1
}
public class Boss : MonoBehaviour
{
    public BossState CurrentState = BossState.stay;

    public GameObject gameControllerObject;
    private NavMeshAgent agent;
    private GameObject player;

    public GameObject craPosition1; //detect crash
    public GameObject craPosition2;
    public GameObject craPosition3;
    public GameObject back;

    public GameObject arml; //left arm
    public GameObject armr; //right arm

    public int HP = 48;
    float time_stay = 0;
    float time_attack = 0;
    float time_crash = 0;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
    }
    public int BossCra = 7;

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        Transform b = back.transform;
        //Debug.Log("stay");
        //Debug.Log(time_stay);
        //Debug.Log("crash");
        //Debug.Log(time_crash);
        switch (CurrentState)
        {
            case BossState.stay:
                time_stay += Time.deltaTime;
                if (distance >= 5 && distance <= 13 && time_stay > 3)
                    CurrentState = BossState.crash;
                if (distance < 5 && time_stay >3)
                    CurrentState = BossState.attack1;
                agent.isStopped = true;
                break;
            case BossState.crash:
                time_stay = 0;
                time_crash += Time.deltaTime;
                if (time_crash > 7)
                {
                    agent.Warp(b.position);
                    CurrentState = BossState.stay;
                    time_crash = 0;
                }
                agent.isStopped = false;
                agent.SetDestination(player.transform.position);
                crash1();
                break;
            case BossState.attack1:
                time_stay = 0;
                time_attack += Time.deltaTime;

                if (time_attack > 5)
                {
                    agent.Warp(b.position);
                    time_attack = 0;
                }
                if (distance >= 5 && distance <= 13)
                    CurrentState = BossState.crash;
                if (distance > 13)
                    CurrentState = BossState.stay;
                Attack1();
                break;
        }

    }
    private IEnumerator CrashAni(int targetAngle, int animationSpeed)
    {
        for (int r = 0; r < animationSpeed; r += 1) // left
        {
            arml.transform.localEulerAngles = new Vector3(Mathf.LerpAngle(transform.localEulerAngles.y, targetAngle, 5f / animationSpeed), 0, -30);
            yield return null;
        }
        for (int r = 0; r < animationSpeed; r += 1)
        {
            armr.transform.localEulerAngles = new Vector3(Mathf.LerpAngle(transform.localEulerAngles.y, targetAngle, 5f / animationSpeed), 180, -30);
            yield return null;
        }
    }

    private IEnumerator AttackAni(int targetAngle, int animationSpeed)
    {
        for (int r = 0; r < animationSpeed; r += 1) // left
        {
            arml.transform.localEulerAngles = new Vector3(Mathf.LerpAngle(transform.localEulerAngles.y, targetAngle, 5f / animationSpeed), 0, -30);
            yield return null;
        }
        for (int r = 0; r < animationSpeed; r += 1)
        {
            armr.transform.localEulerAngles = new Vector3(Mathf.LerpAngle(transform.localEulerAngles.y, targetAngle, 5f / animationSpeed), 180, -30);
            yield return null;
        }
    }
    void crash1()
    {
        GameObject gameObject;
        Transform b = back.transform;
        GameStart gamestart = gameControllerObject.GetComponent<GameStart>();
        StartCoroutine(CrashAni(0, 5));
        RaycastHit colliderHit1;
        RaycastHit colliderHit2;
        RaycastHit colliderHit3;
        if (Physics.Raycast(craPosition1.transform.position, craPosition1.transform.forward, out colliderHit1, 3))
        {
            gameObject = colliderHit1.collider.gameObject;
            if (gameObject.tag == "Player")
            {
                gamestart.PlayerHP -= BossCra;
                agent.Warp(b.position);
                CurrentState = BossState.stay;
                //Time.timeScale = 0;
            }
        }
        else if (Physics.Raycast(craPosition2.transform.position, craPosition2.transform.forward, out colliderHit2, 3))
        {
            gameObject = colliderHit2.collider.gameObject;
            if (gameObject.tag == "Player")
            {
                gamestart.PlayerHP -= BossCra;
                agent.Warp(b.position);
                CurrentState = BossState.stay;
            }
        }
        else if (Physics.Raycast(craPosition3.transform.position, craPosition3.transform.forward, out colliderHit3, 3))
        {
            gameObject = colliderHit3.collider.gameObject;
            if (gameObject.tag == "Player")
            {
                gamestart.PlayerHP -= BossCra;
                agent.Warp(b.position);
                CurrentState = BossState.stay;
            }
        }
    }
    void Attack1()
    {
        arml.transform.Rotate(Vector3.right * time_attack * 20);
        armr.transform.Rotate(Vector3.right * time_attack * 20);
        agent.isStopped = true;
    }
}
