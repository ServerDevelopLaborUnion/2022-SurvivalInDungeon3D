using static Yields;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PortalVisualEffect : MonoBehaviour
{
    [SerializeField]
    private float _weightSmooth = 5f;

    private Volume _volume;

    private Transform _portal;

    private Vector3 _otherPos;
    private Vector3 _portalPos;
    private Vector3 _colPos;

    private void Start() {
        _volume = GetComponent<Volume>();
        _portal = transform.parent;
    }

    // private void OnGUI() {
    //     GUIStyle label = new GUIStyle();
    //     label.fontSize = 40;
    //     label.normal.textColor = Color.red;

    //     GUILayout.Label($"DIS : {Vector3.Distance(_otherPos, _portalPos)}", label);
    //     GUILayout.Label($"DIS : {_colPos.magnitude}", label);
    //     GUILayout.Label($"DIS : { Mathf.Clamp01( (_colPos.magnitude - Vector3.Distance(_otherPos, _portalPos)) / _colPos.magnitude) }", label);
    // }


    private void OnTriggerStay(Collider other) {
        if(other.CompareTag("Player"))
        {
            _otherPos = other.transform.position;
            _otherPos.y = 0f;
            _portalPos = _portal.position;
            _portalPos.y = 0f;
            _colPos = new Vector3(transform.localScale.x, 0f, 0f);

            float weightValue = Mathf.Clamp01((_colPos.magnitude - Vector3.Distance(_otherPos, _portalPos)) / _colPos.magnitude);
            // _volume.weight = 1 - Mathf.Clamp(Vector3.Distance(other.transform.position, _portal.position), 0, 10) / 10;
            _volume.weight = weightValue;
            Color color = Color.white;
            color.a = Mathf.Clamp01(weightValue);

            Define.FadeParent.SetFadeColor(color);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player"))
        {
            _volume.weight = 0f;
            StartCoroutine(FadeZero());
        }
    }

    private IEnumerator FadeZero()
    {
        yield return WaitEndOfFrame;
        Define.FadeParent.Fade(0f, 0f);
    }
}
