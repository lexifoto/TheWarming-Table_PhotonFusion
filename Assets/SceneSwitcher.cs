using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public string targetSceneName;
    public GameObject loadingUI;         // ��ġ�Loading...�� UI Panel
    public AudioSource audioSource;      // ������Ч�� AudioSource
    public AudioClip loadingSound;       // ����ʱ���ŵ���Ч

    public void StartSceneTransition()
    {
        StartCoroutine(LoadSceneWithEffect());
    }

    IEnumerator LoadSceneWithEffect()
    {
        // 1. ������Ч
        if (audioSource && loadingSound)
        {
            audioSource.PlayOneShot(loadingSound);
        }

        // 2. ��ʾ UI
        if (loadingUI)
        {
            loadingUI.SetActive(true);
        }

        // 3. ��һ�ᣨȷ����Ч�ܲ���һ���֣�
        yield return new WaitForSeconds(1f);

        // 4. �첽���س���
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(targetSceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
