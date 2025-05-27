using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Shelflife : MonoBehaviour
{
    private float lastClickTime = 0f;
    private float debounceThreshold = 0.3f;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI count;
    public TextMeshProUGUI buttonState;

    public float decayTime = 30f;
    public float remainingTime;

    private bool isPaused = false;
    private bool isIced = false;
    private bool hasDecayed = false;

    public float decayDuration = 2f; // Delay before destroy
    private float clipRate = 0f;

    public Renderer targetRenderer;
    private Material normalMaterial;
    public Material iceMaterial;


    void Start()
    {
        remainingTime = decayTime;
        normalMaterial = GetComponent<Renderer>().material;

    }

    void Update()
    {
        if (!isPaused && remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime <= 0f && !hasDecayed)
        {
            remainingTime = 0f;
            timerText.text = "Decaying...";
            hasDecayed = true;
            StartCoroutine(StartDecay());
        }

        // Clamp and display timer
        remainingTime = Mathf.Max(remainingTime, 0f);
        if (!hasDecayed)
        {
            timerText.text = Mathf.CeilToInt(remainingTime).ToString() + "s";
        }
    }

    public void ButtonPressed()
    {
        if (Time.time - lastClickTime < debounceThreshold)
            return;

        lastClickTime = Time.time;
        isPaused = !isPaused;
        buttonState.text = isPaused ? "Unfreeze it" : "Freeze it";

        ToggleMaterial();
    }

    public void ToggleMaterial()
    {
        if (targetRenderer == null || normalMaterial == null || iceMaterial == null)
            return;

        isIced = !isIced;
        targetRenderer.material = isIced ? iceMaterial : normalMaterial;
    }

    IEnumerator StartDecay()
    {
        // Gradually increase _Cliprate from 0 to 1
        while (clipRate < 1f)
        {
            clipRate += Time.deltaTime / decayTime;
            normalMaterial.SetFloat("_Cliprate", clipRate);
            yield return null;
        }

        // Final message & destroy
        timerText.text = "Fully Decayed!";
        yield return new WaitForSeconds(decayDuration);
        Destroy(gameObject);
    }
}



/*
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Shelflife : MonoBehaviour
{

{
    public float expireDuration = 200f; // Starting expire time in seconds
    public TextMeshProUGUI expireTimeText;
    public TextMeshProUGUI counterText;
    int counter;
    public Button freezeButton;

    private bool isPaused = false;
    private float currentExpireTime;

    void Start()
    {
        currentExpireTime = expireDuration;


        // Hook up the button click
        if (freezeButton != null)
            freezeButton.onClick.AddListener(TogglePause);
    }

    void Update()
    {

        if (isPaused == false)
        {
            currentExpireTime -= Time.deltaTime;
            expireTimeText.text = Mathf.CeilToInt(currentExpireTime).ToString() + "s";
        }

        else if (isPaused == true)
        {
            currentExpireTime -= 300;
        }

        
    }

    public void TogglePause()
    {
        isPaused  = !isPaused;
        Debug.Log("Expire timer paused: " + isPaused);
        counter++;
        counterText.text = counter + "";
    }
}
*/