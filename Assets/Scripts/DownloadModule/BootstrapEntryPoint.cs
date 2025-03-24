using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BootstrapEntryPoint : MonoBehaviour
{
    [SerializeField] private Slider loading;
    private IEnumerator Start()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        while (!asyncLoad.isDone)
        {
            loading.value = asyncLoad.progress;
            yield return null;
        }
    }
}
