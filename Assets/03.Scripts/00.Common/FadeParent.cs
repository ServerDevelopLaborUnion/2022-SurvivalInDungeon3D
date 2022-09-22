using static Define;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FadeParent : MonoBehaviour
{

    private Image _fadeObj;

    private void Start() {
        _fadeObj = transform.GetChild((int)FADECHILDS.FADEOBJECT).GetComponent<Image>();
    }


    public void Fade(float duration, Color fadeColor = new Color())
    {

    }
}
