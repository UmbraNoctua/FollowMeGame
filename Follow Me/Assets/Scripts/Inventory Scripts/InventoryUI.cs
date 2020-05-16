using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    //Inventory inventory; //script does not like the word inventory, despite the Canvas being a parent of inventory

    void Start()
    {
      //  inventory = Inventory.instance;
       // inventory.onItemChangedCallback += UpdateUI;
    }

    // Update is called once per frame
    void Update ()
    {
        
    }

    void UpdateUI ()
    {
        Debug.Log("UPDATING UI");
    }

}
