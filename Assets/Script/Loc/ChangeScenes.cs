using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public string NameScene;
    public Vector2 playerPoint;
    public VectorValue playerPosition;

    //public Vector2 cameraNewMax;
    //public Vector2 cameraNewMin;
    //public VectorValue cameraMin;
    //public VectorValue cameraMax;


    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;

    public float fadeTime;

    private void Awake()
    {
        if (fadeInPanel != null)
        {
            GameObject panal = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panal, 1);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerPosition.RunTimeValue = playerPoint;
            //SceneManager.LoadScene(NameScene);
            StartCoroutine(Fade());
        }
    }

    public IEnumerator Fade()
    {
        if (fadeOutPanel != null)
        {
            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeTime);
        //ResetCamera();
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(NameScene);
        while(!asyncOperation.isDone)
        {
            yield return null;
        }
    }

    //public void ResetCamera()
    //{
    //    cameraMax.initialValue = cameraNewMax;
    //    cameraMin.initialValue = cameraNewMin;
    //}

}
