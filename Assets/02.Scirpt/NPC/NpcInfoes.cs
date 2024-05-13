using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "NpcInfoes", menuName = "Npc/Infoes/Default", order = 0)]
public class NpcInfoes : ScriptableObject
{
    public int NpcNumber;
    public string NpcName;
    public Sprite NpcSprite;
    public List<string> NpcDialogues;
}
