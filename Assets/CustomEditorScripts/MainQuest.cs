using UnityEngine;
using System;

[Serializable]
public class MainQuest {
    public enum QuestType{
        Talk,
        Kill,
        Collect
    }
    public GameObject color;
    public QuestType position;
}