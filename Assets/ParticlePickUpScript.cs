using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePickUpScript : MonoBehaviour
{
    OrbitGenerator orb;
    particleFollowPath particlePath;
    Vector3 particleNewPos;
    GameObject particle;
    bool pickedUp = false;
    Transform _center;
    // CharacterController player;
    Transform particlePlayer;

    Transform particleInicialPos;

    private void Start()
    {
        particlePlayer = GameObject.FindGameObjectWithTag("ParticlePlayer").transform;
        particle = transform.GetChild(0).gameObject;
        orb = transform.GetChild(0).GetComponent<OrbitGenerator>();
        particlePath = transform.GetChild(0).GetComponent<particleFollowPath>();
        particleNewPos = new Vector3(0.1f, 0, 0);
        particleInicialPos = FindObjectOfType<CharacterController>().transform.GetChild(0);
        // player = FindObjectOfType<CharacterController>();
    }

    private void Update()
    {
        if (pickedUp)
        {
            //particle.transform.position = Vector3.MoveTowards(transform.position, (player.transform.position + particleNewPos), Time.deltaTime * 50f);
             iTween.MoveUpdate(particle, iTween.Hash("easetype", iTween.EaseType.easeInCubic, "time", 2f, "position", particleInicialPos));
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _center = other.transform;
            PickUpParticle(_center);
            GetComponent<SphereCollider>().enabled = false;
        }
    }

    void PickUpParticle(Transform center)
    {
        transform.GetChild(0).SetParent(particlePlayer);
        pickedUp = true;
       // iTween.MoveTo(particle, iTween.Hash("easetype", iTween.EaseType.easeInOutCubic, "speed", 1f, "oncomplete", "CompletePickUp","position", player.transform));
       // orb.SetOrbitValues(center);
        StartCoroutine(FinishPickUP());
    }

    void CompletePickUp()
    {
        pickedUp = false;
        particlePath.enabled = true;       
        Destroy(gameObject);
    }

    IEnumerator FinishPickUP()
    {
        yield return new WaitForSeconds(.7f);
        pickedUp = false;
        //particle.transform.position = new Vector3(0.1f, 0, 0);
        orb.SetOrbitValues(_center);
        particlePath.enabled = true;
        Destroy(gameObject);
    }

    public void bb()
    {
        Debug.Log("completed");
    }
}
