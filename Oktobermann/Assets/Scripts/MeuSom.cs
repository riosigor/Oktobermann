using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MeuSom : MonoBehaviour
{
    //Salve do jogo
    private Salve Salvador;

    

    //Referente ao Botão
    public Image MeuBotao;
    public Image MeuBotaoFX;
    //Referente a imagem do botão ligado e desligado
    public Sprite btLigado;
    public Sprite btDesligado;
    //Estado atual do botão (desligado e ligado)
    public bool estadoAudio = true;

    public bool estadoAudioFX = true;

    //Mixer
    public AudioMixer MeuMixer;

    //dano
    public AudioClip dano;
    //ponto
    public AudioClip ponto;
    //moeda
    public AudioClip moeda;
    //vidro quebrando
    public AudioClip vidro;
    //arroto
    public AudioClip arroto;
    //golada
    public AudioClip golada;
    //comprando
    public AudioClip comprando;

    //Emissor de som
    private AudioSource fonteDeSom;


    // Start is called before the first frame update
    void Start()
    {
        //Busca o save do jogo
        Salvador = GameObject.FindGameObjectWithTag("GameController").GetComponent<Salve>();
        //Informa o valor do estado
        if(Salvador.InformaSom() == 1) 
        {
            estadoAudio = true;
        } else 
        {
            estadoAudio = false;      
        }
        //Garantindo estado de áudio
        if (estadoAudio == true) 
        {
            MeuBotao.sprite = btLigado;
            MeuMixer.SetFloat("MixerGeral", -5);
        } else 
        {
            MeuBotao.sprite = btDesligado;
            MeuMixer.SetFloat("MixerGeral", -80);
        }

        //Informa o valor do estado FX
        if(Salvador.InformaSomFX() == 1) 
        {
            estadoAudioFX= true;
        } else 
        {
            estadoAudioFX = false;      
        }
        //Garantindo estado de áudio FX
        if (estadoAudioFX == true) 
        {
            MeuBotaoFX.sprite = btLigado;
            MeuMixer.SetFloat("MixerFX", 10);
        } else 
        {
            MeuBotaoFX.sprite = btDesligado;
            MeuMixer.SetFloat("MixerFX", -80);
        }

        fonteDeSom = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Dano
    public void SomDano() 
    {
        fonteDeSom.clip = dano;
        fonteDeSom.Play();
    }
    //Ponto
    public void SomPonto() 
    {
        fonteDeSom.clip = ponto;
        fonteDeSom.Play();
    }
    //Dano
    public void SomMoeda() 
    {
        fonteDeSom.clip = moeda;
        fonteDeSom.Play();
    }
    //vidro quebrando
    public void SomVidro() 
    {
        fonteDeSom.clip = vidro;
        fonteDeSom.Play();
    }
    //arroto
    public void SomArroto() 
    {
        fonteDeSom.clip = arroto;
        fonteDeSom.Play();
    }
    //golada
    public void SomGolada() 
    {
        fonteDeSom.clip = golada;
        fonteDeSom.Play();
    }
    //comprando
    public void SomComprando() 
    {
        fonteDeSom.clip = comprando;
        fonteDeSom.Play();
    }

    public void AlterarSom() 
    {
        if(estadoAudio == true) 
        {
            //Desligar
            MeuMixer.SetFloat("MixerGeral", -80); // Desliga o Som
            MeuBotao.sprite = btDesligado; // Altera o Sprite
            estadoAudio = false; // Altera o Estado
            Salvador.NovoSom(0);
        } else 
        {
            //Ligar
            MeuMixer.SetFloat("MixerGeral", -5); // Liga o som
            MeuBotao.sprite = btLigado; // Altera o Sprite
            estadoAudio = true; // Altera o Estado
            Salvador.NovoSom(1);
        }
    }

    public void AlterarSomFX() {
        if (estadoAudio == true) {
            //Desligar
            MeuMixer.SetFloat("MixerFX", -80); // Desliga o Som
            MeuBotaoFX.sprite = btDesligado; // Altera o Sprite
            estadoAudio = false; // Altera o Estado
            Salvador.NovoSomFX(0);
        } else {
            //Ligar
            MeuMixer.SetFloat("MixerFX", 10); // Liga o som
            MeuBotaoFX.sprite = btLigado; // Altera o Sprite
            estadoAudio = true; // Altera o Estado
            Salvador.NovoSomFX(1);
        }
    }
}