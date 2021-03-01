using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesOn : MonoBehaviour
{
    public GameObject particula1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        // tocou no chao
		if(col.gameObject.tag == "Player")
		{
            SpawnParticle();
            //Destroy(gameObject);
		}
    }
    public void SpawnParticle()
    {
        Vector3 pos0 = transform.position;
		GameObject item = Instantiate(particula1,pos0,Quaternion.identity);
		Destroy(item, 1f);
    }

}
