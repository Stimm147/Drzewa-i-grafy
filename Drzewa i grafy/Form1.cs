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

        void A(Wezel w)
        {
            MessageBox.Show(w.ToString());

            foreach (var dziecko in w.dzieci)
            {
                A(dziecko);
            }
        }

        List<Wezel2> odwiedzone = new();

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

            A(w1);
        }
    }
}