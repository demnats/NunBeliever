using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    private GameObject m_whiteOutPanel;
    [SerializeField] string m_scene;
    [SerializeField] int r;
    [SerializeField] int g;
    [SerializeField] int b;
    [Tooltip("Time to fade"), SerializeField] float waitTime;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            m_whiteOutPanel = GameObject.FindWithTag("WhiteOutPanel");
            StartCoroutine(DoTransition(m_scene, r, g, b));
        }
    }

    IEnumerator DoTransition(string scene,int r, int g, int b)
    {
        var image = m_whiteOutPanel.GetComponent<Image>();

        // Fade in white screen
        float t = 0;
        while (t < 1f)
        {
            t += waitTime;
            image.color = new Color(r, g, b, t);
            yield return null;
        }
        SceneManager.LoadScene(scene);
        yield return new WaitForSeconds(0.1f);

    }

}
