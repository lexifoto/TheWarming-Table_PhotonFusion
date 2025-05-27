using UnityEngine;
using TMPro;  // 确保导入TextMeshPro命名空间


public class FoodDecay : MonoBehaviour
{
    public TextMeshProUGUI countdownText;  // 引用倒计时文本组件
    public float decayTime = 30f;          // 腐烂时间（单位：秒）
    private float remainingTime;           // 剩余时间
    private Material cakeMaterial;        // 食物的材质
    private float clipRate;               // 腐烂的进度（从0到1，控制cliprate）

    void Start()
    {
        // 获取材质，假设每个食物物体都含有这个材质
        cakeMaterial = GetComponent<Renderer>().material;

        if (cakeMaterial == null)
        {
            Debug.LogError("没有找到材质!");
            return;
        }

        remainingTime = decayTime;  // 初始化剩余时间为腐烂时间
        clipRate = 0f;              // 初始腐烂进度为 0
    }

    void Update()
    {
        // 更新倒计时
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;  // 减少剩余时间
            countdownText.text = Mathf.CeilToInt(remainingTime).ToString();  // 显示倒计时数字
        }
        else
        {
            countdownText.text = "腐烂中...";  // 显示腐烂提示
            StartDecay();  // 开始腐烂效果
        }
    }

    void StartDecay()
    {
        // 腐烂过程，随着时间推进，修改 clipRate 属性
        if (clipRate < 1f)  // 控制clipRate的范围在0到1之间，确保腐烂进度不会超过
        {
            clipRate += Time.deltaTime / decayTime;  // 以时间推进腐烂进度，decayTime决定腐烂速率
            cakeMaterial.SetFloat("_cliprate", clipRate);  // 修改材质的 cliprate 属性，控制腐烂效果
        }
        else
        {
            // 完全腐烂后销毁物体
            countdownText.text = "完全腐烂!";
            Destroy(gameObject, 2f);  // 在显示腐烂信息2秒后销毁物体
        }
    }
}