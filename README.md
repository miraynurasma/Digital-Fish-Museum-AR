# Digital Fish Museum AR 🌊📱

**Digital Fish Museum AR**, çocukların deniz canlılarını ve su altı dünyasını interaktif bir şekilde keşfetmesi, eğlenirken öğrenmesi amacıyla geliştirilmiş mobil bir **Artırılmış Gerçeklik (AR)** eğitim uygulamasıdır. 

Bu çalışma, çocukların görsel ve işitsel algılarını destekleyerek geleneksel öğrenme metotlarını modern teknolojiyle harmanlamayı hedefleyen bir **Lisans Mezuniyet Projesidir**.

---

## 🚀 Proje Hakkında & Öne Çıkanlar

* **Çocuk Odaklı İnteraktif Tasarım:** Uygulama, çocukların ilgisini çekecek renk paletlerine ve düşük poligonlu (low-poly), optimize edilmiş deniz canlısı modellerine sahiptir.
* **Sesli Rehber Desteği:** Canlılar sadece görsel olarak değil, çocukların gelişimine uygun özel seslendirmeler ve ses dublajları (voiceover) ile desteklenmiştir.
* **Akademik & Proje Yönetimi Temeli:** Bu projenin geliştirilme sürecinde kazanılan yetkinlikler, TÜBİTAK 2209-A projesi yönetim tecrübesi ve TÜBİTAK 1001 araştırma projelerindeki metodolojiler referans alınarak kurgulanmıştır.

---

## 🛠️ Kullanılan Teknolojiler ve Kütüphaneler

Projenin geliştirilmesinde performans optimizasyonu ve kararlılık ön planda tutulmuştur:

* **Oyun Motoru:** Unity
* **AR Teknolojileri:** AR Foundation & Vuforia SDK (Görüntü işleme ve hedef takibi için)
* **Geliştirme Dili:** C#
* **Hedef Platform:** Android / iOS (Mobil)

---

## 📂 Proje Yapısı

Proje mimarisinde genişletilebilir ve temiz bir kod yapısı (Clean Code) hedeflenmiştir. Görüntü hedefi takibi ve dinamik içerik yönetimi, hazırlanan dinamik script'ler ile yönetilmektedir:

* `Assets/ARHandler.cs`: AR kamera yönetimini, hedef görsellerin taranmasını ve canlı gruplarının ekranda dinamik olarak tetiklenmesini sağlayan ana kontrol mekanizması.
* `Assets/Backrock Studios/LowPoly-Animals`: Çocuklar için optimize edilmiş, performansı olumsuz etkilemeyecek su altı canlı modelleri ve materyal kütüphanesi.

---

## 👥 Test ve Kullanıcı Deneyimi (UX)

Geliştirme aşamasında, uygulamanın hedef kitlesine uygunluğunu ölçmek adına çocuk kullanıcılar ile birebir kullanılabilirlik testleri gerçekleştirilmiş; alınan geri bildirimler doğrultusunda arayüz dinamikleri ve sahneler optimize edilmiştir.
