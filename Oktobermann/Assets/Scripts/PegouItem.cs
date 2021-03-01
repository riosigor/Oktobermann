using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PegouItem : MonoBehaviour
{
    private Salve salvador;

    public TipoItem tipoitens = new TipoItem();
    public GameObject[] itens;
    public GameObject moeda;
    public GameObject vida;
    public GameObject ponto;
    public GameObject speedly;
    public GameObject spdDown;
    // Start is called before the first frame update
    void Start()
    {
        salvador = GameObject.FindGameObjectWithTag("GameController").GetComponent<Salve>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator BuffOn()
    {
        if(salvador.InformaMapa() == 1) 
        {
            if(tipoitens == TipoItem.Cerveja)
            {
                itens[0].SetActive(true);
                yield return new WaitForSeconds(0.5f);
                itens[0].SetActive(false);
            }else if(tipoitens == TipoItem.Moeda)
            {
                itens[2].SetActive(true);
                yield return new WaitForSeconds(0.5f);
                itens[2].SetActive(false);
            }
            else if(tipoitens == TipoItem.Garrafa)
            {
                itens[3].SetActive(true);
                yield return new WaitForSeconds(0.5f);
                itens[3].SetActive(false);
            }else if(tipoitens == TipoItem.Corassaum)
            {
                itens[1].SetActive(true);
                yield return new WaitForSeconds(0.5f);
                itens[1].SetActive(false);
            }
        }else if (salvador.InformaMapa() == 2) 
        {
            if (tipoitens == TipoItem.Cerveja)
            {
                itens[5].SetActive(true);
                yield return new WaitForSeconds(0.5f);
                itens[5].SetActive(false);
            }
            else if (tipoitens == TipoItem.Moeda)
            {
                itens[7].SetActive(true);
                yield return new WaitForSeconds(0.5f);
                itens[7].SetActive(false);
            }
            else if (tipoitens == TipoItem.Garrafa)
            {
                itens[8].SetActive(true);
                yield return new WaitForSeconds(0.5f);
                itens[8].SetActive(false);
            }
            else if (tipoitens == TipoItem.Corassaum)
            {
                itens[6].SetActive(true);
                yield return new WaitForSeconds(0.5f);
                itens[6].SetActive(false);
            }
        }
        StopCoroutine("BuffOn");
    }

    public void ResetAll()
	{
		for (int i = 0; i < itens.Length; i++)
		{
			itens[i].SetActive(false);
		}
	}
}
