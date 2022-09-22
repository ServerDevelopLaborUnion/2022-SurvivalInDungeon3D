using static Yields;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalEnter : MonoBehaviour
{
    [SerializeField]
    private PortalEnter _otherPortal;


    public bool IsEntered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !IsEntered)
        {
            Debug.Log(gameObject.name + "에 닿아서" + other.name + "들어옴");
            _otherPortal.IsEntered = true;
            StartCoroutine(MovePlayer(other));
            Debug.Log("adf");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(gameObject.name + "나감");
            IsEntered = false;
        }
    }

    private IEnumerator MovePlayer(Collider other)
    {
        yield return null;
        other.transform.position = _otherPortal.transform.position;

    }

}
