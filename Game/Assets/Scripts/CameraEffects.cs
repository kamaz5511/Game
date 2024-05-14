using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffects : MonoBehaviour
{
    private CinemachineVirtualCamera _virtualCamera;
    private float SavedZoom;
    public static CameraEffects Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();
        
    }

    public IEnumerator ZoomIn(float CloserTo)
    {
        SavedZoom = _virtualCamera.m_Lens.OrthographicSize;
        while (_virtualCamera.m_Lens.OrthographicSize > CloserTo)
        {
            _virtualCamera.m_Lens.OrthographicSize -= 0.05f;
            yield return new WaitForSeconds(0.01f);
        }
        yield break;
    }
    public void ChangeFollow(Transform follow)
    {
        _virtualCamera.Follow = follow;
    }

    public IEnumerator ZoomOut()
    {
        while (_virtualCamera.m_Lens.OrthographicSize < SavedZoom)
        {
            _virtualCamera.m_Lens.OrthographicSize += 0.05f;
            yield return new WaitForSeconds(0.01f);
        }
        _virtualCamera.Follow = Movement.Instance.transform;
        yield break;
    }
}
