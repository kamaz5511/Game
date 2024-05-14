using UnityEngine;

public class LadderDrop : MonoBehaviour, IUsable
{
    [SerializeField] private GameObject Ladder;
    public void Use()
    {
        Ladder.SetActive(true);
    }
}
