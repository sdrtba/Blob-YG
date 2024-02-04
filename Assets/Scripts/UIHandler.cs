using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private Slider slider;

    void Start()
    {
        slider.value = AudioListener.volume;
    }

    public void Play()
    {
        SceneManager.LoadScene(YandexGame.savesData.maxLevels + 1);
    }

    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ChangeAudioVolume()
    {
        AudioListener.volume = slider.value;
    }

    public void Rate()
    {
        YandexGame.ReviewShow(true);
    }

    public void Reset()
    {
        YandexGame.ResetSaveProgress();
        YandexGame.SaveProgress();
    }
}
