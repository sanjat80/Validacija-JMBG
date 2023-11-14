using System.Text.RegularExpressions;

namespace Validacija_JMBG
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

        private void btnValidiraj_Click(object sender, EventArgs e)
        {
            string ime = txtIme.Text;
            string prezime = txtPrezime.Text;
            string maticni = txtJMBG.Text;
            if (maticni.Length != 13)
            {
                MessageBox.Show("Maticni broj nije validan! Svaki maticni broj mora da sadrzi tacno 13 karaktera!","Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!Regex.IsMatch(maticni, @"^\d+$"))
            {
                MessageBox.Show("Maticni broj nije validan! Svaki maticni broj mora sadrzati iskljucivo brojeve!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string rr = maticni.Substring(6, 2);
                int bbb = Convert.ToInt32(maticni.Substring(9, 3));
                int k = Convert.ToInt32(maticni.Substring(12,1));
                string datum = maticni.Substring(0, 7);
                string dan = datum.Substring(0, 2);
                string mjesec = datum.Substring(2, 2);
                string godina = datum.Substring(4, 3);
                if (ValidirajDatumRodjenja(datum))
                {
                    if (ValidacijaRRRBroja(rr))
                    {
                        string lokacija = VratiLokaciju(rr);
                        string polGradjana = NadjiPol(bbb);
                        if (polGradjana == null)
                        {
                            MessageBox.Show("Maticni broj nije validan! Broj kojim se oznacava pol gradjana nije u dozvoljenom opsegu (0-999)!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        int kontrolna = IzracunajKontrolnuCifru(maticni);
                        if (kontrolna != k)
                        {
                            MessageBox.Show("Maticni broj nije validan! Kontrolna cifra se ne poklapa sa vrijednoscu koja se dobija racunanjem po formuli, na osnovu proslijedjenih podataka!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show($"Maticni broj je validan. Vasi podaci su:" +
                                $"\n Ime: {ime}" +
                                $"\n Prezime: {prezime}" +
                                $"\n Maticni broj: {maticni}" +
                                $"\n Region: {lokacija}" +
                                $"\n Pol gradjana: {polGradjana}" +
                                $"\n Datum rodjenja: {dan}.{mjesec}.{godina}."+
                                $"\n Kontrolna cifra: {kontrolna}");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Maticni broj nije validan! Navedena politicka regija ne postoji!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Maticni broj nije validan! Datum koji ste naveli nije ispravan!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool ValidacijaRRRBroja(string rrrBroj)
        {
            return Regex.IsMatch(rrrBroj, @"^[0-9]{2}$");
        }
        private static Dictionary<string, string> KreirajRečnik()
        {
            return new Dictionary<string, string>
        {
            {"00", "Stranci bez državljanstva bivše SFRJ ili njenih naslednica"},{"01", "Stranci u BiH"},{"02", "Stranci u Crnoj Gori"},{"03", "Stranci u Hrvatskoj"},
            {"04", "Stranci u Makedoniji"},{"05", "Stranci u Sloveniji"},{"07", "Stranci u Srbiji (bez pokrajina)"},
            {"08", "Stranci u Vojvodini"},{"09", "Stranci na Kosovu i Metohiji"},{"10", "Banja Luka"},
            {"11", "Bihać"},{"12", "Doboj"},{"13", "Goražde"},{"14", "Livno"},{"15", "Mostar"},{"16", "Prijedor"},
            {"17", "Sarajevo"},
            {"18", "Tuzla"},
            {"19", "Zenica"},
            {"20", "Podgorica"},
            {"21", "Nikšić"},
            {"26", "Pljevlja"},
            {"30", "Osijek, Slavonija region"},
            {"31", "Bjelovar, Virovitica, Koprivnica, Pakrac, Podravina region"},
            {"32", "Varaždin, Međimurje region"},
            {"33", "Zagreb"},
            {"34", "Karlovac"},
            {"35", "Gospić, Lika region"},
            {"36", "Rijeka, Pula, Istra and Primorje region"},
            {"37", "Sisak, Banovina region"},
            {"38", "Split, Zadar, Dubrovnik, Dalmacija region"},
            {"39", "Ostalo"},
            {"41", "Bitola"},
            {"42", "Kumanovo"},
            {"43", "Ohrid"},
            {"44", "Prilep"},
            {"45", "Skopje"},
            {"46", "Strumica"},
            {"47", "Tetovo"},
            {"48", "Veles"},
            {"49", "Štip"},
            {"50", "Slovenija"},
            {"71", "Beograd region"},
            {"72", "Šumadija"},
            {"73", "Niš region"},
            {"74", "Južna Morava"},
            {"75", "Zaječar"},
            {"76", "Podunavlje"},
            {"77", "Podrinje i Kolubara"},
            {"78", "Kraljevo region"},
            {"79", "Užice region"},
            {"80", "Novi Sad region"},
            {"81", "Sombor region"},
            {"82", "Subotica region"},
            {"85", "Zrenjanin region"},
            {"86", "Pančevo region"},
            {"87", "Kikinda region"},
            {"88", "Ruma region"},
            {"89", "Sremska Mitrovica region"},
            {"90", "Priština region"},
            {"91", "Kosovska Mitrovica region"},
            {"92", "Peć region"},
            {"93", "Đakovica region"},
            {"94", "Prizren region"},
            {"95", "Kosovsko Pomoravski okrug"}
         };
        }
        private string VratiLokaciju(string kljuc)
        {
            Dictionary<string, string> lokacije = KreirajRečnik();
            string lokacija = PronadjiLokaciju(kljuc, lokacije);
            if (lokacija != null)
            {
                return lokacija;
            }
            else
            {
                return null;
            }
        }
        static string PronadjiLokaciju(string kljuc, Dictionary<string, string> lokacije)
        {
            // Provera da li ključ postoji u rečniku
            if (lokacije.ContainsKey(kljuc))
            {
                // Vraćanje odgovarajuće lokacije
                return lokacije[kljuc];
            }
            else
            {
                // Ako ključ nije pronađen
                return null;
            }
        }
        private int IzracunajKontrolnuCifru(string maticniBroj)
        {
            int A = Convert.ToInt32(maticniBroj.Substring(0,1));
            int B = Convert.ToInt32(maticniBroj.Substring(1,1));
            int V = Convert.ToInt32(maticniBroj.Substring(2,1));
            int G = Convert.ToInt32(maticniBroj.Substring(3, 1));
            int D = Convert.ToInt32(maticniBroj.Substring(4, 1));
            int Dj = Convert.ToInt32(maticniBroj.Substring(5, 1));
            int E = Convert.ToInt32(maticniBroj.Substring(6, 1));
            int Y = Convert.ToInt32(maticniBroj.Substring(7, 1));
            int Z = Convert.ToInt32(maticniBroj.Substring(8, 1));
            int I = Convert.ToInt32(maticniBroj.Substring(9, 1));
            int J = Convert.ToInt32(maticniBroj.Substring(10, 1));
            int K = Convert.ToInt32(maticniBroj.Substring(11, 1));
            int L = Convert.ToInt32(maticniBroj.Substring(12, 1));
            int kontrolnaCifra = Convert.ToInt32(11 - ((7 * (A + E) + 6 * (B + Y) + 5 * (V + Z) + 4 * (G + I) + 3 * (D + J) + 2 * (Dj + K)) % 11));
            if(kontrolnaCifra >=1 && kontrolnaCifra <=9)
            {
                return kontrolnaCifra;
            }
            else
            {
                return 0;
            }
        }
        private string NadjiPol(int bbb)
        {
            string pol;
            if (bbb >= 000 && bbb <= 999)
            {
                if (bbb >= 000 && bbb <= 499)
                {
                    pol = "Muski";
                }
                else
                {
                    pol = "Zenski";
                }
                return pol;
            }
            else
            {
                return null;
            }
        }
        static bool ValidirajDatumRodjenja(string datumRodjenja)
        {
            int dan = Convert.ToInt32(datumRodjenja.Substring(0, 2));
            int mjesec = Convert.ToInt32(datumRodjenja.Substring(2, 2));
            int godina = Convert.ToInt32(datumRodjenja.Substring(4, 3));
            int prvaCifra = Convert.ToInt32(datumRodjenja.Substring(4, 1));
            if(prvaCifra == 0)
            {
                godina += 2000;
            }
            else
            {
                godina+=1000;
            }
            if (godina < 1950 || godina > 2023)
            {
                return false;
            }
            if (mjesec < 1 || mjesec > 12)
            {
                return false;
            }
            int brojDanaUMjesecu = DateTime.DaysInMonth(godina, mjesec);
            if (dan < 1 || dan > brojDanaUMjesecu)
            {
                return false;
            }
            if (mjesec == 2 && (brojDanaUMjesecu == 30 || brojDanaUMjesecu == 31))
            {
                return false;
            }
            if (mjesec == 2 && brojDanaUMjesecu == 29 && !JePrestupnaGodina(godina))
            {
                return false;
            }

            return true;
        }

        static bool JePrestupnaGodina(int godina)
        {
            if(DateTime.IsLeapYear(godina))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}