using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryEventHandler : MonoBehaviour
{
    public void ResumeGame()
    {
        FindObjectOfType<Inventory>().DisableInventory();
    }
}
