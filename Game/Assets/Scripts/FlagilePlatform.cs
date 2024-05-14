using System.Collections;
using UnityEngine;

public class FlagilePlatform : MonoBehaviour
{
    [SerializeField] private float TimeToDestroy = 1f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Movement>() != null)
        {
            StartCoroutine(Destroy());
        }
    }
    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(TimeToDestroy);
        Destroy(gameObject);
    }
}
