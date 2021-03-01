using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salve : MonoBehaviour 
{
    //Som (Ligado = 1, Desligado = 0)
    private int som = 1;

	private int somFX = 1;
	private int maiorPontuacao = 0;
	private int TotalPontos = 0;
	private int mapa = 0;
	private int VidasMax = 0;
	private int moedas = 0;

	private int nivel = 0;

	// Use this for initialization
	void Start () 
	{
		//Total de Pontos
		if(PlayerPrefs.HasKey("TotalPontos") == true)
		{
			maiorPontuacao = PlayerPrefs.GetInt("TotalPontos");
		}else
		{
			PlayerPrefs.SetInt("TotalPontos", 0);
		}
		//Mapa Atual
		if(PlayerPrefs.HasKey("mapa") == true)
		{
			mapa = PlayerPrefs.GetInt("mapa");
		}else
		{
			PlayerPrefs.SetInt("mapa", 0);
		}
		//Record
		if(PlayerPrefs.HasKey("Record") == true)
		{
			maiorPontuacao = PlayerPrefs.GetInt("Record");
		}else
		{
			PlayerPrefs.SetInt("Record", 0);
		}
		//Moedas
		if(PlayerPrefs.HasKey("Moedas") == true)
		{
			maiorPontuacao = PlayerPrefs.GetInt("Moedas");
		}else
		{
			PlayerPrefs.SetInt("Moedas", 0);
		}
		//Vidas
		if(PlayerPrefs.HasKey("VidasMax") == true)
		{
			VidasMax = PlayerPrefs.GetInt("VidasMax");
		}else
		{
			PlayerPrefs.SetInt("VidasMax", 3);
		}
		//Nível
		if(PlayerPrefs.HasKey("nivel") == true)
		{
			nivel = PlayerPrefs.GetInt("nivel");
		}else
		{
			PlayerPrefs.SetInt("nivel", 1);
		}
        //Som
        if (PlayerPrefs.HasKey("som") == true) 
        {
            som = PlayerPrefs.GetInt("som");
        } else 
        {
            PlayerPrefs.SetInt("som", 1);
        }
		
	    //SomFX
        if (PlayerPrefs.HasKey("somFX") == true) 
        {
            somFX = PlayerPrefs.GetInt("somFX");
        } else 
        {
            PlayerPrefs.SetInt("somFX", 1);
        }
    }
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	//Recebe Valor de pontos
	public bool NovoRecord(int valor)
	{
		if(maiorPontuacao >= valor)
		{
			return false;
		}else
		{
			PlayerPrefs.SetInt("Record", valor);
			return true;
		}
	}
	//Informa Valor de pontos
	public int InformaRecord()
	{
		maiorPontuacao = PlayerPrefs.GetInt("Record");
		return maiorPontuacao;
	}
	//Recebe Valor de Moedas
	public void NovoMoeda(int valor)
	{
		PlayerPrefs.SetInt("Moedas", valor);
	}
	//Informa Valor de moedas
	public int InformaMoeda()
	{
		moedas = PlayerPrefs.GetInt("Moedas");
		return moedas;
	}
	//Informar Total de Pontos
	public int InformaPontosTotal()
	{
		TotalPontos = PlayerPrefs.GetInt("TotalPontos");
		return TotalPontos;
	}
    //Salva O Total De Pontos
    public void NovoPonto(int valor)
    {
        //Recebe valor dos pontos
        PlayerPrefs.SetInt("TotalPontos", valor);
    }
    //Valor do mapa
    public void NovoMapa(int valor) 
	{
        //Recebe valor do mapa
        PlayerPrefs.SetInt("mapa", valor);
    }
	public int InformaMapa() 
	{
        mapa = PlayerPrefs.GetInt("mapa");
        return mapa;
    }
	// VIDAS
	public int InformarVidas()
	{
		VidasMax = PlayerPrefs.GetInt("VidasMax");
		return VidasMax;
	}

	public void AumentaVida()
	{
		VidasMax = PlayerPrefs.GetInt("VidasMax");
		VidasMax++;
		PlayerPrefs.SetInt("VidasMax", VidasMax);
	}

	// Nível
	public int InformarNivel()
	{
		nivel = PlayerPrefs.GetInt("nivel");
		return nivel;
	}

	public void AumentaNivel()
	{
		nivel = PlayerPrefs.GetInt("nivel");
		nivel++;
		PlayerPrefs.SetInt("nivel", nivel);
	}

    // Som
    public void NovoSom(int valor) 
	{
        //Recebe valor de som
        PlayerPrefs.SetInt("som", valor);
    }   

    public int InformaSom() 
	{
        som = PlayerPrefs.GetInt("som");
        return som;
    }

	// SomFX
    public void NovoSomFX(int valor) {
        //Recebe valor de som
        PlayerPrefs.SetInt("somFX", valor);
    }
        

    public int InformaSomFX() {
        somFX = PlayerPrefs.GetInt("somFX");
        return somFX;
    }
}