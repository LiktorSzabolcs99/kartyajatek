using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Kartya
{
    #region Kartya_Osztaly
    public struct Kartyatulj
    {
        public int ID;
        public int erteke;
        public string kategoria; //Tav,Ost,Koz
        public string keppeseg;
        public bool zarolva;
        public bool aktiv;
        public Point elozopozicio;
        public Point aktualispoz;
        public Bitmap kep;
    } 
    #endregion

    public partial class Form1 : Form
    {
        #region Valtozok/logikai
        bool Ellenfelkore = false;
        Kartyatulj[] lap = new Kartyatulj[30];
        public string kategoria;
        public int osszertek = 0;
        public List<int> Lrandomszam = new List<int>();
        public List<int> Ellenfelrandomszam = new List<int>();
        int kivalasztott=0;
        int[] paklitartalma = new int[25] {1,2,3,4,5,6,7,8,9,10,11,12,13,
                                               14,15,16,17,18,19,20,21,22,23,24,25 };


        private Point elozopozicio1 = new Point(-1, -1);
        private Point elozopozicio2 = new Point(-1, -1);
        private Point elozopozicio3 = new Point(-1, -1);
        private Point elozopozicio4 = new Point(-1, -1);
        private Point elozopozicio5 = new Point(-1, -1);
        private Point elozopozicio6 = new Point(-1, -1);
        private Point elozopozicio7 = new Point(-1, -1);
        private Point elozopozicio8 = new Point(-1, -1);
        private Point elozopozicio9 = new Point(-1, -1);
        private Point elozopozicio10 = new Point(-1, -1);
        private Point elozopozicio11 = new Point(-1, -1);
        private Point elozopozicio12 = new Point(-1, -1);
        private Point elozopozicio13 = new Point(-1, -1);
        private Point elozopozicio14 = new Point(-1, -1);
        private Point elozopozicio15 = new Point(-1, -1);
        private Point elozopozicio16 = new Point(-1, -1);
        private Point elozopozicio17 = new Point(-1, -1);
        private Point elozopozicio18 = new Point(-1, -1);
        private Point elozopozicio19 = new Point(-1, -1);
        private Point elozopozicio20 = new Point(-1, -1);
        private Point elozopozicio21 = new Point(-1, -1);
        private Point elozopozicio22 = new Point(-1, -1);
        private Point elozopozicio23 = new Point(-1, -1);
        private Point elozopozicio24 = new Point(-1, -1);
        private Point elozopozicio25 = new Point(-1, -1);

        List<int> Kozmezoben = new List<int>();
        List<int> Tavmezoben = new List<int>();
        List<int> Ostrommezoben1 = new List<int>();
        List<int> Ostrommezoben2 = new List<int>();

        int ID1, ID2, ID3, ID4, ID5,
            ID6, ID7, ID8, ID9, ID10,
            ID11, ID12, ID13, ID14,
            ID15, ID16, ID17, ID18,
            ID19, ID20, ID21, ID22,
            ID23, ID24, ID25;

        int lepteto = 0;
        int Elllepteto = 0;
        int csakegyszer = 0;
        int csakegyszer02 = 0;
        int csakegyszer03 = 0;
        bool csakegyszerlap1 = false;
        int Index = 0;
        bool Egerfelengedve = false;
        bool KozKartyazarolas = false;
        bool TavKartyazarolas = false;
        bool OstKartyazarolas = false;
        bool Kulzorkartyan = false;
        bool folyamatban = false;

        List<int> Kartyakpalyan = new List<int>();

        int EllKmezolepteto = 0;
        int EllTmezolepteto = 0;

        int Kmezolepteto = 0;
        int Tmezolepteto = 0;
        int Omezo1lepteto = 0;
        int Omzeo2lepteto = 0;
        #endregion

        #region Bitmap-ok
        private Bitmap Alapkartya;

        private Bitmap KozelharcosKartya;
        private Bitmap KozelharcosMezo = new Bitmap(@"C:\Users\User\Desktop\Zárodolgozat\Kesz mezo\KozMezo.png");

        private Bitmap TavolsagiKartya;
        private Bitmap TavolsagiMezo = new Bitmap(@"C:\Users\User\Desktop\Zárodolgozat\Kesz mezo\TavMezo.png");

        private Bitmap OstromKartya;
        Bitmap OstromMezo1 = new Bitmap(@"C:\Users\User\Desktop\Zárodolgozat\Kesz mezo\OstMezo.png");
        Bitmap OstromMezo2 = new Bitmap(@"C:\Users\User\Desktop\Zárodolgozat\Kesz mezo\OstMezo.png");

        private Bitmap EllKozelharcosKartya;
        private Bitmap EllKozelharcosMezo = new Bitmap(@"C:\Users\User\Desktop\Zárodolgozat\Kesz mezo\KozMezo.png");

        private Bitmap EllTavolsagiKartya;
        private Bitmap EllTavolsagiMezo = new Bitmap(@"C:\Users\User\Desktop\Zárodolgozat\Kesz mezo\TavMezo.png");

        private Bitmap EllOstromKartya;
        Bitmap EllOstromMezo1 = new Bitmap(@"C:\Users\User\Desktop\Zárodolgozat\Kesz mezo\OstMezo.png");
        Bitmap EllOstromMezo2 = new Bitmap(@"C:\Users\User\Desktop\Zárodolgozat\Kesz mezo\OstMezo.png");

        Bitmap Pakli = new Bitmap(@"C:\Users\User\Desktop\Zárodolgozat\Kesz mezo\PT.png");
        Bitmap EllPakli = new Bitmap(@"C:\Users\User\Desktop\Zárodolgozat\Kesz mezo\PT.png");

        Bitmap Temeto = new Bitmap(@"C:\Users\User\Desktop\Zárodolgozat\Kesz mezo\PT.png");
        Bitmap EllTemeto = new Bitmap(@"C:\Users\User\Desktop\Zárodolgozat\Kesz mezo\PT.png");

        private Bitmap Kartyakkezben;
        private Bitmap EllKartyakkezben;

        Bitmap Esemenykartya = new Bitmap(@"C:\Users\User\Desktop\Zárodolgozat\Kesz mezo\IJMezo.png");

        private Bitmap Boostkartya = new Bitmap(@"C:\Users\User\Desktop\Zárodolgozat\Kesz mezo\TavBonusz.png");
        #endregion



        #region Point-ok bitmap poziciók
        //A bitmapok helye a console-on

        Point Kijeloltlaphelye;
        Point Kijeloltmezohelye;
        Bitmap Kijeloltmezo;
        bool Kijeloltkartyazarolasa;
        bool egyszer1 = false;
        bool egyszer2 = false;
        bool egyszer3 = false;
        bool egyszer4 = false;

        //Játékos Paklija
        //"Királyság" lapok

        private Bitmap lap1 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Kiraly.png");
        private Point lap1helye = new Point(1250, 605);
        bool lap1zarolasa = false;
        Point elozopoz1 = new Point(0, 0);

        private Bitmap lap2 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Herceg03.png");
        private Point lap2helye = new Point(1250, 605);
        bool lap2zarolasa = false;
        Point elozopoz2 = new Point(0, 0);

        private Bitmap lap3 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Testor1.png");
        private Point lap3helye = new Point(1250, 605);
        bool lap3zarolasa = false;
        Point elozopoz3 = new Point(0, 0);

        private Bitmap lap4 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Testor2.png");
        private Point lap4helye = new Point(1250, 605);
        bool lap4zarolasa = false;
        Point elozopoz4 = new Point(0, 0);

        private Bitmap lap5 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\ijasz1.png");
        private Point lap5helye = new Point(1250, 605);
        bool lap5zarolasa = false;
        Point elozopoz5 = new Point(0, 0);

        private Bitmap lap6 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\ijasz2.png");
        private Point lap6helye = new Point(1250, 605);
        bool lap6zarolasa = false;
        Point elozopoz6 = new Point(0, 0);

        private Bitmap lap7 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\ijasz3.png");
        private Point lap7helye = new Point(1250, 605);
        bool lap7zarolasa = false;
        Point elozopoz7 = new Point(0, 0);

        private Bitmap lap8 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Foldmuves1.png");
        private Point lap8helye = new Point(1250, 605);
        bool lap8zarolasa = false;
        Point elozopoz8 = new Point(0, 0);

        private Bitmap lap9 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Foldmuves2.png");
        private Point lap9helye = new Point(1250, 605);
        bool lap9zarolasa = false;
        Point elozopoz9 = new Point(0, 0);

        private Bitmap lap10 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Sorkatona1.png");
        private Point lap10helye = new Point(1250, 605);
        bool lap10zarolasa = false;
        Point elozopoz10 = new Point(0, 0);

        private Bitmap lap11 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Sorkatona2.png");
        private Point lap11helye = new Point(1250, 605);
        bool lap11zarolasa = false;
        Point elozopoz11 = new Point(0, 0);

        private Bitmap lap12 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Zsoldos.png");
        private Point lap12helye = new Point(1250, 605);
        bool lap12zarolasa = false;
        Point elozopoz12 = new Point(0, 0);

        private Bitmap lap13 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Szamszerijasz1.png");
        private Point lap13helye = new Point(1250, 605);
        bool lap13zarolasa = false;
        Point elozopoz13 = new Point(0, 0);

        private Bitmap lap14 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\szamszerijasz2.png");
        private Point lap14helye = new Point(1250, 605);
        bool lap14zarolasa = false;
        Point elozopoz14 = new Point(0, 0);

        private Bitmap lap15 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Magus.png");
        private Point lap15helye = new Point(1250, 605);
        bool lap15zarolasa = false;
        Point elozopoz15 = new Point(0, 0);

        private Bitmap lap16 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Hajitogep1.png");
        private Point lap16helye = new Point(1250, 605);
        bool lap16zarolasa = false;
        Point elozopoz16 = new Point(0, 0);

        private Bitmap lap17 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Lovag.png");
        private Point lap17helye = new Point(1250, 605);
        bool lap17zarolasa = false;
        Point elozopoz17 = new Point(0, 0);

        private Bitmap lap18 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Katapult1.png");
        private Point lap18helye = new Point(1250, 605);
        bool lap18zarolasa = false;
        Point elozopoz18 = new Point(0, 0);

        private Bitmap lap19 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Katapult2.png");
        private Point lap19helye = new Point(1250, 605);
        bool lap19zarolasa = false;
        Point elozopoz19 = new Point(0, 0);

        private Bitmap lap20 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Ballista1.png");
        private Point lap20helye = new Point(1250, 605);
        bool lap20zarolasa = false;
        Point elozopoz20 = new Point(0, 0);

        private Bitmap lap21 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Ballista2.png");
        private Point lap21helye = new Point(1250, 605);
        bool lap21zarolasa = false;
        Point elozopoz21 = new Point(0, 0);

        private Bitmap lap22 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Lord.png");
        private Point lap22helye = new Point(1250, 605);
        bool lap22zarolasa = false;
        Point elozopoz22 = new Point(0, 0);

        private Bitmap lap23 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Ranger.png");
        private Point lap23helye = new Point(1250, 605);
        bool lap23zarolasa = false;
        Point elozopoz23 = new Point(0, 0);

        private Bitmap lap24 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\nehezlovassag1.png");
        private Point lap24helye = new Point(1250, 605);
        bool lap24zarolasa = false;
        Point elozopoz24 = new Point(0, 0);

        private Bitmap lap25 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\nehezlovassag2.png");
        private Point lap25helye = new Point(1250, 605);
        bool lap25zarolasa = false;
        Point elozopoz25 = new Point(0, 0);
        /*-------------------------------------------------------------------------------------*/
        #endregion

        //Ellenfél paklia
        private Bitmap Elap1 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Kiraly.png");
        private Point Elap1helye = new Point(30, 5);
        bool Elap1zarolasa = false;
        Point Eelozopoz1 = new Point(0, 0);

        private Bitmap Elap2 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Herceg03.png");
        private Point Elap2helye = new Point(30, 5);
        bool Elap2zarolasa = false;
        Point Eelozopoz2 = new Point(0, 0);

        private Bitmap Elap3 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Testor1.png");
        private Point Elap3helye = new Point(30, 5);
        bool Elap3zarolasa = false;
        Point Eelozopoz3 = new Point(0, 0);

        private Bitmap Elap4 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Testor2.png");
        private Point Elap4helye = new Point(30, 5);
        bool Elap4zarolasa = false;
        Point Eelozopoz4 = new Point(0, 0);

        private Bitmap Elap5 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\ijasz1.png");
        private Point Elap5helye = new Point(30, 5);
        bool Elap5zarolasa = false;
        Point Eelozopoz5 = new Point(0, 0);

        private Bitmap Elap6 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\ijasz2.png");
        private Point Elap6helye = new Point(30, 5);
        bool Elap6zarolasa = false;
        Point Eelozopoz6 = new Point(0, 0);

        private Bitmap Elap7 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\ijasz3.png");
        private Point Elap7helye = new Point(30, 5);
        bool Elap7zarolasa = false;
        Point Eelozopoz7 = new Point(0, 0);

        private Bitmap Elap8 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Foldmuves1.png");
        private Point Elap8helye = new Point(30, 5);
        bool Elap8zarolasa = false;
        Point Eelozopoz8 = new Point(0, 0);

        private Bitmap Elap9 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Foldmuves2.png");
        private Point Elap9helye = new Point(30, 5);
        bool Elap9zarolasa = false;
        Point Eelozopoz9 = new Point(0, 0);

        private Bitmap Elap10 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Sorkatona1.png");
        private Point Elap10helye = new Point(30, 5);
        bool Elap10zarolasa = false;
        Point Eelozopoz10 = new Point(0, 0);

        private Bitmap Elap11 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Sorkatona2.png");
        private Point Elap11helye = new Point(30, 5);
        bool Elap11zarolasa = false;
        Point Eelozopoz11 = new Point(0, 0);

        private Bitmap Elap12 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Zsoldos.png");
        private Point Elap12helye = new Point(30, 5);
        bool Elap12zarolasa = false;
        Point Eelozopoz12 = new Point(0, 0);

        private Bitmap Elap13 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Szamszerijasz1.png");
        private Point Elap13helye = new Point(30, 5);
        bool Elap13zarolasa = false;
        Point Eelozopoz13 = new Point(0, 0);

        private Bitmap Elap14 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\szamszerijasz2.png");
        private Point Elap14helye = new Point(30, 5);
        bool Elap14zarolasa = false;
        Point Eelozopoz14 = new Point(0, 0);

        private Bitmap Elap15 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Magus.png");
        private Point Elap15helye = new Point(30, 5);
        bool Elap15zarolasa = false;
        Point Eelozopoz15 = new Point(0, 0);

        private Bitmap Elap16 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Hajitogep1.png");
        private Point Elap16helye = new Point(30, 5);
        bool Elap16zarolasa = false;
        Point Eelozopoz16 = new Point(0, 0);

        private Bitmap Elap17 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Lovag.png");
        private Point Elap17helye = new Point(30, 5);
        bool Elap17zarolasa = false;
        Point Eelozopoz17 = new Point(0, 0);

        private Bitmap Elap18 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Katapult1.png");
        private Point Elap18helye = new Point(30, 5);
        bool Elap18zarolasa = false;
        Point Eelozopoz18 = new Point(0, 0);

        private Bitmap Elap19 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Katapult2.png");
        private Point Elap19helye = new Point(30, 5);
        bool Elap19zarolasa = false;
        Point Eelozopoz19 = new Point(0, 0);

        private Bitmap Elap20 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Ballista1.png");
        private Point Elap20helye = new Point(30, 5);
        bool Elap20zarolasa = false;
        Point Eelozopoz20 = new Point(0, 0);

        private Bitmap Elap21 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Ballista2.png");
        private Point Elap21helye = new Point(30, 5);
        bool Elap21zarolasa = false;
        Point Eelozopoz21 = new Point(0, 0);

        private Bitmap Elap22 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Lord.png");
        private Point Elap22helye = new Point(30, 5);
        bool Elap22zarolasa = false;
        Point Eelozopoz22 = new Point(0, 0);

        private Bitmap Elap23 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\Ranger.png");
        private Point Elap23helye = new Point(30, 5);
        bool Elap23zarolasa = false;
        Point Eelozopoz23 = new Point(0, 0);

        private Bitmap Elap24 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\nehezlovassag1.png");
        private Point Elap24helye = new Point(30, 5);
        bool Elap24zarolasa = false;
        Point Eelozopoz24 = new Point(0, 0);

        private Bitmap Elap25 = new Bitmap(@"E:\Kártyák\Kártyák\Királyság frakció\Fix\Megszerkesztett\nehezlovassag2.png");
        private Point Elap25helye = new Point(30, 5);
        bool Elap25zarolasa = false;
        Point Eelozopoz25 = new Point(0, 0);

        #region Mezők helye
        //Saját mezők
        private Point Ideiglenespoz = new Point(500, 500);
        private Point Ideiglenespoz2 = new Point(0, 0);

        private Point KezdoKartyakhelye = new Point(212, 603);

        private Point Boostkartyahelye1 = new Point(210, 390);
        private Point Boostkartyahelye2 = new Point(210, 495);

        private Point Esemenykartyahelye = new Point(50, 250);
        private Point Kartyakkezbenhelye = new Point(210, 600);

        private Point Kozelharcosmezohelye = new Point(285, 390);
        //private Point Kozelharcoskartyahelye = new Point(212, 603);

        private Point Tavolsagimezohelye = new Point(285, 495);
       // private Point Tavolsagikartyahelye = new Point(281, 603);

        private Point Ostrommezohelye1 = new Point(5, 495);
        private Point Ostrommezohelye2 = new Point(1160, 495);
        //private Point Ostromkartyahelye = new Point(300, 500);

        private Point Paklihelye = new Point(1250, 605);
        private Point Temetohelye = new Point(1180, 605);

        //Ellenfél mezői

        private Point EllBoostkartyahelye1 = new Point(210, 215);
        private Point EllBoostkartyahelye2 = new Point(210, 110);

        private Point EllKartyakkezbenhelye = new Point(210, 5);

        private Point EllKozelharcosmezohelye = new Point(285, 215);
       // private Point EllKozelharcoskartyahelye = new Point(100, 100);

        private Point EllTavolsagimezohelye = new Point(285, 110);
       // private Point EllTavolsagikartyahelye = new Point(100, 250);

        private Point EllOstrommezohelye1 = new Point(5, 110);
        private Point EllOstrommezohelye2 = new Point(1160, 110);
       // private Point EllOstromkartyahelye = new Point(100, 380);

        private Point EllPaklihelye = new Point(30, 5);
        private Point EllTemetohelye = new Point(100, 5);

       

        //Pen feher = new Pen(Color.White);
        Point kulzorlock = new Point(-1, -1);

        Point aktualiskulzorpozicio = MousePosition; 
        #endregion



        public Form1()
        {
            

            Kartyatulj[] lap = new Kartyatulj[30];
            for (int i = 1; i < lap.Length; i++)
            {
                lap[i].aktualispoz = lap1helye;
            }


            //Itt hívom meg a beolvasott adatokat a fájból
            Adatbeolvasas(ref osszertek,ref lap);
            for (int i = 0; i < lap.Length; i++)
            {
                Kategoriavalasztas(lap[i].kategoria,ref kategoria);
                
            }
            /*--------------------------------------------------------------- */
            
            InitializeComponent();

            // ez azért kell hogy ne vibráljon a draw Image
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);
            /*--------------------------------------------------------------- */

            #region Bitmap-oknak Itt adok értéket
            //Saját
            Alapkartya = new Bitmap(65, 95);
            Kartyakkezben = new Bitmap(945, 105);

            KozelharcosKartya = new Bitmap(65, 95);

            TavolsagiKartya = new Bitmap(65, 95);


            OstromKartya = new Bitmap(65, 95);


            //Ellenfél
            EllKartyakkezben = new Bitmap(945, 105);

            EllKozelharcosKartya = new Bitmap(65, 95);

            EllTavolsagiKartya = new Bitmap(65, 95);


            EllOstromKartya = new Bitmap(65, 95);
 


            #endregion
        }



        #region Négyzetek létrehozása 
        Rectangle mezo1 = new Rectangle(0, 0, 945, 100);
        Rectangle Ostmezo = new Rectangle(0, 0, 200, 100);
        Rectangle kartyalap = new Rectangle(0, 0, 65, 95);
        Rectangle esemenymezo = new Rectangle(0, 0, 100, 200);
        Rectangle boostlap = new Rectangle(0, 0, 70, 100);
        #endregion


        #region Kártyák kinézete
        //Kártyák kinézete
        /*
        private void kartyarajz(string kapottkategoria)
        {

            if (kapottkategoria == "Kozelharcos")
            {
                using (var g = Graphics.FromImage(KozelharcosKartya))
                {
                    g.FillRectangle(Brushes.Orange, kartyalap);
                }
            }

            if (kapottkategoria == "Tavolsagi")
            {
                using (var g = Graphics.FromImage(TavolsagiKartya))
                {
                    g.FillRectangle(Brushes.DarkGreen, kartyalap);
                }
            }


            if (kapottkategoria == "Ostrom")
            {
                using (var g = Graphics.FromImage(OstromKartya))
                {
                    g.FillRectangle(Brushes.DarkRed, kartyalap);
                }
            }
        }
        */
        #endregion

        #region Mezők kinézete
        //Mezők kinézete
        private void mezorajz()
        {
            using (var g = Graphics.FromImage(Kartyakkezben))
            {
                g.FillRectangle(Brushes.White, mezo1);
            }
            
            //Ellenfél
            using (var g = Graphics.FromImage(EllKartyakkezben))
            {
                g.FillRectangle(Brushes.White, mezo1);
            }
            
        }
        #endregion




        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;




            #region Mezők kirajzolása 
            mezorajz();
            g.DrawImage(Boostkartya, Boostkartyahelye1);
            g.DrawImage(Boostkartya, Boostkartyahelye2);
            g.DrawImage(Boostkartya, EllBoostkartyahelye1);
            g.DrawImage(Boostkartya, EllBoostkartyahelye2);

            g.DrawImage(Esemenykartya, Esemenykartyahelye);
            // g.DrawImage(Kartyakkezben, Kartyakkezbenhelye);
            g.DrawImage(KozelharcosMezo, Kozelharcosmezohelye);
            g.DrawImage(TavolsagiMezo, Tavolsagimezohelye);
            g.DrawImage(OstromMezo1, Ostrommezohelye1);
            g.DrawImage(OstromMezo2, Ostrommezohelye2);


            // g.DrawImage(EllKartyakkezben, EllKartyakkezbenhelye);
            g.DrawImage(EllKozelharcosMezo, EllKozelharcosmezohelye);
            g.DrawImage(EllTavolsagiMezo, EllTavolsagimezohelye);
            g.DrawImage(EllOstromMezo1, EllOstrommezohelye1);
            g.DrawImage(EllOstromMezo2, EllOstrommezohelye2);

            g.DrawImage(Pakli, Paklihelye);
            g.DrawImage(EllPakli, EllPaklihelye);

            g.DrawImage(Temeto, Temetohelye);
            g.DrawImage(EllTemeto, EllTemetohelye);
            #endregion

            g.DrawImage(lap1, lap1helye);
            //elozopozicio1 = lap1helye;

            g.DrawImage(lap2, lap2helye);
            //elozopozicio2 = lap1helye;

            g.DrawImage(lap3, lap3helye);
            //elozopozicio3 = lap1helye;

            g.DrawImage(lap4, lap4helye);
            // elozopozicio4 = lap1helye;

            g.DrawImage(lap5, lap5helye);
            //elozopozicio5 = lap1helye;

            g.DrawImage(lap6, lap6helye);
            // elozopozicio6 = lap1helye;

            g.DrawImage(lap7, lap7helye);
            //elozopozicio7 = lap1helye;

            g.DrawImage(lap8, lap8helye);
            //elozopozicio8 = lap1helye;

            g.DrawImage(lap9, lap9helye);
            //elozopozicio9 = lap1helye;

            g.DrawImage(lap10, lap10helye);
            // elozopozicio10 = lap1helye;

            g.DrawImage(lap11, lap11helye);
            // elozopozicio11 = lap1helye;

            g.DrawImage(lap12, lap12helye);
            //elozopozicio12 = lap1helye;

            g.DrawImage(lap13, lap13helye);
            //elozopozicio13 = lap1helye;

            g.DrawImage(lap14, lap14helye);
            //elozopozicio14 = lap1helye;

            g.DrawImage(lap15, lap15helye);
            //elozopozicio15 = lap1helye;

            g.DrawImage(lap16, lap16helye);
            //elozopozicio16 = lap1helye;

            g.DrawImage(lap17, lap17helye);
            // elozopozicio17 = lap1helye;

            g.DrawImage(lap18, lap18helye);
            //elozopozicio18 = lap1helye;

            g.DrawImage(lap19, lap19helye);
            //elozopozicio19 = lap1helye;

            g.DrawImage(lap20, lap20helye);
            //elozopozicio20 = lap1helye;

            g.DrawImage(lap21, lap21helye);
            //elozopozicio21 = lap1helye;

            g.DrawImage(lap22, lap22helye);
            //elozopozicio22 = lap1helye;

            g.DrawImage(lap23, lap23helye);
            //elozopozicio23 = lap1helye;

            g.DrawImage(lap24, lap24helye);
            //elozopozicio24 = lap1helye;

            g.DrawImage(lap25, lap25helye);
            //elozopozicio25 = lap1helye;


/*----------------------------------------------------------------------------------------------------------------*/

            //Ellenfél
            g.DrawImage(Elap1, Elap1helye);
            //elozopozicio1 = lap1helye;

            g.DrawImage(Elap2, Elap2helye);
            //elozopozicio2 = lap1helye;

            g.DrawImage(Elap3, Elap3helye);
            //elozopozicio3 = lap1helye;

            g.DrawImage(Elap4, Elap4helye);
            // elozopozicio4 = lap1helye;

            g.DrawImage(Elap5, Elap5helye);
            //elozopozicio5 = lap1helye;

            g.DrawImage(Elap6, Elap6helye);
            // elozopozicio6 = lap1helye;

            g.DrawImage(Elap7, Elap7helye);
            //elozopozicio7 = lap1helye;

            g.DrawImage(Elap8, Elap8helye);
            //elozopozicio8 = lap1helye;

            g.DrawImage(Elap9, Elap9helye);
            //elozopozicio9 = lap1helye;

            g.DrawImage(Elap10, Elap10helye);
            // elozopozicio10 = lap1helye;

            g.DrawImage(Elap11, Elap11helye);
            // elozopozicio11 = lap1helye;

            g.DrawImage(Elap12, Elap12helye);
            //elozopozicio12 = lap1helye;

            g.DrawImage(Elap13, Elap13helye);
            //elozopozicio13 = lap1helye;

            g.DrawImage(Elap14, Elap14helye);
            //elozopozicio14 = lap1helye;

            g.DrawImage(Elap15, Elap15helye);
            //elozopozicio15 = lap1helye;

            g.DrawImage(Elap16, Elap16helye);
            //elozopozicio16 = lap1helye;

            g.DrawImage(Elap17, Elap17helye);
            // elozopozicio17 = lap1helye;

            g.DrawImage(Elap18, Elap18helye);
            //elozopozicio18 = lap1helye;

            g.DrawImage(Elap19, Elap19helye);
            //elozopozicio19 = lap1helye;

            g.DrawImage(Elap20, Elap20helye);
            //elozopozicio20 = lap1helye;

            g.DrawImage(Elap21, Elap21helye);
            //elozopozicio21 = lap1helye;

            g.DrawImage(Elap22, Elap22helye);
            //elozopozicio22 = lap1helye;

            g.DrawImage(Elap23, Elap23helye);
            //elozopozicio23 = lap1helye;

            g.DrawImage(Elap24, Elap24helye);
            //elozopozicio24 = lap1helye;

            g.DrawImage(Elap25, Elap25helye);
            //elozopozicio25 = lap1helye;

            if (csakegyszer == 0)
            {
                csakegyszer++;
                Elsokilenckartya(paklitartalma, ref Lrandomszam);
                
            }

            if(csakegyszer03 == 0)
            {
                csakegyszer03++;
                Elsokilenckartya(paklitartalma, ref Ellenfelrandomszam);
            }


            Point kirako = new Point(212, 603);
            Point kirako2 = new Point(210, 5);

            if (csakegyszer02 == 0)
            {
                foreach (var szamok in Ellenfelrandomszam)
                {
                    //if (lepteto == 16)
                    //  lepteto = 0;
                    switch (szamok)
                    {
                        case 1:
                            kirako2.X = kirako2.X + (Elllepteto * 70);
                            Elap1helye = kirako2;
                            //g.DrawImage(lap2, lap2helye);
                            kirako2 = new Point(210, 5);
                            break;
                        case 2:
                            kirako2.X = kirako2.X + (Elllepteto * 70);
                            Elap2helye = kirako2;
                            //g.DrawImage(lap2, lap2helye);
                            kirako2 = new Point(210, 5);
                            break;
                        case 3:
                            kirako2.X = kirako2.X + (Elllepteto * 70);
                            Elap3helye = kirako2;
                            //g.DrawImage(lap2, lap2helye);
                            kirako2 = new Point(210, 5);
                            break;
                        case 4:
                            kirako2.X = kirako2.X + (Elllepteto * 70);
                            Elap4helye = kirako2;
                            //g.DrawImage(lap2, lap2helye);
                            kirako2 = new Point(210, 5);
                            break;
                        case 5:
                            kirako2.X = kirako2.X + (Elllepteto * 70);
                            Elap5helye = kirako2;
                            //g.DrawImage(lap2, lap2helye);
                            kirako2 = new Point(210, 5);
                            break;
                        case 6:
                            kirako2.X = kirako2.X + (Elllepteto * 70);
                            Elap6helye = kirako2;
                            //g.DrawImage(lap2, lap2helye);
                            kirako2 = new Point(210, 5);
                            break;
                        case 7:
                            kirako2.X = kirako2.X + (Elllepteto * 70);
                            Elap7helye = kirako2;
                            //g.DrawImage(lap2, lap2helye);
                            kirako2 = new Point(210, 5);
                            break;
                        case 8:
                            kirako2.X = kirako2.X + (Elllepteto * 70);
                            Elap8helye = kirako2;
                            //g.DrawImage(lap2, lap2helye);
                            kirako2 = new Point(210, 5);
                            break;
                        case 9:
                            kirako2.X = kirako2.X + (Elllepteto * 70);
                            Elap9helye = kirako2;
                            //g.DrawImage(lap2, lap2helye);
                            kirako2 = new Point(210, 5);
                            break;
                        case 10:
                            kirako2.X = kirako2.X + (Elllepteto * 70);
                            Elap10helye = kirako2;
                            //g.DrawImage(lap2, lap2helye);
                            kirako2 = new Point(210, 5);
                            break;
                        case 11:
                            kirako2.X = kirako2.X + (Elllepteto * 70);
                            Elap11helye = kirako2;
                            //g.DrawImage(lap2, lap2helye);
                            kirako2 = new Point(210, 5);
                            break;
                        case 12:
                            kirako2.X = kirako2.X + (Elllepteto * 70);
                            Elap12helye = kirako2;
                            //g.DrawImage(lap2, lap2helye);
                            kirako2 = new Point(210, 5);
                            break;
                        case 13:
                            kirako2.X = kirako2.X + (Elllepteto * 70);
                            Elap13helye = kirako2;
                            //g.DrawImage(lap2, lap2helye);
                            kirako2 = new Point(210, 5);
                            break;
                        case 14:
                            kirako2.X = kirako2.X + (Elllepteto * 70);
                            Elap14helye = kirako2;
                            //g.DrawImage(lap2, lap2helye);
                            kirako2 = new Point(210, 5);
                            break;
                        case 15:
                            kirako2.X = kirako2.X + (Elllepteto * 70);
                            Elap15helye = kirako2;
                            //g.DrawImage(lap2, lap2helye);
                            kirako2 = new Point(210, 5);
                            break;
                        case 16:
                            kirako2.X = kirako2.X + (Elllepteto * 70);
                            Elap16helye = kirako2;
                            //g.DrawImage(lap2, lap2helye);
                            kirako2 = new Point(210, 5);
                            break;
                        case 17:
                            kirako2.X = kirako2.X + (Elllepteto * 70);
                            Elap17helye = kirako2;
                            //g.DrawImage(lap2, lap2helye);
                            kirako2 = new Point(210, 5);
                            break;
                        case 18:
                            kirako2.X = kirako2.X + (Elllepteto * 70);
                            Elap18helye = kirako2;
                            //g.DrawImage(lap2, lap2helye);
                            kirako2 = new Point(210, 5);
                            break;
                        case 19:
                            kirako2.X = kirako2.X + (Elllepteto * 70);
                            Elap19helye = kirako2;
                            //g.DrawImage(lap2, lap2helye);
                            kirako2 = new Point(210, 5);
                            break;
                        case 20:
                            kirako2.X = kirako2.X + (Elllepteto * 70);
                            Elap20helye = kirako2;
                            //g.DrawImage(lap2, lap2helye);
                            kirako2 = new Point(210, 5);
                            break;
                        case 21:
                            kirako2.X = kirako2.X + (Elllepteto * 70);
                            Elap21helye = kirako2;
                            //g.DrawImage(lap2, lap2helye);
                            kirako2 = new Point(210, 5);
                            break;
                        case 22:
                            kirako2.X = kirako2.X + (Elllepteto * 70);
                            Elap22helye = kirako2;
                            //g.DrawImage(lap2, lap2helye);
                            kirako2 = new Point(210, 5);
                            break;
                        case 23:
                            kirako2.X = kirako2.X + (Elllepteto * 70);
                            Elap23helye = kirako2;
                            //g.DrawImage(lap2, lap2helye);
                            kirako2 = new Point(210, 5);
                            break;
                        case 24:
                            kirako2.X = kirako2.X + (Elllepteto * 70);
                            Elap24helye = kirako2;
                            //g.DrawImage(lap2, lap2helye);
                            kirako2 = new Point(210, 5);
                            break;
                        case 25:
                            kirako2.X = kirako2.X + (Elllepteto * 70);
                            Elap25helye = kirako2;
                            //g.DrawImage(lap2, lap2helye);
                            kirako2 = new Point(210, 5);
                            break;

                        default:
                            break;
                    }
                    Elllepteto++;
                }
                foreach (var szamok in Lrandomszam)
                {
                    //if (lepteto == 16)
                    //  lepteto = 0;
                    switch (szamok)
                    {
                        case 1:
                            kirako.X = kirako.X + (lepteto * 70);
                            lap1helye = kirako;
                            //g.DrawImage(lap2, lap2helye);
                            kirako = new Point(212, 603);
                            break;
                        case 2:
                            kirako.X = kirako.X + (lepteto * 70);
                            lap2helye = kirako;
                            //g.DrawImage(lap2, lap2helye);
                            kirako = new Point(212, 603);
                            break;
                        case 3:
                            kirako.X = kirako.X + (lepteto * 70);
                            lap3helye = kirako;
                            //g.DrawImage(lap2, lap2helye);
                            kirako = new Point(212, 603);
                            break;
                        case 4:
                            kirako.X = kirako.X + (lepteto * 70);
                            lap4helye = kirako;
                            //g.DrawImage(lap2, lap2helye);
                            kirako = new Point(212, 603);
                            break;
                        case 5:
                            kirako.X = kirako.X + (lepteto * 70);
                            lap5helye = kirako;
                            //g.DrawImage(lap2, lap2helye);
                            kirako = new Point(212, 603);
                            break;
                        case 6:
                            kirako.X = kirako.X + (lepteto * 70);
                            lap6helye = kirako;
                            //g.DrawImage(lap2, lap2helye);
                            kirako = new Point(212, 603);
                            break;
                        case 7:
                            kirako.X = kirako.X + (lepteto * 70);
                            lap7helye = kirako;
                            //g.DrawImage(lap2, lap2helye);
                            kirako = new Point(212, 603);
                            break;
                        case 8:
                            kirako.X = kirako.X + (lepteto * 70);
                            lap8helye = kirako;
                            //g.DrawImage(lap2, lap2helye);
                            kirako = new Point(212, 603);
                            break;
                        case 9:
                            kirako.X = kirako.X + (lepteto * 70);
                            lap9helye = kirako;
                            //g.DrawImage(lap2, lap2helye);
                            kirako = new Point(212, 603);
                            break;
                        case 10:
                            kirako.X = kirako.X + (lepteto * 70);
                            lap10helye = kirako;
                            //g.DrawImage(lap2, lap2helye);
                            kirako = new Point(212, 603);
                            break;
                        case 11:
                            kirako.X = kirako.X + (lepteto * 70);
                            lap11helye = kirako;
                            //g.DrawImage(lap2, lap2helye);
                            kirako = new Point(212, 603);
                            break;
                        case 12:
                            kirako.X = kirako.X + (lepteto * 70);
                            lap12helye = kirako;
                            //g.DrawImage(lap2, lap2helye);
                            kirako = new Point(212, 603);
                            break;
                        case 13:
                            kirako.X = kirako.X + (lepteto * 70);
                            lap13helye = kirako;
                            //g.DrawImage(lap2, lap2helye);
                            kirako = new Point(212, 603);
                            break;
                        case 14:
                            kirako.X = kirako.X + (lepteto * 70);
                            lap14helye = kirako;
                            //g.DrawImage(lap2, lap2helye);
                            kirako = new Point(212, 603);
                            break;
                        case 15:
                            kirako.X = kirako.X + (lepteto * 70);
                            lap15helye = kirako;
                            //g.DrawImage(lap2, lap2helye);
                            kirako = new Point(212, 603);
                            break;
                        case 16:
                            kirako.X = kirako.X + (lepteto * 70);
                            lap16helye = kirako;
                            //g.DrawImage(lap2, lap2helye);
                            kirako = new Point(212, 603);
                            break;
                        case 17:
                            kirako.X = kirako.X + (lepteto * 70);
                            lap17helye = kirako;
                            //g.DrawImage(lap2, lap2helye);
                            kirako = new Point(212, 603);
                            break;
                        case 18:
                            kirako.X = kirako.X + (lepteto * 70);
                            lap18helye = kirako;
                            //g.DrawImage(lap2, lap2helye);
                            kirako = new Point(212, 603);
                            break;
                        case 19:
                            kirako.X = kirako.X + (lepteto * 70);
                            lap19helye = kirako;
                            //g.DrawImage(lap2, lap2helye);
                            kirako = new Point(212, 603);
                            break;
                        case 20:
                            kirako.X = kirako.X + (lepteto * 70);
                            lap20helye = kirako;
                            //g.DrawImage(lap2, lap2helye);
                            kirako = new Point(212, 603);
                            break;
                        case 21:
                            kirako.X = kirako.X + (lepteto * 70);
                            lap21helye = kirako;
                            //g.DrawImage(lap2, lap2helye);
                            kirako = new Point(212, 603);
                            break;
                        case 22:
                            kirako.X = kirako.X + (lepteto * 70);
                            lap22helye = kirako;
                            //g.DrawImage(lap2, lap2helye);
                            kirako = new Point(212, 603);
                            break;
                        case 23:
                            kirako.X = kirako.X + (lepteto * 70);
                            lap23helye = kirako;
                            //g.DrawImage(lap2, lap2helye);
                            kirako = new Point(212, 603);
                            break;
                        case 24:
                            kirako.X = kirako.X + (lepteto * 70);
                            lap24helye = kirako;
                            //g.DrawImage(lap2, lap2helye);
                            kirako = new Point(212, 603);
                            break;
                        case 25:
                            kirako.X = kirako.X + (lepteto * 70);
                            lap25helye = kirako;
                            //g.DrawImage(lap2, lap2helye);
                            kirako = new Point(212, 603);
                            break;

                        default:
                            break;
                    }
                    lepteto++;
                }
            }

            //Ha pakliban van lezárom
            if (lap1helye == Paklihelye)
                lap1zarolasa = true;

            if (lap2helye == Paklihelye)
                lap2zarolasa = true;

            if (lap3helye == Paklihelye)
                lap3zarolasa = true;

            if (lap4helye == Paklihelye)
                lap4zarolasa = true;

            if (lap5helye == Paklihelye)
                lap5zarolasa = true;

            if (lap6helye == Paklihelye)
                lap6zarolasa = true;

            if (lap7helye == Paklihelye)
                lap7zarolasa = true;

            if (lap8helye == Paklihelye)
                lap8zarolasa = true;

            if (lap9helye == Paklihelye)
                lap9zarolasa = true;

            if (lap10helye == Paklihelye)
                lap10zarolasa = true;

            if (lap11helye == Paklihelye)
                lap11zarolasa = true;

            if (lap12helye == Paklihelye)
                lap12zarolasa = true;

            if (lap13helye == Paklihelye)
                lap13zarolasa = true;

            if (lap14helye == Paklihelye)
                lap14zarolasa = true;

            if (lap15helye == Paklihelye)
                lap15zarolasa = true;

            if (lap16helye == Paklihelye)
                lap16zarolasa = true;

            if (lap17helye == Paklihelye)
                lap17zarolasa = true;

            if (lap18helye == Paklihelye)
                lap18zarolasa = true;

            if (lap19helye == Paklihelye)
                lap19zarolasa = true;

            if (lap20helye == Paklihelye)
                lap20zarolasa = true;

            if (lap21helye == Paklihelye)
                lap21zarolasa = true;

            if (lap22helye == Paklihelye)
                lap22zarolasa = true;

            if (lap23helye == Paklihelye)
                lap23zarolasa = true;

            if (lap24helye == Paklihelye)
                lap24zarolasa = true;

            if (lap25helye == Paklihelye)
                lap25zarolasa = true;

            

            csakegyszer02++;
            //lepteto = 0;

            //g.DrawImage(lap2, lap2helye);

            //g.DrawImage(lap1, lap1helye.X,lap1helye.Y);


            //Kártyák kirajzolása

            //Ezt a feltételt azért csináltam, hogy egyszer rajzolja ki az összes kártyát(most ugye "30"db kártya van ezért 
            //"lap" nevezetű tömb az 30 elemű,mert egy pakliban gondolkodtam először),ha eléri az "f" nevű változo egyszer a lap.length-et
            //tehát a 30-at, akkor nem kell újra kirajzolni az összes kártyát, felesleges ugy sincsenek mozdítva
            // if (f != lap.Length)
            /*------------------------------------------------------------------------*/

            //Ezzen a cikluson rajzolom ki lap.length-nyi (tehát 12 lapot,mivel annyi van beleírva a txt-fájlba) kártyákat
            //  for (int i = 1; i < lap.Length; i++)
            // {
            // f++;
            //Ezt gondolom érti ha a kategoria = "Ostrom" amit a fájba írok és onnan is kapja a lap[i].kategoria az értéket
            //akkor az adott "i"-dik elemű kártyának a pozicióját beállítom a KezdoKartyahelyre(A fehérmező/sáv alúl) bal oldaról kezdje
            //felsorolni/kipakolni a lapokat

            //g.DrawImage(OstromKartya, Ostromkartyahelye);
            //g.DrawImage(OstromKartya, Ideiglenespoz);
            //  if (lap[i].kategoria == "Ostrom")
            //  {
            //lap[i].aktualispozX = KezdoKartyakhelye.X + (a * 70);
            //lap[i].aktualispozY = KezdoKartyakhelye.Y;
            //Ezt azért csináltam mert ha az elsőt lapot kihelyeztem a fehér mezőre akkor a következőt nem rá
            //hanem utána szeretném rakni. Az "a" változo igazából azt szeretné jelképzni hogy hányadik éppen vagy hányadiknál tartunk
            // ezért ha az 1-re változik akkor alapból a következőt is ráhelyezné de igy (a * 70) 70-el eltoltam jobbra 
            // a következőt 140-el azt következőt pedig 210-el stb....
            // g.DrawImage(OstromKartya, lap[i].aktualispozX, lap[i].aktualispozY);
            //    a++;

            //Ezt azért írtam ide hogy fejebb a lap[i] elem rögzitett poziciója az Kezdokártya lenne csak rajzolásnál
            //tolja el, de nem jegyzi meg, ezért raktam ide ezt ha már eltolja akkor lap[i]-ben is nyomja el
            // lap[i].aktualispozX = lap[i].aktualispozX + (a * 70);
            // }
            //Amit fentebb csinálok azt itt is lemásoltam
            // if (lap[i].kategoria == "Tavolsagi")
            // {
            //lap[i].aktualispozX = KezdoKartyakhelye.X + (a * 70);
            //lap[i].aktualispozY = KezdoKartyakhelye.Y;

            // g.DrawImage(TavolsagiKartya, lap[i].aktualispozX, lap[i].aktualispozY);
            //    a++;

            // lap[i].aktualispozX = lap[i].aktualispozX + (a * 70);

            //   }
            //Valamit itt is csak közelharcosra
            // if (lap[i].kategoria == "Kozelharcos")
            //  {
            // lap[i].aktualispozX = KezdoKartyakhelye.X + (a * 70);
            // lap[i].aktualispozY = KezdoKartyakhelye.Y;

            // g.DrawImage(KozelharcosKartya, lap[i].aktualispozX , lap[i].aktualispozY);
            //a++;

            //lap[i].aktualispozX = lap[i].aktualispozX + (a * 70);
            //  }
            // }

            /*-------------------------------------------------------------------------------------------- */

            //Ez a kiválasztott kártyát szeretné újrarajzolni

            //g.DrawImage(KozelharcosKartya, lap[Index].aktualispozX, lap[Index].aktualispozY);


            /*------------------------------------------------------------------------*/

            /*
                        private Point EllBoostkartyahelye1 = new Point(210, 215);
                    private Point EllBoostkartyahelye2 = new Point(210, 110);

                    private Point EllKartyakkezbenhelye = new Point(210, 5);

                    private Point EllKozelharcosmezohelye = new Point(285, 215);
                    // private Point EllKozelharcoskartyahelye = new Point(100, 100);

                    private Point EllTavolsagimezohelye = new Point(285, 110);
                    // private Point EllTavolsagikartyahelye = new Point(100, 250);

                    private Point EllOstrommezohelye1 = new Point(5, 110);
                    private Point EllOstrommezohelye2 = new Point(1160, 110);
                    // private Point EllOstromkartyahelye = new Point(100, 380);

                    private Point EllPaklihelye = new Point(30, 5);
                    private Point EllTemetohelye = new Point(100, 5);
                    */
            if (Ellenfelkore)
            {
                csakegyszerlap1 = true;
                if (csakegyszerlap1)
                {
                    EllenfelKartyaRakas(Ellenfelrandomszam, ref kivalasztott);
                }
                csakegyszerlap1 = false;



                switch (kivalasztott)
                {
                    case 1:
                        Elap1helye.X = EllKozelharcosmezohelye.X + (EllKmezolepteto * 75);
                        Elap1helye.Y = EllKozelharcosmezohelye.Y + 2;
                        this.Refresh();
                        EllKmezolepteto++;
                        break;

                    case 2:
                        Elap2helye.X = EllKozelharcosmezohelye.X + (EllKmezolepteto * 75);
                        Elap2helye.Y = EllKozelharcosmezohelye.Y + 2;
                        this.Refresh();
                        EllKmezolepteto++;
                        break;

                    case 3:
                        //kozelharcos/tav
                        Elap3helye.X = EllKozelharcosmezohelye.X + (EllKmezolepteto * 75);
                        Elap3helye.Y = EllKozelharcosmezohelye.Y + 2;
                        this.Refresh();
                        EllKmezolepteto++;
                        break;

                    case 4:
                        Elap4helye.X = EllKozelharcosmezohelye.X + (EllKmezolepteto * 75);
                        Elap4helye.Y = EllKozelharcosmezohelye.Y + 2;
                        this.Refresh();
                        EllKmezolepteto++;
                        break;

                    case 5:
                        Elap5helye.X = EllKozelharcosmezohelye.X + (EllKmezolepteto * 75);
                        Elap5helye.Y = EllKozelharcosmezohelye.Y + 2;
                        this.Refresh();
                        EllKmezolepteto++;
                        break;

                    case 6:
                        Elap6helye.X = EllKozelharcosmezohelye.X + (EllKmezolepteto * 75);
                        Elap6helye.Y = EllKozelharcosmezohelye.Y + 2;
                        this.Refresh();
                        EllKmezolepteto++;
                        break;

                    case 7:
                        Elap7helye.X = EllKozelharcosmezohelye.X + (EllKmezolepteto * 75);
                        Elap7helye.Y = EllKozelharcosmezohelye.Y + 2;
                        this.Refresh();
                        EllKmezolepteto++;
                        break;

                    case 8:
                        Elap8helye.X = EllKozelharcosmezohelye.X + (EllKmezolepteto * 75);
                        Elap8helye.Y = EllKozelharcosmezohelye.Y + 2;
                        this.Refresh();
                        EllKmezolepteto++;
                        break;

                    case 9:
                        Elap9helye.X = EllKozelharcosmezohelye.X + (EllKmezolepteto * 75);
                        Elap9helye.Y = EllKozelharcosmezohelye.Y + 2;
                        this.Refresh();
                        EllKmezolepteto++;
                        break;
                        
                    case 10:
                        Elap10helye.X = EllTavolsagimezohelye.X + (EllTmezolepteto * 75);
                        Elap10helye.Y = EllTavolsagimezohelye.Y + 2;
                        this.Refresh();
                        EllTmezolepteto++;
                        break;

                    case 11:
                        Elap11helye.X = EllTavolsagimezohelye.X + (EllTmezolepteto * 75);
                        Elap11helye.Y = EllTavolsagimezohelye.Y + 2;
                        this.Refresh();
                        EllTmezolepteto++;
                        break;

                    case 12:
                        Elap12helye.X = EllTavolsagimezohelye.X + (EllTmezolepteto * 75);
                        Elap12helye.Y = EllTavolsagimezohelye.Y + 2;
                        this.Refresh();
                        EllTmezolepteto++;
                        break;

                    case 13:
                        Elap13helye.X = EllTavolsagimezohelye.X + (EllTmezolepteto * 75);
                        Elap13helye.Y = EllTavolsagimezohelye.Y + 2;
                        this.Refresh();
                        break;

                    case 14:
                        Elap14helye.X = EllKozelharcosmezohelye.X + (EllKmezolepteto * 75);
                        Elap14helye.Y = EllKozelharcosmezohelye.Y + 2;
                        this.Refresh();
                        EllKmezolepteto++;
                        break;

                    case 15:
                        Elap15helye.X = EllTavolsagimezohelye.X + (EllTmezolepteto * 75);
                        Elap15helye.Y = EllTavolsagimezohelye.Y + 2;
                        this.Refresh();
                        EllTmezolepteto++;
                        break;

                    case 16:
                        Elap16helye.X = EllTavolsagimezohelye.X + (EllTmezolepteto * 75);
                        Elap16helye.Y = EllTavolsagimezohelye.Y + 2;
                        this.Refresh();
                        EllTmezolepteto++;
                        break;

                    case 17:
                        Elap17helye.X = EllKozelharcosmezohelye.X + (EllKmezolepteto * 75);
                        Elap17helye.Y = EllKozelharcosmezohelye.Y + 2;
                        this.Refresh();
                        EllKmezolepteto++;
                        break;

                    case 18:
                        Elap18helye.X = EllKozelharcosmezohelye.X + (EllKmezolepteto * 75);
                        Elap18helye.Y = EllKozelharcosmezohelye.Y + 2;
                        this.Refresh();
                        EllKmezolepteto++;
                        break;

                    case 19:
                        Elap19helye.X = EllKozelharcosmezohelye.X + (EllKmezolepteto * 75);
                        Elap19helye.Y = EllKozelharcosmezohelye.Y + 2;
                        this.Refresh();
                        EllKmezolepteto++;
                        break;

                    case 20:
                        Elap20helye.X = EllKozelharcosmezohelye.X + (EllKmezolepteto * 75);
                        Elap20helye.Y = EllKozelharcosmezohelye.Y + 2;
                        this.Refresh();
                        EllKmezolepteto++;
                        break;

                    case 21:
                        Elap21helye.X = EllKozelharcosmezohelye.X + (EllKmezolepteto * 75);
                        Elap21helye.Y = EllKozelharcosmezohelye.Y + 2;
                        this.Refresh();
                        EllKmezolepteto++;
                        break;

                    case 22:
                        Elap22helye.X = EllTavolsagimezohelye.X + (EllTmezolepteto * 75);
                        Elap22helye.Y = EllTavolsagimezohelye.Y + 2;
                        this.Refresh();
                        EllTmezolepteto++;
                        break;

                    case 23:
                        Elap23helye.X = EllKozelharcosmezohelye.X + (EllKmezolepteto * 75);
                        Elap23helye.Y = EllKozelharcosmezohelye.Y + 2;
                        this.Refresh();
                        EllKmezolepteto++;
                        break;

                    case 24:
                        Elap24helye.X = EllKozelharcosmezohelye.X + (EllKmezolepteto * 75);
                        Elap24helye.Y = EllKozelharcosmezohelye.Y + 2;
                        this.Refresh();
                        EllKmezolepteto++;
                        break;

                    case 25:
                        Elap25helye.X = EllKozelharcosmezohelye.X + (EllKmezolepteto * 75);
                        Elap25helye.Y = EllKozelharcosmezohelye.Y + 2;
                        this.Refresh();
                        EllKmezolepteto++;
                        break;

                    default:
                       // EllenfelKartyaRakas(Ellenfelrandomszam, ref kivalasztott);
                        break;
                }
            }
            Ellenfelkore = false;


        }
        
        


        #region Kartyabanakulzor
        //Ha a kulzor az kártyán van akkor "igazat" küld
        private bool Kartyabanakulzor(Point kartyahelye, Bitmap Kartya)
        {
            if (MousePosition.X >= kartyahelye.X && MousePosition.X <= kartyahelye.X + Kartya.Width
               && MousePosition.Y >= kartyahelye.Y && MousePosition.Y <= kartyahelye.Y + Kartya.Height)
            {
                return true;
            }

            return false;
        }
        /*------------------------------------------------------------------------*/
        #endregion


        #region Kartya_a_mezobe_van_helyezve
        //Ha a kártya a mezoben van húzva akkor ne lehessen mozgatni többet
        private bool Kartya_a_mezobe_van_helyezve(Point kartyahelye, Point mezo1helye, Bitmap mezo1, bool Kartyazarolas, Bitmap kartya)
        {
 
                //Itt megvizsgálóm h be van-e helyezve a kártya
                if (kartyahelye.X + kartya.Width >= mezo1helye.X && kartyahelye.X <= mezo1helye.X + mezo1.Width
                   && kartyahelye.Y + kartya.Height >= mezo1helye.Y && kartyahelye.Y <= mezo1helye.Y + mezo1.Height)
                {
                //Ha bent van akkor és csak is akkor "zárolja"-le a kártyát a mezőre ha az "Mouse up"-olva 
                //tehát az egeret felengedtük

                //Ezt lejebb oldottam meg 
                Ellenfelkore = true;
                return true;
                    

                }

            
            
            return false;
        } 
        #endregion


        //Egér mozgatás
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            
            elozopozicio1 = lap1helye;
            elozopozicio2 = lap2helye;
            elozopozicio3 = lap3helye;
            elozopozicio4 = lap4helye;
            elozopozicio5 = lap5helye;
            elozopozicio6 = lap6helye;
            elozopozicio7 = lap7helye;
            elozopozicio8 = lap8helye;
            elozopozicio9 = lap9helye;
            elozopozicio10 = lap10helye;
            elozopozicio11 = lap11helye;
            elozopozicio12 = lap12helye;
            elozopozicio13 = lap13helye;
            elozopozicio14 = lap14helye;
            elozopozicio15 = lap15helye;
            elozopozicio16 = lap16helye;
            elozopozicio17 = lap17helye;
            elozopozicio18 = lap18helye;
            elozopozicio19 = lap19helye;
            elozopozicio20 = lap20helye;
            elozopozicio21 = lap21helye;
            elozopozicio22 = lap22helye;
            elozopozicio23 = lap23helye;
            elozopozicio24 = lap24helye;
            elozopozicio25 = lap25helye;

            byte egy = 1;
            byte ketto = 2, h = 3, n = 4, o = 5, hat = 6, het = 7,
                nyolc = 8, kil = 9, tiz = 10, tegy = 11, tkett = 12,
                th = 13, tn = 14, to = 15, that = 16, thet = 17, tnyolc = 18,
                tkile = 19, husz = 20, hegy = 21, hketto = 22, hharom = 23,
                hnegy = 24, huszonot = 25;
            bool tartalmaz1 = Kozmezoben.Contains(egy);
            bool tartalmaz2 = Kozmezoben.Contains(ketto);
            bool tartalmaz3 = Kozmezoben.Contains(h);
            bool tartalmaz4 = Kozmezoben.Contains(n);
            bool tartalmaz5 = Tavmezoben.Contains(o);
            bool tartalmaz6 = Tavmezoben.Contains(hat);
            bool tartalmaz7 = Tavmezoben.Contains(het);
            bool tartalmaz8 = Kozmezoben.Contains(nyolc);
            bool tartalmaz9 = Kozmezoben.Contains(kil);
            bool tartalmaz10 = Kozmezoben.Contains(tiz);
            bool tartalmaz11 = Kozmezoben.Contains(tegy);
            bool tartalmaz12 = Kozmezoben.Contains(tkett);
            bool tartalmaz13 = Tavmezoben.Contains(th);
            bool tartalmaz14 = Tavmezoben.Contains(tn);
            bool tartalmaz15 = Tavmezoben.Contains(to);
            bool tartalmaz16 = Ostrommezoben1.Contains(that)|| Ostrommezoben2.Contains(that);
            bool tartalmaz17 = Kozmezoben.Contains(thet);
            bool tartalmaz18 = Ostrommezoben1.Contains(tnyolc)|| Ostrommezoben2.Contains(tnyolc);
            bool tartalmaz19 = Ostrommezoben1.Contains(tkile)|| Ostrommezoben2.Contains(tkile);
            bool tartalmaz20 = Ostrommezoben1.Contains(husz)|| Ostrommezoben2.Contains(husz);
            bool tartalmaz21 = Ostrommezoben1.Contains(hegy)|| Ostrommezoben2.Contains(hegy);
            bool tartalmaz22 = Kozmezoben.Contains(hketto);
            bool tartalmaz23 = Kozmezoben.Contains(hharom)|| Tavmezoben.Contains(hharom);
            bool tartalmaz24 = Kozmezoben.Contains(hnegy);
            bool tartalmaz25 = Kozmezoben.Contains(huszonot);


            //Ideiglenespoz
            if (!lap2zarolasa && !tartalmaz2)
            { 
                //Ha a kiválasztott kártyán "Ideiglenespoz"-on rajta volt a kulzor/rákattintottak
                if (Kartyabanakulzor(lap2helye, Alapkartya))
                {

                    lap1zarolasa = true;
                    //lap2zarolasa = true;
                    lap3zarolasa = true;
                    lap4zarolasa = true;
                    lap5zarolasa = true;
                    lap6zarolasa = true;
                    lap7zarolasa = true;
                    lap8zarolasa = true;
                    lap9zarolasa = true;
                    lap10zarolasa =true;
                    lap11zarolasa =true;
                    lap12zarolasa =true;
                    lap13zarolasa =true;
                    lap14zarolasa =true;
                    lap15zarolasa =true;
                    lap16zarolasa =true;
                    lap17zarolasa =true;
                    lap18zarolasa =true;
                    lap19zarolasa =true;
                    lap20zarolasa =true;
                    lap21zarolasa =true;
                    lap22zarolasa =true;
                    lap23zarolasa =true;
                    lap24zarolasa =true;
                    lap25zarolasa =true;

                    aktualiskulzorpozicio = Control.MousePosition;

                    
                    //és nyomjuk a balgombot
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        //ezeket régen használtam
                        //TavKartyazarolas = true;
                        //OstKartyazarolas = true;
                        //akkor itt egyszer lelockoljuk a kulzort hogy mozgatásnál nem mozduljon el
                        if (kulzorlock.X == -1 && kulzorlock.Y == -1)
                        {
                            //Ezt még nekem is alaposan át kell gondolnom hogy mi is történik itt
                            //Mivel itt akadtam el, de ezt levélben már kifejtettem
                            

                            kulzorlock.X = aktualiskulzorpozicio.X - lap2helye.X;
                            kulzorlock.Y = aktualiskulzorpozicio.Y - lap2helye.Y;

                            //Kulzorlock legyen = a kulzorlock - kártyahelye

                        }
                        //kicsit feljebb ugye le lockoltuk a kulzort tehát ha ide belép akkor a kiválasztott("Index")
                        //lapnak a pozicióját módosítom és majd g.DrawImage-ben újra írom, de itt már ugye Frissítem szóval nem értem
                        else
                        {
                            lap2helye.X = MousePosition.X - kulzorlock.X;
                            lap2helye.Y = MousePosition.Y - kulzorlock.Y;

                            this.Refresh();
                        }


                    }
                }
                


            }
            if (!lap1zarolasa && !tartalmaz1)
            { 
                if (Kartyabanakulzor(lap1helye, Alapkartya))
                {

                    //lap1zarolasa = true;
                    lap2zarolasa = true;
                    lap3zarolasa = true;
                    lap4zarolasa = true;
                    lap5zarolasa = true;
                    lap6zarolasa = true;
                    lap7zarolasa = true;
                    lap8zarolasa = true;
                    lap9zarolasa = true;
                    lap10zarolasa = true;
                    lap11zarolasa = true;
                    lap12zarolasa = true;
                    lap13zarolasa = true;
                    lap14zarolasa = true;
                    lap15zarolasa = true;
                    lap16zarolasa = true;
                    lap17zarolasa = true;
                    lap18zarolasa = true;
                    lap19zarolasa = true;
                    lap20zarolasa = true;
                    lap21zarolasa = true;
                    lap22zarolasa = true;
                    lap23zarolasa = true;
                    lap24zarolasa = true;
                    lap25zarolasa = true;


                    aktualiskulzorpozicio = Control.MousePosition;
                    
                    //és nyomjuk a balgombot
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        //ezeket régen használtam
                        //TavKartyazarolas = true;
                        //OstKartyazarolas = true;
                        //akkor itt egyszer lelockoljuk a kulzort hogy mozgatásnál nem mozduljon el
                        if (kulzorlock.X == -1 && kulzorlock.Y == -1)
                        {
                            //Ezt még nekem is alaposan át kell gondolnom hogy mi is történik itt
                            //Mivel itt akadtam el, de ezt levélben már kifejtettem
                            elozopozicio1 = lap1helye;
                            elozopozicio2 = lap2helye;
                            elozopozicio3 = lap3helye;
                            elozopozicio4 = lap4helye;
                            elozopozicio5 = lap5helye;
                            elozopozicio6 = lap6helye;
                            elozopozicio7 = lap7helye;
                            elozopozicio8 = lap8helye;
                            elozopozicio9 = lap9helye;
                            elozopozicio10 = lap10helye;
                            elozopozicio11 = lap11helye;
                            elozopozicio12 = lap12helye;
                            elozopozicio13 = lap13helye;
                            elozopozicio14 = lap14helye;
                            elozopozicio15 = lap15helye;
                            elozopozicio16 = lap16helye;
                            elozopozicio17 = lap17helye;
                            elozopozicio18 = lap18helye;
                            elozopozicio19 = lap19helye;
                            elozopozicio20 = lap20helye;
                            elozopozicio21 = lap21helye;
                            elozopozicio22 = lap22helye;
                            elozopozicio23 = lap23helye;
                            elozopozicio24 = lap24helye;
                            elozopozicio25 = lap25helye;

                            kulzorlock.X = aktualiskulzorpozicio.X - lap1helye.X;
                            kulzorlock.Y = aktualiskulzorpozicio.Y - lap1helye.Y;

                            //Kulzorlock legyen = a kulzorlock - kártyahelye

                        }
                        //kicsit feljebb ugye le lockoltuk a kulzort tehát ha ide belép akkor a kiválasztott("Index")
                        //lapnak a pozicióját módosítom és majd g.DrawImage-ben újra írom, de itt már ugye Frissítem szóval nem értem
                        else
                        {
                            lap1helye.X = MousePosition.X - kulzorlock.X;
                            lap1helye.Y = MousePosition.Y - kulzorlock.Y;

                            this.Refresh();
                        }


                    }
                }
                

            }
            if (!lap3zarolasa && !tartalmaz3)
            {
                //Ha a kiválasztott kártyán "Ideiglenespoz"-on rajta volt a kulzor/rákattintottak
                if (Kartyabanakulzor(lap3helye, Alapkartya))
                {

                    lap1zarolasa = true;
                    lap2zarolasa = true;
                   // lap3zarolasa = true;
                    lap4zarolasa = true;
                    lap5zarolasa = true;
                    lap6zarolasa = true;
                    lap7zarolasa = true;
                    lap8zarolasa = true;
                    lap9zarolasa = true;
                    lap10zarolasa = true;
                    lap11zarolasa = true;
                    lap12zarolasa = true;
                    lap13zarolasa = true;
                    lap14zarolasa = true;
                    lap15zarolasa = true;
                    lap16zarolasa = true;
                    lap17zarolasa = true;
                    lap18zarolasa = true;
                    lap19zarolasa = true;
                    lap20zarolasa = true;
                    lap21zarolasa = true;
                    lap22zarolasa = true;
                    lap23zarolasa = true;
                    lap24zarolasa = true;
                    lap25zarolasa = true;

                    aktualiskulzorpozicio = Control.MousePosition;
                    //és nyomjuk a balgombot
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        //ezeket régen használtam
                        //TavKartyazarolas = true;
                        //OstKartyazarolas = true;
                        //akkor itt egyszer lelockoljuk a kulzort hogy mozgatásnál nem mozduljon el
                        if (kulzorlock.X == -1 && kulzorlock.Y == -1)
                        {
                            //Ezt még nekem is alaposan át kell gondolnom hogy mi is történik itt
                            //Mivel itt akadtam el, de ezt levélben már kifejtettem
                            elozopozicio1 = lap1helye;
                            elozopozicio2 = lap2helye;
                            elozopozicio3 = lap3helye;
                            elozopozicio4 = lap4helye;
                            elozopozicio5 = lap5helye;
                            elozopozicio6 = lap6helye;
                            elozopozicio7 = lap7helye;
                            elozopozicio8 = lap8helye;
                            elozopozicio9 = lap9helye;
                            elozopozicio10 = lap10helye;
                            elozopozicio11 = lap11helye;
                            elozopozicio12 = lap12helye;
                            elozopozicio13 = lap13helye;
                            elozopozicio14 = lap14helye;
                            elozopozicio15 = lap15helye;
                            elozopozicio16 = lap16helye;
                            elozopozicio17 = lap17helye;
                            elozopozicio18 = lap18helye;
                            elozopozicio19 = lap19helye;
                            elozopozicio20 = lap20helye;
                            elozopozicio21 = lap21helye;
                            elozopozicio22 = lap22helye;
                            elozopozicio23 = lap23helye;
                            elozopozicio24 = lap24helye;
                            elozopozicio25 = lap25helye;

                            kulzorlock.X = aktualiskulzorpozicio.X - lap3helye.X;
                            kulzorlock.Y = aktualiskulzorpozicio.Y - lap3helye.Y;

                            //Kulzorlock legyen = a kulzorlock - kártyahelye

                        }
                        //kicsit feljebb ugye le lockoltuk a kulzort tehát ha ide belép akkor a kiválasztott("Index")
                        //lapnak a pozicióját módosítom és majd g.DrawImage-ben újra írom, de itt már ugye Frissítem szóval nem értem
                        else
                        {
                            lap3helye.X = MousePosition.X - kulzorlock.X;
                            lap3helye.Y = MousePosition.Y - kulzorlock.Y;

                            this.Refresh();
                        }


                    }
                }


            }
            if (!lap4zarolasa && !tartalmaz4)
            {
                //Ha a kiválasztott kártyán "Ideiglenespoz"-on rajta volt a kulzor/rákattintottak
                if (Kartyabanakulzor(lap4helye, Alapkartya))
                {

                    lap1zarolasa = true;
                    lap2zarolasa = true;
                    lap3zarolasa = true;
                    //lap4zarolasa = true;
                    lap5zarolasa = true;
                    lap6zarolasa = true;
                    lap7zarolasa = true;
                    lap8zarolasa = true;
                    lap9zarolasa = true;
                    lap10zarolasa = true;
                    lap11zarolasa = true;
                    lap12zarolasa = true;
                    lap13zarolasa = true;
                    lap14zarolasa = true;
                    lap15zarolasa = true;
                    lap16zarolasa = true;
                    lap17zarolasa = true;
                    lap18zarolasa = true;
                    lap19zarolasa = true;
                    lap20zarolasa = true;
                    lap21zarolasa = true;
                    lap22zarolasa = true;
                    lap23zarolasa = true;
                    lap24zarolasa = true;
                    lap25zarolasa = true;

                    aktualiskulzorpozicio = Control.MousePosition;
                    //és nyomjuk a balgombot
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        //ezeket régen használtam
                        //TavKartyazarolas = true;
                        //OstKartyazarolas = true;
                        //akkor itt egyszer lelockoljuk a kulzort hogy mozgatásnál nem mozduljon el
                        if (kulzorlock.X == -1 && kulzorlock.Y == -1)
                        {
                            //Ezt még nekem is alaposan át kell gondolnom hogy mi is történik itt
                            //Mivel itt akadtam el, de ezt levélben már kifejtettem
                            elozopozicio1 = lap1helye;
                            elozopozicio2 = lap2helye;
                            elozopozicio3 = lap3helye;
                            elozopozicio4 = lap4helye;
                            elozopozicio5 = lap5helye;
                            elozopozicio6 = lap6helye;
                            elozopozicio7 = lap7helye;
                            elozopozicio8 = lap8helye;
                            elozopozicio9 = lap9helye;
                            elozopozicio10 = lap10helye;
                            elozopozicio11 = lap11helye;
                            elozopozicio12 = lap12helye;
                            elozopozicio13 = lap13helye;
                            elozopozicio14 = lap14helye;
                            elozopozicio15 = lap15helye;
                            elozopozicio16 = lap16helye;
                            elozopozicio17 = lap17helye;
                            elozopozicio18 = lap18helye;
                            elozopozicio19 = lap19helye;
                            elozopozicio20 = lap20helye;
                            elozopozicio21 = lap21helye;
                            elozopozicio22 = lap22helye;
                            elozopozicio23 = lap23helye;
                            elozopozicio24 = lap24helye;
                            elozopozicio25 = lap25helye;

                            kulzorlock.X = aktualiskulzorpozicio.X - lap4helye.X;
                            kulzorlock.Y = aktualiskulzorpozicio.Y - lap4helye.Y;

                            //Kulzorlock legyen = a kulzorlock - kártyahelye

                        }
                        //kicsit feljebb ugye le lockoltuk a kulzort tehát ha ide belép akkor a kiválasztott("Index")
                        //lapnak a pozicióját módosítom és majd g.DrawImage-ben újra írom, de itt már ugye Frissítem szóval nem értem
                        else
                        {
                            lap4helye.X = MousePosition.X - kulzorlock.X;
                            lap4helye.Y = MousePosition.Y - kulzorlock.Y;

                            this.Refresh();
                        }


                    }
                }


            }
            if (!lap5zarolasa && !tartalmaz5)
            {
                //Ha a kiválasztott kártyán "Ideiglenespoz"-on rajta volt a kulzor/rákattintottak
                if (Kartyabanakulzor(lap5helye, Alapkartya))
                {

                    lap1zarolasa = true;
                    lap2zarolasa = true;
                    lap3zarolasa = true;
                    lap4zarolasa = true;
                    //lap5zarolasa = true;
                    lap6zarolasa = true;
                    lap7zarolasa = true;
                    lap8zarolasa = true;
                    lap9zarolasa = true;
                    lap10zarolasa = true;
                    lap11zarolasa = true;
                    lap12zarolasa = true;
                    lap13zarolasa = true;
                    lap14zarolasa = true;
                    lap15zarolasa = true;
                    lap16zarolasa = true;
                    lap17zarolasa = true;
                    lap18zarolasa = true;
                    lap19zarolasa = true;
                    lap20zarolasa = true;
                    lap21zarolasa = true;
                    lap22zarolasa = true;
                    lap23zarolasa = true;
                    lap24zarolasa = true;
                    lap25zarolasa = true;

                    aktualiskulzorpozicio = Control.MousePosition;
                    //és nyomjuk a balgombot
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        //ezeket régen használtam
                        //TavKartyazarolas = true;
                        //OstKartyazarolas = true;
                        //akkor itt egyszer lelockoljuk a kulzort hogy mozgatásnál nem mozduljon el
                        if (kulzorlock.X == -1 && kulzorlock.Y == -1)
                        {
                            //Ezt még nekem is alaposan át kell gondolnom hogy mi is történik itt
                            //Mivel itt akadtam el, de ezt levélben már kifejtettem
                            elozopozicio1 = lap1helye;
                            elozopozicio2 = lap2helye;
                            elozopozicio3 = lap3helye;
                            elozopozicio4 = lap4helye;
                            elozopozicio5 = lap5helye;
                            elozopozicio6 = lap6helye;
                            elozopozicio7 = lap7helye;
                            elozopozicio8 = lap8helye;
                            elozopozicio9 = lap9helye;
                            elozopozicio10 = lap10helye;
                            elozopozicio11 = lap11helye;
                            elozopozicio12 = lap12helye;
                            elozopozicio13 = lap13helye;
                            elozopozicio14 = lap14helye;
                            elozopozicio15 = lap15helye;
                            elozopozicio16 = lap16helye;
                            elozopozicio17 = lap17helye;
                            elozopozicio18 = lap18helye;
                            elozopozicio19 = lap19helye;
                            elozopozicio20 = lap20helye;
                            elozopozicio21 = lap21helye;
                            elozopozicio22 = lap22helye;
                            elozopozicio23 = lap23helye;
                            elozopozicio24 = lap24helye;
                            elozopozicio25 = lap25helye;

                            kulzorlock.X = aktualiskulzorpozicio.X - lap5helye.X;
                            kulzorlock.Y = aktualiskulzorpozicio.Y - lap5helye.Y;

                            //Kulzorlock legyen = a kulzorlock - kártyahelye

                        }
                        //kicsit feljebb ugye le lockoltuk a kulzort tehát ha ide belép akkor a kiválasztott("Index")
                        //lapnak a pozicióját módosítom és majd g.DrawImage-ben újra írom, de itt már ugye Frissítem szóval nem értem
                        else
                        {
                            lap5helye.X = MousePosition.X - kulzorlock.X;
                            lap5helye.Y = MousePosition.Y - kulzorlock.Y;

                            this.Refresh();
                        }


                    }
                }


            }
            if (!lap6zarolasa && !tartalmaz6)
            {
                //Ha a kiválasztott kártyán "Ideiglenespoz"-on rajta volt a kulzor/rákattintottak
                if (Kartyabanakulzor(lap6helye, Alapkartya))
                {

                    lap1zarolasa = true;
                    lap2zarolasa = true;
                    lap3zarolasa = true;
                    lap4zarolasa = true;
                    lap5zarolasa = true;
                    //lap6zarolasa = true;
                    lap7zarolasa = true;
                    lap8zarolasa = true;
                    lap9zarolasa = true;
                    lap10zarolasa = true;
                    lap11zarolasa = true;
                    lap12zarolasa = true;
                    lap13zarolasa = true;
                    lap14zarolasa = true;
                    lap15zarolasa = true;
                    lap16zarolasa = true;
                    lap17zarolasa = true;
                    lap18zarolasa = true;
                    lap19zarolasa = true;
                    lap20zarolasa = true;
                    lap21zarolasa = true;
                    lap22zarolasa = true;
                    lap23zarolasa = true;
                    lap24zarolasa = true;
                    lap25zarolasa = true;

                    aktualiskulzorpozicio = Control.MousePosition;
                    //és nyomjuk a balgombot
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        //ezeket régen használtam
                        //TavKartyazarolas = true;
                        //OstKartyazarolas = true;
                        //akkor itt egyszer lelockoljuk a kulzort hogy mozgatásnál nem mozduljon el
                        if (kulzorlock.X == -1 && kulzorlock.Y == -1)
                        {
                            //Ezt még nekem is alaposan át kell gondolnom hogy mi is történik itt
                            //Mivel itt akadtam el, de ezt levélben már kifejtettem
                            elozopozicio1 = lap1helye;
                            elozopozicio2 = lap2helye;
                            elozopozicio3 = lap3helye;
                            elozopozicio4 = lap4helye;
                            elozopozicio5 = lap5helye;
                            elozopozicio6 = lap6helye;
                            elozopozicio7 = lap7helye;
                            elozopozicio8 = lap8helye;
                            elozopozicio9 = lap9helye;
                            elozopozicio10 = lap10helye;
                            elozopozicio11 = lap11helye;
                            elozopozicio12 = lap12helye;
                            elozopozicio13 = lap13helye;
                            elozopozicio14 = lap14helye;
                            elozopozicio15 = lap15helye;
                            elozopozicio16 = lap16helye;
                            elozopozicio17 = lap17helye;
                            elozopozicio18 = lap18helye;
                            elozopozicio19 = lap19helye;
                            elozopozicio20 = lap20helye;
                            elozopozicio21 = lap21helye;
                            elozopozicio22 = lap22helye;
                            elozopozicio23 = lap23helye;
                            elozopozicio24 = lap24helye;
                            elozopozicio25 = lap25helye;

                            kulzorlock.X = aktualiskulzorpozicio.X - lap6helye.X;
                            kulzorlock.Y = aktualiskulzorpozicio.Y - lap6helye.Y;

                            //Kulzorlock legyen = a kulzorlock - kártyahelye

                        }
                        //kicsit feljebb ugye le lockoltuk a kulzort tehát ha ide belép akkor a kiválasztott("Index")
                        //lapnak a pozicióját módosítom és majd g.DrawImage-ben újra írom, de itt már ugye Frissítem szóval nem értem
                        else
                        {
                            lap6helye.X = MousePosition.X - kulzorlock.X;
                            lap6helye.Y = MousePosition.Y - kulzorlock.Y;

                            this.Refresh();
                        }


                    }
                }


            }
            if (!lap7zarolasa && !tartalmaz7)
            {
                //Ha a kiválasztott kártyán "Ideiglenespoz"-on rajta volt a kulzor/rákattintottak
                if (Kartyabanakulzor(lap7helye, Alapkartya))
                {

                    lap1zarolasa = true;
                    lap2zarolasa = true;
                    lap3zarolasa = true;
                    lap4zarolasa = true;
                    lap5zarolasa = true;
                    lap6zarolasa = true;
                    //lap7zarolasa = true;
                    lap8zarolasa = true;
                    lap9zarolasa = true;
                    lap10zarolasa = true;
                    lap11zarolasa = true;
                    lap12zarolasa = true;
                    lap13zarolasa = true;
                    lap14zarolasa = true;
                    lap15zarolasa = true;
                    lap16zarolasa = true;
                    lap17zarolasa = true;
                    lap18zarolasa = true;
                    lap19zarolasa = true;
                    lap20zarolasa = true;
                    lap21zarolasa = true;
                    lap22zarolasa = true;
                    lap23zarolasa = true;
                    lap24zarolasa = true;
                    lap25zarolasa = true;

                    aktualiskulzorpozicio = Control.MousePosition;
                    //és nyomjuk a balgombot
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        //ezeket régen használtam
                        //TavKartyazarolas = true;
                        //OstKartyazarolas = true;
                        //akkor itt egyszer lelockoljuk a kulzort hogy mozgatásnál nem mozduljon el
                        if (kulzorlock.X == -1 && kulzorlock.Y == -1)
                        {
                            //Ezt még nekem is alaposan át kell gondolnom hogy mi is történik itt
                            //Mivel itt akadtam el, de ezt levélben már kifejtettem
                            elozopozicio1 = lap1helye;
                            elozopozicio2 = lap2helye;
                            elozopozicio3 = lap3helye;
                            elozopozicio4 = lap4helye;
                            elozopozicio5 = lap5helye;
                            elozopozicio6 = lap6helye;
                            elozopozicio7 = lap7helye;
                            elozopozicio8 = lap8helye;
                            elozopozicio9 = lap9helye;
                            elozopozicio10 = lap10helye;
                            elozopozicio11 = lap11helye;
                            elozopozicio12 = lap12helye;
                            elozopozicio13 = lap13helye;
                            elozopozicio14 = lap14helye;
                            elozopozicio15 = lap15helye;
                            elozopozicio16 = lap16helye;
                            elozopozicio17 = lap17helye;
                            elozopozicio18 = lap18helye;
                            elozopozicio19 = lap19helye;
                            elozopozicio20 = lap20helye;
                            elozopozicio21 = lap21helye;
                            elozopozicio22 = lap22helye;
                            elozopozicio23 = lap23helye;
                            elozopozicio24 = lap24helye;
                            elozopozicio25 = lap25helye;

                            kulzorlock.X = aktualiskulzorpozicio.X - lap7helye.X;
                            kulzorlock.Y = aktualiskulzorpozicio.Y - lap7helye.Y;

                            //Kulzorlock legyen = a kulzorlock - kártyahelye

                        }
                        //kicsit feljebb ugye le lockoltuk a kulzort tehát ha ide belép akkor a kiválasztott("Index")
                        //lapnak a pozicióját módosítom és majd g.DrawImage-ben újra írom, de itt már ugye Frissítem szóval nem értem
                        else
                        {
                            lap7helye.X = MousePosition.X - kulzorlock.X;
                            lap7helye.Y = MousePosition.Y - kulzorlock.Y;

                            this.Refresh();
                        }


                    }
                }


            }
            if (!lap8zarolasa && !tartalmaz8)
            {
                //Ha a kiválasztott kártyán "Ideiglenespoz"-on rajta volt a kulzor/rákattintottak
                if (Kartyabanakulzor(lap8helye, Alapkartya))
                {

                    lap1zarolasa = true;
                    lap2zarolasa = true;
                    lap3zarolasa = true;
                    lap4zarolasa = true;
                    lap5zarolasa = true;
                    lap6zarolasa = true;
                    lap7zarolasa = true;
                    //lap8zarolasa = true;
                    lap9zarolasa = true;
                    lap10zarolasa = true;
                    lap11zarolasa = true;
                    lap12zarolasa = true;
                    lap13zarolasa = true;
                    lap14zarolasa = true;
                    lap15zarolasa = true;
                    lap16zarolasa = true;
                    lap17zarolasa = true;
                    lap18zarolasa = true;
                    lap19zarolasa = true;
                    lap20zarolasa = true;
                    lap21zarolasa = true;
                    lap22zarolasa = true;
                    lap23zarolasa = true;
                    lap24zarolasa = true;
                    lap25zarolasa = true;

                    aktualiskulzorpozicio = Control.MousePosition;
                    //és nyomjuk a balgombot
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        //ezeket régen használtam
                        //TavKartyazarolas = true;
                        //OstKartyazarolas = true;
                        //akkor itt egyszer lelockoljuk a kulzort hogy mozgatásnál nem mozduljon el
                        if (kulzorlock.X == -1 && kulzorlock.Y == -1)
                        {
                            //Ezt még nekem is alaposan át kell gondolnom hogy mi is történik itt
                            //Mivel itt akadtam el, de ezt levélben már kifejtettem
                            elozopozicio1 = lap1helye;
                            elozopozicio2 = lap2helye;
                            elozopozicio3 = lap3helye;
                            elozopozicio4 = lap4helye;
                            elozopozicio5 = lap5helye;
                            elozopozicio6 = lap6helye;
                            elozopozicio7 = lap7helye;
                            elozopozicio8 = lap8helye;
                            elozopozicio9 = lap9helye;
                            elozopozicio10 = lap10helye;
                            elozopozicio11 = lap11helye;
                            elozopozicio12 = lap12helye;
                            elozopozicio13 = lap13helye;
                            elozopozicio14 = lap14helye;
                            elozopozicio15 = lap15helye;
                            elozopozicio16 = lap16helye;
                            elozopozicio17 = lap17helye;
                            elozopozicio18 = lap18helye;
                            elozopozicio19 = lap19helye;
                            elozopozicio20 = lap20helye;
                            elozopozicio21 = lap21helye;
                            elozopozicio22 = lap22helye;
                            elozopozicio23 = lap23helye;
                            elozopozicio24 = lap24helye;
                            elozopozicio25 = lap25helye;

                            kulzorlock.X = aktualiskulzorpozicio.X - lap8helye.X;
                            kulzorlock.Y = aktualiskulzorpozicio.Y - lap8helye.Y;

                            //Kulzorlock legyen = a kulzorlock - kártyahelye

                        }
                        //kicsit feljebb ugye le lockoltuk a kulzort tehát ha ide belép akkor a kiválasztott("Index")
                        //lapnak a pozicióját módosítom és majd g.DrawImage-ben újra írom, de itt már ugye Frissítem szóval nem értem
                        else
                        {
                            lap8helye.X = MousePosition.X - kulzorlock.X;
                            lap8helye.Y = MousePosition.Y - kulzorlock.Y;

                            this.Refresh();
                        }


                    }
                }


            }
            if (!lap9zarolasa && !tartalmaz9)
            {
                //Ha a kiválasztott kártyán "Ideiglenespoz"-on rajta volt a kulzor/rákattintottak
                if (Kartyabanakulzor(lap9helye, Alapkartya))
                {

                    lap1zarolasa = true;
                    lap2zarolasa = true;
                    lap3zarolasa = true;
                    lap4zarolasa = true;
                    lap5zarolasa = true;
                    lap6zarolasa = true;
                    lap7zarolasa = true;
                    lap8zarolasa = true;
                    //lap9zarolasa = true;
                    lap10zarolasa = true;
                    lap11zarolasa = true;
                    lap12zarolasa = true;
                    lap13zarolasa = true;
                    lap14zarolasa = true;
                    lap15zarolasa = true;
                    lap16zarolasa = true;
                    lap17zarolasa = true;
                    lap18zarolasa = true;
                    lap19zarolasa = true;
                    lap20zarolasa = true;
                    lap21zarolasa = true;
                    lap22zarolasa = true;
                    lap23zarolasa = true;
                    lap24zarolasa = true;
                    lap25zarolasa = true;

                    aktualiskulzorpozicio = Control.MousePosition;
                    //és nyomjuk a balgombot
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        //ezeket régen használtam
                        //TavKartyazarolas = true;
                        //OstKartyazarolas = true;
                        //akkor itt egyszer lelockoljuk a kulzort hogy mozgatásnál nem mozduljon el
                        if (kulzorlock.X == -1 && kulzorlock.Y == -1)
                        {
                            //Ezt még nekem is alaposan át kell gondolnom hogy mi is történik itt
                            //Mivel itt akadtam el, de ezt levélben már kifejtettem
                            elozopozicio1 = lap1helye;
                            elozopozicio2 = lap2helye;
                            elozopozicio3 = lap3helye;
                            elozopozicio4 = lap4helye;
                            elozopozicio5 = lap5helye;
                            elozopozicio6 = lap6helye;
                            elozopozicio7 = lap7helye;
                            elozopozicio8 = lap8helye;
                            elozopozicio9 = lap9helye;
                            elozopozicio10 = lap10helye;
                            elozopozicio11 = lap11helye;
                            elozopozicio12 = lap12helye;
                            elozopozicio13 = lap13helye;
                            elozopozicio14 = lap14helye;
                            elozopozicio15 = lap15helye;
                            elozopozicio16 = lap16helye;
                            elozopozicio17 = lap17helye;
                            elozopozicio18 = lap18helye;
                            elozopozicio19 = lap19helye;
                            elozopozicio20 = lap20helye;
                            elozopozicio21 = lap21helye;
                            elozopozicio22 = lap22helye;
                            elozopozicio23 = lap23helye;
                            elozopozicio24 = lap24helye;
                            elozopozicio25 = lap25helye;

                            kulzorlock.X = aktualiskulzorpozicio.X - lap9helye.X;
                            kulzorlock.Y = aktualiskulzorpozicio.Y - lap9helye.Y;

                            //Kulzorlock legyen = a kulzorlock - kártyahelye

                        }
                        //kicsit feljebb ugye le lockoltuk a kulzort tehát ha ide belép akkor a kiválasztott("Index")
                        //lapnak a pozicióját módosítom és majd g.DrawImage-ben újra írom, de itt már ugye Frissítem szóval nem értem
                        else
                        {
                            lap9helye.X = MousePosition.X - kulzorlock.X;
                            lap9helye.Y = MousePosition.Y - kulzorlock.Y;

                            this.Refresh();
                        }


                    }
                }


            }
            if (!lap10zarolasa && !tartalmaz10)
            {
                //Ha a kiválasztott kártyán "Ideiglenespoz"-on rajta volt a kulzor/rákattintottak
                if (Kartyabanakulzor(lap10helye, Alapkartya))
                {

                    lap1zarolasa = true;
                    lap2zarolasa = true;
                    lap3zarolasa = true;
                    lap4zarolasa = true;
                    lap5zarolasa = true;
                    lap6zarolasa = true;
                    lap7zarolasa = true;
                    lap8zarolasa = true;
                    lap9zarolasa = true;
                    //lap10zarolasa = true;
                    lap11zarolasa = true;
                    lap12zarolasa = true;
                    lap13zarolasa = true;
                    lap14zarolasa = true;
                    lap15zarolasa = true;
                    lap16zarolasa = true;
                    lap17zarolasa = true;
                    lap18zarolasa = true;
                    lap19zarolasa = true;
                    lap20zarolasa = true;
                    lap21zarolasa = true;
                    lap22zarolasa = true;
                    lap23zarolasa = true;
                    lap24zarolasa = true;
                    lap25zarolasa = true;

                    aktualiskulzorpozicio = Control.MousePosition;
                    //és nyomjuk a balgombot
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        //ezeket régen használtam
                        //TavKartyazarolas = true;
                        //OstKartyazarolas = true;
                        //akkor itt egyszer lelockoljuk a kulzort hogy mozgatásnál nem mozduljon el
                        if (kulzorlock.X == -1 && kulzorlock.Y == -1)
                        {
                            //Ezt még nekem is alaposan át kell gondolnom hogy mi is történik itt
                            //Mivel itt akadtam el, de ezt levélben már kifejtettem
                            elozopozicio1 = lap1helye;
                            elozopozicio2 = lap2helye;
                            elozopozicio3 = lap3helye;
                            elozopozicio4 = lap4helye;
                            elozopozicio5 = lap5helye;
                            elozopozicio6 = lap6helye;
                            elozopozicio7 = lap7helye;
                            elozopozicio8 = lap8helye;
                            elozopozicio9 = lap9helye;
                            elozopozicio10 = lap10helye;
                            elozopozicio11 = lap11helye;
                            elozopozicio12 = lap12helye;
                            elozopozicio13 = lap13helye;
                            elozopozicio14 = lap14helye;
                            elozopozicio15 = lap15helye;
                            elozopozicio16 = lap16helye;
                            elozopozicio17 = lap17helye;
                            elozopozicio18 = lap18helye;
                            elozopozicio19 = lap19helye;
                            elozopozicio20 = lap20helye;
                            elozopozicio21 = lap21helye;
                            elozopozicio22 = lap22helye;
                            elozopozicio23 = lap23helye;
                            elozopozicio24 = lap24helye;
                            elozopozicio25 = lap25helye;

                            kulzorlock.X = aktualiskulzorpozicio.X - lap10helye.X;
                            kulzorlock.Y = aktualiskulzorpozicio.Y - lap10helye.Y;

                            //Kulzorlock legyen = a kulzorlock - kártyahelye

                        }
                        //kicsit feljebb ugye le lockoltuk a kulzort tehát ha ide belép akkor a kiválasztott("Index")
                        //lapnak a pozicióját módosítom és majd g.DrawImage-ben újra írom, de itt már ugye Frissítem szóval nem értem
                        else
                        {
                            lap10helye.X = MousePosition.X - kulzorlock.X;
                            lap10helye.Y = MousePosition.Y - kulzorlock.Y;

                            this.Refresh();
                        }


                    }
                }


            }
            if (!lap11zarolasa && !tartalmaz11)
            {
                //Ha a kiválasztott kártyán "Ideiglenespoz"-on rajta volt a kulzor/rákattintottak
                if (Kartyabanakulzor(lap11helye, Alapkartya))
                {

                    lap1zarolasa = true;
                    lap2zarolasa = true;
                    lap3zarolasa = true;
                    lap4zarolasa = true;
                    lap5zarolasa = true;
                    lap6zarolasa = true;
                    lap7zarolasa = true;
                    lap8zarolasa = true;
                    lap9zarolasa = true;
                    lap10zarolasa = true;
                    //lap11zarolasa = true;
                    lap12zarolasa = true;
                    lap13zarolasa = true;
                    lap14zarolasa = true;
                    lap15zarolasa = true;
                    lap16zarolasa = true;
                    lap17zarolasa = true;
                    lap18zarolasa = true;
                    lap19zarolasa = true;
                    lap20zarolasa = true;
                    lap21zarolasa = true;
                    lap22zarolasa = true;
                    lap23zarolasa = true;
                    lap24zarolasa = true;
                    lap25zarolasa = true;

                    aktualiskulzorpozicio = Control.MousePosition;
                    //és nyomjuk a balgombot
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        //ezeket régen használtam
                        //TavKartyazarolas = true;
                        //OstKartyazarolas = true;
                        //akkor itt egyszer lelockoljuk a kulzort hogy mozgatásnál nem mozduljon el
                        if (kulzorlock.X == -1 && kulzorlock.Y == -1)
                        {
                            //Ezt még nekem is alaposan át kell gondolnom hogy mi is történik itt
                            //Mivel itt akadtam el, de ezt levélben már kifejtettem
                            elozopozicio1 = lap1helye;
                            elozopozicio2 = lap2helye;
                            elozopozicio3 = lap3helye;
                            elozopozicio4 = lap4helye;
                            elozopozicio5 = lap5helye;
                            elozopozicio6 = lap6helye;
                            elozopozicio7 = lap7helye;
                            elozopozicio8 = lap8helye;
                            elozopozicio9 = lap9helye;
                            elozopozicio10 = lap10helye;
                            elozopozicio11 = lap11helye;
                            elozopozicio12 = lap12helye;
                            elozopozicio13 = lap13helye;
                            elozopozicio14 = lap14helye;
                            elozopozicio15 = lap15helye;
                            elozopozicio16 = lap16helye;
                            elozopozicio17 = lap17helye;
                            elozopozicio18 = lap18helye;
                            elozopozicio19 = lap19helye;
                            elozopozicio20 = lap20helye;
                            elozopozicio21 = lap21helye;
                            elozopozicio22 = lap22helye;
                            elozopozicio23 = lap23helye;
                            elozopozicio24 = lap24helye;
                            elozopozicio25 = lap25helye;

                            kulzorlock.X = aktualiskulzorpozicio.X - lap11helye.X;
                            kulzorlock.Y = aktualiskulzorpozicio.Y - lap11helye.Y;

                            //Kulzorlock legyen = a kulzorlock - kártyahelye

                        }
                        //kicsit feljebb ugye le lockoltuk a kulzort tehát ha ide belép akkor a kiválasztott("Index")
                        //lapnak a pozicióját módosítom és majd g.DrawImage-ben újra írom, de itt már ugye Frissítem szóval nem értem
                        else
                        {
                            lap11helye.X = MousePosition.X - kulzorlock.X;
                            lap11helye.Y = MousePosition.Y - kulzorlock.Y;

                            this.Refresh();
                        }


                    }
                }


            }
            if (!lap12zarolasa && !tartalmaz12)
            {
                //Ha a kiválasztott kártyán "Ideiglenespoz"-on rajta volt a kulzor/rákattintottak
                if (Kartyabanakulzor(lap12helye, Alapkartya))
                {

                    lap1zarolasa = true;
                    lap2zarolasa = true;
                    lap3zarolasa = true;
                    lap4zarolasa = true;
                    lap5zarolasa = true;
                    lap6zarolasa = true;
                    lap7zarolasa = true;
                    lap8zarolasa = true;
                    lap9zarolasa = true;
                    lap10zarolasa = true;
                    lap11zarolasa = true;
                   // lap12zarolasa = true;
                    lap13zarolasa = true;
                    lap14zarolasa = true;
                    lap15zarolasa = true;
                    lap16zarolasa = true;
                    lap17zarolasa = true;
                    lap18zarolasa = true;
                    lap19zarolasa = true;
                    lap20zarolasa = true;
                    lap21zarolasa = true;
                    lap22zarolasa = true;
                    lap23zarolasa = true;
                    lap24zarolasa = true;
                    lap25zarolasa = true;

                    aktualiskulzorpozicio = Control.MousePosition;
                    //és nyomjuk a balgombot
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        //ezeket régen használtam
                        //TavKartyazarolas = true;
                        //OstKartyazarolas = true;
                        //akkor itt egyszer lelockoljuk a kulzort hogy mozgatásnál nem mozduljon el
                        if (kulzorlock.X == -1 && kulzorlock.Y == -1)
                        {
                            //Ezt még nekem is alaposan át kell gondolnom hogy mi is történik itt
                            //Mivel itt akadtam el, de ezt levélben már kifejtettem
                            elozopozicio1 = lap1helye;
                            elozopozicio2 = lap2helye;
                            elozopozicio3 = lap3helye;
                            elozopozicio4 = lap4helye;
                            elozopozicio5 = lap5helye;
                            elozopozicio6 = lap6helye;
                            elozopozicio7 = lap7helye;
                            elozopozicio8 = lap8helye;
                            elozopozicio9 = lap9helye;
                            elozopozicio10 = lap10helye;
                            elozopozicio11 = lap11helye;
                            elozopozicio12 = lap12helye;
                            elozopozicio13 = lap13helye;
                            elozopozicio14 = lap14helye;
                            elozopozicio15 = lap15helye;
                            elozopozicio16 = lap16helye;
                            elozopozicio17 = lap17helye;
                            elozopozicio18 = lap18helye;
                            elozopozicio19 = lap19helye;
                            elozopozicio20 = lap20helye;
                            elozopozicio21 = lap21helye;
                            elozopozicio22 = lap22helye;
                            elozopozicio23 = lap23helye;
                            elozopozicio24 = lap24helye;
                            elozopozicio25 = lap25helye;

                            kulzorlock.X = aktualiskulzorpozicio.X - lap12helye.X;
                            kulzorlock.Y = aktualiskulzorpozicio.Y - lap12helye.Y;

                            //Kulzorlock legyen = a kulzorlock - kártyahelye

                        }
                        //kicsit feljebb ugye le lockoltuk a kulzort tehát ha ide belép akkor a kiválasztott("Index")
                        //lapnak a pozicióját módosítom és majd g.DrawImage-ben újra írom, de itt már ugye Frissítem szóval nem értem
                        else
                        {
                            lap12helye.X = MousePosition.X - kulzorlock.X;
                            lap12helye.Y = MousePosition.Y - kulzorlock.Y;

                            this.Refresh();
                        }


                    }
                }


            }
            if (!lap13zarolasa && !tartalmaz13)
            {
                //Ha a kiválasztott kártyán "Ideiglenespoz"-on rajta volt a kulzor/rákattintottak
                if (Kartyabanakulzor(lap13helye, Alapkartya))
                {

                    lap1zarolasa = true;
                    lap2zarolasa = true;
                    lap3zarolasa = true;
                    lap4zarolasa = true;
                    lap5zarolasa = true;
                    lap6zarolasa = true;
                    lap7zarolasa = true;
                    lap8zarolasa = true;
                    lap9zarolasa = true;
                    lap10zarolasa = true;
                    lap11zarolasa = true;
                    lap12zarolasa = true;
                    //lap13zarolasa = true;
                    lap14zarolasa = true;
                    lap15zarolasa = true;
                    lap16zarolasa = true;
                    lap17zarolasa = true;
                    lap18zarolasa = true;
                    lap19zarolasa = true;
                    lap20zarolasa = true;
                    lap21zarolasa = true;
                    lap22zarolasa = true;
                    lap23zarolasa = true;
                    lap24zarolasa = true;
                    lap25zarolasa = true;

                    aktualiskulzorpozicio = Control.MousePosition;
                    //és nyomjuk a balgombot
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        //ezeket régen használtam
                        //TavKartyazarolas = true;
                        //OstKartyazarolas = true;
                        //akkor itt egyszer lelockoljuk a kulzort hogy mozgatásnál nem mozduljon el
                        if (kulzorlock.X == -1 && kulzorlock.Y == -1)
                        {
                            //Ezt még nekem is alaposan át kell gondolnom hogy mi is történik itt
                            //Mivel itt akadtam el, de ezt levélben már kifejtettem
                            elozopozicio1 = lap1helye;
                            elozopozicio2 = lap2helye;
                            elozopozicio3 = lap3helye;
                            elozopozicio4 = lap4helye;
                            elozopozicio5 = lap5helye;
                            elozopozicio6 = lap6helye;
                            elozopozicio7 = lap7helye;
                            elozopozicio8 = lap8helye;
                            elozopozicio9 = lap9helye;
                            elozopozicio10 = lap10helye;
                            elozopozicio11 = lap11helye;
                            elozopozicio12 = lap12helye;
                            elozopozicio13 = lap13helye;
                            elozopozicio14 = lap14helye;
                            elozopozicio15 = lap15helye;
                            elozopozicio16 = lap16helye;
                            elozopozicio17 = lap17helye;
                            elozopozicio18 = lap18helye;
                            elozopozicio19 = lap19helye;
                            elozopozicio20 = lap20helye;
                            elozopozicio21 = lap21helye;
                            elozopozicio22 = lap22helye;
                            elozopozicio23 = lap23helye;
                            elozopozicio24 = lap24helye;
                            elozopozicio25 = lap25helye;

                            kulzorlock.X = aktualiskulzorpozicio.X - lap13helye.X;
                            kulzorlock.Y = aktualiskulzorpozicio.Y - lap13helye.Y;

                            //Kulzorlock legyen = a kulzorlock - kártyahelye

                        }
                        //kicsit feljebb ugye le lockoltuk a kulzort tehát ha ide belép akkor a kiválasztott("Index")
                        //lapnak a pozicióját módosítom és majd g.DrawImage-ben újra írom, de itt már ugye Frissítem szóval nem értem
                        else
                        {
                            lap13helye.X = MousePosition.X - kulzorlock.X;
                            lap13helye.Y = MousePosition.Y - kulzorlock.Y;

                            this.Refresh();
                        }


                    }
                }


            }
            if (!lap14zarolasa && !tartalmaz14)
            {
                //Ha a kiválasztott kártyán "Ideiglenespoz"-on rajta volt a kulzor/rákattintottak
                if (Kartyabanakulzor(lap14helye, Alapkartya))
                {

                    lap1zarolasa = true;
                    lap2zarolasa = true;
                    lap3zarolasa = true;
                    lap4zarolasa = true;
                    lap5zarolasa = true;
                    lap6zarolasa = true;
                    lap7zarolasa = true;
                    lap8zarolasa = true;
                    lap9zarolasa = true;
                    lap10zarolasa = true;
                    lap11zarolasa = true;
                    lap12zarolasa = true;
                    lap13zarolasa = true;
                    //lap14zarolasa = true;
                    lap15zarolasa = true;
                    lap16zarolasa = true;
                    lap17zarolasa = true;
                    lap18zarolasa = true;
                    lap19zarolasa = true;
                    lap20zarolasa = true;
                    lap21zarolasa = true;
                    lap22zarolasa = true;
                    lap23zarolasa = true;
                    lap24zarolasa = true;
                    lap25zarolasa = true;

                    aktualiskulzorpozicio = Control.MousePosition;
                    //és nyomjuk a balgombot
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        //ezeket régen használtam
                        //TavKartyazarolas = true;
                        //OstKartyazarolas = true;
                        //akkor itt egyszer lelockoljuk a kulzort hogy mozgatásnál nem mozduljon el
                        if (kulzorlock.X == -1 && kulzorlock.Y == -1)
                        {
                            //Ezt még nekem is alaposan át kell gondolnom hogy mi is történik itt
                            //Mivel itt akadtam el, de ezt levélben már kifejtettem
                            elozopozicio1 = lap1helye;
                            elozopozicio2 = lap2helye;
                            elozopozicio3 = lap3helye;
                            elozopozicio4 = lap4helye;
                            elozopozicio5 = lap5helye;
                            elozopozicio6 = lap6helye;
                            elozopozicio7 = lap7helye;
                            elozopozicio8 = lap8helye;
                            elozopozicio9 = lap9helye;
                            elozopozicio10 = lap10helye;
                            elozopozicio11 = lap11helye;
                            elozopozicio12 = lap12helye;
                            elozopozicio13 = lap13helye;
                            elozopozicio14 = lap14helye;
                            elozopozicio15 = lap15helye;
                            elozopozicio16 = lap16helye;
                            elozopozicio17 = lap17helye;
                            elozopozicio18 = lap18helye;
                            elozopozicio19 = lap19helye;
                            elozopozicio20 = lap20helye;
                            elozopozicio21 = lap21helye;
                            elozopozicio22 = lap22helye;
                            elozopozicio23 = lap23helye;
                            elozopozicio24 = lap24helye;
                            elozopozicio25 = lap25helye;

                            kulzorlock.X = aktualiskulzorpozicio.X - lap14helye.X;
                            kulzorlock.Y = aktualiskulzorpozicio.Y - lap14helye.Y;

                            //Kulzorlock legyen = a kulzorlock - kártyahelye

                        }
                        //kicsit feljebb ugye le lockoltuk a kulzort tehát ha ide belép akkor a kiválasztott("Index")
                        //lapnak a pozicióját módosítom és majd g.DrawImage-ben újra írom, de itt már ugye Frissítem szóval nem értem
                        else
                        {
                            lap14helye.X = MousePosition.X - kulzorlock.X;
                            lap14helye.Y = MousePosition.Y - kulzorlock.Y;

                            this.Refresh();
                        }


                    }
                }


            }
            if (!lap15zarolasa && !tartalmaz15)
            {
                //Ha a kiválasztott kártyán "Ideiglenespoz"-on rajta volt a kulzor/rákattintottak
                if (Kartyabanakulzor(lap15helye, Alapkartya))
                {

                    lap1zarolasa = true;
                    lap2zarolasa = true;
                    lap3zarolasa = true;
                    lap4zarolasa = true;
                    lap5zarolasa = true;
                    lap6zarolasa = true;
                    lap7zarolasa = true;
                    lap8zarolasa = true;
                    lap9zarolasa = true;
                    lap10zarolasa = true;
                    lap11zarolasa = true;
                    lap12zarolasa = true;
                    lap13zarolasa = true;
                    lap14zarolasa = true;
                    //lap15zarolasa = true;
                    lap16zarolasa = true;
                    lap17zarolasa = true;
                    lap18zarolasa = true;
                    lap19zarolasa = true;
                    lap20zarolasa = true;
                    lap21zarolasa = true;
                    lap22zarolasa = true;
                    lap23zarolasa = true;
                    lap24zarolasa = true;
                    lap25zarolasa = true;

                    aktualiskulzorpozicio = Control.MousePosition;
                    //és nyomjuk a balgombot
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        //ezeket régen használtam
                        //TavKartyazarolas = true;
                        //OstKartyazarolas = true;
                        //akkor itt egyszer lelockoljuk a kulzort hogy mozgatásnál nem mozduljon el
                        if (kulzorlock.X == -1 && kulzorlock.Y == -1)
                        {
                            //Ezt még nekem is alaposan át kell gondolnom hogy mi is történik itt
                            //Mivel itt akadtam el, de ezt levélben már kifejtettem
                            elozopozicio1 = lap1helye;
                            elozopozicio2 = lap2helye;
                            elozopozicio3 = lap3helye;
                            elozopozicio4 = lap4helye;
                            elozopozicio5 = lap5helye;
                            elozopozicio6 = lap6helye;
                            elozopozicio7 = lap7helye;
                            elozopozicio8 = lap8helye;
                            elozopozicio9 = lap9helye;
                            elozopozicio10 = lap10helye;
                            elozopozicio11 = lap11helye;
                            elozopozicio12 = lap12helye;
                            elozopozicio13 = lap13helye;
                            elozopozicio14 = lap14helye;
                            elozopozicio15 = lap15helye;
                            elozopozicio16 = lap16helye;
                            elozopozicio17 = lap17helye;
                            elozopozicio18 = lap18helye;
                            elozopozicio19 = lap19helye;
                            elozopozicio20 = lap20helye;
                            elozopozicio21 = lap21helye;
                            elozopozicio22 = lap22helye;
                            elozopozicio23 = lap23helye;
                            elozopozicio24 = lap24helye;
                            elozopozicio25 = lap25helye;

                            kulzorlock.X = aktualiskulzorpozicio.X - lap15helye.X;
                            kulzorlock.Y = aktualiskulzorpozicio.Y - lap15helye.Y;

                            //Kulzorlock legyen = a kulzorlock - kártyahelye

                        }
                        //kicsit feljebb ugye le lockoltuk a kulzort tehát ha ide belép akkor a kiválasztott("Index")
                        //lapnak a pozicióját módosítom és majd g.DrawImage-ben újra írom, de itt már ugye Frissítem szóval nem értem
                        else
                        {
                            lap15helye.X = MousePosition.X - kulzorlock.X;
                            lap15helye.Y = MousePosition.Y - kulzorlock.Y;

                            this.Refresh();
                        }


                    }
                }


            }
            if (!lap16zarolasa && !tartalmaz16)
            {
                //Ha a kiválasztott kártyán "Ideiglenespoz"-on rajta volt a kulzor/rákattintottak
                if (Kartyabanakulzor(lap16helye, Alapkartya))
                {

                    lap1zarolasa = true;
                    lap2zarolasa = true;
                    lap3zarolasa = true;
                    lap4zarolasa = true;
                    lap5zarolasa = true;
                    lap6zarolasa = true;
                    lap7zarolasa = true;
                    lap8zarolasa = true;
                    lap9zarolasa = true;
                    lap10zarolasa = true;
                    lap11zarolasa = true;
                    lap12zarolasa = true;
                    lap13zarolasa = true;
                    lap14zarolasa = true;
                    lap15zarolasa = true;
                    //lap16zarolasa = true;
                    lap17zarolasa = true;
                    lap18zarolasa = true;
                    lap19zarolasa = true;
                    lap20zarolasa = true;
                    lap21zarolasa = true;
                    lap22zarolasa = true;
                    lap23zarolasa = true;
                    lap24zarolasa = true;
                    lap25zarolasa = true;

                    aktualiskulzorpozicio = Control.MousePosition;
                    //és nyomjuk a balgombot
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        //ezeket régen használtam
                        //TavKartyazarolas = true;
                        //OstKartyazarolas = true;
                        //akkor itt egyszer lelockoljuk a kulzort hogy mozgatásnál nem mozduljon el
                        if (kulzorlock.X == -1 && kulzorlock.Y == -1)
                        {
                            //Ezt még nekem is alaposan át kell gondolnom hogy mi is történik itt
                            //Mivel itt akadtam el, de ezt levélben már kifejtettem
                            elozopozicio1 = lap1helye;
                            elozopozicio2 = lap2helye;
                            elozopozicio3 = lap3helye;
                            elozopozicio4 = lap4helye;
                            elozopozicio5 = lap5helye;
                            elozopozicio6 = lap6helye;
                            elozopozicio7 = lap7helye;
                            elozopozicio8 = lap8helye;
                            elozopozicio9 = lap9helye;
                            elozopozicio10 = lap10helye;
                            elozopozicio11 = lap11helye;
                            elozopozicio12 = lap12helye;
                            elozopozicio13 = lap13helye;
                            elozopozicio14 = lap14helye;
                            elozopozicio15 = lap15helye;
                            elozopozicio16 = lap16helye;
                            elozopozicio17 = lap17helye;
                            elozopozicio18 = lap18helye;
                            elozopozicio19 = lap19helye;
                            elozopozicio20 = lap20helye;
                            elozopozicio21 = lap21helye;
                            elozopozicio22 = lap22helye;
                            elozopozicio23 = lap23helye;
                            elozopozicio24 = lap24helye;
                            elozopozicio25 = lap25helye;

                            kulzorlock.X = aktualiskulzorpozicio.X - lap16helye.X;
                            kulzorlock.Y = aktualiskulzorpozicio.Y - lap16helye.Y;

                            //Kulzorlock legyen = a kulzorlock - kártyahelye

                        }
                        //kicsit feljebb ugye le lockoltuk a kulzort tehát ha ide belép akkor a kiválasztott("Index")
                        //lapnak a pozicióját módosítom és majd g.DrawImage-ben újra írom, de itt már ugye Frissítem szóval nem értem
                        else
                        {
                            lap16helye.X = MousePosition.X - kulzorlock.X;
                            lap16helye.Y = MousePosition.Y - kulzorlock.Y;

                            this.Refresh();
                        }


                    }
                }


            }
            if (!lap17zarolasa && !tartalmaz17)
            {
                //Ha a kiválasztott kártyán "Ideiglenespoz"-on rajta volt a kulzor/rákattintottak
                if (Kartyabanakulzor(lap17helye, Alapkartya))
                {

                    lap1zarolasa = true;
                    lap2zarolasa = true;
                    lap3zarolasa = true;
                    lap4zarolasa = true;
                    lap5zarolasa = true;
                    lap6zarolasa = true;
                    lap7zarolasa = true;
                    lap8zarolasa = true;
                    lap9zarolasa = true;
                    lap10zarolasa = true;
                    lap11zarolasa = true;
                    lap12zarolasa = true;
                    lap13zarolasa = true;
                    lap14zarolasa = true;
                    lap15zarolasa = true;
                    lap16zarolasa = true;
                    //lap17zarolasa = true;
                    lap18zarolasa = true;
                    lap19zarolasa = true;
                    lap20zarolasa = true;
                    lap21zarolasa = true;
                    lap22zarolasa = true;
                    lap23zarolasa = true;
                    lap24zarolasa = true;
                    lap25zarolasa = true;

                    aktualiskulzorpozicio = Control.MousePosition;
                    //és nyomjuk a balgombot
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        //ezeket régen használtam
                        //TavKartyazarolas = true;
                        //OstKartyazarolas = true;
                        //akkor itt egyszer lelockoljuk a kulzort hogy mozgatásnál nem mozduljon el
                        if (kulzorlock.X == -1 && kulzorlock.Y == -1)
                        {
                            //Ezt még nekem is alaposan át kell gondolnom hogy mi is történik itt
                            //Mivel itt akadtam el, de ezt levélben már kifejtettem
                            elozopozicio1 = lap1helye;
                            elozopozicio2 = lap2helye;
                            elozopozicio3 = lap3helye;
                            elozopozicio4 = lap4helye;
                            elozopozicio5 = lap5helye;
                            elozopozicio6 = lap6helye;
                            elozopozicio7 = lap7helye;
                            elozopozicio8 = lap8helye;
                            elozopozicio9 = lap9helye;
                            elozopozicio10 = lap10helye;
                            elozopozicio11 = lap11helye;
                            elozopozicio12 = lap12helye;
                            elozopozicio13 = lap13helye;
                            elozopozicio14 = lap14helye;
                            elozopozicio15 = lap15helye;
                            elozopozicio16 = lap16helye;
                            elozopozicio17 = lap17helye;
                            elozopozicio18 = lap18helye;
                            elozopozicio19 = lap19helye;
                            elozopozicio20 = lap20helye;
                            elozopozicio21 = lap21helye;
                            elozopozicio22 = lap22helye;
                            elozopozicio23 = lap23helye;
                            elozopozicio24 = lap24helye;
                            elozopozicio25 = lap25helye;

                            kulzorlock.X = aktualiskulzorpozicio.X - lap17helye.X;
                            kulzorlock.Y = aktualiskulzorpozicio.Y - lap17helye.Y;

                            //Kulzorlock legyen = a kulzorlock - kártyahelye

                        }
                        //kicsit feljebb ugye le lockoltuk a kulzort tehát ha ide belép akkor a kiválasztott("Index")
                        //lapnak a pozicióját módosítom és majd g.DrawImage-ben újra írom, de itt már ugye Frissítem szóval nem értem
                        else
                        {
                            lap17helye.X = MousePosition.X - kulzorlock.X;
                            lap17helye.Y = MousePosition.Y - kulzorlock.Y;

                            this.Refresh();
                        }


                    }
                }


            }
            if (!lap18zarolasa && !tartalmaz18)
            {
                //Ha a kiválasztott kártyán "Ideiglenespoz"-on rajta volt a kulzor/rákattintottak
                if (Kartyabanakulzor(lap18helye, Alapkartya))
                {

                    lap1zarolasa = true;
                    lap2zarolasa = true;
                    lap3zarolasa = true;
                    lap4zarolasa = true;
                    lap5zarolasa = true;
                    lap6zarolasa = true;
                    lap7zarolasa = true;
                    lap8zarolasa = true;
                    lap9zarolasa = true;
                    lap10zarolasa = true;
                    lap11zarolasa = true;
                    lap12zarolasa = true;
                    lap13zarolasa = true;
                    lap14zarolasa = true;
                    lap15zarolasa = true;
                    lap16zarolasa = true;
                    lap17zarolasa = true;
                    //lap18zarolasa = true;
                    lap19zarolasa = true;
                    lap20zarolasa = true;
                    lap21zarolasa = true;
                    lap22zarolasa = true;
                    lap23zarolasa = true;
                    lap24zarolasa = true;
                    lap25zarolasa = true;

                    aktualiskulzorpozicio = Control.MousePosition;
                    //és nyomjuk a balgombot
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        //ezeket régen használtam
                        //TavKartyazarolas = true;
                        //OstKartyazarolas = true;
                        //akkor itt egyszer lelockoljuk a kulzort hogy mozgatásnál nem mozduljon el
                        if (kulzorlock.X == -1 && kulzorlock.Y == -1)
                        {
                            //Ezt még nekem is alaposan át kell gondolnom hogy mi is történik itt
                            //Mivel itt akadtam el, de ezt levélben már kifejtettem
                            elozopozicio1 = lap1helye;
                            elozopozicio2 = lap2helye;
                            elozopozicio3 = lap3helye;
                            elozopozicio4 = lap4helye;
                            elozopozicio5 = lap5helye;
                            elozopozicio6 = lap6helye;
                            elozopozicio7 = lap7helye;
                            elozopozicio8 = lap8helye;
                            elozopozicio9 = lap9helye;
                            elozopozicio10 = lap10helye;
                            elozopozicio11 = lap11helye;
                            elozopozicio12 = lap12helye;
                            elozopozicio13 = lap13helye;
                            elozopozicio14 = lap14helye;
                            elozopozicio15 = lap15helye;
                            elozopozicio16 = lap16helye;
                            elozopozicio17 = lap17helye;
                            elozopozicio18 = lap18helye;
                            elozopozicio19 = lap19helye;
                            elozopozicio20 = lap20helye;
                            elozopozicio21 = lap21helye;
                            elozopozicio22 = lap22helye;
                            elozopozicio23 = lap23helye;
                            elozopozicio24 = lap24helye;
                            elozopozicio25 = lap25helye;

                            kulzorlock.X = aktualiskulzorpozicio.X - lap18helye.X;
                            kulzorlock.Y = aktualiskulzorpozicio.Y - lap18helye.Y;

                            //Kulzorlock legyen = a kulzorlock - kártyahelye

                        }
                        //kicsit feljebb ugye le lockoltuk a kulzort tehát ha ide belép akkor a kiválasztott("Index")
                        //lapnak a pozicióját módosítom és majd g.DrawImage-ben újra írom, de itt már ugye Frissítem szóval nem értem
                        else
                        {
                            lap18helye.X = MousePosition.X - kulzorlock.X;
                            lap18helye.Y = MousePosition.Y - kulzorlock.Y;

                            this.Refresh();
                        }


                    }
                }


            }
            if (!lap19zarolasa && !tartalmaz19)
            {
                //Ha a kiválasztott kártyán "Ideiglenespoz"-on rajta volt a kulzor/rákattintottak
                if (Kartyabanakulzor(lap19helye, Alapkartya))
                {

                    lap1zarolasa = true;
                    lap2zarolasa = true;
                    lap3zarolasa = true;
                    lap4zarolasa = true;
                    lap5zarolasa = true;
                    lap6zarolasa = true;
                    lap7zarolasa = true;
                    lap8zarolasa = true;
                    lap9zarolasa = true;
                    lap10zarolasa = true;
                    lap11zarolasa = true;
                    lap12zarolasa = true;
                    lap13zarolasa = true;
                    lap14zarolasa = true;
                    lap15zarolasa = true;
                    lap16zarolasa = true;
                    lap17zarolasa = true;
                    lap18zarolasa = true;
                    //lap19zarolasa = true;
                    lap20zarolasa = true;
                    lap21zarolasa = true;
                    lap22zarolasa = true;
                    lap23zarolasa = true;
                    lap24zarolasa = true;
                    lap25zarolasa = true;

                    aktualiskulzorpozicio = Control.MousePosition;
                    //és nyomjuk a balgombot
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        //ezeket régen használtam
                        //TavKartyazarolas = true;
                        //OstKartyazarolas = true;
                        //akkor itt egyszer lelockoljuk a kulzort hogy mozgatásnál nem mozduljon el
                        if (kulzorlock.X == -1 && kulzorlock.Y == -1)
                        {
                            //Ezt még nekem is alaposan át kell gondolnom hogy mi is történik itt
                            //Mivel itt akadtam el, de ezt levélben már kifejtettem
                            elozopozicio1 = lap1helye;
                            elozopozicio2 = lap2helye;
                            elozopozicio3 = lap3helye;
                            elozopozicio4 = lap4helye;
                            elozopozicio5 = lap5helye;
                            elozopozicio6 = lap6helye;
                            elozopozicio7 = lap7helye;
                            elozopozicio8 = lap8helye;
                            elozopozicio9 = lap9helye;
                            elozopozicio10 = lap10helye;
                            elozopozicio11 = lap11helye;
                            elozopozicio12 = lap12helye;
                            elozopozicio13 = lap13helye;
                            elozopozicio14 = lap14helye;
                            elozopozicio15 = lap15helye;
                            elozopozicio16 = lap16helye;
                            elozopozicio17 = lap17helye;
                            elozopozicio18 = lap18helye;
                            elozopozicio19 = lap19helye;
                            elozopozicio20 = lap20helye;
                            elozopozicio21 = lap21helye;
                            elozopozicio22 = lap22helye;
                            elozopozicio23 = lap23helye;
                            elozopozicio24 = lap24helye;
                            elozopozicio25 = lap25helye;

                            kulzorlock.X = aktualiskulzorpozicio.X - lap19helye.X;
                            kulzorlock.Y = aktualiskulzorpozicio.Y - lap19helye.Y;

                            //Kulzorlock legyen = a kulzorlock - kártyahelye

                        }
                        //kicsit feljebb ugye le lockoltuk a kulzort tehát ha ide belép akkor a kiválasztott("Index")
                        //lapnak a pozicióját módosítom és majd g.DrawImage-ben újra írom, de itt már ugye Frissítem szóval nem értem
                        else
                        {
                            lap19helye.X = MousePosition.X - kulzorlock.X;
                            lap19helye.Y = MousePosition.Y - kulzorlock.Y;

                            this.Refresh();
                        }


                    }
                }


            }
            if (!lap20zarolasa && !tartalmaz20)
            {
                //Ha a kiválasztott kártyán "Ideiglenespoz"-on rajta volt a kulzor/rákattintottak
                if (Kartyabanakulzor(lap20helye, Alapkartya))
                {

                    lap1zarolasa = true;
                    lap2zarolasa = true;
                    lap3zarolasa = true;
                    lap4zarolasa = true;
                    lap5zarolasa = true;
                    lap6zarolasa = true;
                    lap7zarolasa = true;
                    lap8zarolasa = true;
                    lap9zarolasa = true;
                    lap10zarolasa = true;
                    lap11zarolasa = true;
                    lap12zarolasa = true;
                    lap13zarolasa = true;
                    lap14zarolasa = true;
                    lap15zarolasa = true;
                    lap16zarolasa = true;
                    lap17zarolasa = true;
                    lap18zarolasa = true;
                    lap19zarolasa = true;
                    //lap20zarolasa = true;
                    lap21zarolasa = true;
                    lap22zarolasa = true;
                    lap23zarolasa = true;
                    lap24zarolasa = true;
                    lap25zarolasa = true;

                    aktualiskulzorpozicio = Control.MousePosition;
                    //és nyomjuk a balgombot
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        //ezeket régen használtam
                        //TavKartyazarolas = true;
                        //OstKartyazarolas = true;
                        //akkor itt egyszer lelockoljuk a kulzort hogy mozgatásnál nem mozduljon el
                        if (kulzorlock.X == -1 && kulzorlock.Y == -1)
                        {
                            //Ezt még nekem is alaposan át kell gondolnom hogy mi is történik itt
                            //Mivel itt akadtam el, de ezt levélben már kifejtettem
                            elozopozicio1 = lap1helye;
                            elozopozicio2 = lap2helye;
                            elozopozicio3 = lap3helye;
                            elozopozicio4 = lap4helye;
                            elozopozicio5 = lap5helye;
                            elozopozicio6 = lap6helye;
                            elozopozicio7 = lap7helye;
                            elozopozicio8 = lap8helye;
                            elozopozicio9 = lap9helye;
                            elozopozicio10 = lap10helye;
                            elozopozicio11 = lap11helye;
                            elozopozicio12 = lap12helye;
                            elozopozicio13 = lap13helye;
                            elozopozicio14 = lap14helye;
                            elozopozicio15 = lap15helye;
                            elozopozicio16 = lap16helye;
                            elozopozicio17 = lap17helye;
                            elozopozicio18 = lap18helye;
                            elozopozicio19 = lap19helye;
                            elozopozicio20 = lap20helye;
                            elozopozicio21 = lap21helye;
                            elozopozicio22 = lap22helye;
                            elozopozicio23 = lap23helye;
                            elozopozicio24 = lap24helye;
                            elozopozicio25 = lap25helye;

                            kulzorlock.X = aktualiskulzorpozicio.X - lap20helye.X;
                            kulzorlock.Y = aktualiskulzorpozicio.Y - lap20helye.Y;

                            //Kulzorlock legyen = a kulzorlock - kártyahelye

                        }
                        //kicsit feljebb ugye le lockoltuk a kulzort tehát ha ide belép akkor a kiválasztott("Index")
                        //lapnak a pozicióját módosítom és majd g.DrawImage-ben újra írom, de itt már ugye Frissítem szóval nem értem
                        else
                        {
                            lap20helye.X = MousePosition.X - kulzorlock.X;
                            lap20helye.Y = MousePosition.Y - kulzorlock.Y;

                            this.Refresh();
                        }


                    }
                }


            }
            if (!lap21zarolasa && !tartalmaz21)
            {
                //Ha a kiválasztott kártyán "Ideiglenespoz"-on rajta volt a kulzor/rákattintottak
                if (Kartyabanakulzor(lap21helye, Alapkartya))
                {

                    lap1zarolasa = true;
                    lap2zarolasa = true;
                    lap3zarolasa = true;
                    lap4zarolasa = true;
                    lap5zarolasa = true;
                    lap6zarolasa = true;
                    lap7zarolasa = true;
                    lap8zarolasa = true;
                    lap9zarolasa = true;
                    lap10zarolasa = true;
                    lap11zarolasa = true;
                    lap12zarolasa = true;
                    lap13zarolasa = true;
                    lap14zarolasa = true;
                    lap15zarolasa = true;
                    lap16zarolasa = true;
                    lap17zarolasa = true;
                    lap18zarolasa = true;
                    lap19zarolasa = true;
                    lap20zarolasa = true;
                    //lap21zarolasa = true;
                    lap22zarolasa = true;
                    lap23zarolasa = true;
                    lap24zarolasa = true;
                    lap25zarolasa = true;

                    aktualiskulzorpozicio = Control.MousePosition;
                    //és nyomjuk a balgombot
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        //ezeket régen használtam
                        //TavKartyazarolas = true;
                        //OstKartyazarolas = true;
                        //akkor itt egyszer lelockoljuk a kulzort hogy mozgatásnál nem mozduljon el
                        if (kulzorlock.X == -1 && kulzorlock.Y == -1)
                        {
                            //Ezt még nekem is alaposan át kell gondolnom hogy mi is történik itt
                            //Mivel itt akadtam el, de ezt levélben már kifejtettem
                            elozopozicio1 = lap1helye;
                            elozopozicio2 = lap2helye;
                            elozopozicio3 = lap3helye;
                            elozopozicio4 = lap4helye;
                            elozopozicio5 = lap5helye;
                            elozopozicio6 = lap6helye;
                            elozopozicio7 = lap7helye;
                            elozopozicio8 = lap8helye;
                            elozopozicio9 = lap9helye;
                            elozopozicio10 = lap10helye;
                            elozopozicio11 = lap11helye;
                            elozopozicio12 = lap12helye;
                            elozopozicio13 = lap13helye;
                            elozopozicio14 = lap14helye;
                            elozopozicio15 = lap15helye;
                            elozopozicio16 = lap16helye;
                            elozopozicio17 = lap17helye;
                            elozopozicio18 = lap18helye;
                            elozopozicio19 = lap19helye;
                            elozopozicio20 = lap20helye;
                            elozopozicio21 = lap21helye;
                            elozopozicio22 = lap22helye;
                            elozopozicio23 = lap23helye;
                            elozopozicio24 = lap24helye;
                            elozopozicio25 = lap25helye;

                            kulzorlock.X = aktualiskulzorpozicio.X - lap21helye.X;
                            kulzorlock.Y = aktualiskulzorpozicio.Y - lap21helye.Y;

                            //Kulzorlock legyen = a kulzorlock - kártyahelye

                        }
                        //kicsit feljebb ugye le lockoltuk a kulzort tehát ha ide belép akkor a kiválasztott("Index")
                        //lapnak a pozicióját módosítom és majd g.DrawImage-ben újra írom, de itt már ugye Frissítem szóval nem értem
                        else
                        {
                            lap21helye.X = MousePosition.X - kulzorlock.X;
                            lap21helye.Y = MousePosition.Y - kulzorlock.Y;

                            this.Refresh();
                        }


                    }
                }


            }
            if (!lap22zarolasa && !tartalmaz22)
            {
                //Ha a kiválasztott kártyán "Ideiglenespoz"-on rajta volt a kulzor/rákattintottak
                if (Kartyabanakulzor(lap22helye, Alapkartya))
                {

                    lap1zarolasa = true;
                    lap2zarolasa = true;
                    lap3zarolasa = true;
                    lap4zarolasa = true;
                    lap5zarolasa = true;
                    lap6zarolasa = true;
                    lap7zarolasa = true;
                    lap8zarolasa = true;
                    lap9zarolasa = true;
                    lap10zarolasa = true;
                    lap11zarolasa = true;
                    lap12zarolasa = true;
                    lap13zarolasa = true;
                    lap14zarolasa = true;
                    lap15zarolasa = true;
                    lap16zarolasa = true;
                    lap17zarolasa = true;
                    lap18zarolasa = true;
                    lap19zarolasa = true;
                    lap20zarolasa = true;
                    lap21zarolasa = true;
                    //lap22zarolasa = true;
                    lap23zarolasa = true;
                    lap24zarolasa = true;
                    lap25zarolasa = true;

                    aktualiskulzorpozicio = Control.MousePosition;
                    //és nyomjuk a balgombot
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        //ezeket régen használtam
                        //TavKartyazarolas = true;
                        //OstKartyazarolas = true;
                        //akkor itt egyszer lelockoljuk a kulzort hogy mozgatásnál nem mozduljon el
                        if (kulzorlock.X == -1 && kulzorlock.Y == -1)
                        {
                            //Ezt még nekem is alaposan át kell gondolnom hogy mi is történik itt
                            //Mivel itt akadtam el, de ezt levélben már kifejtettem
                            elozopozicio1 = lap1helye;
                            elozopozicio2 = lap2helye;
                            elozopozicio3 = lap3helye;
                            elozopozicio4 = lap4helye;
                            elozopozicio5 = lap5helye;
                            elozopozicio6 = lap6helye;
                            elozopozicio7 = lap7helye;
                            elozopozicio8 = lap8helye;
                            elozopozicio9 = lap9helye;
                            elozopozicio10 = lap10helye;
                            elozopozicio11 = lap11helye;
                            elozopozicio12 = lap12helye;
                            elozopozicio13 = lap13helye;
                            elozopozicio14 = lap14helye;
                            elozopozicio15 = lap15helye;
                            elozopozicio16 = lap16helye;
                            elozopozicio17 = lap17helye;
                            elozopozicio18 = lap18helye;
                            elozopozicio19 = lap19helye;
                            elozopozicio20 = lap20helye;
                            elozopozicio21 = lap21helye;
                            elozopozicio22 = lap22helye;
                            elozopozicio23 = lap23helye;
                            elozopozicio24 = lap24helye;
                            elozopozicio25 = lap25helye;

                            kulzorlock.X = aktualiskulzorpozicio.X - lap22helye.X;
                            kulzorlock.Y = aktualiskulzorpozicio.Y - lap22helye.Y;

                            //Kulzorlock legyen = a kulzorlock - kártyahelye

                        }
                        //kicsit feljebb ugye le lockoltuk a kulzort tehát ha ide belép akkor a kiválasztott("Index")
                        //lapnak a pozicióját módosítom és majd g.DrawImage-ben újra írom, de itt már ugye Frissítem szóval nem értem
                        else
                        {
                            lap22helye.X = MousePosition.X - kulzorlock.X;
                            lap22helye.Y = MousePosition.Y - kulzorlock.Y;

                            this.Refresh();
                        }


                    }
                }


            }
            if (!lap23zarolasa && !tartalmaz23)
            {
                //Ha a kiválasztott kártyán "Ideiglenespoz"-on rajta volt a kulzor/rákattintottak
                if (Kartyabanakulzor(lap23helye, Alapkartya))
                {

                    lap1zarolasa = true;
                    lap2zarolasa = true;
                    lap3zarolasa = true;
                    lap4zarolasa = true;
                    lap5zarolasa = true;
                    lap6zarolasa = true;
                    lap7zarolasa = true;
                    lap8zarolasa = true;
                    lap9zarolasa = true;
                    lap10zarolasa = true;
                    lap11zarolasa = true;
                    lap12zarolasa = true;
                    lap13zarolasa = true;
                    lap14zarolasa = true;
                    lap15zarolasa = true;
                    lap16zarolasa = true;
                    lap17zarolasa = true;
                    lap18zarolasa = true;
                    lap19zarolasa = true;
                    lap20zarolasa = true;
                    lap21zarolasa = true;
                    lap22zarolasa = true;
                    //lap23zarolasa = true;
                    lap24zarolasa = true;
                    lap25zarolasa = true;

                    aktualiskulzorpozicio = Control.MousePosition;
                    //és nyomjuk a balgombot
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        //ezeket régen használtam
                        //TavKartyazarolas = true;
                        //OstKartyazarolas = true;
                        //akkor itt egyszer lelockoljuk a kulzort hogy mozgatásnál nem mozduljon el
                        if (kulzorlock.X == -1 && kulzorlock.Y == -1)
                        {
                            //Ezt még nekem is alaposan át kell gondolnom hogy mi is történik itt
                            //Mivel itt akadtam el, de ezt levélben már kifejtettem
                            elozopozicio1 = lap1helye;
                            elozopozicio2 = lap2helye;
                            elozopozicio3 = lap3helye;
                            elozopozicio4 = lap4helye;
                            elozopozicio5 = lap5helye;
                            elozopozicio6 = lap6helye;
                            elozopozicio7 = lap7helye;
                            elozopozicio8 = lap8helye;
                            elozopozicio9 = lap9helye;
                            elozopozicio10 = lap10helye;
                            elozopozicio11 = lap11helye;
                            elozopozicio12 = lap12helye;
                            elozopozicio13 = lap13helye;
                            elozopozicio14 = lap14helye;
                            elozopozicio15 = lap15helye;
                            elozopozicio16 = lap16helye;
                            elozopozicio17 = lap17helye;
                            elozopozicio18 = lap18helye;
                            elozopozicio19 = lap19helye;
                            elozopozicio20 = lap20helye;
                            elozopozicio21 = lap21helye;
                            elozopozicio22 = lap22helye;
                            elozopozicio23 = lap23helye;
                            elozopozicio24 = lap24helye;
                            elozopozicio25 = lap25helye;

                            kulzorlock.X = aktualiskulzorpozicio.X - lap23helye.X;
                            kulzorlock.Y = aktualiskulzorpozicio.Y - lap23helye.Y;

                            //Kulzorlock legyen = a kulzorlock - kártyahelye

                        }
                        //kicsit feljebb ugye le lockoltuk a kulzort tehát ha ide belép akkor a kiválasztott("Index")
                        //lapnak a pozicióját módosítom és majd g.DrawImage-ben újra írom, de itt már ugye Frissítem szóval nem értem
                        else
                        {
                            lap23helye.X = MousePosition.X - kulzorlock.X;
                            lap23helye.Y = MousePosition.Y - kulzorlock.Y;

                            this.Refresh();
                        }


                    }
                }


            }
            if (!lap24zarolasa && !tartalmaz24)
            {
                //Ha a kiválasztott kártyán "Ideiglenespoz"-on rajta volt a kulzor/rákattintottak
                if (Kartyabanakulzor(lap24helye, Alapkartya))
                {

                    lap1zarolasa = true;
                    lap2zarolasa = true;
                    lap3zarolasa = true;
                    lap4zarolasa = true;
                    lap5zarolasa = true;
                    lap6zarolasa = true;
                    lap7zarolasa = true;
                    lap8zarolasa = true;
                    lap9zarolasa = true;
                    lap10zarolasa = true;
                    lap11zarolasa = true;
                    lap12zarolasa = true;
                    lap13zarolasa = true;
                    lap14zarolasa = true;
                    lap15zarolasa = true;
                    lap16zarolasa = true;
                    lap17zarolasa = true;
                    lap18zarolasa = true;
                    lap19zarolasa = true;
                    lap20zarolasa = true;
                    lap21zarolasa = true;
                    lap22zarolasa = true;
                    lap23zarolasa = true;
                    //lap24zarolasa = true;
                    lap25zarolasa = true;

                    aktualiskulzorpozicio = Control.MousePosition;
                    //és nyomjuk a balgombot
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        //ezeket régen használtam
                        //TavKartyazarolas = true;
                        //OstKartyazarolas = true;
                        //akkor itt egyszer lelockoljuk a kulzort hogy mozgatásnál nem mozduljon el
                        if (kulzorlock.X == -1 && kulzorlock.Y == -1)
                        {
                            //Ezt még nekem is alaposan át kell gondolnom hogy mi is történik itt
                            //Mivel itt akadtam el, de ezt levélben már kifejtettem
                            elozopozicio1 = lap1helye;
                            elozopozicio2 = lap2helye;
                            elozopozicio3 = lap3helye;
                            elozopozicio4 = lap4helye;
                            elozopozicio5 = lap5helye;
                            elozopozicio6 = lap6helye;
                            elozopozicio7 = lap7helye;
                            elozopozicio8 = lap8helye;
                            elozopozicio9 = lap9helye;
                            elozopozicio10 = lap10helye;
                            elozopozicio11 = lap11helye;
                            elozopozicio12 = lap12helye;
                            elozopozicio13 = lap13helye;
                            elozopozicio14 = lap14helye;
                            elozopozicio15 = lap15helye;
                            elozopozicio16 = lap16helye;
                            elozopozicio17 = lap17helye;
                            elozopozicio18 = lap18helye;
                            elozopozicio19 = lap19helye;
                            elozopozicio20 = lap20helye;
                            elozopozicio21 = lap21helye;
                            elozopozicio22 = lap22helye;
                            elozopozicio23 = lap23helye;
                            elozopozicio24 = lap24helye;
                            elozopozicio25 = lap25helye;

                            kulzorlock.X = aktualiskulzorpozicio.X - lap24helye.X;
                            kulzorlock.Y = aktualiskulzorpozicio.Y - lap24helye.Y;

                            //Kulzorlock legyen = a kulzorlock - kártyahelye

                        }
                        //kicsit feljebb ugye le lockoltuk a kulzort tehát ha ide belép akkor a kiválasztott("Index")
                        //lapnak a pozicióját módosítom és majd g.DrawImage-ben újra írom, de itt már ugye Frissítem szóval nem értem
                        else
                        {
                            lap24helye.X = MousePosition.X - kulzorlock.X;
                            lap24helye.Y = MousePosition.Y - kulzorlock.Y;

                            this.Refresh();
                        }


                    }
                }


            }
            if (!lap25zarolasa && !tartalmaz25)
            {
                //Ha a kiválasztott kártyán "Ideiglenespoz"-on rajta volt a kulzor/rákattintottak
                if (Kartyabanakulzor(lap25helye, Alapkartya))
                {

                    lap1zarolasa = true;
                    lap2zarolasa = true;
                    lap3zarolasa = true;
                    lap4zarolasa = true;
                    lap5zarolasa = true;
                    lap6zarolasa = true;
                    lap7zarolasa = true;
                    lap8zarolasa = true;
                    lap9zarolasa = true;
                    lap10zarolasa = true;
                    lap11zarolasa = true;
                    lap12zarolasa = true;
                    lap13zarolasa = true;
                    lap14zarolasa = true;
                    lap15zarolasa = true;
                    lap16zarolasa = true;
                    lap17zarolasa = true;
                    lap18zarolasa = true;
                    lap19zarolasa = true;
                    lap20zarolasa = true;
                    lap21zarolasa = true;
                    lap22zarolasa = true;
                    lap23zarolasa = true;
                    lap24zarolasa = true;
                    //lap25zarolasa = true;

                    aktualiskulzorpozicio = Control.MousePosition;
                    //és nyomjuk a balgombot
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        //ezeket régen használtam
                        //TavKartyazarolas = true;
                        //OstKartyazarolas = true;
                        //akkor itt egyszer lelockoljuk a kulzort hogy mozgatásnál nem mozduljon el
                        if (kulzorlock.X == -1 && kulzorlock.Y == -1)
                        {
                            //Ezt még nekem is alaposan át kell gondolnom hogy mi is történik itt
                            //Mivel itt akadtam el, de ezt levélben már kifejtettem
                            elozopozicio1 = lap1helye;
                            elozopozicio2 = lap2helye;
                            elozopozicio3 = lap3helye;
                            elozopozicio4 = lap4helye;
                            elozopozicio5 = lap5helye;
                            elozopozicio6 = lap6helye;
                            elozopozicio7 = lap7helye;
                            elozopozicio8 = lap8helye;
                            elozopozicio9 = lap9helye;
                            elozopozicio10 = lap10helye;
                            elozopozicio11 = lap11helye;
                            elozopozicio12 = lap12helye;
                            elozopozicio13 = lap13helye;
                            elozopozicio14 = lap14helye;
                            elozopozicio15 = lap15helye;
                            elozopozicio16 = lap16helye;
                            elozopozicio17 = lap17helye;
                            elozopozicio18 = lap18helye;
                            elozopozicio19 = lap19helye;
                            elozopozicio20 = lap20helye;
                            elozopozicio21 = lap21helye;
                            elozopozicio22 = lap22helye;
                            elozopozicio23 = lap23helye;
                            elozopozicio24 = lap24helye;
                            elozopozicio25 = lap25helye;

                            kulzorlock.X = aktualiskulzorpozicio.X - lap25helye.X;
                            kulzorlock.Y = aktualiskulzorpozicio.Y - lap25helye.Y;

                            //Kulzorlock legyen = a kulzorlock - kártyahelye

                        }
                        //kicsit feljebb ugye le lockoltuk a kulzort tehát ha ide belép akkor a kiválasztott("Index")
                        //lapnak a pozicióját módosítom és majd g.DrawImage-ben újra írom, de itt már ugye Frissítem szóval nem értem
                        else
                        {
                            lap25helye.X = MousePosition.X - kulzorlock.X;
                            lap25helye.Y = MousePosition.Y - kulzorlock.Y;

                            this.Refresh();
                        }


                    }
                }


            }


            #region Regikod

            //Úgy régi hogy elején 3 kártáyval játszottam 
            //A 3 kategoriával
            //Azokat tudtam mozgatni és a mezőbe belehelyezni
            //Akkor ezt a kódot használtam de jobban átgondolva ez már nem fog kelleni
            //Mivel ha kiválasztok egy kártyát amit majd ugy is megfogok és szeretném mozgatni
            //nem fog kelleni a Távolsági és Ostrom kártyák (kategorák) lelockolása majd az összes kártyát le kell zárni

            /*
            if (!TavKartyazarolas)
            {
                //Távolsági kártyák mozgatása
                if (Kartyabanakulzor(Tavolsagikartyahelye, TavolsagiKartya))
                {
                    KozKartyazarolas = true;
                    OstKartyazarolas = true;

                    if (kulzorlock.X == -1 && kulzorlock.Y == -1)
                    {
                        elozopozicio = Tavolsagikartyahelye;
                        kulzorlock.X = Control.MousePosition.X - Tavolsagikartyahelye.X;
                        kulzorlock.Y = Control.MousePosition.Y - Tavolsagikartyahelye.Y;
                        //Kulzorlock legyen = a kulzorlock - kártyahelye

                    }
                    else
                    {
                        Tavolsagikartyahelye.X = MousePosition.X - kulzorlock.X;
                        Tavolsagikartyahelye.Y = MousePosition.Y - kulzorlock.Y;
                        this.Refresh();
                    }
                }
            }

            if (!OstKartyazarolas)
            {
                //Ostrom kártyák mozgatása
                if (Kartyabanakulzor(Ostromkartyahelye, OstromKartya))
                {
                    KozKartyazarolas = true;
                    TavKartyazarolas = true;

                    if (kulzorlock.X == -1 && kulzorlock.Y == -1)
                    {

                        elozopozicio = Ostromkartyahelye;
                        kulzorlock.X = Control.MousePosition.X - Ostromkartyahelye.X;
                        kulzorlock.Y = Control.MousePosition.Y - Ostromkartyahelye.Y;
                        //Kulzorlock legyen = a kulzorlock - kártyahelye

                    }

                    else
                    {
                        Ostromkartyahelye.X = MousePosition.X - kulzorlock.X;
                        Ostromkartyahelye.Y = MousePosition.Y - kulzorlock.Y;
                        this.Refresh();
                    }

                }
            }
            */
            #endregion
        }

        //Egér felengedés
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            
            lap1zarolasa = false;
            lap2zarolasa = false;
            lap3zarolasa = false;
            lap4zarolasa = false;
            lap5zarolasa = false;
            lap6zarolasa = false;
            lap7zarolasa = false;
            lap8zarolasa = false;
            lap9zarolasa = false;
            lap10zarolasa = false;
            lap11zarolasa = false;
            lap12zarolasa = false;
            lap13zarolasa = false;
            lap14zarolasa = false;
            lap15zarolasa = false;
            lap16zarolasa = false;
            lap17zarolasa = false;
            lap18zarolasa = false;
            lap19zarolasa = false;
            lap20zarolasa = false;
            lap21zarolasa = false;
            lap22zarolasa = false;
            lap23zarolasa = false;
            lap24zarolasa = false;
            lap25zarolasa = false;
            
            //Ez ugye azt csinálja ,hogy ha a kártya a mező Bitmapját éritem az arra megfelelő lappal itt a Közelharcos kategóriáju
            //lappal akkor lehelyezi oda és nem engedi kivenni többet
            //Közelharcos

            //lap1
            if (Kartya_a_mezobe_van_helyezve(lap1helye, Kozelharcosmezohelye, KozelharcosMezo, lap1zarolasa, Alapkartya))
            {
                byte egy = 1;
                if (!Kozmezoben.Contains(egy))
                {
                    //Manuálisan megadom melyik pozicióba legyen lezárva a kártyalap
                    lap1helye.X = Kozelharcosmezohelye.X + (Kmezolepteto * 90);
                    lap1helye.Y = Kozelharcosmezohelye.Y + 2;
                    this.Refresh();
                    lap1zarolasa = true;
                    Kozmezoben.Add(egy);
                    Kmezolepteto++;
                    egyszer1 = true;
                    Kartyakpalyan.Add(1);
                }
                
            }
            else
            {
                lap1helye = elozopozicio1;
                // lap2helye.X = KezdoKartyakhelye.X;
                // lap2helye.Y = KezdoKartyakhelye.Y;
                this.Refresh();
            }
           // elozopozicio1 = new Point(-1, -1);
            kulzorlock.X = -1;
            kulzorlock.Y = -1;
        
            //lap2
            if (Kartya_a_mezobe_van_helyezve(lap2helye, Kozelharcosmezohelye, KozelharcosMezo, lap2zarolasa, Alapkartya))
            {
                byte k = 2;
                if (!Kozmezoben.Contains(k))
                {
                    
                    //Manuálisan megadom melyik pozicióba legyen lezárva a kártyalap
                    lap2helye.X = Kozelharcosmezohelye.X + (Kmezolepteto * 90);
                    lap2helye.Y = Kozelharcosmezohelye.Y + 2;
                    this.Refresh();
                    lap2zarolasa = true;
                    Kozmezoben.Add(k);
                    Kmezolepteto++;
                    egyszer1 = true;
                    Kartyakpalyan.Add(2);
                    Ellenfelkore = true;
                }
            }
            else
            {
                lap2helye = elozopozicio2;
               // lap2helye.X = KezdoKartyakhelye.X;
               // lap2helye.Y = KezdoKartyakhelye.Y;
                this.Refresh();
            }
            
            kulzorlock.X = -1;
            kulzorlock.Y = -1;
        
            //lap3
            if (Kartya_a_mezobe_van_helyezve(lap3helye, Kozelharcosmezohelye, KozelharcosMezo, lap3zarolasa, Alapkartya))
            {
                byte h = 3;
                if (!Kozmezoben.Contains(h))
                {
                    //Manuálisan megadom melyik pozicióba legyen lezárva a kártyalap
                    lap3helye.X = Kozelharcosmezohelye.X + (Kmezolepteto * 90);
                    lap3helye.Y = Kozelharcosmezohelye.Y + 2;
                    this.Refresh();
                    lap3zarolasa = true;
                    Kozmezoben.Add(h);
                    Kmezolepteto++;
                    egyszer1 = true;
                    Kartyakpalyan.Add(3);
                }
            }
            else
            {
                lap3helye = elozopozicio3;
               // lap2helye.X = KezdoKartyakhelye.X;
               // lap2helye.Y = KezdoKartyakhelye.Y;
                this.Refresh();
            }

            kulzorlock.X = -1;
            kulzorlock.Y = -1;
        
            //lap4
            if (Kartya_a_mezobe_van_helyezve(lap4helye, Kozelharcosmezohelye, KozelharcosMezo, lap4zarolasa, Alapkartya))
            {
                byte negy = 4;
                if (!Kozmezoben.Contains(negy))
                {
                    //Manuálisan megadom melyik pozicióba legyen lezárva a kártyalap
                    lap4helye.X = Kozelharcosmezohelye.X + (Kmezolepteto * 90);
                    lap4helye.Y = Kozelharcosmezohelye.Y + 2;
                    this.Refresh();
                    lap4zarolasa = true;
                    Kozmezoben.Add(negy);
                    Kmezolepteto++;
                    egyszer1 = true;
                    Kartyakpalyan.Add(4);
                }
                
            }
            else
            {
                lap4helye = elozopozicio4;
               // lap2helye.X = KezdoKartyakhelye.X;
               // lap2helye.Y = KezdoKartyakhelye.Y;
                this.Refresh();
            }

            kulzorlock.X = -1;
            kulzorlock.Y = -1;
        
            //lap5
            if (Kartya_a_mezobe_van_helyezve(lap5helye, Tavolsagimezohelye, TavolsagiMezo, lap5zarolasa, Alapkartya))
            {
                byte ot = 5;
                if (!Tavmezoben.Contains(ot))
                {
                    //Manuálisan megadom melyik pozicióba legyen lezárva a kártyalap
                    lap5helye.X = Tavolsagimezohelye.X + (Tmezolepteto * 90);
                    lap5helye.Y = Tavolsagimezohelye.Y + 2;
                    this.Refresh();
                    lap5zarolasa = true;
                    Tavmezoben.Add(ot);
                    Tmezolepteto++;
                    egyszer2 = true;
                    Kartyakpalyan.Add(5);
                }
            }
            else
            {
                lap5helye = elozopozicio5;
               // lap2helye.X = KezdoKartyakhelye.X;
               // lap2helye.Y = KezdoKartyakhelye.Y;
                this.Refresh();
            }

            kulzorlock.X = -1;
            kulzorlock.Y = -1;
        
            //lap6
            if (Kartya_a_mezobe_van_helyezve(lap6helye, Tavolsagimezohelye, TavolsagiMezo, lap6zarolasa, Alapkartya))
            {
                byte hat = 6;
                if (!Tavmezoben.Contains(hat))
                {
                    //Manuálisan megadom melyik pozicióba legyen lezárva a kártyalap
                    lap6helye.X = Tavolsagimezohelye.X + (Tmezolepteto * 90);
                    lap6helye.Y = Tavolsagimezohelye.Y + 2;
                    this.Refresh();
                    lap6zarolasa = true;
                    Tavmezoben.Add(hat);
                    Tmezolepteto++;
                    egyszer2 = true;
                    Kartyakpalyan.Add(6);
                }
            }
            else
            {
                lap6helye = elozopozicio6;
               // lap2helye.X = KezdoKartyakhelye.X;
               // lap2helye.Y = KezdoKartyakhelye.Y;
                this.Refresh();
            }

            kulzorlock.X = -1;
            kulzorlock.Y = -1;
        
            //lap7
            if (Kartya_a_mezobe_van_helyezve(lap7helye, Tavolsagimezohelye, TavolsagiMezo, lap7zarolasa, Alapkartya))
            {
                byte het = 7;
                if (!Tavmezoben.Contains(het))
                {
                    //Manuálisan megadom melyik pozicióba legyen lezárva a kártyalap
                    lap7helye.X = Tavolsagimezohelye.X + (Tmezolepteto*90);
                    lap7helye.Y = Tavolsagimezohelye.Y + 2;
                    this.Refresh();
                    lap7zarolasa = true;
                    Tavmezoben.Add(het);
                    Tmezolepteto++;
                    egyszer2 = true;
                    Kartyakpalyan.Add(7);
                }
            }
            else
            {
                lap7helye = elozopozicio7;
               // lap2helye.X = KezdoKartyakhelye.X;
               // lap2helye.Y = KezdoKartyakhelye.Y;
                this.Refresh();
            }

            kulzorlock.X = -1;
            kulzorlock.Y = -1;
        
            //lap8
            if (Kartya_a_mezobe_van_helyezve(lap8helye, Kozelharcosmezohelye, KozelharcosMezo, lap8zarolasa, Alapkartya))
            {
                byte nyolc = 8;
                if (!Kozmezoben.Contains(nyolc))
                {
                    //Manuálisan megadom melyik pozicióba legyen lezárva a kártyalap
                    lap8helye.X = Kozelharcosmezohelye.X + (Kmezolepteto * 90);
                    lap8helye.Y = Kozelharcosmezohelye.Y + 2;
                    this.Refresh();
                    lap8zarolasa = true;
                    Kozmezoben.Add(nyolc);
                    Kmezolepteto++;
                    egyszer1 = true;
                    Kartyakpalyan.Add(8);
                }
            }
            else
            {
                lap8helye = elozopozicio8;
               // lap2helye.X = KezdoKartyakhelye.X;
               // lap2helye.Y = KezdoKartyakhelye.Y;
                this.Refresh();
            }

            kulzorlock.X = -1;
            kulzorlock.Y = -1;
        
            //lap9
            if (Kartya_a_mezobe_van_helyezve(lap9helye, Kozelharcosmezohelye, KozelharcosMezo, lap9zarolasa, Alapkartya))
            {
                byte ki = 9;
                if (!Kozmezoben.Contains(ki))
                {
                    //Manuálisan megadom melyik pozicióba legyen lezárva a kártyalap
                    lap9helye.X = Kozelharcosmezohelye.X + (Kmezolepteto * 90);
                    lap9helye.Y = Kozelharcosmezohelye.Y + 2;
                    this.Refresh();
                    lap9zarolasa = true;
                    Kozmezoben.Add(ki);
                    Kmezolepteto++;
                    egyszer1 = true;
                    Kartyakpalyan.Add(9);
                }
            }
            else
            {
                lap9helye = elozopozicio9;
               // lap2helye.X = KezdoKartyakhelye.X;
               // lap2helye.Y = KezdoKartyakhelye.Y;
                this.Refresh();
            }

            kulzorlock.X = -1;
            kulzorlock.Y = -1;
        
            //lap10
            if (Kartya_a_mezobe_van_helyezve(lap10helye, Kozelharcosmezohelye, KozelharcosMezo, lap10zarolasa, Alapkartya))
            {
                byte tiz = 10;
                if (!Kozmezoben.Contains(tiz))
                {
                    //Manuálisan megadom melyik pozicióba legyen lezárva a kártyalap
                    lap10helye.X = Kozelharcosmezohelye.X + (Kmezolepteto * 90);
                    lap10helye.Y = Kozelharcosmezohelye.Y + 2;
                    this.Refresh();
                    lap10zarolasa = true;
                    Kozmezoben.Add(tiz);
                    Kmezolepteto++;
                    egyszer1 = true;
                    Kartyakpalyan.Add(10);
                }
            }
            else
            {
                lap10helye = elozopozicio10;
               // lap2helye.X = KezdoKartyakhelye.X;
               // lap2helye.Y = KezdoKartyakhelye.Y;
                this.Refresh();
            }

            kulzorlock.X = -1;
            kulzorlock.Y = -1;
        
            //lap11
            if (Kartya_a_mezobe_van_helyezve(lap11helye, Kozelharcosmezohelye, KozelharcosMezo, lap11zarolasa, Alapkartya))
            {
                byte tegy = 11;
                if (!Kozmezoben.Contains(tegy))
                {
                    //Manuálisan megadom melyik pozicióba legyen lezárva a kártyalap
                    lap11helye.X = Kozelharcosmezohelye.X + (Kmezolepteto * 90);
                    lap11helye.Y = Kozelharcosmezohelye.Y + 2;
                    this.Refresh();
                    lap11zarolasa = true;
                    Kozmezoben.Add(tegy);
                    Kmezolepteto++;
                    egyszer1 = true;
                    Kartyakpalyan.Add(11);
                }
            }
            else
            {
                lap11helye = elozopozicio11;
               // lap2helye.X = KezdoKartyakhelye.X;
               // lap2helye.Y = KezdoKartyakhelye.Y;
                this.Refresh();
            }

            kulzorlock.X = -1;
            kulzorlock.Y = -1;
        
            //lap12
            if (Kartya_a_mezobe_van_helyezve(lap12helye, Kozelharcosmezohelye, KozelharcosMezo, lap12zarolasa, Alapkartya))
            {
                byte tizenk = 12;
                if (!Kozmezoben.Contains(tizenk))
                {
                    //Manuálisan megadom melyik pozicióba legyen lezárva a kártyalap
                    lap12helye.X = Kozelharcosmezohelye.X + (Kmezolepteto * 90);
                    lap12helye.Y = Kozelharcosmezohelye.Y + 2;
                    this.Refresh();
                    lap12zarolasa = true;
                    //EllenségKozmezobe majd
                    Kozmezoben.Add(tizenk);
                    Kmezolepteto++;
                    egyszer1 = true;
                    Kartyakpalyan.Add(12);
                }
            }
            else
            {
                lap12helye = elozopozicio12;
               // lap2helye.X = KezdoKartyakhelye.X;
               // lap2helye.Y = KezdoKartyakhelye.Y;
                this.Refresh();
            }

            kulzorlock.X = -1;
            kulzorlock.Y = -1;
        
            //lap13
            if (Kartya_a_mezobe_van_helyezve(lap13helye, Tavolsagimezohelye, TavolsagiMezo, lap13zarolasa, Alapkartya))
            {
                byte th = 13;
                if (!Tavmezoben.Contains(th))
                {
                    //Manuálisan megadom melyik pozicióba legyen lezárva a kártyalap
                    lap13helye.X = Tavolsagimezohelye.X + (Tmezolepteto * 90);
                    lap13helye.Y = Tavolsagimezohelye.Y + 2;
                    this.Refresh();
                    lap13zarolasa = true;
                    Tavmezoben.Add(th);
                    Tmezolepteto++;
                    egyszer2 = true;
                    Kartyakpalyan.Add(13);
                }
            }
            else
            {
                lap13helye = elozopozicio13;
               // lap2helye.X = KezdoKartyakhelye.X;
               // lap2helye.Y = KezdoKartyakhelye.Y;
                this.Refresh();
            }

            kulzorlock.X = -1;
            kulzorlock.Y = -1;
        
            //lap14
            if (Kartya_a_mezobe_van_helyezve(lap14helye, Tavolsagimezohelye, TavolsagiMezo, lap14zarolasa, Alapkartya))
            {
                byte tnegy = 14;
                if (!Tavmezoben.Contains(tnegy))
                {
                    //Manuálisan megadom melyik pozicióba legyen lezárva a kártyalap
                    lap14helye.X = Tavolsagimezohelye.X + (Tmezolepteto * 90);
                    lap14helye.Y = Tavolsagimezohelye.Y + 2;
                    this.Refresh();
                    lap14zarolasa = true;
                    Tavmezoben.Add(tnegy);
                    Tmezolepteto++;
                    egyszer2 = true;
                    Kartyakpalyan.Add(14);
                }
            }
            else
            {
                lap14helye = elozopozicio14;
               // lap2helye.X = KezdoKartyakhelye.X;
               // lap2helye.Y = KezdoKartyakhelye.Y;
                this.Refresh();
            }

            kulzorlock.X = -1;
            kulzorlock.Y = -1;
        
            //lap15
            if (Kartya_a_mezobe_van_helyezve(lap15helye, Tavolsagimezohelye, TavolsagiMezo, lap15zarolasa, Alapkartya))
            {
                byte to = 15;
                if (!Tavmezoben.Contains(to))
                {
                    //Manuálisan megadom melyik pozicióba legyen lezárva a kártyalap
                    lap15helye.X = Tavolsagimezohelye.X + (Tmezolepteto * 90);
                    lap15helye.Y = Tavolsagimezohelye.Y + 2;
                    this.Refresh();
                    lap15zarolasa = true;
                    Tavmezoben.Add(to);
                    Tmezolepteto++;
                    egyszer2 = true;
                    Kartyakpalyan.Add(15);
                }

            }
            else
            {
                lap15helye = elozopozicio15;
               // lap2helye.X = KezdoKartyakhelye.X;
               // lap2helye.Y = KezdoKartyakhelye.Y;
                this.Refresh();
            }

            kulzorlock.X = -1;
            kulzorlock.Y = -1;
        
            //lap16
            if (Kartya_a_mezobe_van_helyezve(lap16helye, Ostrommezohelye1, OstromMezo1, lap16zarolasa, Alapkartya))
            {
                byte th = 16;
                if (!Ostrommezoben1.Contains(th))
                {
                    //Manuálisan megadom melyik pozicióba legyen lezárva a kártyalap
                    lap16helye.X = Ostrommezohelye1.X + (Omezo1lepteto * 90);
                    lap16helye.Y = Ostrommezohelye1.Y + 2;
                    this.Refresh();
                    lap16zarolasa = true;
                    Ostrommezoben1.Add(th);
                    Omezo1lepteto++;
                    egyszer3 = true;
                    Kartyakpalyan.Add(16);
                }
            }
            else if (Kartya_a_mezobe_van_helyezve(lap16helye, Ostrommezohelye2, OstromMezo2, lap16zarolasa, Alapkartya))
            {
                byte th = 16;
                if (!Ostrommezoben2.Contains(th))
                {
                    //Manuálisan megadom melyik pozicióba legyen lezárva a kártyalap
                    lap16helye.X = Ostrommezohelye2.X + (Omzeo2lepteto * 90);
                    lap16helye.Y = Ostrommezohelye2.Y + 2;
                    this.Refresh();
                    lap16zarolasa = true;
                    Ostrommezoben2.Add(th);
                    Omzeo2lepteto++;
                    egyszer4 = true;
                    Kartyakpalyan.Add(16);
                }
            }
            else
            {
                lap16helye = elozopozicio16;
               // lap2helye.X = KezdoKartyakhelye.X;
               // lap2helye.Y = KezdoKartyakhelye.Y;
                this.Refresh();
            }

            kulzorlock.X = -1;
            kulzorlock.Y = -1;
        
            //lap17
            if (Kartya_a_mezobe_van_helyezve(lap17helye, Kozelharcosmezohelye, KozelharcosMezo, lap17zarolasa, Alapkartya))
            {
                byte thet = 17;
                if (!Kozmezoben.Contains(thet))
                {
                    //Manuálisan megadom melyik pozicióba legyen lezárva a kártyalap
                    lap17helye.X = Kozelharcosmezohelye.X + (Kmezolepteto * 90);
                    lap17helye.Y = Kozelharcosmezohelye.Y + 2;
                    this.Refresh();
                    lap17zarolasa = true;
                    Kozmezoben.Add(thet);
                    Kmezolepteto++;
                    egyszer1 = true;
                    Kartyakpalyan.Add(17);
                }
            }
            else
            {
                lap17helye = elozopozicio17;
               // lap2helye.X = KezdoKartyakhelye.X;
               // lap2helye.Y = KezdoKartyakhelye.Y;
                this.Refresh();
            }
    
            kulzorlock.X = -1;
            kulzorlock.Y = -1;
        
            //lap18
            if (Kartya_a_mezobe_van_helyezve(lap18helye, Ostrommezohelye1, OstromMezo1, lap18zarolasa, Alapkartya))
            {
                byte tn = 18;
                if (!Ostrommezoben1.Contains(tn))
                {
                    //Manuálisan megadom melyik pozicióba legyen lezárva a kártyalap
                    lap18helye.X = Ostrommezohelye1.X + (Omezo1lepteto * 90);
                    lap18helye.Y = Ostrommezohelye1.Y + 2;
                    this.Refresh();
                    lap18zarolasa = true;
                    Ostrommezoben1.Add(tn);
                    Omezo1lepteto++;
                    egyszer3 = true;
                    Kartyakpalyan.Add(18);
                }
            }
            else if (Kartya_a_mezobe_van_helyezve(lap18helye, Ostrommezohelye2, OstromMezo2, lap18zarolasa, Alapkartya))
            {
                byte tn = 18;
                if (!Ostrommezoben2.Contains(tn))
                {
                    //Manuálisan megadom melyik pozicióba legyen lezárva a kártyalap
                    lap18helye.X = Ostrommezohelye2.X + (Omzeo2lepteto * 90);
                    lap18helye.Y = Ostrommezohelye2.Y + 2;
                    this.Refresh();
                    lap18zarolasa = true;
                    Ostrommezoben2.Add(tn);
                    Omzeo2lepteto++;
                    egyszer4 = true;
                    Kartyakpalyan.Add(18);
                }
            }
            else
            {
                lap18helye = elozopozicio18;
               // lap2helye.X = KezdoKartyakhelye.X;
               // lap2helye.Y = KezdoKartyakhelye.Y;
                this.Refresh();
            }

            kulzorlock.X = -1;
            kulzorlock.Y = -1;
        
            //lap19
            if (Kartya_a_mezobe_van_helyezve(lap19helye, Ostrommezohelye1, OstromMezo1, lap19zarolasa, Alapkartya))
            {
                byte tk = 19;
                if (!Ostrommezoben1.Contains(tk))
                {

                    //Manuálisan megadom melyik pozicióba legyen lezárva a kártyalap
                    lap19helye.X = Ostrommezohelye1.X + (Omezo1lepteto * 90);
                    lap19helye.Y = Ostrommezohelye1.Y + 2;
                    this.Refresh();
                    lap19zarolasa = true;
                    Ostrommezoben1.Add(tk);
                    Omezo1lepteto++;
                    egyszer3 = true;
                    Kartyakpalyan.Add(19);
                }
            }
            else if (Kartya_a_mezobe_van_helyezve(lap19helye, Ostrommezohelye2, OstromMezo2, lap19zarolasa, Alapkartya))
            {
                byte tk = 19;
                if (!Ostrommezoben2.Contains(tk))
                {

                    //Manuálisan megadom melyik pozicióba legyen lezárva a kártyalap
                    lap19helye.X = Ostrommezohelye2.X + (Omzeo2lepteto * 90);
                    lap19helye.Y = Ostrommezohelye2.Y + 2;
                    this.Refresh();
                    lap19zarolasa = true;
                    Ostrommezoben2.Add(tk);
                    Omzeo2lepteto++;
                    egyszer4 = true;
                    Kartyakpalyan.Add(19);
                }
            }
            else
            {
                lap19helye = elozopozicio19;
               // lap2helye.X = KezdoKartyakhelye.X;
               // lap2helye.Y = KezdoKartyakhelye.Y;
                this.Refresh();
            }

            kulzorlock.X = -1;
            kulzorlock.Y = -1;
        
            //lap20
            if (Kartya_a_mezobe_van_helyezve(lap20helye, Ostrommezohelye1, OstromMezo1, lap20zarolasa, Alapkartya))
            {
                byte h = 20;
                if (!Ostrommezoben1.Contains(h))
                {
                    //Manuálisan megadom melyik pozicióba legyen lezárva a kártyalap
                    lap20helye.X = Ostrommezohelye1.X + (Omezo1lepteto * 90);
                    lap20helye.Y = Ostrommezohelye1.Y + 2;
                    this.Refresh();
                    lap20zarolasa = true;
                    Ostrommezoben1.Add(h);
                    Omezo1lepteto++;
                    egyszer3 = true;
                    Kartyakpalyan.Add(20);
                }
            }
            else if (Kartya_a_mezobe_van_helyezve(lap20helye, Ostrommezohelye2, OstromMezo2, lap20zarolasa, Alapkartya))
            {
                byte h = 20;
                if (!Ostrommezoben2.Contains(h))
                {
                    //Manuálisan megadom melyik pozicióba legyen lezárva a kártyalap
                    lap20helye.X = Ostrommezohelye2.X + (Omzeo2lepteto * 90);
                    lap20helye.Y = Ostrommezohelye2.Y + 2;
                    this.Refresh();
                    lap20zarolasa = true;
                    Ostrommezoben2.Add(h);
                    Omzeo2lepteto++;
                    egyszer4 = true;
                    Kartyakpalyan.Add(20);
                }
            }
            else
            {
                lap20helye = elozopozicio20;
               // lap2helye.X = KezdoKartyakhelye.X;
               // lap2helye.Y = KezdoKartyakhelye.Y;
                this.Refresh();
            }

            kulzorlock.X = -1;
            kulzorlock.Y = -1;
        
            //lap21
            if (Kartya_a_mezobe_van_helyezve(lap21helye, Ostrommezohelye1, OstromMezo1, lap21zarolasa, Alapkartya))
            {
                byte he = 21;
                if (!Ostrommezoben1.Contains(he))
                {
                    //Manuálisan megadom melyik pozicióba legyen lezárva a kártyalap
                    lap21helye.X = Ostrommezohelye1.X + (Omezo1lepteto * 90);
                    lap21helye.Y = Ostrommezohelye1.Y + 2;
                    this.Refresh();
                    lap21zarolasa = true;
                    Ostrommezoben1.Add(he);
                    Omezo1lepteto++;
                    egyszer3 = true;
                    Kartyakpalyan.Add(21);
                }
            }
            else if (Kartya_a_mezobe_van_helyezve(lap21helye, Ostrommezohelye2, OstromMezo2, lap21zarolasa, Alapkartya))
            {
                byte he = 21;
                if (!Ostrommezoben2.Contains(he))
                {
                    //Manuálisan megadom melyik pozicióba legyen lezárva a kártyalap
                    lap21helye.X = Ostrommezohelye2.X + (Omzeo2lepteto * 90);
                    lap21helye.Y = Ostrommezohelye2.Y + 2;
                    this.Refresh();
                    lap21zarolasa = true;
                    Ostrommezoben2.Add(he);
                    Omzeo2lepteto++;
                    egyszer4 = true;
                    Kartyakpalyan.Add(21);
                }
            }
            else
            {
                lap21helye = elozopozicio21;
               // lap2helye.X = KezdoKartyakhelye.X;
               // lap2helye.Y = KezdoKartyakhelye.Y;
                this.Refresh();
            }

            kulzorlock.X = -1;
            kulzorlock.Y = -1;
        
            //lap22
            if (Kartya_a_mezobe_van_helyezve(lap22helye, Kozelharcosmezohelye, KozelharcosMezo, lap22zarolasa, Alapkartya))
            {
                byte hk = 22;
                if (!Kozmezoben.Contains(hk))
                {
                    //Manuálisan megadom melyik pozicióba legyen lezárva a kártyalap
                    lap22helye.X = Kozelharcosmezohelye.X + (Kmezolepteto * 90);
                    lap22helye.Y = Kozelharcosmezohelye.Y + 2;
                    this.Refresh();
                    lap22zarolasa = true;
                    Kozmezoben.Add(hk);
                    Kmezolepteto++;
                    egyszer1 = true;
                    Kartyakpalyan.Add(22);
                }
            }
            else
            {
                lap22helye = elozopozicio22;
               // lap2helye.X = KezdoKartyakhelye.X;
               // lap2helye.Y = KezdoKartyakhelye.Y;
                this.Refresh();
            }

            kulzorlock.X = -1;
            kulzorlock.Y = -1;
        
            //lap23
            if (Kartya_a_mezobe_van_helyezve(lap23helye, Tavolsagimezohelye, TavolsagiMezo, lap23zarolasa, Alapkartya))
            {
                byte hh = 23;
                if (!Tavmezoben.Contains(hh))
                {
                    //Manuálisan megadom melyik pozicióba legyen lezárva a kártyalap
                    lap23helye.X = Tavolsagimezohelye.X + (Tmezolepteto * 90);
                    lap23helye.Y = Tavolsagimezohelye.Y + 2;
                    this.Refresh();
                    lap23zarolasa = true;
                    Tavmezoben.Add(hh);
                    Tmezolepteto++;
                    egyszer2 = true;
                    Kartyakpalyan.Add(23);
                }
            }
            else if (Kartya_a_mezobe_van_helyezve(lap23helye, Kozelharcosmezohelye, KozelharcosMezo, lap23zarolasa, Alapkartya))
            {
                byte hh = 23;
                if (!Kozmezoben.Contains(hh))
                {
                    //Manuálisan megadom melyik pozicióba legyen lezárva a kártyalap
                    lap23helye.X = Kozelharcosmezohelye.X + (Kmezolepteto * 90);
                    lap23helye.Y = Kozelharcosmezohelye.Y + 2;
                    this.Refresh();
                    lap23zarolasa = true;
                    Kozmezoben.Add(hh);
                    Kmezolepteto++;
                    egyszer1 = true;
                    Kartyakpalyan.Add(23);
                }
            }
            else
            {
                lap23helye = elozopozicio23;
               // lap2helye.X = KezdoKartyakhelye.X;
               // lap2helye.Y = KezdoKartyakhelye.Y;
                this.Refresh();
            }

            kulzorlock.X = -1;
            kulzorlock.Y = -1;
        
            //lap24
            if (Kartya_a_mezobe_van_helyezve(lap24helye, Kozelharcosmezohelye, KozelharcosMezo, lap24zarolasa, Alapkartya))
            {
                byte hn = 24;
                if (!Kozmezoben.Contains(hn))
                {
                    //Manuálisan megadom melyik pozicióba legyen lezárva a kártyalap
                    lap24helye.X = Kozelharcosmezohelye.X + (Kmezolepteto * 90);
                    lap24helye.Y = Kozelharcosmezohelye.Y + 2;
                    this.Refresh();
                    lap24zarolasa = true;
                    Kozmezoben.Add(hn);
                    Kmezolepteto++;
                    egyszer1 = true;
                    Kartyakpalyan.Add(24);
                }
            }
            else
            {
                lap24helye = elozopozicio24;
               // lap2helye.X = KezdoKartyakhelye.X;
               // lap2helye.Y = KezdoKartyakhelye.Y;
                this.Refresh();
            }

            kulzorlock.X = -1;
            kulzorlock.Y = -1;
        
            //lap25
            if (Kartya_a_mezobe_van_helyezve(lap25helye, Kozelharcosmezohelye, KozelharcosMezo, lap25zarolasa, Alapkartya))
            {
                byte ho = 25;
                if (!Kozmezoben.Contains(ho))
                {
                    //Manuálisan megadom melyik pozicióba legyen lezárva a kártyalap
                    lap25helye.X = Kozelharcosmezohelye.X + (Kmezolepteto * 90);
                    lap25helye.Y = Kozelharcosmezohelye.Y + 2;
                    this.Refresh();
                    lap25zarolasa = true;
                    Kozmezoben.Add(ho);
                    Kmezolepteto++;
                    egyszer1 = true;
                    Kartyakpalyan.Add(25);
                    Ellenfelkore = true;
                }
            }
            else
            {
                lap25helye = elozopozicio25;
               // lap2helye.X = KezdoKartyakhelye.X;
               // lap2helye.Y = KezdoKartyakhelye.Y;
                this.Refresh();
            }
            
            kulzorlock.X = -1;
            kulzorlock.Y = -1;
        }
    

        /// <summary>
        /// Ez pedig az Adat beolvasása valamit összértéket is számol de csak hogy lássam az is sikerül
        /// </summary>
        public static void Adatbeolvasas(ref int osszertek,ref Kartyatulj[]lapok)
        {
            string[] adatok = File.ReadAllLines("Kartyak.txt");
            //Kartyatulj[] lapok = new Kartyatulj[adatok.Length];
            

            for (int i = 1; i < adatok.Length; i++)
            {
                string[] tmp = adatok[i].Split(';');
                lapok[i].ID = int.Parse(tmp[0]);
                lapok[i].erteke = int.Parse(tmp[1]);
                lapok[i].kategoria = tmp[2];
                lapok[i].keppeseg = tmp[3];
            }
        }

        public static void Pontszamolas(ref int osszertek, List<int> Kartyakamezon,ref bool egyszer)
        {

            int mennyiseg = Kartyakamezon.Count();
             osszertek = 0;
           // mennyiseg = Kartyakamezon.Count + 1;
            while (mennyiseg != 0)
            {
                foreach (var k in Kartyakamezon)
                {
                    switch (k)
                    {
                        case 1:
                            osszertek += 10;
                            mennyiseg--;
                            break;
                        case 2:
                            osszertek += 15;
                            mennyiseg--;
                            break;
                        case 3:
                            osszertek += 8;
                            mennyiseg--;
                            break;
                        case 4:
                            osszertek += 8;
                            mennyiseg--;
                            break;
                        case 5:
                            osszertek += 2;
                            mennyiseg--;
                            break;
                        case 6:
                            osszertek += 2;
                            mennyiseg--;
                            break;
                        case 7:
                            osszertek += 2;
                            mennyiseg--;
                            break;
                        case 8:
                            osszertek += 1;
                            mennyiseg--;
                            break;
                        case 9:
                            osszertek += 1;
                            mennyiseg--;
                            break;
                        case 10:
                            osszertek += 4;
                            mennyiseg--;
                            break;
                        case 11:
                            osszertek += 4;
                            mennyiseg--;
                            break;
                        case 12:
                            osszertek += 5;
                            mennyiseg--;
                            break;
                        case 13:
                            osszertek += 6;
                            mennyiseg--;
                            break;
                        case 14:
                            osszertek += 6;
                            mennyiseg--;
                            break;
                        case 15:
                            osszertek += 10;
                            mennyiseg--;
                            break;
                        case 16:
                            osszertek += 14;
                            mennyiseg--;
                            break;
                        case 17:
                            osszertek += 15;
                            mennyiseg--;
                            break;
                        case 18:
                            osszertek += 8;
                            mennyiseg--;
                            break;
                        case 19:
                            osszertek += 8;
                            mennyiseg--;
                            break;
                        case 20:
                            osszertek += 6;
                            mennyiseg--;
                            break;
                        case 21:
                            osszertek += 6;
                            mennyiseg--;
                            break;
                        case 22:
                            osszertek += 10;
                            mennyiseg--;
                            break;
                        case 23:
                            osszertek += 10;
                            mennyiseg--;
                            break;
                        case 24:
                            osszertek += 14;
                            mennyiseg--;
                            break;
                        case 25:
                            osszertek += 14;
                            mennyiseg--;
                            break;
                    }
                }
            }
            
            //osszertek = osszertek + ertek;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Paint(object sender, PaintEventArgs e)
        {
            
            if (egyszer1)
            {
                Pontszamolas(ref osszertek, Kartyakpalyan, ref egyszer1);
                label2.Text = osszertek.ToString();
            }

            if(egyszer2)
            {
                Pontszamolas(ref osszertek, Kartyakpalyan, ref egyszer2);
                label2.Text = osszertek.ToString();
            }

            if(egyszer3)
            {
                Pontszamolas( ref osszertek, Kartyakpalyan, ref egyszer3);
                label2.Text = osszertek.ToString();
            }

            if(egyszer4)
            {
                Pontszamolas( ref osszertek, Kartyakpalyan, ref egyszer4);
                label2.Text = osszertek.ToString();
            }
            egyszer1 = false;
            egyszer2 = false;
            egyszer3 = false;
            egyszer4 = false;


        }
        //ez nem biztos hogy kellet de már megírtam használom
        private void Kategoriavalasztas(string kapottkategoria,ref string viszaadottkategoria)
        {
            Kartyatulj L = new Kartyatulj();
            L.kategoria = kapottkategoria;
            switch (L.kategoria)
            {
                case "Kozelharcos":
                    viszaadottkategoria = "Kozelharcos";
                    break;

                case "Tavolsagi":
                    viszaadottkategoria = "Tavolsagi";
                    break;

                case "Ostrom":
                    viszaadottkategoria = "Ostrom";
                    break;

                default:
                    viszaadottkategoria = "Nincs";
                    break;
            }
        }

        //Először MouseHoverrel szerettem volna megcsinálni a kijelölést de nem sikerült
        private void Form1_MouseHover(object sender, EventArgs e)
        {

        }

        //Utána kattintással
        private void Form1_Click(object sender, EventArgs e)
        {
            
        }
        
        //Nem tudom mi a kattintás és az egér kattintás között a különbség
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
    
        }

        public static void Elsokilenckartya(int[]paklitartalma, ref List<int> Lrandomszam)
        {
            int mennyiseg = 9;
            Randomkartyahuzas(mennyiseg, paklitartalma,ref Lrandomszam);
        }

        public static void Randomkartyahuzas(int mennyiseg,int[]paklitartalma,ref List<int> Lrandomszam)
        {
            Random rnd = new Random();


            //int[] paklitartalma = new int[25] {1,2,3,4,5,6,7,8,9,10,11,12,13,
                                              // 14,15,16,17,18,19,20,21,22,23,24,25 };

            //List<int> Lrandomszam = new List<int>();

            while (mennyiseg != 0)
            {
                //Ha a random számot megtalálja a Lrandomszam-ban akkor nem csináljon semmit
                //ha nem akkor adja hozzá az Lrandomszámhoz a random számot és a mennyiséget csökkentjük
                // azért csökkentem mert ha a listába rakott egy elemet akkor egy kártáyval kevesebbet kell kihuznom pakaliból
                int random = rnd.Next(1, 25);
                if (!Lrandomszam.Contains(random))
                {
                    Lrandomszam.Add(random);
                    mennyiseg--;
                }

            }
        }
        public static void EllenfelKartyaRakas(List<int> Kihelyezettlapok, ref int kivalasztott)
        {
            Random rnd = new Random();
            int szamlalo = Kihelyezettlapok.Count;

            int szam = rnd.Next(1, 25);
            while (szamlalo != 0)
            {
                if (Kihelyezettlapok.Contains(szam))
                {
                    Kihelyezettlapok.Remove(szam);
                    szamlalo--;
                    if (szamlalo == 0)
                        break;
                     szam = rnd.Next(1, 25);

                }
                 szam = rnd.Next(1, 25);
            }
            kivalasztott = szam;
            

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kmezolepteto = 0;
            Tmezolepteto = 0;
            Omezo1lepteto = 0;
            Omzeo2lepteto = 0;
            egyszer1 = true;
            foreach (var k in Kartyakpalyan)
            {
                switch (k)
                {
                    case 1:
                        lap1helye = Temetohelye;
                        break;
                    case 2:
                        lap2helye = Temetohelye;
                        break;
                    case 3:
                        lap3helye = Temetohelye;
                        break;
                    case 4:
                        lap4helye = Temetohelye;
                        break;
                    case 5:
                        lap5helye = Temetohelye;
                        break;
                    case 6:
                        lap6helye = Temetohelye;
                        break;
                    case 7:
                        lap7helye = Temetohelye;
                        break;
                    case 8:
                        lap8helye = Temetohelye;
                        break;
                    case 9:
                        lap9helye = Temetohelye;
                        break;
                    case 10:
                        lap10helye = Temetohelye;
                        break;
                    case 11:
                        lap11helye = Temetohelye;
                        break;
                    case 12:
                        lap12helye = Temetohelye;
                        break;
                    case 13:
                        lap13helye = Temetohelye;
                        break;
                    case 14:
                        lap14helye = Temetohelye;
                        break;
                    case 15:
                        lap15helye = Temetohelye;
                        break;
                    case 16:
                        lap16helye = Temetohelye;
                        break;
                    case 17:
                        lap17helye = Temetohelye;
                        break;
                    case 18:
                        lap18helye = Temetohelye;
                        break;
                    case 19:
                        lap19helye = Temetohelye;
                        break;
                    case 20:
                        lap20helye = Temetohelye;
                        break;
                    case 21:
                        lap21helye = Temetohelye;
                        break;
                    case 22:
                        lap22helye = Temetohelye;
                        break;
                    case 23:
                        lap23helye = Temetohelye;
                        break;
                    case 24:
                        lap24helye = Temetohelye;
                        break;
                    case 25:
                        lap25helye = Temetohelye;
                        break;
                }
            }
            Kartyakpalyan.Clear();
            if (egyszer1)
            {
                Pontszamolas(ref osszertek, Kartyakpalyan, ref egyszer1);
                label2.Text = osszertek.ToString();
            }
            egyszer1 = false;
            this.Refresh();
        }
    }
}
