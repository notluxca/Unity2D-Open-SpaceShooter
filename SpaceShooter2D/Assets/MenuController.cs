using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public GameObject MenuPannel;
    public GameObject creditsPannel;
    public GameObject controlsPannel;

    public Animator FadeImage;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MenuPannel.SetActive(true);
        creditsPannel.SetActive(false);
        controlsPannel.SetActive(false);
    }

    public void StartGame()
    {
        StartCoroutine(StartGameSequence());
    }

    IEnumerator StartGameSequence()
    {
        FadeImage.Play("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);

    }

    public void OpenMenu()
    {
        MenuPannel.SetActive(true);
        creditsPannel.SetActive(false);
        controlsPannel.SetActive(false);
    }

    public void OpenCredits()
    {
        MenuPannel.SetActive(false);
        creditsPannel.SetActive(true);
        controlsPannel.SetActive(false);
    }

    public void OpenControls()
    {
        MenuPannel.SetActive(false);
        creditsPannel.SetActive(false);
        controlsPannel.SetActive(true);
    }
}
