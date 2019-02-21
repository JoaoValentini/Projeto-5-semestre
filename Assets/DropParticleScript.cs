using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropParticleScript : MonoBehaviour
{
    Transform particlePlayer;
    // Start is called before the first frame update
    void Start()
    {
        particlePlayer = GameObject.FindGameObjectWithTag("ParticlePlayer").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(particlePlayer.childCount > 1) DropParticle();
        }
    }

    public void DropParticle()
    {     
        particlePlayer.GetChild(1).GetComponent<particleFollowPath>().enabled = false;
        particlePlayer.GetChild(1).SetParent(null);

    }
}
