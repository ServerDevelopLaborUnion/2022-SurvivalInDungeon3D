using static Define;

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class SceneLoader : MonoBehaviour
{
    private Canvas _fadeCanvas;
    private void Awake() {
        _fadeCanvas = Define.FadeParent.GetComponent<Canvas>();

        SceneManager.sceneLoaded += (x, y) =>
        {
            _fadeCanvas.worldCamera = MainCam;
            Debug.Log("a");
            Define.FadeParent.Fade(1f, 0f);
        };
    }
    public static void LoadScene(BuildingScenes sceneType)
    {
        Define.FadeParent.SetFadeColor(Color.white, true);

        Define.FadeParent.Fade(1f, 1f).OnComplete(()=>{
            SceneManager.LoadScene((int)sceneType);
        });
    }
}
