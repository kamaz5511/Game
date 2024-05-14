using Cinemachine;
using UnityEngine;

public class Lever : MonoBehaviour, IUsable
{
    [SerializeField] private Gates Gate;
    public void Use()
    {
        if (Gate != null) Gate.Open();
        //Cinemachin
    }
}
