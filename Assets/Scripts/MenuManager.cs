using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {
    public static MenuManager manager;

    #region manager variables
    public List<CharacterManager> characters;
    public Transform spawnPoint;
    internal static string display_name;
    #endregion

    private void Awake()
	{
        if (manager != null)
            Destroy(gameObject);

        manager = this;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
