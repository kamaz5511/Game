using System.Collections;
using UnityEngine;

public class PointPlatform : Platform
{
    [SerializeField] private Transform[] Points;
    [SerializeField] private float Speed = 2f;
    private int Count;
    private void Start()
    {
        StartCoroutine(MoveTo(Points[Count]));
        StartCoroutine(CheckPosition(Points[Count]));
    }
    private IEnumerator MoveTo(Transform target)
    {
        while (transform.position != target.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
            yield return null;
        }
    }
    private IEnumerator CheckPosition(Transform target)
    {
        yield return new WaitUntil(() => Vector2.Distance(transform.position, target.position) < 0.1f);
        StopAllCoroutines();
        Count++;
        if(Count >= Points.Length)
        {
            Count = 0;
        }
        StartCoroutine(MoveTo(Points[Count]));
        StartCoroutine(CheckPosition(Points[Count]));
        yield break;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Movement>() != null)
        {
            Movement.Instance.transform.SetParent(transform, true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Movement>() != null)
        {
            if (gameObject.activeSelf == true) Movement.Instance.transform.SetParent(null, true);
        }
    }
}
