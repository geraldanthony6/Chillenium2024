using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActionVisual : MonoBehaviour
{

    [SerializeField] SpriteRenderer sprite;
    [SerializeField] TextMeshProUGUI text;

    [SerializeField] private Color color = new Color(255f / 255f, 69f / 255f, 0);

    private void Start()
    {
        sprite.color = color;
        //text.color = color;
    }

    private void Update()
    {
        //float alpha = Mathf.Clamp(Mathf.Abs(Mathf.Sin(Time.time)), 0.7f, 1);
        float alpha = Mathf.Lerp(0.7f,0.95f,Mathf.Abs(Mathf.Sin(Time.time*3)));
        sprite.color = new Color(color.r, color.g, color.b, alpha);
        text.color = new Color(1, 1, 1, alpha);
        if (Input.GetKey(KeyCode.F))
            Activate();
    }

    public void Activate()
    {
        color = new Color(220f/255, 20f/255, 60f/266);
    }

}
