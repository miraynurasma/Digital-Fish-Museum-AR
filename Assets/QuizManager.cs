using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuizManager : MonoBehaviour
{
    [System.Serializable]
    public class Question
    {
        public string questionText;
        public string[] answers;
        public int correctAnswerIndex;
    }

    public List<Question> questions = new List<Question>();
    public Text questionUiText;
    public Button[] answerButtons; 
    public Text scoreText;
    
    // --- YENİ EKLEDİĞİMİZ SATIR: Müfettiş (Inspector) panelinde paneli bağlamak için ---
    public GameObject siklarPaneli; 

    private int currentQuestionIndex = 0;
    private int score = 0;

    void Start()
    {
        // 1. SORU: BİLGE KAPLUMBAĞA
        questions.Add(new Question { 
            questionText = "Denizler altındaki bu büyülü maceramızda, bizi ilk sahnede karşılayan ve denizlerin en yaşlı üyesi olan sevimli dostumuz kimdir?", 
            answers = new string[] { "Bilge Kaplumbağa", "Süslü" }, 
            correctAnswerIndex = 0 
        });

        // 2. SORU: PIRILTI
        questions.Add(new Question { 
            questionText = "Denizler altındaki bu büyülü dünyada, tatlı pembe rengiyle etrafına neşe saçan ve denizlerimize renk katan sevimli dostumuz kimdir?", 
            answers = new string[] { "Pırıltı", "Haylaz Yengeç" }, 
            correctAnswerIndex = 0 
        });

        // 3. SORU: SOSYAL YUNUS
        questions.Add(new Question { 
            questionText = "Denizde zıplamayı ve gezmeyi en çok conversational canlımız hangisidir?", 
            answers = new string[] { "Sosyal Yunus", "Uykucu Balık" }, 
            correctAnswerIndex = 0 
        });

        // 4. SORU: BALONCUK
        questions.Add(new Question { 
            questionText = "Denizin en obur ve tombul canlısı hangisidir?", 
            answers = new string[] { "Baloncuk", "Narin Balık" }, 
            correctAnswerIndex = 0 
        });

        // 5. SORU: AY IŞIĞI
        questions.Add(new Question { 
            questionText = "Pembe rengiyle denize ışık saçan gizemli canlı hangisidir?", 
            answers = new string[] { "Ay Işığı", "Gölge Balığı" }, 
            correctAnswerIndex = 0 
        });

        // 6. SORU: GÜÇLÜ KÖPEKBALIĞI
        questions.Add(new Question { 
            questionText = "Güçlü kuyruğuyla harika manevralar yapan canlımız hangisidir?", 
            answers = new string[] { "Güçlü Köpekbalığı", "Minik Karides" }, 
            correctAnswerIndex = 0 
        });

        // 7. SORU: SOMURTKAN
        questions.Add(new Question { 
            questionText = "Denizler altındaki bu neşeli dünyada, herkes gülümserken bir türlü yüzü gülmeyen ve hep somurtan o ilginç dostumuz kimdir?", 
            answers = new string[] { "Somurtkan", "Neşeli Balık" }, 
            correctAnswerIndex = 0 
        });

        ShowQuestion();
    }

    void ShowQuestion()
    {
        if (currentQuestionIndex < questions.Count)
        {
            questionUiText.text = questions[currentQuestionIndex].questionText;
            for (int i = 0; i < answerButtons.Length; i++)
            {
                answerButtons[i].GetComponentInChildren<Text>().text = questions[currentQuestionIndex].answers[i];
                
                int index = i;
                answerButtons[i].onClick.RemoveAllListeners();
                answerButtons[i].onClick.AddListener(() => OnAnswerSelected(index));
            }
        }
        else
        {
            // --- GÜNCELLEDİĞİMİZ KISIM: Oyun bittiğinde burası çalışır ---
            questionUiText.text = "Tebrikler! Denizlerin Bilgesi Oldun. 🎉";
            scoreText.text = "Toplam Puanın: " + score + " / " + questions.Count;
            
            // Tek tek buton kapatmak yerine tüm şıklar panelini tek seferde görünmez yapıyoruz:
            if (siklarPaneli != null)
            {
                siklarPaneli.SetActive(false);
            }
        }
    }

    void OnAnswerSelected(int selectedIndex)
    {
        if (selectedIndex == questions[currentQuestionIndex].correctAnswerIndex)
        {
            score++;
        }
        currentQuestionIndex++;
        ShowQuestion();
    }
}