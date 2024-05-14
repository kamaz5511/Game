using Cinemachine;
using System.Collections;
using UnityEngine;

public class Buildings : MonoBehaviour,IUsable
{
    public GameObject OtherDoor;
    [SerializeField]private CinemachineVirtualCamera _virtualCamera;
    [SerializeField] private float ZoomInCount,SavedZoom;
    private bool Enter = false,CanUse = true;
    public void Use()
    {
        EnterOnBuild();
    }
    public void EnterOnBuild()
    {
        if (CanUse)
        {
            CanUse = false;
            Movement.Instance.Freeze();
            Enter = !Enter;
            if (Enter)
            {
                StartCoroutine(FadeOut(gameObject));
                if(OtherDoor != null)StartCoroutine(FadeOut(OtherDoor));
                CameraEffects.Instance.ChangeFollow(transform);
                StartCoroutine(CameraEffects.Instance.ZoomIn(ZoomInCount));
            }
            else
            {
                StartCoroutine(FadeIn(gameObject));
                if(OtherDoor != null)StartCoroutine(FadeIn(OtherDoor));
                StartCoroutine(CameraEffects.Instance.ZoomOut());
            }
        }
    }
    private IEnumerator FadeOut(GameObject gameObject)
    {
        SpriteRenderer spriterenderer = gameObject.GetComponent<SpriteRenderer>();
        for(float f = 1f; f>= -0.05f;f -= 0.05f)
        {
            Color color = spriterenderer.material.color;
            color.a = f;
            spriterenderer.material.color = color;
            if(color.a <= 0)
            {
                Show();
                yield break;
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
    private IEnumerator FadeIn(GameObject gameObject)
    {
        SpriteRenderer spriterenderer = gameObject.GetComponent<SpriteRenderer>();
        for (float f = 0.05f; f <= 1; f += 0.05f)
        {
            Color color = spriterenderer.material.color;
            color.a = f;
            spriterenderer.material.color = color;
            if (color.a >= 0.94)
            {
                Show();
                yield break;
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
    private IEnumerator ZoomIn()
    {
        _virtualCamera.Follow = transform;
        SavedZoom = _virtualCamera.m_Lens.OrthographicSize;
        while (_virtualCamera.m_Lens.OrthographicSize > ZoomInCount)
        {
            _virtualCamera.m_Lens.OrthographicSize -= 0.05f;
            yield return new WaitForSeconds(0.01f);
        }
        yield break;
    }
    private IEnumerator ZoomOut()
    {
        while (_virtualCamera.m_Lens.OrthographicSize < SavedZoom)
        {
            _virtualCamera.m_Lens.OrthographicSize += 0.05f;
            yield return new WaitForSeconds(0.01f);
        }
        _virtualCamera.Follow = Movement.Instance.transform;
        yield break;
    }
    private void Show()
    {
        transform.GetChild(0).gameObject.SetActive(Enter);
        Movement.Instance.UnFreeze();
        CanUse = true;
    }
}
