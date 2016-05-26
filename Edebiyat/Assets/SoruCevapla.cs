using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoruCevapla : MonoBehaviour {

    class Soru
    {
        public string SoruIcerik { get; set; }
        public List<string> Cevaplar { get; set; }

        public Soru(string Icerik, List<string> cevaplistesi)
        {
            SoruIcerik = Icerik;
            Cevaplar = cevaplistesi;
        }
    }

    List<Soru> sorulistesi = new List<Soru>();
    Soru currentquestion = null;
    public Text SoruYazi;
    public Text CevapYaziA;
    public Text CevapYaziB;
    public Text CevapYaziC;
    public Text CevapYaziD;
    public Text CevapYaziE;
    public Button CevapButon1;
    public Button CevapButon2;
    public Button CevapButon3;
    public Button CevapButon4;
    public Button CevapButon5;
    string answer;
    int dogru = 0;
    int yanlis = 0;
    ColorBlock green = new ColorBlock();
    ColorBlock red = new ColorBlock();
    ColorBlock normal = new ColorBlock();

    public Text FinalYazi;
    public GameObject MainSet;
    // Use this for initialization
    void Start ()
    {
        sorulistesi.Add(new Soru("\"Ekmek bıçağını bilemem lâzım.\" cümlesindeki tamlamanın türü aşağıdakilerden hangisidir?", new List<string> {"Belirtisiz isim tamlaması.", "Belirtili isim tamlaması.", "Sıfat Tamlaması", "Takısız isim tamlaması.", "Zincirleme İsim Tamlaması" }));
        sorulistesi.Add(new Soru("Aşağıdaki cümlelerin hangisinde isim yoktur?", new List<string> { "Yiyin, için, eğlenin, gülün, oynayın!", "Bir yer ki burası, güneşler gündüzler başkadır.", "Aylar, gece korkuyla bakar pencereden.", "İnsanlar var burda, yatar bir hiçten.", "Bayram varmış dışarda, seyran varmış." }));
        sorulistesi.Add(new Soru("Aşağıdakilerin hangisinde tamlayanı düşmüş bir isim tamlaması vardır?", new List<string> { "Dayısı bu işe çok kızacak.", "Böyle bir eve herkes sahip olamaz.", "Öğrencilerin durumu sevindirici.", "Çukurova'nın havasına alışamadım.", "Onun ipiyle kuyuya inilmez." }));
        sorulistesi.Add(new Soru("Aşağıdaki dizelerin hangisinde tamlayanla tamlanan yer değiştirmiştir?", new List<string> { "Yokluğun en korkuncu ölümlerin.", "Akrebin kıskacında yoğurmuş bizi kader", "Türkiye gibi aydınlık ve güzelsin.", "Nedir suratımda bu çukur yollar.", "Sarmaşıklı odanın yeşil perdeleri var." }));
        sorulistesi.Add(new Soru("Yıldızlı isim tamlamalarından hangisi diğerlerinden farklıdır?", new List<string> { "Hep bu *ayak sesleri* dolaşıyor dışarda.", "*Bulutların altında* hayal kuruyorum.", "*Ufkumuzun aynası*, ateşten bayrak!", "*Ailemizin problemleri* sona erdi.", "*Çocuğun kolu* yorgandan dışarı çıktı." }));
        sorulistesi.Add(new Soru("Aşağıdaki cümlelerin hangisinde yıldızlı sözcük hâl eki almıştır ?", new List<string> { "*Evi* çok güzel boyamışlar.", "*Annesi* onu yalnız bırakmaz.", "*Öfkesi* saman alevi gibidir.", "*Gülüşü* insana hayat verir.", "*Yüzü* renkten renge giriyordu" }));
        //sorulistesi.Add(new Soru("", new List<string> { "", "", "", "", "" }));
        newQ();

        green = CevapButon1.colors;
        red = CevapButon1.colors;
        normal = CevapButon1.colors;

        green.normalColor = Color.green;
        green.pressedColor = Color.green;
        green.highlightedColor = Color.green;
        green.disabledColor = Color.green;

        red.normalColor = Color.red;
        red.pressedColor = Color.red;
        red.highlightedColor = Color.red;
        red.disabledColor = Color.red;
    }

    float towait = 0;
    bool changetime = false;
    bool returntime = false;
    void Update()
    {
        towait -= Time.deltaTime;

        if (towait < 0 && changetime)
        {
            CevapButon1.colors = normal;
            CevapButon2.colors = normal;
            CevapButon3.colors = normal;
            CevapButon4.colors = normal;
            CevapButon5.colors = normal;
            newQ();
            changetime = false;
        }

        if (towait < 0 && returntime)
        {
            SceneManager.LoadScene("Main");
            returntime = false;
        }
    }

        void newQ () {
        if (sorulistesi.Count != 0)
        {
            currentquestion = sorulistesi[(new System.Random()).Next(sorulistesi.Count)];
            answer = currentquestion.Cevaplar[0];
            SoruYazi.text = currentquestion.SoruIcerik + " (D:" + dogru + " Y:" + yanlis + ")";
            var availableAnswers = currentquestion.Cevaplar;

            List<int> notinc = new List<int>();
            var curr = Random.Range(0, 5);
            while (notinc.Contains(curr))
            {
                curr = Random.Range(0, 5);
            }
            notinc.Add(curr);
            CevapYaziA.text = "" + availableAnswers[curr];

            while (notinc.Contains(curr))
            {
                curr = Random.Range(0, 5);
            }
            notinc.Add(curr);
            CevapYaziB.text = "" + availableAnswers[curr];

            while (notinc.Contains(curr))
            {
                curr = Random.Range(0, 5);
            }
            notinc.Add(curr);
            CevapYaziC.text = "" + availableAnswers[curr];

            while (notinc.Contains(curr))
            {
                curr = Random.Range(0, 5);
            }
            notinc.Add(curr);
            CevapYaziD.text = "" + availableAnswers[curr];

            while (notinc.Contains(curr))
            {
                curr = Random.Range(0, 5);
            }
            notinc.Add(curr);
            CevapYaziE.text = "" + availableAnswers[curr];
        }
        else
        {
            MainSet.SetActive(false);
            FinalYazi.gameObject.SetActive(true);
            FinalYazi.text = string.Format("{0} doğru {1} yanlış yaptınız!", dogru, yanlis);
            changetime = false;
            returntime = true;
            towait = 5;
        }
    }

    void commonStuff(bool iscorrect, Button currentbutton)
    {
        sorulistesi.Remove(currentquestion);

        if (iscorrect) { dogru++; currentbutton.colors = green; } else
        {
            yanlis++; currentbutton.colors = red;
            if (CevapYaziA.text == answer)
            {
                CevapButon1.colors = green;
            }
            else if (CevapYaziB.text == answer)
            {
                CevapButon2.colors = green;
            }
            else if (CevapYaziC.text == answer)
            {
                CevapButon3.colors = green;
            }
            else if (CevapYaziD.text == answer)
            {
                CevapButon4.colors = green;
            }
            else if (CevapYaziE.text == answer)
            {
                CevapButon5.colors = green;
            }
        }
        towait = 1.5f;
        changetime = true;
    }

    public void CevapA()
    {
        if (!changetime)
        {
            commonStuff((CevapYaziA.text == answer), CevapButon1);
        }
    }

    public void CevapB()
    {
        if (!changetime)
        {
            commonStuff((CevapYaziB.text == answer), CevapButon2);
        }
    }

    public void CevapC()
    {
        if (!changetime)
        {
            commonStuff((CevapYaziC.text == answer), CevapButon3);
        }
    }

    public void CevapD()
    {
        if (!changetime)
        {
            commonStuff((CevapYaziD.text == answer), CevapButon4);
        }
    }

    public void CevapE()
    {
        if (!changetime)
        {
            commonStuff((CevapYaziE.text == answer), CevapButon5);
        }
    }
}
