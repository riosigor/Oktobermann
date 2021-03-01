using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeuBg : MonoBehaviour
{
    private Rigidbody2D myBody;
    public Salve salvador;
    public float sunsetTime;
    public Sprite sun, moon;
    public GameObject bgNight, posteA, posteB;
    SpriteRenderer sunSprite, bgN;
    Animator poste, poste1;
    public enum tipoBG {Sol, NuvemGrande, NuvemPequena};
    public tipoBG tipobgs = new tipoBG();
    public float velocidade;
    private GameController GameC;
    bool solOn = true;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        salvador = GameObject.FindGameObjectWithTag("GameController").GetComponent<Salve>();
        GameC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        sunSprite = GetComponent<SpriteRenderer>();
        if(tipobgs==tipoBG.Sol)
        {
            bgN = bgNight.GetComponent<SpriteRenderer>();
            if(salvador.InformaMapa() == 1) 
            {
                poste = posteA.GetComponent<Animator>();
                poste1 = posteB.GetComponent<Animator>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveClouds();
    }  

    void ChangeSpriteSun()
    {
        if(solOn == true)
        {
            solOn = false;
            StartCoroutine("FadeInSpriteBgCeuDia");
            StopCoroutine("FadeOutSpriteBgCeuDia");
            sunSprite.sprite = moon;
        }else
        {
            solOn = true;
            StartCoroutine("FadeOutSpriteBgCeuDia");
            StopCoroutine("FadeInSpriteBgCeuDia");
            sunSprite.sprite = sun;
        }
    }

    public IEnumerator FadeOutSpriteBgCeuDia()
    {
        Color tmpColor = bgN.color;
        while  (tmpColor.a > 0f)
        {
            tmpColor.a -= Time.deltaTime / sunsetTime;
            bgN.color = tmpColor;

            if (tmpColor.a <= 0f)
                tmpColor.a = 0.0f;
        yield return null;
        }
        bgN.color = tmpColor;
    }

    public IEnumerator FadeInSpriteBgCeuDia()
    {
        Color tmpColor = bgN.color;
        while (tmpColor.a < 0.6f)
        {
            tmpColor.a += Time.deltaTime / sunsetTime;
            bgN.color = tmpColor;

            if (tmpColor.a >= 0.6f)
                tmpColor.a = 0.6f;
            yield return null;
        }
        bgN.color = tmpColor;
    }

    void MoveClouds()
    {
        if(GameC.pausado==false)
        {
            if(tipobgs == tipoBG.NuvemGrande)
            {
                myBody.position = new Vector3(transform.position.x - velocidade, transform.position.y, transform.position.z);
                if(transform.position.x < -11.5f) 
                {
                    myBody.position = new Vector3( 11.5f, transform.position.y, transform.position.z);
                    velocidade = Random.Range(0.01f, 0.02f);
                }
            }
            if(tipobgs == tipoBG.Sol)
            {
                myBody.position = new Vector3(transform.position.x - velocidade, transform.position.y, transform.position.z);
                if(transform.position.x < -11.5f) 
                {
                    ChangeSpriteSun();
                    myBody.position = new Vector3( 11.5f, transform.position.y, transform.position.z);
                    velocidade = 0.003f;
                }
                if(transform.position.x >= 9 && transform.position.x <=9.2)
                {
                    if (salvador.InformaMapa() == 1) 
                    {
                        if (solOn == true)
                        {
                            poste.SetBool("lightOn", true);
                            poste1.SetBool("lightOn", true);
                        }
                        else
                        {
                            poste.SetBool("lightOn", false);
                            poste1.SetBool("lightOn", false);
                        }
                    }
                }
            }
            if(tipobgs == tipoBG.NuvemPequena)
            {
                myBody.position = new Vector3(transform.position.x - velocidade, transform.position.y, transform.position.z);
                if(transform.position.x < -11.5f) 
                {
                    myBody.position = new Vector3( 11.5f, transform.position.y, transform.position.z);
                    velocidade = Random.Range(0.03f, 0.05f);
                }
            }
        }
    }
}
