using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMap : MonoBehaviour
{
    private GameController gameC;
    private Salve Salvador;
    private int mapaAtual;
    public GameObject map1;
    public GameObject map2;

    // Start is called before the first frame update
    void Start()
    {
        gameC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        Salvador = GameObject.FindGameObjectWithTag("GameController").GetComponent<Salve>();
        MapChange(Salvador.InformaMapa());
        //Debug.Log(Salvador.InformaMapa());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MapChange(int value)
    {
        switch(value)
        {
            case 1:
                map1.SetActive(true);
                map2.SetActive(false);
            break;
            case 2:
                map1.SetActive(false);
                map2.SetActive(true);
            break;
            default:
                value = 1;
                MapChange(1);
            break;
        }
        gameC.ChangeCharacter();
        Salvador.NovoMapa(value);
    }

}
