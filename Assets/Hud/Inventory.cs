using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public event EventHandler<InventoryEventArgs> ItemAdded;
    public event EventHandler<InventoryEventArgs> ItemUsed;
    public event EventHandler<InventoryEventArgs> ItemRemoved;

    List<IInventoryItem> items = new List<IInventoryItem>();
    public void addItem(IInventoryItem item)
    {
        if(items.Contains(item))
        {
            Debug.Log("item  already picked up");
            return;
        }
        items.Add(item);
        item.onPickup();
        ItemAdded?.Invoke(this, new InventoryEventArgs(item));
    }
    public void useItem(IInventoryItem item)
    {
        ItemUsed?.Invoke(this, new InventoryEventArgs(item));
    }
    public void removeItem(IInventoryItem item)
    {
        items.Remove(item);
        ItemRemoved?.Invoke(this, new InventoryEventArgs(item));
    }
}
