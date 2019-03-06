using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum gender{
    male,
    female
}

public enum heroClass
{
    Paladin,
    Mage,
    Human,
    Orc
}

[System.Serializable]
public struct Character
{
    public string Name;
    public Sprite HUD_HeroImage;
    public List<Traits> Traits;
    public List<Powers> Powers;
    public HeroClass HeroClass;
    public Gender Gender;
}

[System.Serializable]
public struct Traits
{
    public Sprite HUD_traitimage;
    public string TraitName;
}

[System.Serializable]
public struct Powers
{
    public Sprite HUD_powerimage;
    public string PowerName;
}

[System.Serializable]
public struct HeroClass
{
    public Sprite HUD_heroclassimage;
    public heroClass ClassName;
}

[System.Serializable]
public struct Gender
{
    public Sprite HUD_Genderimage;
    public gender Hero_Gender;
}