using UnityEngine;

public class FallingStone : MonoBehaviour
{
    [SerializeField] private int GroundLayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == GroundLayer)
        {
            Destroy(gameObject);
        }
    }
}
