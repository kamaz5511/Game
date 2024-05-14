using UnityEngine;

public class Ladder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Movement>() != null)
        {
            collision.GetComponent<Movement>().IsTouchingLadder = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Movement>() != null)
        {
            collision.GetComponent<Movement>().IsTouchingLadder = false
                
                ;
        }
    }
}
