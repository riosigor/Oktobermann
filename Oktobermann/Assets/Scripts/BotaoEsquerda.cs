using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotaoEsquerda : Button 
{   
    Animator animator;
    private GameObject Personagem;
    void Awake ()
    {
        Personagem = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        animator = Personagem.GetComponent<Animator>();
    }
    void Update()
    {
        Pressionar();
    }
    void Pressionar()
    {
        if(IsPressed()== true)
        {
            animator.SetBool("Walking",true);
            Personagem.transform.localScale = new Vector3(-0.25f,0.25f,0.25f);
            Personagem.GetComponent<Jogador>().MoverE();
        }else
        {
            if(IsPressed()== false)
            {
                animator.SetBool("Walking",false);
            }
        }
    }
}
