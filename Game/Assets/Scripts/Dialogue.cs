using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue : MonoBehaviour
{
    [Header("��� NPC")]
    public string Name;
    [Header("��� �������� ���������")]
    public string MainName = "��������";
    [TextArea(3, 10), Header("������")]
    public string[] Sentences;
    [HideInInspector]public bool Started = false, PlayOnce = false, Change;
    [Header("������ ����� ������������� ��������� ���?")]
    public bool Cyclic = true;
    [Header("��� �������?")]
    public bool Monologue = false;
}
