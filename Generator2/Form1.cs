using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Generator2
{
    public partial class Form1 : Form
    {
        public static string locConnection = "User Id = s95522; Password = 9584626; Data Source = 217.173.198.135:1522/orcltp.iaii.local;";
        public static string[] imiona = { "Lena", "Jakub", "Julia", "Kacper", "Emilia", "Zuzanna", "Filip", "Maja", "Szymon", "Zofia", "Jan", "Amelia", "Antoni", "Hanna", "Michał", "Aleksandra", "Wojciech", "Wiktoria", "Mateusz", "Natalia", "Bartosz", "Oliwia", "Adam", "Alicja", "Franciszek", "Nikola", "Piotr", "Maria", "Aleksander", "Mikołaj", "Anna,", "Wiktor", "Nadia", "Igor", "Gabriela", "Marcel", "Martyna", "Dawid", "Antonina", "Alan", "Milena", "Oliwier", "Magdalena", "Maciej", "Laura", "Oskar", "Weronika", "Karol", "Karolina", "Tomasz", "Pola", "Maksymilian", "Agata", "Dominik", "Kornelia", "Stanisław", "Liliana", "Miłosz", "Iga", "Paweł", "Michalina", "Hubert", "Patrycja", "Krzysztof", "Paulina", "Kamil", "Kinga", "Patryk", "Nina", "Nikodem", "Jagoda", "Fabian", "Marta", "Bartłomiej", "Katarzyna", "Leon", "Joanna", "Sebastian", "Małgorzata", "Julian", "Klaudia", "Tymoteusz", "Helena", "Gabriel", "Barbara", "Tymon", "Dominika", "Krystian", "Kaja", "Ksawery", "Blanka", "Adrian", "Marcelina", "Ignacy", "Izabela", "Łukasz", "Ewa", "Błażej", "Łucja", "Marcin" };
        public static string[] nazwiska = { "Nowak", "Kowalski", "Wiśniewski", "Wójcik", "Kowalczyk", "Kamiński", "Lewandowski", "Zieliński", "Szymański", "Woźniak", "Dąbrowski", "Kozłowski", "Jankowski", "Mazur", "Wojciechowski", "Kwiatkowski", "Krawczyk", "Kaczmarek", "Piotrowski", "Grabowski", "Zając", "Pawłowski", "Michalski", "Król", "Wieczorek", "Jabłoński", "Wróbel", "Nowakowski", "Majewski", "Olszewski", "Stępień", "Malinowsk", "Jaworski", "Adamczy", "Dudek", "Nowicki", "Pawlak", "Górsk", "Witkowski", "Walczak", "Sikora", "Baran", "Rutkowski", "Michalak", "Szewczyk", "Ostrowski", "Tomaszewski", "Pietrzak", "Zalewski", "Wróblewski" };
        public static string[] plec = { "M", "F" };
        public static string[] obecnosc = { "N", "O" };
        public static string[] data_wystawienia = { "1998-01-14", "1997-12-12", "2000-12-15", "2010-03-09", "2020-01-01" };
        public static string[] miasta = { "Brzeg", "Opole", "Wroclaw", "Warszawa", "Gdansk" };
        public static double[] srednie = { 2.0, 3.46, 4.47, 5.00, 1.0 };
        public static string[] klasy_nazwy = { "1A", "1B", "2C", "4D", "3B" };
        public static string[] specjalnosc = { "Elektryczna", "Mechaniczna", "Informatyczna", "Teleinformatczyna", "Hotelarska" };
        public static string[] typ_oceny = { "Cząstkowa", "Semestralna", "Końcowo-roczna" };
        public static string[] przedmioty = { "Matematyka", "j.Polski", ".=j.Angielski" };

        public static OracleConnection connection = new OracleConnection(locConnection);
        public static OracleDataReader reader;

        public static Random random = new Random(0);
        public static Random random2 = new Random(15);
        public static Random random3 = new Random(20);
        public static Random random4 = new Random(4);
        public static Random random5 = new Random(63);
        public static Random random6 = new Random(45);

        public static int[] nauczyciele_id = new int[100000];
        public static int[] uczniowie_id = new int[100000];
        public static int[] klasy = new int[100000];
        public static int[] sale_id = new int[100000];
        public static int[] typ_oceny_id = new int[100000];
        public static int[] przedmioty_id = new int[100000];

        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("Nauczyciele");
            comboBox1.Items.Add("Oceny");
            comboBox1.Items.Add("Klasy");
            comboBox1.Items.Add("Uczniowie");
            comboBox1.Items.Add("Obecnosc");
            comboBox1.Items.Add("Typ Oceny");
            comboBox1.Items.Add("Sale");
            comboBox1.Items.Add("Sale zajęciowe");
            comboBox1.Items.Add("Przedmioty");
            comboBox1.Items.Add("Uczy");
            comboBox1.Text = "Nauczyciele";
          

        }
        public void importNaucz()
        {
            
            string sql = null;
            OracleCommand command;
            int losoweimie = random.Next(20);
            int losowenaz = random2.Next(40) + random3.Next(10);
            int losowaklasa = random4.Next(4);
            int losowaplec = random5.Next(2);
            int ilosc = Convert.ToInt32(textBox1.Text);
            int j = 0;

            connection.Open();
            sql = "Select klasy_id from klasy";
            command = new OracleCommand(sql, connection);
            command.CommandText = sql;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                klasy[j] = reader.GetInt32(0);
                j++;
            }

            connection.Close();
            
            for (int i = 1; i <= ilosc ; i++)
            {
                 losoweimie = random.Next(20);
                 losowenaz = random2.Next(40) + random3.Next(10);
                 losowaklasa = random4.Next(4);
                 losowaplec = random5.Next(2);
                 ilosc = Convert.ToInt32(textBox1.Text);

                sql = "INSERT INTO nauczyciele(nauczyciele_ID,imie,nazwisko,klasy_klasy_id,plec)" +
                    " VALUES(nauczyciele_seq.nextval," + "'" + imiona[losoweimie] + "'" + "," + "'" + nazwiska[losowenaz] + "'," + "'" + klasy[losowaklasa] + "','" + plec[losowaplec] + "'" + ")";

                Console.WriteLine(i);
                using (StreamWriter save = File.AppendText(@"D:\insert_do_nauczycieli.txt"))
                {

                    connection.Open();
                    save.WriteLine(sql);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                    
                }
                progressBar1.Value = i * progressBar1.Maximum / ilosc;
                connection.Close();
            }
            
        }
        public void importUczni()
        {

            string sql = null;
            OracleCommand command;
            int losoweimie;
            int losowenaz;
            int losowadata;
            int losowaplec;
            int losowe_miasto;
            int losowe_miejsce;
            int losowa_klasa;
            int losowa_srednia;
            int ilosc = Convert.ToInt32(textBox1.Text);
            int j = 0;

            connection.Open();
            sql = "Select klasy_id from klasy";
            command = new OracleCommand(sql, connection);
            command.CommandText = sql;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                klasy[j] = reader.GetInt32(0);
                j++;
            }

          
        
            connection.Close();

            for (int i = 1; i <= ilosc; i++)
            {
                losoweimie = random.Next(20);
                losowenaz  =  random2.Next(40) + random3.Next(10);
                losowadata = random4.Next(5);
                losowaplec = random5.Next(2);
                losowe_miasto = random.Next(5);
                losowe_miejsce = random2.Next(5);
                losowa_klasa = random.Next(5);
                losowa_srednia = random3.Next(srednie.Count() - 1);

                ilosc = Convert.ToInt32(textBox1.Text);

                sql = "INSERT INTO uczniowie(imie,nazwisko,data_urodzenia,miejsce_urodzenia,miejsce_zamieszkania,plec,srednia,uczniowie_id,klasy_klasy_id)" +
                    " VALUES('" + imiona[losoweimie] + "','" + nazwiska[losowenaz] + "',TO_DATE('" + data_wystawienia[losowadata] + "','YYYY-MM-DD'),'"+ miasta[losowe_miejsce] +"','"+ miasta[losowe_miasto] +"','" + plec[losowaplec] +"','"+ srednie[losowa_srednia] +"',uczniowie_seq.nextval,'"+ klasy[losowa_klasa] +"')";

                Console.WriteLine(i);
                using (StreamWriter save = File.AppendText(@"D:\insert_do_uczniowie.txt"))
                {

                    connection.Open();
                    save.WriteLine(sql);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();

                }
                progressBar1.Value = i * progressBar1.Maximum / ilosc;
                connection.Close();
            }

        }
        public void importKlasy()
        {

            string sql = null;
            OracleCommand command;
            int losoweimie = random.Next(20);
            int losowenaz = random2.Next(40) + random3.Next(10);
            int losowaklasa = random4.Next(4);
            int losowaplec = random5.Next(2);
            int ilosc = Convert.ToInt32(textBox1.Text);
            command = new OracleCommand(sql, connection);



            for (int i = 1; i <= ilosc; i++)
            {
                losoweimie = random.Next(4);
                losowenaz = random2.Next(4);
                losowaklasa = random4.Next(4);
                ilosc = Convert.ToInt32(textBox1.Text);

                sql = "INSERT INTO klasy(klasy_id,nazwa,specjalnosc,data_rozpoczecia)" +
                    " VALUES(klasy_seq.nextval,'" + klasy_nazwy[losoweimie] + "','" + specjalnosc[losowenaz] + "',TO_DATE('" + data_wystawienia[losowaklasa] + "','YYYY-MM-DD'))";

                Console.WriteLine(i);
                using (StreamWriter save = File.AppendText(@"D:\inserty_do_klas.txt"))
                {

                    connection.Open();
                    save.WriteLine(sql);
                    
                    command.CommandText = sql;
                    command.ExecuteNonQuery();

                }
                progressBar1.Value = i * progressBar1.Maximum / ilosc;
                connection.Close();
            }

        }
        public void importOceny()
        {

            string sql = null;
            OracleCommand command;
            int losoweimie;
            int losowenaz;
            int losowaklasa;
            int losowaplec;
            int losowy_typ;
            int losowy_uczen;
            int ilosc = Convert.ToInt32(textBox1.Text);
            int j = 0;
            int k = 0;
            int l = 0;
            int p = 0;

            connection.Open();
            sql = "Select nauczyciele_id from nauczyciele";
            command = new OracleCommand(sql, connection);
            command.CommandText = sql;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                nauczyciele_id[j] = reader.GetInt32(0);
                j++;
            }

            sql = "Select przedmioty_id from przedmioty";
            command = new OracleCommand(sql, connection);
            command.CommandText = sql;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                przedmioty_id[k] = reader.GetInt32(0);
                k++;
            }

            sql = "Select typ_oceny_id from typ_oceny";
            command = new OracleCommand(sql, connection);
            command.CommandText = sql;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                typ_oceny_id[l] = reader.GetInt32(0);
                l++;
            }

            sql = "Select uczniowie_id from uczniowie";
            command = new OracleCommand(sql, connection);
            command.CommandText = sql;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                uczniowie_id[p] = reader.GetInt32(0);
                p++;
            }

            connection.Close();

            for (int i = 1; i <= ilosc; i++)
            {
                losoweimie = random.Next(4);
                losowenaz = random2.Next(4);
                losowaklasa = random4.Next(4);
                losowaplec = random5.Next(4);
                losowy_typ = random3.Next(4);
                losowy_uczen = random6.Next(4);
                ilosc = Convert.ToInt32(textBox1.Text);

                sql = "INSERT INTO oceny(ocena, data_wystawienia, nauczyciele_nauczyciele_id, przedmiony_przedmiony_id, typ_oceny_typ_oceny_id, uczniowie_uczniowie_id, id_oceny)" +
                      " VALUES(" + losowaklasa + ", TO_DATE('" + data_wystawienia[losowenaz] + "','YYYY-MM-DD'), " + nauczyciele_id[losoweimie] + ", " + przedmioty_id[losowaplec] + ", " + typ_oceny_id[losowy_typ] + ", " + uczniowie_id[losowy_uczen] + ", oceny_seq.nextval)";

                Console.WriteLine(i);
                using (StreamWriter save = File.AppendText(@"D:\insert_do_ocen.txt"))
                {

                    connection.Open();
                    save.WriteLine(sql);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();

                }
                progressBar1.Value = i * progressBar1.Maximum / ilosc;
                connection.Close();
            }

        }
        public void importPrzedmioty()
        {

            string sql = null;
            OracleCommand command;
            int losoweimie = random.Next(20);
            int losowenaz = random2.Next(40) + random3.Next(10);
            int losowaklasa = random4.Next(4);
            int losowaplec = random5.Next(2);
            int ilosc = Convert.ToInt32(textBox1.Text);
            int j = 0;

        

            for (int i = 1; i <= ilosc; i++)
            {
                losoweimie = random.Next(20);
                losowenaz = random2.Next(40) + random3.Next(10);
                losowaklasa = random4.Next(4);
                losowaplec = random5.Next(2);
                ilosc = Convert.ToInt32(textBox1.Text);

                sql = "insert into przedmioty(nazwa,przedmioty_id)" +
                     "VALUES('" + przedmioty[losowaplec] + "', przedmioty_seq.nextval)";

                Console.WriteLine(i);
                using (StreamWriter save = File.AppendText(@"D:\insert_do_przedmioty.txt"))
                {

                    connection.Open();
                    save.WriteLine(sql);
                    command = new OracleCommand(sql, connection);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();

                }
                progressBar1.Value = i * progressBar1.Maximum / ilosc;
                connection.Close();
            }

        }
        public void importSale()
        {

            string sql = null;
            OracleCommand command;
            int losoweimie = random.Next(20);
            int losowenaz = random2.Next(40) + random3.Next(10);
            int losowaklasa = random4.Next(4);
            int losowaplec = random5.Next(2);
            int ilosc = Convert.ToInt32(textBox1.Text);
            int j = 0;

            connection.Open();
            sql = "Select nauczyciele_id from nauczyciele";
            command = new OracleCommand(sql, connection);
            command.CommandText = sql;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                nauczyciele_id[j] = reader.GetInt32(0);
                j++;
            }

            connection.Close();

            for (int i = 1; i <= ilosc; i++)
            {
                losoweimie = random.Next(5);
                
                losowaklasa = random4.Next(4);
                
                ilosc = Convert.ToInt32(textBox1.Text);

                sql = "insert into sala(numer_sali,sala_id,nauczyciele_nauczyciele_id)" +
                    " VALUES(" + losowaklasa + ",sale_seq.nextval,'" + nauczyciele_id[losoweimie] + "')";

                Console.WriteLine(i);
                using (StreamWriter save = File.AppendText(@"D:\insert_sale.txt"))
                {

                    connection.Open();
                    save.WriteLine(sql);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();

                }
                progressBar1.Value = i * progressBar1.Maximum / ilosc;
                connection.Close();
            }

        }
        public void importSale_zaj()
        {

            string sql = null;
            OracleCommand command;
            int losowaklasa;
            int losowaplec;
            int ilosc = Convert.ToInt32(textBox1.Text);
            int j = 0;
            int k = 0;

            connection.Open();
            sql = "Select uczniowie_id from uczniowie";
            command = new OracleCommand(sql, connection);
            command.CommandText = sql;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                uczniowie_id[j] = reader.GetInt32(0);
                j++;
            }
           
            sql = "Select sala_id from sala";
            command.CommandText = sql;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                sale_id[k] = reader.GetInt32(0);
                k++;
            }

            connection.Close();

            for (int i = 1; i <= ilosc; i++)
            {
                losowaklasa = random4.Next(4);
                losowaplec = random5.Next(2);
                ilosc = Convert.ToInt32(textBox1.Text);

                sql = "insert into sala_zajeciowa(uczniowie_uczniowie_id,sala_sala_id,sala_zj_id)" +
                     " VALUES('" + uczniowie_id[losowaklasa] + "','" + sale_id[losowaplec] + "',sale_zj_seq.nextval)";

                Console.WriteLine(i);
                using (StreamWriter save = File.AppendText(@"D:\insert_sale_zajeciowe.txt"))
                {

                    connection.Open();
                    save.WriteLine(sql);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();

                }
                progressBar1.Value = i * progressBar1.Maximum / ilosc;
                connection.Close();
            }

        }
        public void importObecnosc()
        {

            string sql = null;
            OracleCommand command;
            
           
            int losowaobecnosc = random5.Next(2);
            int ilosc = Convert.ToInt32(textBox1.Text);
            int j = 0;

            connection.Open();
            sql = "Select uczniowie_id from uczniowie";
            command = new OracleCommand(sql, connection);
            command.CommandText = sql;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                uczniowie_id[j] = reader.GetInt32(0);
                j++;
            }

            connection.Close();

            for (int i = 1; i <= ilosc; i++)
            {
                
                
                losowaobecnosc = random5.Next(2);
                ilosc = Convert.ToInt32(textBox1.Text);

                sql = "INSERT INTO obecność(obecność,uczniowie_uczniowie_id,id_obecnosc)" +
                    " Values('" + obecnosc[losowaobecnosc] + "'," + uczniowie_id[losowaobecnosc] + ",obecnosc_seq.nextval)"; 

                Console.WriteLine(i);
                using (StreamWriter save = File.AppendText(@"D:\inserty_do_obecnosci.txt"))
                {

                    connection.Open();
                    save.WriteLine(sql);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();

                }
                progressBar1.Value = i * progressBar1.Maximum / ilosc;
                connection.Close();
            }

        }
        public void importTyp_Oceny()
        {

            string sql = null;
            OracleCommand command;
            int losoweimie = random.Next(20);
            int losowenaz = random2.Next(40) + random3.Next(10);
            int losowaklasa = random4.Next(4);
            int losowaplec = random5.Next(2);
            int ilosc = Convert.ToInt32(textBox1.Text);
            int j = 0;

            connection.Open();
            sql = "Select klasy_id from klasy";
            command = new OracleCommand(sql, connection);
            command.CommandText = sql;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                klasy[j] = reader.GetInt32(0);
                j++;
            }

            connection.Close();

            for (int i = 1; i <= ilosc; i++)
            {
               
                losowaplec = random5.Next(2);
                ilosc = Convert.ToInt32(textBox1.Text);

                sql = "INSERT INTO typ_oceny(typ_oceny,typ_oceny_id)" +
                       " VALUES('" + typ_oceny[losowaplec] + "',typ_seq.nextval)";

                Console.WriteLine(i);
                using (StreamWriter save = File.AppendText(@"D:\insert_typ.txt"))
                {

                    connection.Open();
                    save.WriteLine(sql);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();

                }
                progressBar1.Value = i * progressBar1.Maximum / ilosc;
                connection.Close();
            }

        }
        public void importUczy()
        {

            string sql = null;
            OracleCommand command;
            int losowaklasa;
            int losowaplec;
            int ilosc = Convert.ToInt32(textBox1.Text);
            int j = 0;
            int k = 0;

            connection.Open();
            sql = "Select nauczyciele_id from nauczyciele";
            command = new OracleCommand(sql, connection);
            command.CommandText = sql;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                nauczyciele_id[j] = reader.GetInt32(0);
                j++;
            }

            sql = "Select przedmioty_id from przedmioty";
            command.CommandText = sql;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                przedmioty_id[k] = reader.GetInt32(0);
                k++;
            }

            connection.Close();

            for (int i = 1; i <= ilosc; i++)
            {
                losowaklasa = random4.Next(4);
                losowaplec = random5.Next(2);
                ilosc = Convert.ToInt32(textBox1.Text);

                sql = "INSERT INTO uczy(nauczyciele_nauczyciele_id,przedmiony_przedmiony_id,uczy_id)" +
                      " VALUES('" + nauczyciele_id[losowaklasa] + "','" + przedmioty_id[losowaplec] + "',uczy_seq.nextval)";

                Console.WriteLine(i);
                using (StreamWriter save = File.AppendText(@"D:\Insert_do_uczy.txt"))
                {

                    connection.Open();
                    save.WriteLine(sql);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();

                }
                progressBar1.Value = i * progressBar1.Maximum / ilosc;
                connection.Close();
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "Nauczyciele")
                {
                    label1.Text = "";
                    importNaucz();
                    label1.Text = "done";
                    progressBar1.Value = 0;
                }
                else if (comboBox1.Text == "Oceny")
                {
                    label1.Text = "";
                    importOceny();
                    label1.Text = "done";
                    progressBar1.Value = 0;
                }
                else if (comboBox1.Text == "Przedmioty")
                {
                    label1.Text = "";
                    importPrzedmioty();
                    label1.Text = "done";
                    progressBar1.Value = 0;
                }
                else if (comboBox1.Text == "Sale")
                {
                    label1.Text = "";
                    importSale();
                    label1.Text = "done";
                    progressBar1.Value = 0;
                }
                else if (comboBox1.Text == "Sale zajęciowe")
                {
                    label1.Text = "";
                    importSale_zaj();
                    label1.Text = "done";
                    progressBar1.Value = 0;
                }
                else if (comboBox1.Text == "Uczniowie")
                {
                    label1.Text = "";
                    importUczni();
                    label1.Text = "done";
                    progressBar1.Value = 0;
                }
                else if (comboBox1.Text == "Typ Oceny")
                {
                    label1.Text = "";
                    importTyp_Oceny();
                    label1.Text = "done";
                    progressBar1.Value = 0;
                }
                else if (comboBox1.Text == "Obecnosc")
                {
                    label1.Text = "";
                    importObecnosc();
                    label1.Text = "done";
                    progressBar1.Value = 0;
                }
                else if (comboBox1.Text == "Klasy")
                {
                    label1.Text = "";
                    importKlasy();
                    label1.Text = "done";
                    progressBar1.Value = 0;
                }
                else if (comboBox1.Text == "Uczy")
                {
                    label1.Text = "";
                    importUczy();
                    label1.Text = "done";
                    progressBar1.Value = 0;
                }
            }
            catch(FormatException)
            {
                MessageBox.Show("Prosze wpisać liczbę");
                
            }
            catch(OracleException)
            {
                MessageBox.Show("Tabela nieistnieje");
            }
            finally
            {
                connection.Close();
            }
           

        }

       
    }
}
