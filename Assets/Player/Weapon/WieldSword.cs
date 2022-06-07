using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WieldSword : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private IEnumerator WeaponAni(int targetAngle, int targetAngle2, int animationSpeed)
    {
        for (int r = 0; r < animationSpeed; r += 1)
        {
            transform.localEulerAngles = new Vector3(Mathf.LerpAngle(transform.localEulerAngles.y, targetAngle, 5f / animationSpeed), targetAngle2, 30);
            yield return null;
        }
    }
    public GameObject hitPosition;
    public float Distance = 2.5f;
    public AudioSource Hitting;
    public void Wield(int Pattack)
    {
        GameObject gameObject;
        StartCoroutine(WeaponAni(-90, 150, 5));
        RaycastHit colliderHit;
        if (Physics.Raycast(hitPosition.transform.position, hitPosition.transform.forward, out colliderHit, Distance))
        {
            gameObject = colliderHit.collider.gameObject;
            Debug.Log(gameObject.tag);
            if (gameObject.tag == "Enemy")
            {
                Hitting.Play(); //sound
                if (gameObject.GetComponent<EnemyController>().HP <= Pattack)
                    Destroy(gameObject);
                if (gameObject.GetComponent<EnemyController>().HP > Pattack)
                    gameObject.GetComponent<EnemyController>().HP -= Pattack;
            }
            if (gameObject.tag == "Boss")
            {
                Hitting.Play(); //sound
                //Debug.Log(gameObject.GetComponent<Hitted>().HP);
                if (gameObject.GetComponent<Boss>().HP <= Pattack)
                    Destroy(gameObject);
                if (gameObject.GetComponent<Boss>().HP > Pattack)
                    gameObject.GetComponent<Boss>().HP -= Pattack;
            }
        }
    }
    public void Wieldback()
    {
        StartCoroutine(WeaponAni(0, 170, 5));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
