using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuContrioller : MonoBehaviour {

    public GameObject titlePanel;

    public GameObject altPanel;

    public GameObject creditPanel;

    public Scrollbar creditScrollBar;

    public GameObject welcome;

    public GameObject altScenario;

    private static MenuContrioller ctrl;

    // Use this for initialization
    void Start () {
        if (ctrl == null) {
            ctrl = this;
        }
        // Welcome and title
        welcome.SetActive(true);
        titlePanel.SetActive(true);

        // Alternative scenario
        altScenario.SetActive(false);
        altPanel.SetActive(false);

        // Credits
        creditPanel.SetActive(false);
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

    // 1 = Title
    // 2 = Alternative Storyline
    // 3 = End/Credits
    public static void LoadUI(int index) {
        Debug.Log("Unloading scene : " + SceneManager.GetActiveScene().name);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("UI", LoadSceneMode.Single);

        // Welcome and title
        ctrl.welcome.SetActive(index == 1);
        ctrl.titlePanel.SetActive(index == 1);

        // Alternative scenario
        ctrl.altScenario.SetActive(index == 2);
        ctrl.altPanel.SetActive(index == 2);

        // Credits
        ctrl.creditPanel.SetActive(index == 3);
        ctrl.creditScrollBar.value = 0.0f;
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
