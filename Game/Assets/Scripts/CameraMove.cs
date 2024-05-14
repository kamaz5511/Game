using Cinemachine;
using System.Collections;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float CameraTransitionSpeed = 0.01f;
    private CinemachineVirtualCamera _virtualCamera;
    private CinemachineFramingTransposer _transposer;
    private Coroutine Up, Down,Right, Left,TimerCor;

    private void Start()
    {
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();
        _transposer = _virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
         Up =  StartCoroutine(IncreaseScreen(_transposer.m_ScreenY, false));
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            if(Up != null)StopCoroutine(Up);
            StartCoroutine(DecreaseeScreen(_transposer.m_ScreenY, false, 0.5f,true));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Down = StartCoroutine(DecreaseeScreen(_transposer.m_ScreenY,false));
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            if(Down != null)StopCoroutine(Down);
            StartCoroutine(IncreaseScreen(_transposer.m_ScreenY, false, 0.5f,true));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Right = StartCoroutine(DecreaseeScreen(_transposer.m_ScreenX));
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            if(Right != null)StopCoroutine(Right);
            StartCoroutine(IncreaseScreen(_transposer.m_ScreenX, true, 0.5f,true));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Left = StartCoroutine(IncreaseScreen(_transposer.m_ScreenX));
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            if(Left != null)StopCoroutine(Left);
            StartCoroutine(DecreaseeScreen(_transposer.m_ScreenX, true, 0.5f, true));
        }
    }
    private IEnumerator IncreaseScreen(float Screen,bool ItX = true,float ToNum = 1f, bool UnFreeze = false)
    {
        if (Movement.Instance.GetOnGround())
        {
            Movement.Instance.Freeze();
            while (Screen < ToNum)
            {
                Screen += CameraTransitionSpeed;
                if (ItX)
                {
                    _transposer.m_ScreenX = Screen;
                }
                else
                {
                    _transposer.m_ScreenY = Screen;
                }
                yield return null;
            }
            if (UnFreeze) Movement.Instance.UnFreeze();
            yield break;
        }

    }
    private IEnumerator DecreaseeScreen(float Screen, bool ItX = true, float ToNum = 0, bool UnFreeze = false)
    {
        if (Movement.Instance.GetOnGround())
        {
            Movement.Instance.Freeze();
            while (Screen > ToNum)
            {
                Screen -= CameraTransitionSpeed;
                if (ItX)
                {
                    _transposer.m_ScreenX = Screen;
                }
                else
                {
                    _transposer.m_ScreenY = Screen;
                }
                yield return null;
            }
            if (UnFreeze) Movement.Instance.UnFreeze();
            yield break;
        }

    }
}