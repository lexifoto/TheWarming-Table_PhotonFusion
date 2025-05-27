using UnityEngine;

public class EatTrigger : MonoBehaviour
{
    public AudioClip soundEffect;  // ������Ч
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;

        // ȷ����Ч������
        if (soundEffect != null)
        {
            audioSource.clip = soundEffect;
        }
        else
        {
            Debug.LogWarning("��Чδ���ã�");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))  // ȷ��ʳ��� Tag ��Ϊ "Food"
        {
            Debug.Log($"{other.gameObject.name} ������ͷ����");

            // ������Ч��ʹ�� PlayOneShot����ֹ��Ч����ϣ�
            if (soundEffect != null)
            {
                audioSource.PlayOneShot(soundEffect);
            }

            // ����ʳ��
            Destroy(other.gameObject);
        }
    }
}
