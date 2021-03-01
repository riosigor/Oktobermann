using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TocarSom : MonoBehaviour
{
    public enum tipoDebuff{normal,verde};
    public tipoDebuff debuffSpawn = new tipoDebuff();
    private MeuSom somJogador;
    private Jogador player;
    private GameController GameC;
    public GameObject CervejaDebuff;


    // Start is called before the first frame update
    void Start()
    {
        GameC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        somJogador = GameObject.FindGameObjectWithTag("sons").GetComponent<MeuSom>();
        player= GameObject.FindGameObjectWithTag("Player").GetComponent<Jogador>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // tocou no chao
		if(col.gameObject.tag == "chao")
		{
            SpawnItemDebuff();
            Destroy(gameObject);
		}
    }

    public void SpawnItemDebuff()
    {
        if(debuffSpawn == tipoDebuff.normal)
        {
            Vector3 pos0 = transform.position;
            GameObject item = Instantiate(CervejaDebuff,pos0,Quaternion.identity);
		    Destroy(item, 5f);
        }
        if(debuffSpawn == tipoDebuff.verde)
        {
            Vector3 pos0 = new Vector3(transform.position.x, -4.1f,transform.position.z);
            GameObject item = Instantiate(CervejaDebuff,pos0,Quaternion.identity);
		    Destroy(item, 5f);
        }
    }

}
