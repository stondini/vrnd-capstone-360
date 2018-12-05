using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuContrioller : MonoBehaviour {

    public GameObject titlePanel;

    public GameObject creditPanel;

    public Scrollbar creditScrollBar;

    private static bool title = true;

    // Use this for initialization
    void Start () {
        titlePanel.SetActive(title);
        creditPanel.SetActive(!title);
        title = !title;
        creditScrollBar.value = 0.0f;
    }

    // Update is called once per frame
    void Update () {
		
	}

    void FixedUpdate()
    {
        if (creditScrollBar.value >= 1.0f) 
        {
            creditScrollBar.value = 0.0f;
        }

        creditScrollBar.value = creditScrollBar.value + (0.1f * Time.deltaTime);
    }

    public void OnStart() {
        SceneManager.LoadScene("OutsideScene", LoadSceneMode.Single);
    }
}
