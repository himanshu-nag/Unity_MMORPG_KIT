using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour {
    public static MenuUIManager UIMenuManager;
    #region public variables
    public Text currenthero_nameLbl;
    public Text currenthero_classLbl;
    public Image currenthero_classImg;
    public Image currenthero_GenderImg;
    public Transform currenthero_power, currenthero_trait;
    public List<Image> _powerImg;
    public List<Image> _traitImg;

    public InputField display_NameTxt;

    public Transform CharacterList;
    public GameObject SelectionPanelHUD;

    CharacterManager currentIndex;
    #endregion

    private void Awake()
	{
        if (UIMenuManager != null)
            Destroy(gameObject);

        UIMenuManager = this;
	}

	private void Start()
	{
        foreach (CharacterManager item in MenuManager.manager.characters)
        {
            GameObject sHUD =  Instantiate(SelectionPanelHUD.gameObject,CharacterList);
            sHUD.GetComponent<HUDSelectionManager>().currentCM = item;
        }

        foreach (Transform item in currenthero_power)
        {
            _powerImg.Add(item.GetComponent<Image>());
        }

        foreach (Transform item in currenthero_trait)
        {
            _traitImg.Add(item.GetComponent<Image>());
        }
    }

    public void SelectCharacter(CharacterManager Character)
    {
        if (currentIndex != null)
            currentIndex.gameObject.SetActive(false);
        currentIndex = Character;
        var character = Character.character;
        currenthero_nameLbl.text = character.Name;
        currenthero_classLbl.text = character.HeroClass.ClassName.ToString();
        currenthero_classImg.sprite = character.HeroClass.HUD_heroclassimage;
        currenthero_GenderImg.sprite = character.Gender.HUD_Genderimage;
        if(Refresh())
        {
            var index = 0;
            foreach (var item in character.Powers)
            {
                _powerImg[index].sprite = item.HUD_powerimage;
                _powerImg[index].gameObject.SetActive(true);
                index += 1;
            }

            index = 0;
            foreach (var item in character.Traits)
            {
                _traitImg[index].sprite = item.HUD_traitimage;
                _traitImg[index].gameObject.SetActive(true);
                index += 1;
            }
        }
    }

    public bool Refresh()
    {
        foreach (Transform item in currenthero_power)
        {
            item.gameObject.SetActive(false);
        }

        foreach (Transform item in currenthero_trait)
        {
            item.gameObject.SetActive(false);
        }

        return true;    
    }
}
