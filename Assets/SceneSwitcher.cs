using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public string targetSceneName;
    public GameObject loadingUI;         // 你的“Loading...” UI Panel
    public AudioSource audioSource;      // 播放音效的 AudioSource
    public AudioClip loadingSound;       // 加载时播放的音效

    public void StartSceneTransition()
    {
        StartCoroutine(LoadSceneWithEffect());
    }

    IEnumerator LoadSceneWithEffect()
    {
        // 1. 播放音效
        if (audioSource && loadingSound)
        {
            audioSource.PlayOneShot(loadingSound);
        }

        // 2. 显示 UI
        if (loadingUI)
        {
            loadingUI.SetActive(true);
        }

        // 3. 等一会（确保音效能播放一部分）
        yield return new WaitForSeconds(1f);

        // 4. 异步加载场景
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(targetSceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
