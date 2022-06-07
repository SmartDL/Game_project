using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WieldHammor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private IEnumerator WeaponAni(int targetAngle, int animationSpeed)
    {
        for (int r = 0; r < animationSpeed; r += 1)
        {
            transform.localEulerAngles = new Vector3(25, 70, Mathf.LerpAngle(transform.localEulerAngles.y, targetAngle, 5f / animationSpeed));
            yield return null;
        }
    }
    public GameObject hitPosition;
    public float Distance = 2.5f;
    public AudioSource Hitting;
    public void Wield()
    {
        GameObject gameObject;
        StartCoroutine(WeaponAni(90, 2));
        RaycastHit colliderHit;
        if (Physics.Raycast(hitPosition.transform.position, hitPosition.transform.forward, out colliderHit, Distance))
        {
            gameObject = colliderHit.collider.gameObject;
            Hitting.Play();
            //Debug.Log(gameObject.tag);
            if (gameObject.tag == "Wall1")
            {
                Destroy(gameObject);
            }
        }
    }
    public void Wieldback()
    {
        StartCoroutine(WeaponAni(0, 2));
    }
    // Update is called once per frame
    void Update()
    {

    }
}
