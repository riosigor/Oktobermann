using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuff : MonoBehaviour
{
    private Salve salvador;

    private PegouItem pegouItem;
    public Jogador player;
    private bool slowed = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Jogador>();
        salvador = GameObject.FindGameObjectWithTag("GameController").GetComponent<Salve>();
        pegouItem = GameObject.FindGameObjectWithTag("GameController").GetComponent<PegouItem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (salvador.InformaMapa() == 1) 
            {
                pegouItem.itens[4].SetActive(true);
                player.cervejinha = this.gameObject;
                player.slowed=true;
                player.velBoost = player.velNormal / 4;
                player.vel = player.velBoost;    
            }else if(salvador.InformaMapa() == 2)
            {
                pegouItem.itens[9].SetActive(true);
                player.cervejinha = this.gameObject;
                player.slowed = true;
                player.velBoost = player.velNormal / 4;
                player.vel = player.velBoost;
            }
        }
    }
    void OnTriggerExit2D(Collider2D ohter)
    {
        if(ohter.gameObject.tag == "Player")
        {
            if (salvador.InformaMapa() == 1)
            {
                pegouItem.itens[4].SetActive(false);
                player.vel = player.velNormal;
            }else if (salvador.InformaMapa() == 2)
            {
                pegouItem.itens[9].SetActive(false);
                player.vel = player.velNormal;
            }
        }
    }
}
