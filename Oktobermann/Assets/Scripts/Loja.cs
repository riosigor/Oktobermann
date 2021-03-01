using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loja : MonoBehaviour {
	//Pegando informações do save
	private Salve Salvador;

	public Text TotalMoedas;

	private MeuSom somJogador;

	public Text custoCoracao;

	public Text custoSkin;
	private int minhaCarteira;

	// Use this for initialization
	void Start () 
	{
		somJogador = GameObject.FindGameObjectWithTag("sons").GetComponent<MeuSom>();
		Salvador = GameObject.FindGameObjectWithTag("GameController").GetComponent<Salve>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		ExibirMoedas();
		AtualizaCusto();
	}
	void AtualizaCusto()
	{
		int custo = Salvador.InformarVidas() * 5;
		custoCoracao.text =  "Vidas: " + Salvador.InformarVidas().ToString()+"\n $ "+custo.ToString();
		int custoNivel = Salvador.InformarNivel() * 50;
		custoSkin.text = "Nivel: " + Salvador.InformarNivel().ToString()+"\n $ "+custoNivel.ToString();
	}

	void ExibirMoedas()
	{
		TotalMoedas.text = Salvador.InformaMoeda().ToString();
	}

	public void Botao1()
	{
        if(Salvador.InformarVidas() <= 9)
        {
		    int vidasAtuais = Salvador.InformarVidas();
		    int valorVida = 5 * vidasAtuais;
		    Comprar(valorVida,1);
        }
	}

	public void Botao2()
	{
		if(Salvador.InformarNivel() == 1)
		{
			Comprar(50,2);
		}else if(Salvador.InformarNivel() <= 2)
		{
			int nivelAtual = Salvador.InformarNivel();
			int valorNivel = 50 * nivelAtual;
			Comprar(valorNivel,2);
		}
	}


	void Comprar(int Valor, int numero_botao)
	{
		// verifica o tanto de moedas
		minhaCarteira = Salvador.InformaMoeda();
		// verifica se você tem moedas para comprar
		if(Valor <= minhaCarteira)
		{
			somJogador.SomComprando();
			minhaCarteira= minhaCarteira - Valor;
			Salvador.NovoMoeda(minhaCarteira);
			Comprado(numero_botao);
		}
	}


	void Comprado(int numeroCompra)
	{
		switch(numeroCompra){
		
			case 1:
				Salvador.AumentaVida();
				break;
			case 2:
				Salvador.AumentaNivel();
				break;
			default:
				// não deve acontecer
				break;
		}
		
	}

	public void QuadBirdButton(int num)
	{

		switch(num)
		{
			case 1:
				Application.OpenURL("https://play.google.com/store/apps/details?id=com.CloudByteStudio.QuadbirdSave&hl=pt_PT");
			break;

			case 2:
				Application.OpenURL("http://cloudbytestudio.com/");
			break;

			default:

			break;
		}
		
	}
}
