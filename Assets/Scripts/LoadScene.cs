using UnityEngine;
using UnityEngine.EventSystems;

public class LoadScene : MonoBehaviour,IPointerDownHandler
{
    public string sceneName;

    public void OnPointerDown(PointerEventData eventData)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        Debug.Log("Load Scene Button Clicked: " + sceneName);
    }
}
