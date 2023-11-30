using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitcher : MonoBehaviour
{
    public int targetSceneBuildIndex;
    public void SwitchScene()
    {
        SceneManager.LoadSceneAsync(targetSceneBuildIndex, LoadSceneMode.Single);
    }
}
