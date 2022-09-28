using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public static class Utils
{
    public static CinemachineVirtualCamera VCam
    {
        get
        {
            if (_vCam == null)
            {
                _vCam = GameObject.FindObjectOfType<CinemachineVirtualCamera>();
            }
            return _vCam;
        }
    }

    private static CinemachineVirtualCamera _vCam;
}
