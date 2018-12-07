using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuContrioller : MonoBehaviour
{

    public GameObject titlePanel;

    public GameObject altPanel;

    public GameObject creditPanel;

    public Scrollbar creditScrollBar;

    public GameObject welcome;

    public GameObject altScenario;

    static MenuContrioller() {
        MenuChoice.menuChoice.SetMenuIdx(1);
    }

    // Use this for initialization
    void Start()
    {
        int menuIdx = MenuChoice.menuChoice.GetMenuIdx();
        // Welcome and title
        welcome.SetActive(menuIdx == 1);
        titlePanel.SetActive(menuIdx == 1);

        // Alternative scenario
        altScenario.SetActive(menuIdx == 2);
        altPanel.SetActive(menuIdx == 2);

        // Credits
        creditPanel.SetActive(menuIdx == 3);
        creditScrollBar.value = 0.0f;
    }

    // Update is called once per frame
    void Update () {
		
	}

    void FixedUpdate()
    {
        if (creditPanel.activeSelf)
        {
            if (creditScrollBar.value >= 1.0f)
            {
                creditScrollBar.value = 0.0f;
            }

            creditScrollBar.value = creditScrollBar.value + (0.1f * Time.deltaTime);
        }
    }

    public void OnStart() {
        Debug.Log("Unloading scene : " + SceneManager.GetActiveScene().name);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("OutsideScene", LoadSceneMode.Single);
    }

    public void OnStoryline1()
    {
        Debug.Log("Unloading scene : " + SceneManager.GetActiveScene().name);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("InsideScene", LoadSceneMode.Single);
    }

    public void OnStoryline2()
    {
        Debug.Log("Unloading scene : " + SceneManager.GetActiveScene().name);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("OutsideSceneAlt", LoadSceneMode.Single);
    }
}
