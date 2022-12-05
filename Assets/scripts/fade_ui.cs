using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fade_ui : MonoBehaviour
{
    CanvasGroup canvasGroup;
    // Start is called before the first frame update
    int delay = 2;  
    void Awake() 
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    void Start()
    {
        StartCoroutine(lerpin());
    }

    public IEnumerator lerpin() 
    {
        for(float f = 0; f <= 2; f += Time.deltaTime) 
        {
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, f / 2);      
            yield return null;
        }
            yield return new WaitForSeconds(delay);
            canvasGroup.alpha = 1;
            StartCoroutine(lerpOut());
    }

    public IEnumerator lerpOut() 
    {    
        for(float f = 0; f <= 2; f += Time.deltaTime) 
        {
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, f / 2);      
            yield return null;
        }
        yield return new WaitForSeconds(1);
        canvasGroup.alpha = 0;
        nextscene();
    }
    public void nextscene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
