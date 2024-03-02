using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera PlayerCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            
            Vector2 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10.0f);
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(position);
            Vector3 newPosition = new Vector3(worldPosition.x, worldPosition.y, -10.0f);
            StartCoroutine(MoveCamera(newPosition, 1));
            //transform.position = new Vector3(worldPosition.x, worldPosition.y, -10.0f);
            Debug.Log("Move Camera To this spot" + worldPosition.ToString());
        }
    }

    IEnumerator MoveCamera(Vector3 targetPostion, float duration)
    {
        float time = 0.0f;
        Vector3 startPos = transform.position;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPos, targetPostion, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPostion;
    }
}
