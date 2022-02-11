using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform myTarget;
    // Start is called before the first frame update
    public AudioSource LobbyMusic;
    void Start()
    {
        LobbyMusic.loop = true;
        LobbyMusic.Play();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        gameObject.transform.position = new Vector3(myTarget.position.x, myTarget.position.y, gameObject.transform.position.z);
    }
}
