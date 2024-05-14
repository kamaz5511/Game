using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityArea : MonoBehaviour
{
    private IEnermy EnemyOwner;
    private bool InSeeArea = false;
    [SerializeField] private float CloseDistance = 5;

    private void Start()
    {
        EnemyOwner = transform.parent.GetComponent<IEnermy>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Movement>() != null && !Movement.Instance.Hidden)
        {
           EnemyOwner.OnSeePlayer();
            StartCoroutine(CheckDistance());
            InSeeArea = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Movement>() != null)
        {
            EnemyOwner.OnStopSeePlayer();
            InSeeArea=false;
        }
    }
    private IEnumerator CheckDistance()
    {
        yield return new WaitUntil(() => Vector2.Distance(transform.position, Movement.Instance.transform.position) <= CloseDistance);
        if (!Movement.Instance.Hidden)
        {
            EnemyOwner.OnPlayerClose();
            StartCoroutine(CheckDistanceGap());
        }
        yield break;

    }
    private IEnumerator CheckDistanceGap()
    {
        yield return new WaitUntil(() => Vector2.Distance(transform.position, Movement.Instance.transform.position) > CloseDistance);
        EnemyOwner.OnPlayerNotClose();
        if (InSeeArea)
        {
            StartCoroutine(CheckDistance());
            yield break;
        }
            yield break;

    }
}
