using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelFadeIn : MonoBehaviour
{
    private GameObject m_whiteOutPanel;
    private float t;

    [SerializeField] private int r;
    [SerializeField] private int b;
    [SerializeField] private int g;
    [SerializeField] private float fadeInTime;
    // Start is called before the first frame update
    void Start()
    {
        m_whiteOutPanel = GameObject.FindWithTag("WhiteOutPanel");
        t = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (t > 0) StartCoroutine(FadeOut(r,b,g));
    }
    IEnumerator FadeOut(int r, int b, int g)
    {
        var image = m_whiteOutPanel.GetComponent<Image>();
        
        // Fade out white screen
        while (t > 0f)
        {
            t -= fadeInTime;
            image.color = new Color(r, b, g, t);
            yield return new WaitForSeconds(0.02f / Time.deltaTime);
        }
    }
}
