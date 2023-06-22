using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void DisplayScreen()
    {
        text.enabled = true;
        StartCoroutine(ExitWithDelay());
    }

    private IEnumerator ExitWithDelay()
    {
        yield return new WaitForSeconds(2.0f);
        ExitGame();
    }

    private void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
