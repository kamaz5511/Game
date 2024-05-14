using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private PlatformEffector2D Effector;
    private Coroutine coroutine;

    private void Start()
    {
        Effector = GetComponent<PlatformEffector2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Movement>() != null)
        {
            if(Movement.Instance.transform.position.y < transform.position.y)Movement.Instance.CanJump = false;
            coroutine = StartCoroutine(WaitForClick());
        } 
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Movement>() != null)
        {
            Movement.Instance.CanJump = true;
            StopCoroutine(coroutine);
            if(Effector == null)
            {
                Effector = GetComponent<PlatformEffector2D>();
            }
            Effector.rotationalOffset = 0;
        }
    }
    private IEnumerator WaitForClick()
    {
        yield return new WaitUntil(() => Input.GetAxis("Vertical") < 0 && transform.position.y < Movement.Instance.transform.position.y);
        if(transform.position.y < Movement.Instance.transform.position.y)Effector.rotationalOffset = 180;
        yield break;
    }
}
