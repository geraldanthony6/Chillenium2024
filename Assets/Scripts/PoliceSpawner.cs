using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceSpawner : MonoBehaviour
{
    [SerializeField] private GameObject PolicePrefab;

    [SerializeField] private Transform SpawnPoint;

    [SerializeField] private GameObject CopsText;

    [SerializeField] private SpriteRenderer Renderer;
    
    [SerializeField] private Color color = new Color(255f / 255f, 69f / 255f, 0);

    [SerializeField] private bool IsActive;
    // Start is called before the first frame update
    void Start()
    {
        Renderer.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsActive)
        {
            float alpha = Mathf.Lerp(0.7f,0.95f,Mathf.Abs(Mathf.Sin(Time.time*3)));
            Renderer.color = new Color(color.r, color.g, color.b, alpha); 
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            SpawnPolice();
        }

    }

    public void SpawnPolice()
    {
        CopsText.SetActive(true);
        IsActive = true;
        Instantiate(PolicePrefab, transform.position, Quaternion.identity);
        Activate();
    }
    
    public void Activate()
    {
        color = new Color(220f/255, 20f/255, 60f/266);
    }
}
