using UnityEngine;
using TMPro;  // ȷ������TextMeshPro�����ռ�


public class FoodDecay : MonoBehaviour
{
    public TextMeshProUGUI countdownText;  // ���õ���ʱ�ı����
    public float decayTime = 30f;          // ����ʱ�䣨��λ���룩
    private float remainingTime;           // ʣ��ʱ��
    private Material cakeMaterial;        // ʳ��Ĳ���
    private float clipRate;               // ���õĽ��ȣ���0��1������cliprate��

    void Start()
    {
        // ��ȡ���ʣ�����ÿ��ʳ�����嶼�����������
        cakeMaterial = GetComponent<Renderer>().material;

        if (cakeMaterial == null)
        {
            Debug.LogError("û���ҵ�����!");
            return;
        }

        remainingTime = decayTime;  // ��ʼ��ʣ��ʱ��Ϊ����ʱ��
        clipRate = 0f;              // ��ʼ���ý���Ϊ 0
    }

    void Update()
    {
        // ���µ���ʱ
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;  // ����ʣ��ʱ��
            countdownText.text = Mathf.CeilToInt(remainingTime).ToString();  // ��ʾ����ʱ����
        }
        else
        {
            countdownText.text = "������...";  // ��ʾ������ʾ
            StartDecay();  // ��ʼ����Ч��
        }
    }

    void StartDecay()
    {
        // ���ù��̣�����ʱ���ƽ����޸� clipRate ����
        if (clipRate < 1f)  // ����clipRate�ķ�Χ��0��1֮�䣬ȷ�����ý��Ȳ��ᳬ��
        {
            clipRate += Time.deltaTime / decayTime;  // ��ʱ���ƽ����ý��ȣ�decayTime������������
            cakeMaterial.SetFloat("_cliprate", clipRate);  // �޸Ĳ��ʵ� cliprate ���ԣ����Ƹ���Ч��
        }
        else
        {
            // ��ȫ���ú���������
            countdownText.text = "��ȫ����!";
            Destroy(gameObject, 2f);  // ����ʾ������Ϣ2�����������
        }
    }
}