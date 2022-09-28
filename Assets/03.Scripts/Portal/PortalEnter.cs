using static Utils;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PortalEnter : MonoBehaviour
{
    [SerializeField]
    private PortalEnter _otherPortal;


    public bool IsEntered = false;

    public Vector3 Damping{ get; set; }

    private CinemachineTransposer _ct;
    private void Start() {
        _ct = VCam.GetCinemachineComponent<CinemachineTransposer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !IsEntered)
        {
            _otherPortal.IsEntered = true;
            //VCam.transform.position += _otherPortal.transform.position;
            _otherPortal.Damping = new Vector3(_ct.m_XDamping, _ct.m_YDamping, _ct.m_ZDamping);
            _ct.m_XDamping = 0f;
            _ct.m_YDamping = 0f;
            _ct.m_ZDamping = 0f;


            StartCoroutine(MovePlayer(other));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _ct.m_XDamping = Damping.x;
            _ct.m_YDamping = Damping.y;
            _ct.m_ZDamping = Damping.z;
            IsEntered = false;
        }
    }

    private IEnumerator MovePlayer(Collider other)
    {
        yield return null;
        other.transform.position = _otherPortal.transform.position;

    }

}
