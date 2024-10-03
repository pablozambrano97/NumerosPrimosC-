using CalculadoraNumerosPrimos_Domain;
using CalculadoraNumerosPrimos_Soporte;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraNumerosPrimos
{
    public partial class FrmPrincipal : Form
    {
        private int childFormNumber = 0;

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            int rangoMenor = 0;
            int rangoMayor = 0;
            List<int> numerosPrimos = new List<int>();

            if (rdBtnrRango1.Checked)
            {
                rangoMenor = 1;
                rangoMayor = 99;
            }
            else if (rdBtnrRango2.Checked)
            {
                rangoMenor = 100;
                rangoMayor = 999;
            }
            else if (rdBtnrRango3.Checked)
            {
                rangoMenor = 1000;
                rangoMayor = 9999;
            }
            else if (rdBtnrRango4.Checked)
            {
                rangoMenor = 10000;
                rangoMayor = 99999;
            }
            else if (rdBtnrRango5.Checked)
            {
                rangoMenor = 100000;
                rangoMayor = 999999;
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();


            if (!rdBtnrRango1.Checked &&
                !rdBtnrRango2.Checked &&
                !rdBtnrRango3.Checked &&
                !rdBtnrRango4.Checked &&
                !rdBtnrRango5.Checked)
            {
                MessageBox.Show("Por favor seleccione un rango.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                CalcularDTO calcularDTO = new CalcularDTO()
                {
                    RangoMenor = rangoMenor,
                    RangoMayor = rangoMayor
                };

                List<CalcularDTO> resultado = CalculoDomain.CalcularNumero(calcularDTO);
                foreach (var item in resultado)
                {
                    numerosPrimos.Add(item.numeroPrimo);
                }
            }
            sw.Stop();
            double tSegundos = sw.Elapsed.TotalSeconds;
            txtTiempo.Text = tSegundos.ToString();
            txtNumeroMenor.Text = numerosPrimos[0].ToString();
            txtNumeroMayor.Text = numerosPrimos[numerosPrimos.Count-1].ToString();
            txtCantidad.Text=numerosPrimos.Count.ToString();
            txtRango.Text = rangoMenor.ToString() + "-" +rangoMayor.ToString();
        }
        
    }
}
