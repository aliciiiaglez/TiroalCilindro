using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Material hitMaterial;
    public AudioClip shotSound;
    private AudioSource gunAudioSource;
    public int score;
    [SerializeField]
    TextMeshProUGUI ScoreText;
    void Awake()
    {
        gunAudioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        //ccon tablet y con ordenador (0, pq es el bot izquu del ratón, 1 rueda o 2 el bot derech) (TouchPhase.Began/GetMouseButtonDown)
        if((Input.touchCount >= 1 && Input.GetTouch(0).phase == TouchPhase.Ended) || (Input.GetMouseButtonUp(0)))
        {
            gunAudioSource.PlayOneShot(shotSound);
            Vector3 pos = Input.mousePosition;
            if (Application.platform == RuntimePlatform.Android)
            { 
                pos = Input.GetTouch(0).position;
            }

            Ray rayo = Camera.main.ScreenPointToRay(pos);
            RaycastHit hitInfo;
            if (Physics.Raycast(rayo, out hitInfo) == true)
            {
                if (hitInfo.collider.tag.Equals("Lata"))
                {
                    Rigidbody rigidbodyLata = hitInfo.collider.GetComponent<Rigidbody>();
                    rigidbodyLata.AddForce(rayo.direction * 50f, ForceMode.VelocityChange);
                    hitInfo.collider.GetComponent<MeshRenderer>().material = hitMaterial;
                    score += 10;
                    
                }
                
                
            }
            else
            {
            score -= 5;
            }

            
        }
        
        ScoreText.text = "Score = " + score;
        if (score <= 0)
        {
            score = 0;
        }
    }


    
}
