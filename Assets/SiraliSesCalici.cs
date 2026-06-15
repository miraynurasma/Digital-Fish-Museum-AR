using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SiraliSesCalici : MonoBehaviour
{
    [Header("Ayarlar")]
    [Tooltip("Sýrayla çalacak sesleri buraya sürükleyin.")]
    public List<AudioSource> sesListesi;

    [Tooltip("Sesler arasýndaki bekleme süresi.")]
    public float beklemeSuresi = 1.5f;

    [Tooltip("Sayfa açýldýðýnda sesler otomatik baþlasýn mý?")]
    public bool otomatikBasla = true;

    private Coroutine sesDongusu;

    void OnEnable()
    {
        // Sayfa (veya obje) aktif olduðunda çalýþýr
        if (otomatikBasla)
        {
            Baslat();
        }
    }

    void OnDisable()
    {
        // Sayfa deðiþtiðinde veya kapandýðýnda sesleri durdurur (Karýþýklýðý önler)
        Durdur();
    }

    public void Baslat()
    {
        Durdur(); // Eðer çalýþan varsa önce temizle
        sesDongusu = StartCoroutine(SiraylaCal());
    }

    public void Durdur()
    {
        if (sesDongusu != null)
        {
            StopCoroutine(sesDongusu);
        }

        // Tüm sesleri sustur
        foreach (var ses in sesListesi)
        {
            if (ses != null && ses.isPlaying) ses.Stop();
        }
    }

    IEnumerator SiraylaCal()
    {
        foreach (AudioSource ses in sesListesi)
        {
            if (ses != null && ses.clip != null)
            {
                ses.Play();

                // Ses bitene kadar bekle + ekstra ara süre
                yield return new WaitForSeconds(ses.clip.length + beklemeSuresi);
            }
        }
    }
}