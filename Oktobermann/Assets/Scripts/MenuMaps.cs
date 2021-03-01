using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuMaps : MonoBehaviour
{
    //public int id;
    public Text Prog;
    public Image BarraProg;
    public Button buttonChangeMap;
    public int PontosNec;
    public int pontosAtuais;

    private Salve salvador;

    // Start is called before the first frame update
    void Start()
    {
        salvador = GameObject.FindGameObjectWithTag("GameController").GetComponent<Salve>();
        VerifyPoints();
    }

    // Update is called once per frame
    void Update()
    {
        //VerifyPoints();
    }

    void VerifyPoints()
    {
        if(pontosAtuais < PontosNec)
        {  
            pontosAtuais = salvador.InformaPontosTotal();
            Prog.text = "Pontos: " + pontosAtuais + "/" + PontosNec.ToString();
            BarraProg.fillAmount = (float)pontosAtuais/(float)PontosNec;
            buttonChangeMap.enabled = false;
        }
        if(pontosAtuais >= PontosNec)
        {
            pontosAtuais = salvador.InformaPontosTotal();
            Prog.text = "Mapa Liberado";
            BarraProg.fillAmount = 1;
            buttonChangeMap.enabled = true;
        }
    }
}
