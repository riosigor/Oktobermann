using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour 
{
    public GameObject cloudRain;
    public GameObject spawnObject;
    public GameObject polenta;
	public GameObject Cerveja;
	public GameObject Objeto_que_cai;
	public GameObject Obj_que_cai2;
	public GameObject Garrafa;
	public float tempo = 1f;

    private int rainSorteio;
    private bool readyToRain = false;

	public GameObject ObjetoMoeda;

	private int contador = 0;

	//public float contadorSpawner = 50;

	private GameController GameC;
    private Salve salvador;

	// Use this for initialization
	void Start () 
	{
		GameC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        salvador = GameObject.FindGameObjectWithTag("GameController").GetComponent<Salve>();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
		

	public IEnumerator Spawnar()
	{
        yield return new WaitForSeconds(tempo);
        SpawnItens();
        tempo -= 0.003f;
	}

    void SpawnItens() 
    {
        int sorteio = Random.Range(0, 100);

        if (sorteio <= 25)
        {
            if (salvador.InformaMapa() == 1)
            {
                float posX = Random.Range(-7, 7);

                Vector3 pos0 = new Vector3(posX, 5.7f, 0);
                GameObject item = Instantiate(Objeto_que_cai, pos0, Quaternion.identity);
                Destroy(item, 2.5f);
                contador = 0;
            }
            else if (salvador.InformaMapa() == 2)
            {
                float posX = Random.Range(-7, 7);

                Vector3 pos0 = new Vector3(posX, 5.7f, 0);
                GameObject item = Instantiate(polenta, pos0, Quaternion.identity);
                Destroy(item, 2.5f);
                contador = 0;
            }
        }
        else
        {
            if (sorteio > 25 && sorteio < 60)
            {
                float posX = Random.Range(-7, 7);

                Vector3 pos0 = new Vector3(posX, 5.7f, 0);
                GameObject item = Instantiate(Obj_que_cai2, pos0, Quaternion.identity);
                contador = 0;
            }
            else
            {
                if (sorteio > 60 && sorteio < 75)
                {
                    float posX = Random.Range(-7, 7);

                    Vector3 pos0 = new Vector3(posX, 5.7f, 0);
                    GameObject item = Instantiate(ObjetoMoeda, pos0, Quaternion.identity);
                    Destroy(item, 2.5f);
                    contador = 0;
                }
                else
                if (sorteio > 75 && sorteio < 95)
                {
                    float posX = Random.Range(-7, 7);

                    Vector3 pos0 = new Vector3(posX, 5.7f, 0);
                    GameObject item = Instantiate(Cerveja, pos0, Quaternion.identity);
                    contador = 0;
                }
                if (sorteio > 95)
                {
                    float posX = Random.Range(-7, 7);

                    Vector3 pos0 = new Vector3(posX, 5.7f, 0);
                    GameObject item = Instantiate(Garrafa, pos0, Quaternion.identity);
                    contador = 0;
                }

            }
        }

        if(tempo <= 0.15f) 
        {
            tempo = 0.15f;
        }
        StartCoroutine("Spawnar");
        if(readyToRain == false)
        {
            StartCoroutine("RainTime");
        }
    }
    
    public IEnumerator RainTime()
    {
        readyToRain = true;
        cloudRain.SetActive(true);
        rainSorteio = Random.Range(0,100);
        yield return new WaitForSeconds(10);
        cloudRain.SetActive(false);
        StopCoroutine("Spawnar");
        RainEvent();
        yield return new WaitForSeconds(5);
        StartCoroutine("Spawnar");
        readyToRain = false;
    }

    public IEnumerator TimeToRain()
    {
        float time = Random.Range(0.15f,0.25f);
        int itemRange = Random.Range(20,50); 

        
        for (int i = 0; i < itemRange; i++)
        {
            float posX = Random.Range(-7, 7);

            Vector3 pos0 = new Vector3(posX, 5.7f, 0);

            yield return new WaitForSeconds(time);

            GameObject item = Instantiate(spawnObject, pos0, Quaternion.identity);
        }
        
    }

    public void RainEvent()
    {
        int sorteio = Random.Range(1,100);      
        //Debug.Log(rainSorteio);
        if(sorteio >= 95)
        {
            spawnObject = Garrafa;
        }else if(sorteio < 95 && sorteio >= 75)
        {
            spawnObject = Cerveja;
        }else if(sorteio < 75 && sorteio >= 60)
        {
            spawnObject = ObjetoMoeda;
        }else if(sorteio < 60 && sorteio >= 25)
        {
            spawnObject = Obj_que_cai2;
        }else if(sorteio < 25 && sorteio >= 1)
        {
            if(salvador.InformaMapa() == 1)
            {
                spawnObject = Objeto_que_cai;
            }
            else if(salvador.InformaMapa() == 2)
            {
                spawnObject = polenta;
            }
            
        }
        StartCoroutine(TimeToRain());
    }
}