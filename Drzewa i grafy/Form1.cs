using System.CodeDom.Compiler;

namespace Drzewa_i_grafy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public class Wezel
        {
            public int wartosc;

            public List<Wezel> dzieci = new List<Wezel>();

            public Wezel(int liczba)
            {
                this.wartosc = liczba;
            }

            public override string ToString()
            {
                return "Wartoœæ: " + this.wartosc.ToString();
            }
        }

        public class Wezel2
        {
            public int wartosc;

            public List<Wezel2> sasiedzi = new List<Wezel2>();

            public Wezel2(int liczba)
            {
                this.wartosc = liczba;
            }

            public override string ToString()
            {
                return "Wartoœæ: " + this.wartosc.ToString();
            }

            public void Add(Wezel2 w)
            {
                this.sasiedzi.Add(w);
                w.sasiedzi.Add(this);
            }

        }

        public class Wezel3
        {
            public int wartosc;

            public Wezel3 rodzic;
            public Wezel3 lewe_dziecko;
            public Wezel3 prawe_dziecko;

            public Wezel3(int liczba)
            {
                this.wartosc = liczba;
            }

            public override string ToString()
            {
                return "Wartoœæ: " + this.wartosc.ToString();
            }
            public void Add(int liczba)
            {
                var dziecko = new Wezel3(liczba);
                dziecko.rodzic = this;
                if (liczba < this.wartosc)
                {
                    this.lewe_dziecko = dziecko;
                }
                else
                {
                    this.prawe_dziecko = dziecko;
                }
            }
        }

        public class DrzewoBinarne
        {
            public Wezel3 korzen;
            public int liczba_wezlow;

            public DrzewoBinarne(int liczba)
            {
                this.korzen = new(liczba);
                this.liczba_wezlow = 1;
            }
            public void Add(int liczba)
            {
                var rodzic = this.ZnajdzWezelPoKtorymNull(liczba);
                rodzic.Add(liczba);
            }


            Wezel3 ZnajdzWezelPoKtorymNull(int liczba)
            {
                var w = this.korzen;
                while (true)
                {
                    if (liczba < w.wartosc)
                    {
                        if (w.lewe_dziecko == null)
                        {
                            return w;
                        }
                        else
                        {
                            w = w.lewe_dziecko;
                        }
                    }
                    else
                    {
                        if (w.prawe_dziecko == null)
                        {
                            return w;
                        }
                        else
                        {
                            w = w.prawe_dziecko;
                        }
                    }
                }
            }

            public Wezel3? Znajdz(int liczba)
            {
                var w = this.korzen;

                while (true)
                {
                    if (liczba == w.wartosc)
                        return w;
                    else if (liczba < w.wartosc)
                        w = w.lewe_dziecko;
                    else if (liczba > w.wartosc)
                        w = w.prawe_dziecko;
                    else
                        return null;
                }
            }
            public Wezel3 ZnajdzMin(Wezel3 w)
            {
                while (true)
                {
                    if (w.lewe_dziecko == null)
                        return w;
                    else
                        w = w.lewe_dziecko;
                }
            }
            public Wezel3 ZnajdzMax(Wezel3 w)
            {
                while (true)
                {
                    if (w.prawe_dziecko == null)
                        return w;
                    else
                        w = w.prawe_dziecko;
                }
            }
            public Wezel3? Nastepnik(Wezel3 w)
            {
                if (w.prawe_dziecko != null)
                    return this.ZnajdzMin(w.prawe_dziecko);
                else if (w.prawe_dziecko == null)
                {
                    while (true)
                    {
                        if (w.rodzic.lewe_dziecko == w)
                            return w.rodzic;
                        else
                            w = w.rodzic;
                    }
                }
                else
                    return null;

            }


            public Wezel3? Poprzednik(Wezel3 w)
            {
                if (w.lewe_dziecko != null)
                    return this.ZnajdzMax(w.lewe_dziecko);
                else if (w.lewe_dziecko == null)
                {
                    while (true)
                    {
                        if (w.rodzic.prawe_dziecko == w)
                            return w.rodzic;
                        else
                            w = w.rodzic;
                    }
                }
                else
                    return null;
            }
            public Wezel3 Usun(Wezel3 w)
            {
                if(w.lewe_dziecko == null && w.prawe_dziecko == null)
                {
                    if(w == w.rodzic.prawe_dziecko)
                    {
                        w.rodzic.prawe_dziecko = null;
                    }
                    else
                    {
                        w.rodzic.prawe_dziecko = null;
                    }
                    w.rodzic = null;
                    return w;
                }
                else if (w.lewe_dziecko == null && w.prawe_dziecko != null)
                {
                    if (w == w.rodzic.prawe_dziecko)
                    {

                        w.prawe_dziecko.rodzic = w.rodzic;
                        w.rodzic.prawe_dziecko = w.prawe_dziecko;
                    }
                    else
                    {
                        w.prawe_dziecko.rodzic = w.rodzic;
                        w.rodzic.lewe_dziecko = w.prawe_dziecko;
                    }
                    w.prawe_dziecko = null;
                    w.rodzic = null;
                }
                else if (w.lewe_dziecko != null && w.prawe_dziecko == null)
                {
                    if (w == w.rodzic.prawe_dziecko)
                    {

                        w.lewe_dziecko.rodzic = w.rodzic;
                        w.rodzic.prawe_dziecko = w.lewe_dziecko;
                    }
                    else
                    {
                        w.lewe_dziecko.rodzic = w.rodzic;
                        w.rodzic.lewe_dziecko = w.lewe_dziecko;
                    }
                    w.prawe_dziecko = null;
                    w.rodzic = null;
                }
            }


        }
        void A(Wezel w)
        {
            MessageBox.Show(w.ToString());

            foreach (var dziecko in w.dzieci)
            {
                A(dziecko);
            }
        }

        List<Wezel2> odwiedzone = new();
        List<Wezel2> temp = new();

        void A(Wezel2 w)
        {
            odwiedzone.Add(w);

            MessageBox.Show(w.ToString());

            foreach (var sasiad in w.sasiedzi)
            {
                if (!odwiedzone.Contains(sasiad))
                {
                    A(sasiad);
                }
            }
        }
        void A_w_szerz(Wezel2 w)
        {
            temp.RemoveAt(0);
            odwiedzone.Add(w);
            MessageBox.Show(w.ToString());

            foreach (var sasiad in w.sasiedzi)
            {
                if (!odwiedzone.Contains(sasiad) && !temp.Contains(sasiad))
                {
                    temp.Add(sasiad);
                }
            }
            foreach (var sasiad1 in temp)
            {
                A_w_szerz(sasiad1);
                if (temp.Count < 1)
                {
                    break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var w1 = new Wezel(5);
            var w2 = new Wezel(2);
            var w3 = new Wezel(1);
            var w4 = new Wezel(3);
            var w5 = new Wezel(4);
            var w6 = new Wezel(6);

            w1.dzieci.Add(w2);
            w1.dzieci.Add(w3);
            w1.dzieci.Add(w4);
            w2.dzieci.Add(w5);
            w2.dzieci.Add(w6);

            A(w1);

            //var listaWezlow = new List<Wezel>();  
            //listaWezlow.Add(w1);  
            //listaWezlow.Add(w2);  
            //listaWezlow.Add(w3);  
            //listaWezlow.Add(w4);  
            //listaWezlow.Add(w5);  
            //listaWezlow.Add(w6);  
            //cbWezly.Items.AddRange(listaWezlow.ToArray());  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var w1 = new Wezel2(5);
            var w2 = new Wezel2(3);
            var w3 = new Wezel2(1);
            var w4 = new Wezel2(2);
            var w5 = new Wezel2(4);
            var w6 = new Wezel2(8);
            var w7 = new Wezel2(7);

            w1.Add(w2);
            w1.Add(w3);
            w2.Add(w4);
            w2.Add(w5);
            w3.Add(w6);
            w3.Add(w7);
            w4.Add(w6);
            w5.Add(w7);

            odwiedzone.Clear();
            temp.Add(w1);
            A_w_szerz(w1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var uuh = new DrzewoBinarne(5);
            uuh.Add(3);
            uuh.Add(2);
            uuh.Add(11);
            uuh.Add(4);
            //uuh.Add(6);
            MessageBox.Show(uuh.korzen.prawe_dziecko.wartosc.ToString());
        }
        
    }
}