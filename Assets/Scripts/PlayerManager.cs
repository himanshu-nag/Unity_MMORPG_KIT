using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    public const int STARTVALUE = 10;
    internal bool ifNoSaveFound= true;
    public static PlayerManager playerManager;
    internal int playerHealth,playerhealthMAX, playerMana,playerManaMAX;
    public KeyCode itemPickUpKey;

    PickUpObjectScript PickUpObject;
    InventoryUIManager inventoryUI;
    private void Awake()
    {
        if (playerManager != null)
            Destroy(gameObject);

        playerManager = this;
        if (ifNoSaveFound)
        {
            playerHealth = STARTVALUE;
            playerMana = STARTVALUE;
            playerhealthMAX = 100;
            playerManaMAX = 100;
        }
    }

    private void Start()
    {
        PickUpObject = new PickUpObjectScript();
        inventoryUI = InventoryUIManager.InventoryUI;
    }

    int keyCodeResult;
	public void Update()
	{
        if (Input.anyKeyDown)
        {
            if (int.TryParse(Input.inputString,out keyCodeResult))
            {
                inventoryUI.inventory.UseItem(keyCodeResult);
            }

        }
	}
}
