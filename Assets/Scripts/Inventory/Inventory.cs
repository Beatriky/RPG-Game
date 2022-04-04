using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{  

#region Singleton
    public static Inventory instance;
    void Awake (){
        if( instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found!");
            return;
        }
        instance = this;
    }
#endregion
   
    public int space = 20;
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public List<Item> items = new List<Item>();

    public bool Add (Item item)
	{
		// Don't do anything if it's a default item
		if (!item.isDefaultItem)
		{
			// Check if out of space
			if (items.Count >= space)
			{
				Debug.Log("Not enough room.");
				return false;
			}

			items.Add(item);	// Add item to list

			if (onItemChangedCallback != null)
				onItemChangedCallback.Invoke();
		}

		return true;
	}

	// Remove an item
	public void Remove (Item item)
	{
		items.Remove(item);		// Remove item from list

		if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke();
	}

}