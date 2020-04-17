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
        public int elozopozicioX;
        public int elozopozicioY;
        public int aktualispozX;
        public int aktualispozY;
        public string Bitmap;
    } 
    #endregion

    public partial class Form1 : Form
    {
        #region Valtozok/logikai
        Kartyatulj[] lap = new Kartyatulj[30];
        public string kategoria;
        public int osszertek = 0;


        private Point elozopozicio = new Point(-1, -1);

        int Index = 0;
        bool Egerfelengedve = false;
        bool KozKartyazarolas = false;
        bool TavKartyazarolas = false;
        bool OstKartyazarolas = false;
        bool Kulzorkartyan = false;
        bool folyamatban = false;
        #endregion

        #region Bitmap-ok
        private Bitmap Alapkartya;

        private Bitmap KozelharcosKartya;
        private Bitmap KozelharcosMezo;

        private Bitmap TavolsagiKartya;
        private Bitmap TavolsagiMezo;

        private Bitmap OstromKartya;
        private Bitmap OstromMezo1;
        private Bitmap OstromMezo2;

        private Bitmap EllKozelharcosKartya;
        private Bitmap EllKozelharcosMezo;

        private Bitmap EllTavolsagiKartya;
        private Bitmap EllTavolsagiMezo;

        private Bitmap EllOstromKartya;
        private Bitmap EllOstromMezo1;
        private Bitmap EllOstromMezo2;

        private Bitmap Pakli;
        private Bitmap EllPakli;

        private Bitmap Temeto;
        private Bitmap EllTemeto;

        private Bitmap Kartyakkezben;
        private Bitmap EllKartyakkezben;

        private Bitmap Esemenykartya;

        private Bitmap Boostkartya;
        #endregion



        #region Point-ok bitmap poziciók
        //A bitmapok helye a console-on

        //Saját mezők
        private Point Ideiglenespoz = new Point(0, 0);
        private Point Ideiglenespoz2 = new Point(0, 0);

        private Point KezdoKartyakhelye = new Point(212, 603);

        private Point Boostkartyahelye1 = new Point(210, 390);
        private Point Boostkartyahelye2 = new Point(210, 495);

        private Point Esemenykartyahelye = new Point(50, 250);
        private Point Kartyakkezbenhelye = new Point(210, 600);

        private Point Kozelharcosmezohelye = new Point(285, 390);
        private Point Kozelharcoskartyahelye = new Point(212, 603);

        private Point Tavolsagimezohelye = new Point(285, 495);
        private Point Tavolsagikartyahelye = new Point(281, 603);

        private Point Ostrommezohelye1 = new Point(5, 495);
        private Point Ostrommezohelye2 = new Point(1160, 495);
        private Point Ostromkartyahelye = new Point(350, 603);

        private Point Paklihelye = new Point(1250, 605);
        private Point Temetohelye = new Point(1180, 605);

        //Ellenfél mezői

        private Point EllBoostkartyahelye1 = new Point(210, 215);
        private Point EllBoostkartyahelye2 = new Point(210, 110);

        private Point EllKartyakkezbenhelye = new Point(210, 5);

        private Point EllKozelharcosmezohelye = new Point(285, 215);
        private Point EllKozelharcoskartyahelye = new Point(100, 100);

        private Point EllTavolsagimezohelye = new Point(285, 110);
        private Point EllTavolsagikartyahelye = new Point(100, 250);

        private Point EllOstrommezohelye1 = new Point(5, 110);
        private Point EllOstrommezohelye2 = new Point(1160, 110);
        private Point EllOstromkartyahelye = new Point(100, 380);

        private Point EllPaklihelye = new Point(30, 5);
        private Point EllTemetohelye = new Point(100, 5);

        Pen feher = new Pen(Color.White);
        Point kulzorlock = new Point(-1, -1);

        Point aktualiskulzorpozicio = MousePosition; 
        #endregion



        public Form1()
        {
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

            KozelharcosMezo = new Bitmap(870, 105);
            KozelharcosKartya = new Bitmap(65, 95);

            TavolsagiKartya = new Bitmap(65, 95);
            TavolsagiMezo = new Bitmap(870, 105);

            OstromKartya = new Bitmap(65, 95);
            OstromMezo1 = new Bitmap(200, 205);
            OstromMezo2 = new Bitmap(200, 205);

            Pakli = new Bitmap(65, 95);
            Temeto = new Bitmap(65, 95);

            Esemenykartya = new Bitmap(100, 200);
            Boostkartya = new Bitmap(70, 100);

            //Ellenfél
            EllKartyakkezben = new Bitmap(945, 105);

            EllKozelharcosMezo = new Bitmap(870, 105);
            EllKozelharcosKartya = new Bitmap(65, 95);

            EllTavolsagiKartya = new Bitmap(65, 95);
            EllTavolsagiMezo = new Bitmap(870, 105);

            EllOstromKartya = new Bitmap(65, 95);
            EllOstromMezo1 = new Bitmap(200, 205);
            EllOstromMezo2 = new Bitmap(200, 205);

            EllPakli = new Bitmap(65, 95);
            EllTemeto = new Bitmap(65, 95);


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
        #endregion

        #region Mezők kinézete
        //Mezők kinézete
        private void mezorajz()
        {
            using (var g = Graphics.FromImage(Boostkartya))
            {
                g.FillRectangle(Brushes.Gray, boostlap);
            }
            //Esemény mező
            using (var g = Graphics.FromImage(Esemenykartya))
            {
                g.FillRectangle(Brushes.Silver, esemenymezo);
            }

            //Pakli + Ellenfél Pakli
            using (var g = Graphics.FromImage(Pakli))
            {
                g.FillRectangle(Brushes.Purple, kartyalap);
            }
            using (var g = Graphics.FromImage(EllPakli))
            {
                g.FillRectangle(Brushes.Purple, kartyalap);
            }

            //Temetők
            using (var g = Graphics.FromImage(Temeto))
            {
                g.FillRectangle(Brushes.Blue, kartyalap);
            }
            using (var g = Graphics.FromImage(EllTemeto))
            {
                g.FillRectangle(Brushes.Blue, kartyalap);
            }

            using (var g = Graphics.FromImage(Kartyakkezben))
            {
                g.FillRectangle(Brushes.White, mezo1);
            }

            using (var g = Graphics.FromImage(KozelharcosMezo))
            {
                g.FillRectangle(Brushes.Yellow, mezo1);
            }

            using (var g = Graphics.FromImage(TavolsagiMezo))
            {
                g.FillRectangle(Brushes.Green, mezo1);
            }

            using (var g = Graphics.FromImage(OstromMezo1))
            {
                g.FillRectangle(Brushes.Red, Ostmezo);
            }

            using (var g = Graphics.FromImage(OstromMezo2))
            {
                g.FillRectangle(Brushes.Red, Ostmezo);
            }

            //Ellenfél
            using (var g = Graphics.FromImage(EllKartyakkezben))
            {
                g.FillRectangle(Brushes.White, mezo1);
            }

            using (var g = Graphics.FromImage(EllKozelharcosMezo))
            {
                g.FillRectangle(Brushes.Yellow, mezo1);
            }

            using (var g = Graphics.FromImage(EllTavolsagiMezo))
            {
                g.FillRectangle(Brushes.Green, mezo1);
            }

            using (var g = Graphics.FromImage(EllOstromMezo1))
            {
                g.FillRectangle(Brushes.Red, Ostmezo);
            }
            using (var g = Graphics.FromImage(EllOstromMezo2))
            {
                g.FillRectangle(Brushes.Red, Ostmezo);
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
            g.DrawImage(Kartyakkezben, Kartyakkezbenhelye);
            g.DrawImage(KozelharcosMezo, Kozelharcosmezohelye);
            g.DrawImage(TavolsagiMezo, Tavolsagimezohelye);
            g.DrawImage(OstromMezo1, Ostrommezohelye1);
            g.DrawImage(OstromMezo2, Ostrommezohelye2);


            g.DrawImage(EllKartyakkezben, EllKartyakkezbenhelye);
            g.DrawImage(EllKozelharcosMezo, EllKozelharcosmezohelye);
            g.DrawImage(EllTavolsagiMezo, EllTavolsagimezohelye);
            g.DrawImage(EllOstromMezo1, EllOstrommezohelye1);
            g.DrawImage(EllOstromMezo2, EllOstrommezohelye2);

            g.DrawImage(Pakli, Paklihelye);
            g.DrawImage(EllPakli, EllPaklihelye);

            g.DrawImage(Temeto, Temetohelye);
            g.DrawImage(EllTemeto, EllTemetohelye);
            #endregion

            //Kártyák kirajzolása
            int a = 0;
            int f = 0;
            //Ezt a feltételt azért csináltam, hogy egyszer rajzolja ki az összes kártyát(most ugye "30"db kártya van ezért 
            //"lap" nevezetű tömb az 30 elemű,mert egy pakliban gondolkodtam először),ha eléri az "f" nevű változo egyszer a lap.length-et
            //tehát a 30-at, akkor nem kell újra kirajzolni az összes kártyát, felesleges ugy sincsenek mozdítva
            if (f != lap.Length)
            /*------------------------------------------------------------------------*/
            {
                //Ezzen a cikluson rajzolom ki lap.length-nyi (tehát 12 lapot,mivel annyi van beleírva a txt-fájlba) kártyákat
                for (int i = 0; i < lap.Length; i++)
                {
                    f++;
                    //Ezt gondolom érti ha a kategoria = "Ostrom" amit a fájba írok és onnan is kapja a lap[i].kategoria az értéket
                    //akkor az adott "i"-dik elemű kártyának a pozicióját beállítom a KezdoKartyahelyre(A fehérmező/sáv alúl) bal oldaról kezdje
                    //felsorolni/kipakolni a lapokat
                    kartyarajz(lap[i].kategoria);
                    if (lap[i].kategoria == "Ostrom")
                    {
                        lap[i].aktualispozX = KezdoKartyakhelye.X;
                        lap[i].aktualispozY = KezdoKartyakhelye.Y;
                        //Ezt azért csináltam mert ha az elsőt lapot kihelyeztem a fehér mezőre akkor a következőt nem rá
                        //hanem utána szeretném rakni. Az "a" változo igazából azt szeretné jelképzni hogy hányadik éppen vagy hányadiknál tartunk
                        // ezért ha az 1-re változik akkor alapból a következőt is ráhelyezné de igy (a * 70) 70-el eltoltam jobbra 
                        // a következőt 140-el azt következőt pedig 210-el stb....
                        g.DrawImage(OstromKartya, lap[i].aktualispozX + (a * 70), lap[i].aktualispozY);
                        a++;

                        //Ezt azért írtam ide hogy fejebb a lap[i] elem rögzitett poziciója az Kezdokártya lenne csak rajzolásnál
                        //tolja el, de nem jegyzi meg, ezért raktam ide ezt ha már eltolja akkor lap[i]-ben is nyomja el
                        lap[i].aktualispozX = lap[i].aktualispozX + (a * 70);
                    }
                    //Amit fentebb csinálok azt itt is lemásoltam
                    if (lap[i].kategoria == "Tavolsagi")
                    {
                        lap[i].aktualispozX = KezdoKartyakhelye.X;
                        lap[i].aktualispozY = KezdoKartyakhelye.Y;

                        g.DrawImage(TavolsagiKartya, lap[i].aktualispozX + (a * 70), lap[i].aktualispozY);
                        a++;

                        lap[i].aktualispozX = lap[i].aktualispozX + (a * 70);

                    }
                    //Valamit itt is csak közelharcosra
                    if (lap[i].kategoria == "Kozelharcos")
                    {
                        lap[i].aktualispozX = KezdoKartyakhelye.X;
                        lap[i].aktualispozY = KezdoKartyakhelye.Y;

                        g.DrawImage(KozelharcosKartya, lap[i].aktualispozX + (a * 70), lap[i].aktualispozY);
                        a++;

                        lap[i].aktualispozX = lap[i].aktualispozX + (a * 70);
                    }
                }
            }
              /*-------------------------------------------------------------------------------------------- */

            //Ez a kiválasztott kártyát szeretné újrarajzolni
            if (Kulzorkartyan)
            {
                g.DrawImage(KozelharcosKartya, lap[Index].aktualispozX, lap[Index].aktualispozY);
            }
            /*------------------------------------------------------------------------*/
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
        private bool Kartya_a_mezobe_van_helyezve(Point kartyahelye, Point mezo1helye, Bitmap mezo1, bool egerfelengedve, bool Kartyazarolas, Bitmap kartya)
        {
            //Ezt igazából nem is használom, de nem törlöm még ki :D
            if (!egerfelengedve)
            {
                //Itt megvizsgálóm h be van-e helyezve a kártya
                if (kartyahelye.X + kartya.Width >= mezo1helye.X && kartyahelye.X <= mezo1helye.X + mezo1.Width
                   && kartyahelye.Y + kartya.Height >= mezo1helye.Y && kartyahelye.Y <= mezo1helye.Y + mezo1.Height)
                {
                    //Ha bent van akkor és csak is akkor "zárolja"-le a kártyát a mezőre ha az "Mouse up"-olva 
                    //tehát az egeret felengedtük

                    //Ezt lejebb oldottam meg 
                    return true;

                }


            }
            return false;
        } 
        #endregion


        //Egér mozgatás
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //Ha a kiválasztott kártyán "Ideiglenespoz"-on rajta volt a kulzor/rákattintottak
            if (Kartyabanakulzor(Ideiglenespoz, Alapkartya))
            { 
                aktualiskulzorpozicio = Control.MousePosition;
                //és nyomjuk a balgombot
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    //ezeket régen használtam
                    TavKartyazarolas = true;
                    OstKartyazarolas = true;
                    //akkor itt egyszer lelockoljuk a kulzort hogy mozgatásnál nem mozduljon el
                    if (kulzorlock.X == -1 && kulzorlock.Y == -1)
                    {
                        //Ezt még nekem is alaposan át kell gondolnom hogy mi is történik itt
                        //Mivel itt akadtam el, de ezt levélben már kifejtettem
                        elozopozicio.X = lap[Index].aktualispozX;
                        elozopozicio.Y = lap[Index].aktualispozY;
                        kulzorlock.X = Control.MousePosition.X - lap[Index].aktualispozX;
                        kulzorlock.Y = Control.MousePosition.Y - lap[Index].aktualispozY;
                        //Kulzorlock legyen = a kulzorlock - kártyahelye

                    }
                    //kicsit feljebb ugye le lockoltuk a kulzort tehát ha ide belép akkor a kiválasztott("Index")
                    //lapnak a pozicióját módosítom és majd g.DrawImage-ben újra írom, de itt már ugye Frissítem szóval nem értem
                    else
                    {
                        lap[Index].aktualispozX = MousePosition.X - kulzorlock.X;
                        lap[Index].aktualispozY = MousePosition.Y - kulzorlock.Y;
                        this.Refresh();
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

    }

        //Egér felengedés
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            //Ez is régi kód
            //kijelolve=false;
            KozKartyazarolas = false;
            TavKartyazarolas = false;
            OstKartyazarolas = false;
            /*-------------------------*/

            //Ez ugye azt csinálja ,hogy ha a kártya a mező Bitmapját éritem az arra megfelelő lappal itt a Közelharcos kategóriáju
            //lappal akkor lehelyezi oda és nem engedi kivenni többet
            //Közelharcos
            if (Kartya_a_mezobe_van_helyezve(Kozelharcoskartyahelye, Kozelharcosmezohelye, KozelharcosMezo, Egerfelengedve, KozKartyazarolas, KozelharcosKartya))
            {
                //Manuálisan megadom melyik pozicióba legyen lezárva a kártyalap
                Kozelharcoskartyahelye.X = Kozelharcosmezohelye.X + 5;
                Kozelharcoskartyahelye.Y = Kozelharcosmezohelye.Y + 2;
                this.Refresh();
                KozKartyazarolas = true;
            }
            /*
            else
            {
                //Az összes kártyának kell egy elöző pozició
                //ezt a Osztályba szeretném beleírni minden kártáynak egyedi ugye
                Kozelharcoskartyahelye = elozopozicio;
                this.Refresh();
            }
            */

            //Távolsági
            if (Kartya_a_mezobe_van_helyezve(Tavolsagikartyahelye, Tavolsagimezohelye, TavolsagiMezo, Egerfelengedve, TavKartyazarolas, TavolsagiKartya))
            {
                //Manuálisan megadom melyik pozicióba legyen lezárva a kártyalap
                Tavolsagikartyahelye.X = Tavolsagimezohelye.X + 5;
                Tavolsagikartyahelye.Y = Tavolsagimezohelye.Y + 2;
                this.Refresh();
                TavKartyazarolas = true;
            }
            /*
            else
            {
                Tavolsagikartyahelye = elozopozicio;
                this.Refresh();
            }
            */

            //Ostrom mező 1
            if (Kartya_a_mezobe_van_helyezve(Ostromkartyahelye, Ostrommezohelye1, OstromMezo1, Egerfelengedve, OstKartyazarolas, OstromKartya))
            {
                //Manuálisan megadom melyik pozicióba legyen lezárva a kártyalap
                Ostromkartyahelye.X = Ostrommezohelye1.X + 5;
                Ostromkartyahelye.Y = Ostrommezohelye1.Y + 2;
                this.Refresh();
                OstKartyazarolas = true;
            }
            /*
            else
            {
                Ostromkartyahelye = elozopozicio;
                this.Refresh();
            }
            */


            if (Kartya_a_mezobe_van_helyezve(Ostromkartyahelye, Ostrommezohelye2, OstromMezo2, Egerfelengedve, OstKartyazarolas, OstromKartya))
            {
                //Manuálisan megadom melyik pozicióba legyen lezárva a kártyalap
                Ostromkartyahelye.X = Ostrommezohelye2.X + 5;
                Ostromkartyahelye.Y = Ostrommezohelye2.Y + 2;
                this.Refresh();
                OstKartyazarolas = true;
            }
            /*
            else
            {
                Ostromkartyahelye = elozopozicio;
                this.Refresh();
            }
            */

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

            

            for (int i = 1; i < lapok.Length; i++)
            {
                Pontszamolas(lapok[i].erteke, ref osszertek);
            }
        }

        public static void Pontszamolas(int ertek, ref int osszertek)
        {
            osszertek = osszertek + ertek;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Paint(object sender, PaintEventArgs e)
        {
            label2.Text = osszertek.ToString();
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
            if (!folyamatban)
            {
                //az asd azért kellet hogy "Watch-ban" visszanézem hogy hányszor lett a "Kulzorkartyan" true
                int asd = 0;
                //Itt az akart lenni a gondolat menet hogy ha rákattintok egy kártyára azt lényegében kijelöli
                //Ő-t kell mozgatni, for ciklussal megkeresem hogy melyik lap az pozició segitségével amit ugye 
                //lap[i].aktualispozX és Y-ban tárolok
                //"Kartyavanakulzor"-nak egy Point kellett ezért csináltam "Ideiglenespoz" amit egyenlővé tettem
                //mindig az "i"-dik aktualispoz-val
                for (int i = 1; i < lap.Length; i++)
                {
                    lap[i].zarolva = true;
                    Ideiglenespoz.X = lap[i].aktualispozX;
                    Ideiglenespoz.Y = lap[i].aktualispozY;
                    

                    //Ha megtaláltam akkor megjegyzem melyik volt az a ciklusban 
                    //valamint a kulzorkartyan a kijelölés szeretne lenni
                    if (Kartyabanakulzor(Ideiglenespoz, Alapkartya))
                    {
                        Index = i;
                        Kulzorkartyan = true;
                    }
                        

                    if (Kulzorkartyan)
                    {
                        //ez a logikai változot azért csináltam ha véletlenül másik kártyára kattintanék, akkor
                        //ide(Form1_MouseClick) ne tudjon belépni amíg egy kártyával dolgozok
                        //természetesen ha végeznék amozgatásával akkor ez menni vissza "false"-ra
                        folyamatban = true;
                        //ez majd gondoltam a jövöben fog kelleni
                        lap[Index].zarolva = false;
                        //és az asd tudja mire van
                        asd++;
                        break;
                    }

                }
            }
            
        }
    }
}
