using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private IEnumerator DoorAnimation(int targetAngle, int animationSpeed)
    {
        for (int r = 0; r < animationSpeed; r += 1)
        {
            transform.localEulerAngles = new Vector3(1, Mathf.LerpAngle(transform.localEulerAngles.y, targetAngle,
                5f / animationSpeed), 0);
            yield return null;
        }
    }
    public void Open()
    {
        StartCoroutine(DoorAnimation(90, 2));
        //Debug.Log("opening");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
