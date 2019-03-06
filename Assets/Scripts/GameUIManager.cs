using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameUIManager : MonoBehaviour {
    public static GameUIManager gameUI;
    public Slider healthBar, manaBar;
    public Text pickUpDescription;

    private void Awake()
    {
        if (gameUI != null)
            Destroy(gameObject);

        gameUI = this;
    }

    PlayerManager Player;
	// Use this for initialization
	void Start () {
        Player = PlayerManager.playerManager;
        healthBar.value = Player.playerHealth;
        manaBar.value = Player.playerMana;
	}
	
	public void UpdatePlayerHealthBar() {
        healthBar.value = Player.playerHealth;
	}

    public void UpdatePlayerManaBar()
    {
        manaBar.value = Player.playerMana;
    }
}
