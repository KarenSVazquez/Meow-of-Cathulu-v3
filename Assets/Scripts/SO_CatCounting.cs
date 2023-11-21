using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scriptable Objects", menuName = "CatCounter", order = 0)]
public class SO_CatCounting : ScriptableObject
{
    public int CatNumber;
    public int CatGoal;
    public Sprite[] dialogueImages; // todos los npc van a tener la misma xcantidad de img
    public bool IsCathuluVisible;
    public Vector3 NPCPosition;

}
