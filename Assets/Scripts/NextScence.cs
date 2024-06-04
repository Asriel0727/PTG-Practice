using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScence : MonoBehaviour
{
    private const string TargetSceneName = "Scene_2(Pro)";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SwitchScene();
        }
    }

    private void SwitchScene()
    {
        SceneManager.LoadScene(TargetSceneName);
    }
}
