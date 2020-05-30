using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tactic
{
   public class CharacterData
    {
        string prefab;
        string position;

        public CharacterData(string prefab, string position)
        {
            this.Prefab = prefab;
            this.Position = position;
        }

        public string Prefab { get => prefab; set => prefab = value; }
        public string Position { get => position; set => position = value; }
    }

    List<CharacterData> characterDatas = new List<CharacterData>();

    public List<CharacterData> CharacterDatas { get => characterDatas; set => characterDatas = value; }

    public Tactic(CharacterData[] characterDatas)
    {
        foreach(CharacterData cd in characterDatas)
        {
            this.CharacterDatas.Add(cd);
        }
    }

    public Tactic(string filePath)
    {

    }
}
