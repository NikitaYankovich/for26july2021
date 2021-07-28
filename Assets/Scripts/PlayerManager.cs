using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    private Animator animator;
    [SerializeField][Range(0,1)]private float walkspeed = 0.5f;

    public CinemachineVirtualCamera vcamera1;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetFloat("Blend IDLE/Walk",walkspeed);
        transform.Translate(new Vector3(0,0,((walkspeed-0.5f)*3)*Time.deltaTime));

        if (Input.GetKey(KeyCode.W) && walkspeed <1) {walkspeed += 0.002f;}
        else if (!Input.GetKey(KeyCode.W) && walkspeed >0.5){walkspeed -= 0.002f;}
        else if (Input.GetKey(KeyCode.S) && walkspeed >0) {walkspeed -= 0.002f;}
        else if (!Input.GetKey(KeyCode.S) && walkspeed <0.5){walkspeed += 0.002f;}

        if (Input.GetKey(KeyCode.A)){transform.rotation *= Quaternion.Euler(0,-0.05f,0);}
        if (Input.GetKey(KeyCode.D)){transform.rotation *= Quaternion.Euler(0,0.05f,0);}

        if (Input.GetKey(KeyCode.V)){vcamera1.m_Priority *= -1;}

        
    }

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("Main");
    }
}
