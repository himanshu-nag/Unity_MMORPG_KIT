using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDSelectionManager:MonoBehaviour{

    public Text hero_name;
    public Image hero_image;
    public Image hero_classimage;
    internal CharacterManager currentCM;

    private void Start()
	{
        var temp = currentCM.character;
        hero_name.text = temp.Name;
        hero_image.sprite = temp.HUD_HeroImage;
        hero_classimage.sprite = temp.HeroClass.HUD_heroclassimage;
	}

    public void Call() { currentCM.gameObject.SetActive(true); }
}
