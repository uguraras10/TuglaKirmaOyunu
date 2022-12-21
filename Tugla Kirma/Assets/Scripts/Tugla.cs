using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tugla : MonoBehaviour
{
    public GameObject kirilmaEfekti;
    public AudioClip sesEfektiTuglaKirilma;
    public AudioClip sesEfektiTuglaCarpma;
    public static int toplamTuglaSayisi;
    public Sprite[] tuglaSprite;
    private int maxCarpmaSayisi;
    private int CarpmaSayisi;
    private Puan puanScripti;
    // Start is called before the first frame update
    void Start()
    {
        maxCarpmaSayisi = tuglaSprite.Length + 1;
        toplamTuglaSayisi++;
        puanScripti = GameObject.FindObjectOfType<Puan>().GetComponent<Puan>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnCollisionEnter2D(Collision2D diger)
    {
        if (diger.gameObject.name.Equals("top"))
        {
            puanScripti.PuanArtir();
            CarpmaSayisi++;
            if (CarpmaSayisi>=maxCarpmaSayisi)
            {
                toplamTuglaSayisi--;
                Debug.Log(toplamTuglaSayisi);
                if (toplamTuglaSayisi<=0)
                {
                    GameObject.FindObjectOfType<OyunKontrol>().GetComponent<OyunKontrol>().BirSonrakiSahne();
                }
                Vector3 pos = diger.contacts[0].point;
                GameObject go = Instantiate(kirilmaEfekti, pos, Quaternion.identity) as GameObject;
                Color tuglaRengi = GetComponent<SpriteRenderer>().color;
                go.GetComponent<ParticleSystemRenderer>().material.color = tuglaRengi;
                Destroy(go, 1f);
                AudioSource.PlayClipAtPoint(sesEfektiTuglaKirilma, transform.position);
                Destroy(gameObject);
            }
            else
            {
                AudioSource.PlayClipAtPoint(sesEfektiTuglaCarpma, transform.position);
                GetComponent<SpriteRenderer>().sprite = tuglaSprite[CarpmaSayisi - 1];
            }
        }
    }
}
