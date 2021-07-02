using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{

    public Vector2 CameraChangeMax;
    public Vector2 CameraChangeMin;
    public Vector3 PlayerChange;

    private CameraMove CamM;

    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText;

    void Start()
    {
        CamM = Camera.main.GetComponent<CameraMove>();
    }


    void Update()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            CamM.minPosition = CameraChangeMin;
            CamM.maxPosition = CameraChangeMax;
            other.transform.position += PlayerChange;
            if (needText)
            {
                StartCoroutine(placeNameCo());
            }
        }  
    }

    private IEnumerator placeNameCo()
    {
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(2f);
        text.SetActive(false);

    }

}
