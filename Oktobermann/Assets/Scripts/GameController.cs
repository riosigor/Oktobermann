using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour 
{
    [Header("Player")]
    public GameObject CharMap1;
    public GameObject CharMap2;

    public bool sunsetOn = false;
    //botão de pausar
	public Text pause;
    public bool pausado = false;
    public Image botaoDePausar;
    public Sprite btPause;
    public Sprite btPlay;
    //public GameObject prefab1, prefab2, prefab3;
	//Salve do jogo
	private Salve Salvador;

	//Telas de Record e GameOver
	public Text totalPontos;
	public GameObject GameOver;
	public Text Record;
	public Text MaiorRecord;
	public Text Parabens;

	public Text TotalMoedas;

	public Text MoedasAtuais;

	public bool morreu = false;

	//Pontos, moedas e vidas no canvas
	public Text pontos;
	public Text moedas;
	public Text vida;
	//Guarda a variável do usuário
	private GameObject Jogador;
    public GameObject[] Jogadores;
	//Detectar se o jogo está ativo
	public bool gameON = false;

	public bool mostrarRecompensa = false;

	private Spawner spawner;
	private ChangeMap mudarMapa;

    private PegouItem pegouItem;

	// Use this for initialization
	void Start ()
	{
        pegouItem = GameObject.FindGameObjectWithTag("GameController").GetComponent<PegouItem>();
        mudarMapa = GameObject.FindGameObjectWithTag("GameController").GetComponent<ChangeMap>();
		spawner = GameObject.FindGameObjectWithTag("GameController").GetComponent<Spawner>();
		//Busca o jogador
		Jogador = GameObject.FindGameObjectWithTag("Player");
		Salvador = GameObject.FindGameObjectWithTag("GameController").GetComponent<Salve>();
		//Inicia o jogo em tempo 1
		Time.timeScale=1;
	}
	
	// Update is called once per frame
	void Update () {
        if(pausado == false)
        {
		    if(gameON == true)
		    {
                int numJogador = Salvador.InformaMapa() - 1;

                pontos.text = Jogadores[numJogador].GetComponent<Jogador>().pontos.ToString();
                vida.text = Jogadores[numJogador].GetComponent<Jogador>().vida.ToString();
                moedas.text = Jogadores[numJogador].GetComponent<Jogador>().moedas.ToString();

                Morreu();
		    }
		    if(gameON == false)
		    {
			    LimparCena();
		    }
        }
	}

	void FixedUpdate()
	{

	}

	public bool EstadoJogo()
	{
		return gameON;
	}

	public void ParametrosIniciais()
	{
        int numJogador = Salvador.InformaMapa() - 1;

		Time.timeScale = 1;
        if(numJogador == 0)
        {
		    spawner.tempo = 1.5f;            
        }else
        {
            spawner.tempo = 1f;
        }
        Jogadores[numJogador].GetComponent<Jogador>().qtdArrotos = 1;
        Jogadores[numJogador].GetComponent<Jogador>().pontos = 0;
        Jogadores[numJogador].GetComponent<Jogador>().vida = 1;
        Jogadores[numJogador].GetComponent<Jogador>().moedas = 0;
        Jogadores[numJogador].GetComponent<Jogador>().vida = Salvador.InformarVidas();
		if(Salvador.InformarNivel() >= 1)
		{
            Jogadores[numJogador].GetComponent<Jogador>().AtualizaSprite();
        }
		GameOver.SetActive(false);
		morreu = false;
	}		

	public void IniciarJogo()
	{
		gameON = true;
		ParametrosIniciais();
        spawner.StartCoroutine("Spawnar");
	}
	void Morreu()
	{
        int numJogador = Salvador.InformaMapa() - 1;

        if (Jogadores[numJogador].GetComponent<Jogador>().vida == 0)
		{
            int sorteio = Random.Range(0, 100);
			gameON = false;
            if(sorteio >=20 && sorteio <= 30)
            {
                //Debug.Log(sorteio);
			    GetComponent<Propaganda>().ShowAd2();
            }
			Time.timeScale=0;
			GameOver.SetActive(true);
			morreu = true;
			mostrarRecompensa = true;
			Record.text = "Pontos: " + Jogadores[numJogador].GetComponent<Jogador>().pontos.ToString();
			if(Salvador.NovoRecord(Jogadores[numJogador].GetComponent<Jogador>().pontos) == true)
			{
				//Dar parabéns
				//Debug.Log("Parabéns");
            } else
			{
                //Não dar parabéns
                //Debug.Log("Tente outra vez");
			}
			MaiorRecord.text = "Record: " + Salvador.InformaRecord().ToString();

			// Informa Moedas

			//Informar Moedas Atuais


			MoedasAtuais.text = Jogadores[numJogador].GetComponent<Jogador>().moedas.ToString();


			//pega moedas do save
			int moedasatuais = Salvador.InformaMoeda();
			//soma as moedas
			moedasatuais = moedasatuais + Jogadores[numJogador].GetComponent<Jogador>().moedas;
			//informa ao save o total de moedas
			Salvador.NovoMoeda(moedasatuais);
			//exibe as moedas
			TotalMoedas.text = Salvador.InformaMoeda().ToString();

            //pega pontos do save
            int PontosAtuais = Salvador.InformaPontosTotal();
            //soma os pontos
            PontosAtuais = PontosAtuais + Jogadores[numJogador].GetComponent<Jogador>().pontos;
            //informa ao save o total de pontos
            Salvador.NovoPonto(PontosAtuais);

            spawner.StopCoroutine("Spawnar");
        }

    }
	//Dar recompensa ao jogador
	public void RecompensarJogador()
	{
        int numJogador = Salvador.InformaMapa() - 1;
        
        //Multiplica moedas atuais x2
        int vzs2 = Jogadores[numJogador].GetComponent<Jogador>().moedas * 2;
		//Informa a nova quantidade de moedas atuais
		MoedasAtuais.text = vzs2.ToString();

		//pega moedas do save
		int moedasatuais = Salvador.InformaMoeda();
		//soma as moedas
		moedasatuais = moedasatuais + Jogadores[numJogador].GetComponent<Jogador>().moedas;
		//informa ao save o total de moedas
		Salvador.NovoMoeda(moedasatuais);
		//exibe as moedas
		TotalMoedas.text = Salvador.InformaMoeda().ToString();

    }

	public void Reiniciar()
	{
		gameON=true;
        pegouItem.ResetAll();
		ParametrosIniciais();
        spawner.StartCoroutine("Spawnar");
	}

    public void Fechar()
    {
        Application.Quit();
    }

	public void VoltarMenu()
	{
		SceneManager.LoadScene(0);
	}

	public void LimparCena()
	{
		//Limpa a cena
		GameObject[] gameObjeto = GameObject.FindGameObjectsWithTag("comida");
        foreach (GameObject destroy in gameObjeto)
        Destroy(destroy);
		GameObject[] gameObjeto2 = GameObject.FindGameObjectsWithTag("malvado");
        foreach (GameObject destroy in gameObjeto2)
        Destroy(destroy);
		GameObject[] gameObjeto3 = GameObject.FindGameObjectsWithTag("moeda");
        foreach (GameObject destroy in gameObjeto3)
        Destroy(destroy);
		GameObject[] gameObjeto4 = GameObject.FindGameObjectsWithTag("garrafa");
        foreach (GameObject destroy in gameObjeto4)
        Destroy(destroy);
		GameObject[] gameObjeto5 = GameObject.FindGameObjectsWithTag("cerveja");
        foreach (GameObject destroy in gameObjeto5)
        Destroy(destroy);
		GameObject[] gameObjeto6 = GameObject.FindGameObjectsWithTag("cervejaDebuff");
        foreach (GameObject destroy in gameObjeto6)
        Destroy(destroy);
	}

    public void PausarJogo()
    {
        if (pausado == false)
        {
            pausado = true;
			pause.text = "Play".ToString();
            Time.timeScale = 0;
        }
        else
        {
            pausado = false;
			pause.text = "Pause".ToString();
            Time.timeScale = 1;
        }
    }

    public void ChangeCharacter() 
    {  
        if (Salvador.InformaMapa()==1) 
        {
            CharMap1.SetActive(true);
            CharMap2.SetActive(false);
        }
        else if (Salvador.InformaMapa() == 2) 
        {
            CharMap1.SetActive(false);
            CharMap2.SetActive(true);
        }
    }
}