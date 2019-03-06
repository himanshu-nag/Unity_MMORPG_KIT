using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public Character character;

    public delegate void onActive();
    onActive characterSelected;

    [HideInInspector]
    internal GameObject CharacterPrefab;

    private void Awake()
    {
        characterSelected += CharacterManager_CharacterSelected;
        CharacterPrefab = this.gameObject;
    }

    void CharacterManager_CharacterSelected()
    {
        MenuUIManager.UIMenuManager.SelectCharacter(this);
    }

    private void OnEnable()
	{
        characterSelected();
	}
}

