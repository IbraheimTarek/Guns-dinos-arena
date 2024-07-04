using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider loadingBar;


    public float LoadingMinTime = 1;

    private bool Loading = false;
    private float StartLoadingTime;
    private AsyncOperation LoadingOperation;

    void Update()
    {
        loadinsideUpdate();
    }
    public void Play()
    {
        //StartCoroutine(loadSceneAsync());
        StartLoading();
    }
    public void Quit()
    {
        Debug.Log("Quit!!!");
        Application.Quit();
    }

    private void loadinsideUpdate()
    {
        if (Loading)
        {
            float loadingTime = Time.time - StartLoadingTime;
            Debug.Log(loadingTime);
            float barValue = LoadingOperation.progress / 0.9f * (loadingTime / LoadingMinTime);

            float progress = Mathf.Clamp01(barValue);

            loadingBar.value = progress;
            // Checks if the min loading time has passed
            if (loadingTime >= LoadingMinTime)
            {
                // At this point if the loading is really over, the scene will load
                // If the load it's not over, it will continue to load and switch to the scene at the end
                LoadingOperation.allowSceneActivation = true;
                Loading = false;
            }
        }
    }
    private void StartLoading()
    {
        // Start loading the Scene asynchronously
        LoadingOperation = SceneManager.LoadSceneAsync((int)StaticData.currentMap + 1);

        // Set allowSceneActivation to false inmediately so it wold finish loading
        LoadingOperation.allowSceneActivation = false;

        // Store the starting time of the loading process
        StartLoadingTime = Time.time;

        Loading = true;

        loadingScreen.SetActive(true);
    }

    // IEnumerator loadSceneAsync()
    // {
    //     AsyncOperation op = SceneManager.LoadSceneAsync((int)StaticData.currentMap + 1);
    //     loadingScreen.SetActive(true);
    //     while (!op.isDone)
    //     {
    //         //yield return new WaitForSeconds(100.0f);
    //         float progress = Mathf.Clamp01(op.progress / 0.9f);
    //         loadingBar.value = progress;
    //         yield return null;
    //     }
    // }
}
