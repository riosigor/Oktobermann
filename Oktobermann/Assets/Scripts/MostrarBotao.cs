using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MostrarBotao : MonoBehaviour
{
    public GameObject botaoRecompensa;
    private GameController GameC;
    //private Salve Salvador;

    int sorteio;
    // Start is called before the first frame update
    void Start()
    {
        GameC = GameObject.FindGameObjectWithTag("GameController")
        .GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
      MostrarBotaoRecompensa();
    }

    public void MostrarBotaoRecompensa() 
    {
        if(GameC.morreu == true){
            if(GameC.mostrarRecompensa == true)
            {
                GameC.mostrarRecompensa = false;       
                botaoRecompensa.SetActive(true);
            }
        }
    }
}
