using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Gates : MonoBehaviour
{
    [HideInInspector] public bool Closed = true;
    private Transform Transforming;
    [SerializeField] private float Speed = 2f, TimeToClose = 10f;

    private void Start() => Transforming = GetComponent<Transform>();   
    public void Open()
    {
        if (Closed)StartCoroutine(GoUp());
    }
    public void Close()
    {
        StartCoroutine(GoDown());
    }
    private IEnumerator GoUp()
    {
        float position = transform.position.y + 4f;
        while (transform.position.y < position)
        {
            Transforming.Translate(Vector2.up * Speed * Time.deltaTime);
            yield return null;
        }
        StartCoroutine(Timer());
        Closed = false;
        yield break;
    }
    private IEnumerator GoDown()
    {
        float position = transform.position.y - 4f;
        while (transform.position.y > position)
        {
            Transforming.Translate(Vector2.down * Speed * Time.deltaTime);
            yield return null;
        }
        yield break;
    }
    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(TimeToClose);
        Close();
        Closed = true;
        yield break;
    }
}
