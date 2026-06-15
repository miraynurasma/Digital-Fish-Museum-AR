using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARHandler : MonoBehaviour
{
    private ARTrackedImageManager trackedImageManager;

    [Header("Canlý Gruplarý")]
    public GameObject grup1;
    public GameObject grup2;
    public GameObject grup3;

    void Awake()
    {
        trackedImageManager = GetComponent<ARTrackedImageManager>();

        if (trackedImageManager == null)
        {
            trackedImageManager = FindObjectOfType<ARTrackedImageManager>();
        }
    }

    void OnEnable()
    {
        if (trackedImageManager != null)
            trackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    void OnDisable()
    {
        if (trackedImageManager != null)
            trackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

    void OnImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        // Yeni resimler için
        foreach (var trackedImage in eventArgs.added) UpdateImage(trackedImage);

        // Güncellenen (hareket eden veya ekranda duran) resimler için
        foreach (var trackedImage in eventArgs.updated) UpdateImage(trackedImage);

        // Resim tamamen kaybolduðunda takýlý kalmamasý için kapatma
        foreach (var trackedImage in eventArgs.removed)
        {
            SetAllGroupsActive(false);
        }
    }

    void UpdateImage(ARTrackedImage trackedImage)
    {
        string name = trackedImage.referenceImage.name;

        // TAKILMAYI ÖNLEYEN KRÝTÝK KONTROL:
        // Eðer resim o an takip edilmiyorsa (Limited/None), objeleri gizle.
        if (trackedImage.trackingState != TrackingState.Tracking)
        {
            SetGroupActive(name, false);
            return;
        }

        // Eðer resim baþarýyla takip ediliyorsa, sadece o grubu aç ve konumlandýr
        SetGroupActive(name, true, trackedImage.transform.position);
    }

    // Gruplarýn açýlýp kapanmasýný yöneten yardýmcý fonksiyon
    void SetGroupActive(string name, bool isActive, Vector3? position = null)
    {
        if (name == "canlilar_grup_1")
        {
            grup1.SetActive(isActive);
            if (isActive && position.HasValue) grup1.transform.position = position.Value;
        }
        else if (name == "canlilar_grup_2")
        {
            grup2.SetActive(isActive);
            if (isActive && position.HasValue) grup2.transform.position = position.Value;
        }
        else if (name == "canlilar_grup_3")
        {
            grup3.SetActive(isActive);
            if (isActive && position.HasValue) grup3.transform.position = position.Value;
        }
    }

    void SetAllGroupsActive(bool isActive)
    {
        if (grup1 != null) grup1.SetActive(isActive);
        if (grup2 != null) grup2.SetActive(isActive);
        if (grup3 != null) grup3.SetActive(isActive);
    }
}