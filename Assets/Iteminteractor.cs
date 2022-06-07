using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iteminteractor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Inventory inventory;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        IInventoryItem item = hit.gameObject.GetComponent<IInventoryItem>();
        if(item!=null)
        {
            inventory.addItem(item); // where inventory is the inventory object ref
        }
    }
}
