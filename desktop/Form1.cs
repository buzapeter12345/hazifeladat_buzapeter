using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vizsgagyakKonyvesWinform
{
    public partial class Form1 : Form
    {
        List<Book> list = new List<Book>();
        public Form1()
        {
            InitializeComponent();

            string[] lines = File.ReadAllLines("books.txt");
            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                Book obj = new Book(values[0], values[1], values[2], values[3], values[4]);
                list.Add(obj);
            }

            int osszDb = 0;
            foreach (var i in list)
            {
                osszDb += i.db;
            }

            label1.Text = $"Az össz darabszám: {osszDb} db";

            List<Book> legdragabbak = new List<Book>();
            Book legdragabb = list[0];
            legdragabbak.Add(legdragabb);

            foreach (var termek in list)
            {
                if (termek.ar > legdragabb.ar)
                {
                    legdragabb = termek;
                    legdragabbak.Clear();
                    legdragabbak.Add(legdragabb);
                }
                else if (termek.ar == legdragabb.ar)
                {
                    legdragabbak.Add(termek);
                }
            }

            foreach (var i in legdragabbak)
            {
                dataGridView1.Rows.Add(i.kategoria, i.cim, i.ar);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedCategory = comboBox1.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedCategory))
            {
                var selectedProducts = list.Where(t => t.kategoria.Equals(selectedCategory)).ToList();

                listBox1.Items.Clear();

                foreach (var i in selectedProducts)
                {
                    listBox1.Items.Add($"Cím: {i.cim}, Ár: {i.ar}, Darabszám: {i.db}");
                }
            }
        }
    }
}
