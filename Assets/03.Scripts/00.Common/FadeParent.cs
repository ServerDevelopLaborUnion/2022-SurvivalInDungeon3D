using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FadeParent : MonoBehaviour
{

    public enum FADECHILDS
    {
        FADEOBJECT,
        TOPBAR,
        BOTTOMBAR,
    }

    private Image _fadeObj;

    private void Start()
    {
        _fadeObj = transform.GetChild((int)FADECHILDS.FADEOBJECT).GetComponent<Image>();
    }

    /// <summary>
    /// FadeObject를 duration동안 alpha로 만들어준다
    /// </summary>
    /// <param name="duration"> 몇 초에 걸쳐 alpha를 적용할 것 인지 </param>
    /// <param name="alpha"> 최종적으로 alpha가 몇이 될 것 인지 </param>
    public Tweener Fade(float duration, float alpha)
    {
        return _fadeObj.DOFade(alpha, duration);
    }

    /// <summary>
    /// FadeObject의 Color를 fadeColor로 설정해준다
    /// </summary>
    /// <param name="fadeObjColor"> 바꿔줄 Color </param>
    /// <param name="withoutAlpha"> alpha를 적용할 것 인지 말 건지 </param>
    public void SetFadeColor(Color fadeObjColor, bool withoutAlpha = false)
    {
        Color color = fadeObjColor;
        if(withoutAlpha)
        {
            color.a = 0f;
        }
        _fadeObj.color = color;
    }

}
