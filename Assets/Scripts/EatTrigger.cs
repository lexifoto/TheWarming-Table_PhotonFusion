using UnityEngine;

public class EatTrigger : MonoBehaviour
{
    public AudioClip soundEffect;  // 拖入音效
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;

        // 确保音效已设置
        if (soundEffect != null)
        {
            audioSource.clip = soundEffect;
        }
        else
        {
            Debug.LogWarning("音效未设置！");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))  // 确保食物的 Tag 设为 "Food"
        {
            Debug.Log($"{other.gameObject.name} 碰到了头部！");

            // 播放音效（使用 PlayOneShot，防止音效被打断）
            if (soundEffect != null)
            {
                audioSource.PlayOneShot(soundEffect);
            }

            // 销毁食物
            Destroy(other.gameObject);
        }
    }
}
