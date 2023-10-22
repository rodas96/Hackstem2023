using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeTransition : MonoBehaviour
{
    public Image fadePanel;
    public float fadeDuration = 1f;

    private bool shouldFadeIn = false;
    private bool shouldFadeOut = false;

    public GameObject[] pracaDeAlegria;
    public GameObject[] avatarCreation;

    private GameObject[] objectsToDeactivate; // Array of objects to deactivate after fade out
    private GameObject[] objectsToActivate;   // Array of objects to activate after fade in

    private void Update()
    {
        if (shouldFadeIn)
        {
            FadeIn();
        }
        else if (shouldFadeOut)
        {
            FadeOut();
        }
    }

    public void StartFadeTransition(GameObject[] deactivate, GameObject[] activate)
    {
        objectsToDeactivate = deactivate;
        objectsToActivate = activate;
        shouldFadeOut = true;
    }

    void FadeOut()
    {
        fadePanel.color = new Color(fadePanel.color.r, fadePanel.color.g, fadePanel.color.b, fadePanel.color.a + (Time.deltaTime / fadeDuration));
        if (fadePanel.color.a >= 1)
        {
            shouldFadeOut = false;
            foreach (GameObject obj in objectsToDeactivate)
            {
                obj.SetActive(false);
            }
            foreach (GameObject obj in objectsToActivate)
            {
                obj.SetActive(true);
            }
            shouldFadeIn = true;
        }
    }

    void FadeIn()
    {
        fadePanel.color = new Color(fadePanel.color.r, fadePanel.color.g, fadePanel.color.b, fadePanel.color.a - (Time.deltaTime / fadeDuration));
        if (fadePanel.color.a <= 0)
        {
            shouldFadeIn = false;
        }
    }

    public void SwitchToAvatarCreation()
    {
        // Adjust these as needed
        StartFadeTransition(pracaDeAlegria, avatarCreation);
    }

    public void SwitchFromAvatarCreation()
    {
        // Adjust these as needed
        StartFadeTransition(avatarCreation, pracaDeAlegria);
    }

}
