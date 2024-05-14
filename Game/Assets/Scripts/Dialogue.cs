using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue : MonoBehaviour
{
    [Header("Имя NPC")]
    public string Name;
    [Header("Имя Игрового персонажа")]
    public string MainName = "Токугава";
    [TextArea(3, 10), Header("Диалог")]
    public string[] Sentences;
    [HideInInspector]public bool Started = false, PlayOnce = false, Change;
    [Header("Диалог можно воспроизвести несколько раз?")]
    public bool Cyclic = true;
    [Header("Это монолог?")]
    public bool Monologue = false;
}
