﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using WindowsFormsApp1.Properties;
using System.Net.NetworkInformation;


namespace WindowsFormsApp1
{
    public partial class FormMain : Form
    {

        private Rectangle buttonOriginalRectangle;
        private Rectangle originalFormSize;

        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;

        private DataSet ds = new DataSet();
        private string alamat, query;
        public FormMain()
        {
            alamat = "server=localhost; database=db_vdean; username=root; password=;";
            koneksi = new MySqlConnection(alamat);

            InitializeComponent();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                query = string.Format("insert into `data_mahasiswa` (`nomor`,`nama_mahasiswa`, `status`, `jumlah_poin`, `seating`) VALUES ('{0}','{1}', '{2}','{3}','{4}')", txtNomor.Text, txtNama.Text, txtStatus.Text, txtPoin.Text, txtSeating.Text);
                
                koneksi.Open();
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                int res = perintah.ExecuteNonQuery();

                koneksi.Close();
                if (res == 1)
                {
                    MessageBox.Show("Sukses menambahkan data.");
                    FormMain_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Penambahan data gagal");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                query = string.Format("UPDATE `data_mahasiswa` SET `nama_mahasiswa`='{0}',`status`='{1}',`jumlah_poin`='{2}',`seating`='{3}' where nomor = '{4}'", txtNama.Text, txtStatus.Text, txtPoin.Text, txtSeating.Text, txtNomor.Text);
                ds.Clear();
                koneksi.Open();
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                adapter.Fill(ds);
                koneksi.Close();

                FormMain_Load(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                koneksi.Open();
                query = string.Format("delete from data_mahasiswa where nomor = '{0}'", txtNomor.Text);
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                ds.Clear();
                adapter.Fill(ds);
                koneksi.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                FormMain_Load(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtNama_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                koneksi.Open();
                query = string.Format("SELECT `nomor`, `nama_mahasiswa`, `status`, `jumlah_poin`, `seating` FROM `data_mahasiswa` WHERE nomor = '{0}'", txtNomor.Text);
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                ds.Clear();
                adapter.Fill(ds);
                koneksi.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow kolom in ds.Tables[0].Rows)
                    {
                        txtNomor.Text = kolom["nomor"].ToString();
                        txtNama.Text = kolom["nama_mahasiswa"].ToString();
                        txtStatus.Text = kolom["status"].ToString();
                        txtPoin.Text = kolom["jumlah_poin"].ToString();
                        txtSeating.Text = kolom["seating"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            try
            {
                koneksi.Open();
                query = string.Format("SELECT  `nama_mahasiswa`, `status`, `jumlah_poin`, `seating` FROM `data_mahasiswa` WHERE nama_mahasiswa = '{0}'", txtNama.Text);
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                ds.Clear();
                adapter.Fill(ds);
                koneksi.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow kolom in ds.Tables[0].Rows)
                    {
                        txtNomor.Text = kolom["nomor"].ToString();
                        txtNama.Text = kolom["nama_mahasiswa"].ToString();
                        txtStatus.Text = kolom["status"].ToString();
                        txtPoin.Text = kolom["jumlah_poin"].ToString();
                        txtSeating.Text = kolom["seating"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            try
            {
                koneksi.Open();
                query = string.Format("SELECT `nomor`, `nama_mahasiswa`, `status`, `jumlah_poin`, `seating` FROM `data_mahasiswa` WHERE seating = '{0}'", txtSeating.Text);
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                ds.Clear();
                adapter.Fill(ds);
                koneksi.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow kolom in ds.Tables[0].Rows)
                    {
                        txtNomor.Text = kolom["nomor"].ToString();
                        txtNama.Text = kolom["nama_mahasiswa"].ToString();
                        txtStatus.Text = kolom["status"].ToString();
                        txtPoin.Text = kolom["jumlah_poin"].ToString();
                        txtSeating.Text = kolom["seating"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            originalFormSize = new Rectangle(this.Location.X, this.Location.Y, this.Size.Width, this.Size.Height);
            buttonOriginalRectangle = new Rectangle(button3.Location.X, button3.Location.Y, button3.Width, button3.Height);

            try
            {
                koneksi.Open();
                query = string.Format("Select * from data_mahasiswa");
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                ds.Clear();
                adapter.Fill(ds);
                koneksi.Close();

                dataGridView2.DataSource = ds.Tables[0];
                dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView2.Columns[0].HeaderText = "Nomor";
                dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView2.Columns[1].HeaderText = "Nama";
                dataGridView2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView2.Columns[2].HeaderText = "Tempat Tinggal";
                dataGridView2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView2.Columns[3].HeaderText = "Jumlah Poin";
                dataGridView2.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView2.Columns[4].HeaderText = "Sitting Ibadah";

                txtNomor.Clear();
                txtNama.Clear();
                txtStatus.Clear();
                txtPoin.Clear();
                txtSeating.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void resizeControl(Rectangle r, Control c)
        {
            float xRatio = (float)(this.Width) / (float)(originalFormSize.Width);
            float yRatio = (float)(this.Height) / (float)(originalFormSize.Height);

            int newX = (int)(r.Width * xRatio);
            int newY = (int)(r.Height * yRatio);

            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);

            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           regist regist1 = new regist();
            regist1.Show();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            resizeControl(buttonOriginalRectangle, button3);
            resizeControl(buttonOriginalRectangle, btnClear);
            resizeControl(buttonOriginalRectangle, btnSearch);
            resizeControl(buttonOriginalRectangle, btnUpdate);
            resizeControl(buttonOriginalRectangle, btnDelete);
        }
    }
}