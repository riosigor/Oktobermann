using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour 
{
    private Rigidbody2D myBody;
	//debuff
	public GameObject cervejinha;
	public bool slowed = false;
	//scripts externos
	private Salve Salvador;
	private PegouItem pegouItem;
	private GameController GameC;
	//animação do player
	Animator animator;
	public int vida = 10;
	public int pontos = 0;
	public int qtdArrotos = 1;
	public int moedas = 0;
	public float vel;
	public float velNormal = 0.08f;
	public float velBoost;
	public bool podeSeguir;
	//Chamar Som
	private MeuSom somJogador;

	// Use this for initialization
	void Start () 
	{
        myBody = GetComponent<Rigidbody2D>();
		Salvador = GameObject.FindGameObjectWithTag("GameController").GetComponent<Salve>();
		vel = velNormal;
		pegouItem = GameObject.FindGameObjectWithTag("GameController").GetComponent<PegouItem>();
		podeSeguir = true;
		animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
		somJogador = GameObject.FindGameObjectWithTag("sons").GetComponent<MeuSom>();
		GameC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}
	
	public void AtualizaSprite()
	{
		float niveAtual = (float)Salvador.InformarNivel();
		velNormal = niveAtual/16;
		vel = velNormal;
	}

	// Update is called once per frame
	void Update () 
	{
        if (GameC.pausado == false)
        {
		    if(GameC.EstadoJogo()==true)
		    {
			    SeguirDedo();
		    }
		    if(podeSeguir == false)
		    {
			    animator.SetBool("Walking",false);
		    }

			isSlowed();
        }
		//Arroto();
	}

	public void MoverE()
	{
		if(transform.position.x >= -6.5)
		{
			Vector3 destino = new Vector3(transform.position.x - vel, transform.position.y, transform.position.z);
			transform.position = destino;
		}
	}

	public void MoverD()
	{
		if(transform.position.x < 6.5)
		{
			Vector3 destino = new Vector3(transform.position.x + vel, transform.position.y, transform.position.z);
			transform.position = destino;
		}
	}

	public bool PodeSeguir()
	{
		return podeSeguir;
	}
	void SeguirDedo()
	{
		if(Input.GetMouseButton(0) && transform.position.x <= 7 && transform.position.x >= -7)
		{
			podeSeguir = true;
			// capturar a posição do mouse \\
			Vector3 destino = Input.mousePosition;
			// corrigir a posição do mouse \\
			Vector3 destinoCorrigido = Camera.main.ScreenToWorldPoint(destino);
			// posição eixo X e Y \\
			Vector3 destinoFinal = new Vector3(destinoCorrigido.x,transform.position.y,transform.position.z);
			// Fazer o jogador seguir \\
			transform.position = Vector3.MoveTowards(transform.position,destinoFinal,vel);
			if(destinoCorrigido.x <	 1)
			{
				animator.SetBool("Walking",true);
				transform.localScale = new Vector3(-0.5f,0.5f,0.5f);
			}else
			{
				animator.SetBool("Walking",true);
				transform.localScale = new Vector3(0.5f,0.5f,0.5f);
			}
		}else
		{
			podeSeguir = false;
		}
		if(transform.position.x < -6.5f)
		{
			Vector3 x = new Vector3(-6.5f,transform.position.y,transform.position.z);
			transform.position = x;
		}else if (transform.position.x > 6.5f)
        {
			Vector3 x = new Vector3(6.5f,transform.position.y,transform.position.z);
			transform.position = x;
		}
	}

	//Onde ocorre as colisões

	void OnCollisionEnter2D(Collision2D col)
	{
		// tocou na "comida"
		if(col.gameObject.tag == "comida")
		{
            pegouItem.tipoitens = TipoItem.Cerveja;
			pegouItem.StartCoroutine("BuffOn");
			somJogador.SomPonto();
			pontos++;	
			Destroy(col.gameObject);
		}
		// tocou na moeda
		if(col.gameObject.tag == "moeda")
		{
            pegouItem.tipoitens = TipoItem.Moeda;
            pegouItem.StartCoroutine("BuffOn");
			somJogador.SomMoeda();
			moedas++;
			Destroy(col.gameObject);
		}
		// tocou no inimigo
		if(col.gameObject.tag == "malvado")
		{
            pegouItem.tipoitens = TipoItem.Corassaum;
            animator.SetTrigger("Damaged");
			pegouItem.StartCoroutine("BuffOn");
			somJogador.SomDano();
			vida--;
			Destroy(col.gameObject);
		}
		//bebeu cerveja
		if(col.gameObject.tag == "cerveja")
		{
            pegouItem.tipoitens = TipoItem.Cerveja;
            pegouItem.StartCoroutine("BuffOn");
			somJogador.SomGolada();
			pontos += 2;
			Destroy(col.gameObject);
		}
		if(col.gameObject.tag == "garrafa")
		{
            pegouItem.tipoitens = TipoItem.Garrafa;
            pegouItem.StartCoroutine("BuffOn");
			somJogador.SomGolada();
			StartCoroutine("SpeedBoost");
			pontos +=1;
			Destroy(col.gameObject);
		}
		if(pontos > 1)
		{
			int valorD = qtdArrotos * 10;
			if(pontos >= valorD)
			{
				somJogador.SomArroto();
				qtdArrotos++;
			}
		}
	}

	IEnumerator SpeedBoost()
	{
		velBoost = velNormal * 2;
		vel = velBoost;
		yield return new WaitForSeconds(3.5f);
		vel = velNormal;
		StopCoroutine("SpeedBoost");
	}	
	public void isSlowed()
	{
		if(slowed == true)
		{
			if(cervejinha == null)
			{
                if (Salvador.InformaMapa() == 1) 
                {
				    pegouItem.itens[4].SetActive(false);
				    slowed=false;
				    vel = velNormal;
                }else if(Salvador.InformaMapa() == 2)
                {
                    pegouItem.itens[9].SetActive(false);
                    slowed = false;
                    vel = velNormal;
                }
			}
		}
	}
}