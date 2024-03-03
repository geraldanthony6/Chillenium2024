using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float PlayerSpeed;

    [SerializeField] private Animator AnimController;

    [SerializeField] private GameObject PlayerMesh;

    [SerializeField] private Quaternion MovingLeftRotation = new Quaternion(-90.0f, 90.0f, -90.0f, Quaternion.identity.w);

    [SerializeField] private AudioSource Source;

    [SerializeField] private AudioClip TauntSound;

    [SerializeField] private AudioClip PointSound;

    [SerializeField] private AudioClip SlapSound;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * 15f * Time.deltaTime * Input.GetAxisRaw("Horizontal"));

        transform.Translate(Vector2.up * 15f * Time.deltaTime * Input.GetAxisRaw("Vertical"));

        if (Input.GetAxisRaw("Horizontal") != 0.0f || Input.GetAxisRaw("Vertical") != 0.0f)
        {
            AnimController.SetBool("IsWalking", true);
        }
        else if (Input.GetAxisRaw("Horizontal") == 0.0f && Input.GetAxisRaw("Vertical") == 0.0f)
        {
            AnimController.SetBool("IsWalking", false);
        }


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AnimController.SetTrigger("DoTaunt");
            Source.clip = TauntSound;
            Source.Play();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AnimController.SetTrigger("DoSlap");
            Source.clip = SlapSound;
            Source.Play();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            AnimController.SetTrigger("DoPoint");
            Source.clip = PointSound;
            Source.Play();
        }

        OnRotate();

    }

    void OnRotate()
    {
        var LookRotation = Quaternion.LookRotation(new Vector3(Input.GetAxisRaw("Horizontal") * 90.0f, 0.0f,
            Input.GetAxisRaw("Vertical") * 90.0f).normalized, Vector3.up);
        PlayerMesh.transform.rotation = LookRotation;
    }

    IEnumerator DoTaunt()
    {
        AnimController.SetTrigger("DoTaunt");
        yield return new WaitForSeconds(1.0f);
        //AnimController.SetTrigger("DoTaunt");
    }
}
