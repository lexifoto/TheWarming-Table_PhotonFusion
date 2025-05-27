using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Countdown : MonoBehaviour
{
    public float timeStart = 10f; // 倒计时
    public Text textBox; // UI 文本
    public Renderer foodRenderer; // 绑定食物的 Renderer
    public ParticleSystem bubbleParticles; // 绑定泡泡粒子系统

    private Material foodMaterial; // 存储食物材质
    private bool isDissolving = false; // 确保只执行一次

    void Start()
    {
        if (textBox != null)
            textBox.text = timeStart.ToString();

        if (foodRenderer != null)
            foodMaterial = foodRenderer.material; // 获取食物材质

        // 确保一开始不溶解
        if (foodMaterial != null)
            foodMaterial.SetFloat("_ClipRate", 0);

        // 确保泡泡一开始不播放
        if (bubbleParticles != null)
            bubbleParticles.Stop();
    }

    void Update()
    {
        if (timeStart > 0)
        {
            timeStart -= Time.deltaTime;
            timeStart = Mathf.Max(timeStart, 0); // 确保不会小于 0


            if (textBox != null)
                textBox.text = Mathf.Round(timeStart).ToString();
        }
        else if (!isDissolving) // 倒计时归零后，才触发溶解
        {
            StartCoroutine(StartDissolve());
            isDissolving = true; // 只执行一次
        }
    }

    IEnumerator StartDissolve()
    {
        // 隐藏倒计时文本
        if (textBox != null)
            textBox.gameObject.SetActive(false);

        if (textBox != null)
        {
            textBox.text = "0"; // 确保玩家能看到 0
            yield return new WaitForSeconds(1f); // 延迟 1 秒再隐藏，确保 0 显示
            textBox.gameObject.SetActive(false);
        }

        // 渐变溶解
        float dissolveAmount = 0;
        while (dissolveAmount < 1)
        {
            dissolveAmount += Time.deltaTime / 5; // 5秒内完成溶解
            foodMaterial.SetFloat("_ClipRate", dissolveAmount);
            yield return null;
        }

        // 确保最终 ClipRate = 1
        foodMaterial.SetFloat("_ClipRate", 1);

        // **溶解完成后，启动泡泡粒子系统**
        if (bubbleParticles != null)
        {
            yield return new WaitForSeconds(0.5f); // 延迟 0.5 秒，增加过渡感
            bubbleParticles.Play();
        }
    }
}
