using System.Collections;
using UnityEngine;

public class Patrol : MonoBehaviour,IEnermy
{
    private Transform _transform;
    private Vector2 PatrolPoint;
    private Coroutine _Coroutine;
    [SerializeField] private float Speed = 2f,PatrolDistance = 5f,WaitTimeOnBorder = 0f;
    private bool PlayerClose = false;
    public void OnPlayerClose()
    {
        Debug.Log("Игрок близко");
        PlayerClose = true;
    }
    public void OnSeePlayer()
    {
         StopAllCoroutines();
        StartCoroutine(ChasePlayer());
    }

    public void OnStopSeePlayer()
    {
        PlayerClose=false;
        StopAllCoroutines();
        StartCoroutine(GoToPatrolPlace());
    }

    private void Start()
    {
        _transform = GetComponent<Transform>();
        PatrolPoint = transform.position;
        _Coroutine = StartCoroutine(Move());
        StartCoroutine(TurnAtBorder());
    }
    private IEnumerator Move()
    {
        while (true) {
            _transform.Translate(Vector2.right * Speed * Time.deltaTime);
            yield return null;
        }
    }
    private IEnumerator TurnAtBorder()
    {
        yield return new WaitUntil(() => transform.position.x > PatrolPoint.x + PatrolDistance);
        StopCoroutine(_Coroutine);
        yield return new WaitForSeconds(WaitTimeOnBorder);
        _Coroutine = StartCoroutine(Move());
        Flip(180);
        yield return new WaitUntil(() => transform.position.x < PatrolPoint.x - PatrolDistance);
        StopCoroutine(_Coroutine);
        yield return new WaitForSeconds(WaitTimeOnBorder);
        _Coroutine = StartCoroutine(Move());
        Flip(0);
        StartCoroutine(TurnAtBorder());
        yield break;
    }
    private void Flip(float Angel)
    {
      _transform.eulerAngles = new Vector3(0, Angel, 0);
    }
    private IEnumerator ChasePlayer()
    {
        while (true)
        {
            GoToPlayer();
            if (Movement.Instance.Hidden)
            {
                while(Vector2.Distance(transform.position, Movement.Instance.transform.position) >= 1)
                {
                    GoToPlayer();
                    yield return null;
                }
                if (PlayerClose) {
                    Debug.Log("Игрок спрятался, достать из куста");
                    UnHidePlayer();
                    yield break;
                }
                else
                {
                    Debug.Log("Игрок спрятался, подождлать и уйти");
                    yield return new WaitForSeconds(2);
                    //Анимация осмотра по сторонам
                    StartCoroutine(GoToPatrolPlace());
                    yield break;
                }
            }
            yield return null;
        }
    }
    private void GoToPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(Movement.Instance.transform.position.x, transform.position.y), Speed * Time.deltaTime);
    }
    private void UnHidePlayer()
    {
         Movement player = Movement.Instance;
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.UnFreeze();
        player.Physick.gravityScale = 1f;
        player.GetComponent<Collider2D>().isTrigger = false;
        player.Hidden = false;
    }
    private IEnumerator GoToPatrolPlace()
    {
        if (transform.eulerAngles.y == 0)
        {
            Flip(180);
        }
        else
        {
            Flip(0);
        }
        while (Vector2.Distance(transform.position, PatrolPoint) >= 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, PatrolPoint, Speed * Time.deltaTime);
            yield return null;
        }
        _Coroutine = StartCoroutine(Move());
        StartCoroutine(TurnAtBorder());
        if (transform.eulerAngles.y == 180)
        {
            Flip(0);
        }
            yield break;
    }

    public void OnPlayerNotClose()
    {
        PlayerClose = false;
    }
}