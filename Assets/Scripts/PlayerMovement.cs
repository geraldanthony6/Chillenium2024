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
        
        Debug.Log("Horizontal Value: " +Input.GetAxisRaw("Horizontal") );

        if (Input.GetAxisRaw("Horizontal") != 0.0f || Input.GetAxisRaw("Vertical") != 0.0f)
        {
            AnimController.SetBool("IsWalking", true);
        } else if (Input.GetAxisRaw("Horizontal") == 0.0f && Input.GetAxisRaw("Vertical") == 0.0f)
        {
            AnimController.SetBool("IsWalking", false);
        }
        
        if (Input.GetAxisRaw("Horizontal") == -1.0f)
        {
           Debug.Log("Flip the Character To Look Left");
           //PlayerMesh.transform.localRotation = MovingLeftRotation;
        }

        if (Input.GetAxisRaw("Horizontal") == 0.0f)
        {
            Debug.Log("No Flip Horizontal");
        }


        if (Input.GetAxisRaw("Horizontal") == 1.0f)
        {
            Debug.Log("Flip the character to the right");
        }
        
        if (Input.GetAxisRaw("Vertical") == -1.0f)
        {
            Debug.Log("Flip the Character To Look Down");
            //PlayerMesh.transform.localRotation = MovingLeftRotation;
        }

        if (Input.GetAxisRaw("Vertical") == 0.0f)
        {
            Debug.Log("No Flip Vertical");
        }


        if (Input.GetAxisRaw("Vertical") == 1.0f)
        {
            Debug.Log("Flip the character to Up");
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
