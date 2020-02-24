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
        float curDelay = 0f;
        loading.SetActive(true);

        //while (curDelay < minDelay)
        //{
        //    curDelay += Random.Range(0, 50) * Time.deltaTime;
        //    loadingBar.fillAmount = curDelay / minDelay;
        //    yield return new WaitForEndOfFrame();
        //}

        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

        while (!async.isDone)
        {
            loadingBar.fillAmount = async.progress;

            yield return null;
        }

    }
}
