using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Countdown : MonoBehaviour
{
    public float timeStart = 10f; // ����ʱ
    public Text textBox; // UI �ı�
    public Renderer foodRenderer; // ��ʳ��� Renderer
    public ParticleSystem bubbleParticles; // ����������ϵͳ

    private Material foodMaterial; // �洢ʳ�����
    private bool isDissolving = false; // ȷ��ִֻ��һ��

    void Start()
    {
        if (textBox != null)
            textBox.text = timeStart.ToString();

        if (foodRenderer != null)
            foodMaterial = foodRenderer.material; // ��ȡʳ�����

        // ȷ��һ��ʼ���ܽ�
        if (foodMaterial != null)
            foodMaterial.SetFloat("_ClipRate", 0);

        // ȷ������һ��ʼ������
        if (bubbleParticles != null)
            bubbleParticles.Stop();
    }

    void Update()
    {
        if (timeStart > 0)
        {
            timeStart -= Time.deltaTime;
            timeStart = Mathf.Max(timeStart, 0); // ȷ������С�� 0


            if (textBox != null)
                textBox.text = Mathf.Round(timeStart).ToString();
        }
        else if (!isDissolving) // ����ʱ����󣬲Ŵ����ܽ�
        {
            StartCoroutine(StartDissolve());
            isDissolving = true; // ִֻ��һ��
        }
    }

    IEnumerator StartDissolve()
    {
        // ���ص���ʱ�ı�
        if (textBox != null)
            textBox.gameObject.SetActive(false);

        if (textBox != null)
        {
            textBox.text = "0"; // ȷ������ܿ��� 0
            yield return new WaitForSeconds(1f); // �ӳ� 1 �������أ�ȷ�� 0 ��ʾ
            textBox.gameObject.SetActive(false);
        }

        // �����ܽ�
        float dissolveAmount = 0;
        while (dissolveAmount < 1)
        {
            dissolveAmount += Time.deltaTime / 5; // 5��������ܽ�
            foodMaterial.SetFloat("_ClipRate", dissolveAmount);
            yield return null;
        }

        // ȷ������ ClipRate = 1
        foodMaterial.SetFloat("_ClipRate", 1);

        // **�ܽ���ɺ�������������ϵͳ**
        if (bubbleParticles != null)
        {
            yield return new WaitForSeconds(0.5f); // �ӳ� 0.5 �룬���ӹ��ɸ�
            bubbleParticles.Play();
        }
    }
}
