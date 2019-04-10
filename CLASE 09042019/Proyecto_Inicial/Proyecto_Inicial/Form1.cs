﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Proyecto_Inicial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            DriveInfo[] u =DriveInfo.GetDrives();
            foreach (DriveInfo unidad in u)
            {
                try
                {
                    listBox1.Items.Add(unidad.Name);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Leyendo los discos"+ex.Message, "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            String unidades;
         //   unidades = listBox1.SelectedIndex.ToString();
            unidades = listBox1.SelectedItem.ToString();
            DriveInfo d = new DriveInfo(unidades);
            listBox2.Items.Add("Disco: "+d.Name+"\n");

            if(d.IsReady)
            {
                listBox2.Items.Add("Espacio Ocupado (GB) " + (d.TotalSize - d.TotalFreeSpace) / 1024 / 1024 / 1024 + " \n");
                listBox2.Items.Add("Espacio Disponible (GB) " + (d.TotalFreeSpace) / 1024 / 1024 / 1024 + " \n");
                listBox2.Items.Add("Espacio Total (GB) " + (d.TotalSize) / 1024 / 1024 / 1024 + " \n");
            }
            listBox2.Items.Add("Tipo de Disco Utilizado "+d.DriveType.ToString());
            listBox2.Items.Add("Tipo de Disco Formato " + d.DriveFormat.ToString());

            treeView1.Nodes.Clear();
            if(d.IsReady)
            {
                DirectoryInfo dir = new DirectoryInfo(unidades);
                foreach (DirectoryInfo sub in dir.GetDirectories())
                {
                    treeView1.Nodes.Add(sub.Name);
                }
                foreach (FileInfo file in dir.GetFiles())
                {
                    TreeNode nodo = new TreeNode();
                    nodo.Text = file.Name;
                    nodo.ForeColor = Color.Blue;
                    treeView1.Nodes.Add(nodo);
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String Dir = "C:/test";
            String arch="C:/prueba.txt";
            if(!Directory.Exists(Dir))
            {
                Directory.CreateDirectory(Dir);
            }
            else
            {
                MessageBox.Show("Existe el Directorio: " + Dir, "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            if (!File.Exists(arch))
            {
                File.Create(arch);
            }
            else
            {
                MessageBox.Show("Existe el Directorio: " + Dir, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}