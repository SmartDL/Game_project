using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public enum EnemyState
{
    idle,
    run,
    attack
}
public class EnemyController : MonoBehaviour
{
    public EnemyState CurrentState = EnemyState.idle;
    public GameObject gameControllerObject;
    private NavMeshAgent agent;
    public GameObject hitPosition;
    public GameObject back;
    private GameObject player;
    public int HP = 6;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        switch (CurrentState)
        {
            case EnemyState.idle:
                if (distance >= 1.5 && distance <= 7)
                    CurrentState = EnemyState.run;
                agent.isStopped = true;
                break;
            case EnemyState.run:
                if (distance > 7)
                    CurrentState = EnemyState.idle;
                if (distance < 1.5)
                    CurrentState = EnemyState.attack;
                agent.isStopped = false;
                agent.SetDestination(player.transform.position);
                break;
            case EnemyState.attack:
                if (distance >= 1.5 && distance <= 7)
                    CurrentState = EnemyState.run;
                if (distance > 7)
                    CurrentState = EnemyState.idle;
                agent.isStopped = true;
                attack1();
                break;
        }
    }
    void attack1()
    {
        Transform b = back.transform;
        GameObject gameObject;
        RaycastHit colliderHit;
        GameStart gamestart = gameControllerObject.GetComponent<GameStart>();
        if (Physics.Raycast(hitPosition.transform.position, hitPosition.transform.forward, out colliderHit, 2))
        {
            gameObject = colliderHit.collider.gameObject;
            Debug.Log(gameObject.tag);
            if (gameObject.tag == "Player")
            {
                gamestart.PlayerHP -= 2;
                agent.Warp(b.position);
            }
        }
        //Debug.Log(gamestart.PlayerHP);
    }
}
