using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float PlayerSpeed;

    [SerializeField] private Animator AnimController;

    [SerializeField] private GameObject PlayerMesh;

    [SerializeField] private Quaternion MovingLeftRotation = new Quaternion(-90.0f, 90.0f, -90.0f, Quaternion.identity.w);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * 15f * Time.deltaTime * Input.GetAxisRaw("Horizontal"));
        
        transform.Translate(Vector2.up * 15f * Time.deltaTime * Input.GetAxisRaw("Vertical"));

        if (Input.GetAxisRaw("Horizontal") != 0.0f || Input.GetAxisRaw("Vertical") != 0.0f)
        {
            AnimController.SetBool("IsWalking", true);
        } else if (Input.GetAxisRaw("Horizontal") == 0.0f && Input.GetAxisRaw("Vertical") == 0.0f)
        {
            AnimController.SetBool("IsWalking", false);
        }
        
        OnRotate();

    }

    void OnRotate()
    {
        var LookRotation = Quaternion.LookRotation(new Vector3(Input.GetAxisRaw("Horizontal") * 90.0f, 0.0f,
            Input.GetAxisRaw("Vertical") * 90.0f).normalized, Vector3.up);
        PlayerMesh.transform.rotation = LookRotation;
    }
}
