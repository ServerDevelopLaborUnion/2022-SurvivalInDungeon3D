using static Define;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLoadScene : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SceneLoader.LoadScene(BuildingScenes.PlayerWork);
    }
}
