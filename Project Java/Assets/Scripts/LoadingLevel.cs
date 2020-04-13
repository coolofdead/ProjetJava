using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingLevel : MonoBehaviour
{
    public GameObject loading;
    public Image loadingBar;

    private float minDelay = 100f;

    public IEnumerator LoadScene(string sceneName)
    {
        for (int i = 0; i < 10; i++)
            yield return new WaitForEndOfFrame();

        loading.SetActive(true);

        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

        while (!async.isDone)
        {
            loadingBar.fillAmount = async.progress;

            yield return null;
        }

    }
}
