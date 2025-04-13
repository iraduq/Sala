using System.Windows.Forms;
using System;
using System.Drawing;
using SalaDeFitness.LibrarieModele;
using SalaDeFitness.NivelStocareDate;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Interfata.Validari;



namespace Interfata
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// 
        private Button btnClienti;
        private Button btnAntrenori;
        private Button btnAngajat;
        private Button btnAbonament;
        private Button btnHome;


        private Button btnAdaugareClient;
        private Button btnAfisareClienti;
        private Button btnCautaClient;
        private Button btnBackClienti;

        private Label lblDetaliiAntrenori;

        private AdministrareClienti_FisierText adminClienti;
        private AdministrareAntrenori_FisierText adminAntrenori;
        private AdministrareAngajati_FisierText adminAngajati;
        private AdministrareAbonamenteClienti_FisierText adminAbonamente;

        private void InitializeComponent()
        {
            string locatieFisierSolutie = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string numeFisierClienti = "clienti.txt";
            string numeFisierAntrenori = "antrenori.txt";
            string numeFisierAngajati = "angajati.txt";
            string numeFisierAbonamente = "abonamente.txt";

            AddHomeButton();

            string caleCompletaFisierClienti = Path.Combine(locatieFisierSolutie, numeFisierClienti);
            string caleCompletaFisierAntrenori = Path.Combine(locatieFisierSolutie, numeFisierAntrenori);
            string caleCompletaFisierAngajati = Path.Combine(locatieFisierSolutie, numeFisierAngajati);
            string caleCompletaFisierAbonamente = Path.Combine(locatieFisierSolutie, numeFisierAbonamente);


            adminClienti = new AdministrareClienti_FisierText(caleCompletaFisierClienti);
            adminAntrenori = new AdministrareAntrenori_FisierText(caleCompletaFisierAntrenori);
            adminAngajati = new AdministrareAngajati_FisierText(caleCompletaFisierAngajati);
            adminAbonamente = new AdministrareAbonamenteClienti_FisierText(caleCompletaFisierAbonamente);


            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Gestionare sala fitness";

            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E2236");

            btnClienti = new Button();
            btnAntrenori = new Button();
            btnAngajat = new Button();
            btnAbonament = new Button();


            Font buttonFont = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);

            int buttonWidth = 200;
            int buttonHeight = 50;
            int spaceBetweenButtons = 20;

            int centerX = (this.ClientSize.Width - buttonWidth) / 2;
            int startY = (this.ClientSize.Height - (buttonHeight * 4) - (spaceBetweenButtons * 3)) / 2;

            btnClienti.Text = "Clienti";
            btnClienti.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            btnClienti.Location = new System.Drawing.Point(centerX, startY);
            btnClienti.BackColor = System.Drawing.ColorTranslator.FromHtml("#2F3347");
            btnClienti.ForeColor = System.Drawing.Color.White;
            btnClienti.Font = buttonFont;
            btnClienti.FlatStyle = FlatStyle.Flat;
            btnClienti.FlatAppearance.BorderSize = 0;
            btnClienti.Click += BtnClienti_Click;


            btnAntrenori.Text = "Antrenori";
            btnAntrenori.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            btnAntrenori.Location = new System.Drawing.Point(centerX, startY + buttonHeight + spaceBetweenButtons);
            btnAntrenori.BackColor = System.Drawing.ColorTranslator.FromHtml("#2F3347");
            btnAntrenori.ForeColor = System.Drawing.Color.White;
            btnAntrenori.Font = buttonFont;
            btnAntrenori.FlatStyle = FlatStyle.Flat;
            btnAntrenori.FlatAppearance.BorderSize = 0;
            btnAntrenori.Click += BtnAntrenori_Click;


            btnAngajat.Text = "Angajat";
            btnAngajat.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            btnAngajat.Location = new System.Drawing.Point(centerX, startY + 2 * (buttonHeight + spaceBetweenButtons));
            btnAngajat.BackColor = System.Drawing.ColorTranslator.FromHtml("#2F3347");
            btnAngajat.ForeColor = System.Drawing.Color.White;
            btnAngajat.Font = buttonFont;
            btnAngajat.FlatStyle = FlatStyle.Flat;
            btnAngajat.FlatAppearance.BorderSize = 0;
            btnAngajat.Click += BtnAngajat_Click;
            btnAngajat.MouseEnter += (s, e) => { btnAngajat.BackColor = System.Drawing.ColorTranslator.FromHtml("#3A4053"); };
            btnAngajat.MouseLeave += (s, e) => { btnAngajat.BackColor = System.Drawing.ColorTranslator.FromHtml("#2F3347"); };

            btnAbonament.Text = "Abonament";
            btnAbonament.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            btnAbonament.Location = new System.Drawing.Point(centerX, startY + 3 * (buttonHeight + spaceBetweenButtons));
            btnAbonament.BackColor = System.Drawing.ColorTranslator.FromHtml("#2F3347");
            btnAbonament.ForeColor = System.Drawing.Color.White;
            btnAbonament.Font = buttonFont;
            btnAbonament.FlatStyle = FlatStyle.Flat;
            btnAbonament.FlatAppearance.BorderSize = 0;
            btnAbonament.Click += BtnAbonament_Click;
            btnAbonament.MouseEnter += (s, e) => { btnAbonament.BackColor = System.Drawing.ColorTranslator.FromHtml("#3A4053"); };
            btnAbonament.MouseLeave += (s, e) => { btnAbonament.BackColor = System.Drawing.ColorTranslator.FromHtml("#2F3347"); };

          
            btnBackClienti = new Button();
            btnBackClienti.Text = "Inapoi";
            btnBackClienti.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            btnBackClienti.Location = new System.Drawing.Point(centerX, startY + 4 * (buttonHeight + spaceBetweenButtons));
            btnBackClienti.BackColor = System.Drawing.ColorTranslator.FromHtml("#2F3347");
            btnBackClienti.ForeColor = System.Drawing.Color.White;
            btnBackClienti.Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
            btnBackClienti.FlatStyle = FlatStyle.Flat;
            btnBackClienti.FlatAppearance.BorderSize = 0;
            btnBackClienti.Click += BtnReintoarcere_Click;
            btnBackClienti.MouseEnter += (s, e) => { btnBackClienti.BackColor = System.Drawing.ColorTranslator.FromHtml("#3A4053"); };
            btnBackClienti.MouseLeave += (s, e) => { btnBackClienti.BackColor = System.Drawing.ColorTranslator.FromHtml("#2F3347"); };
            btnBackClienti.Hide();

            this.Controls.Add(btnBackClienti);
            this.Controls.Add(btnClienti);
            this.Controls.Add(btnAntrenori);
            this.Controls.Add(btnAngajat);
            this.Controls.Add(btnAbonament);


            this.lblDetaliiAntrenori = new System.Windows.Forms.Label();
            this.lblDetaliiAntrenori.AutoSize = true;
            this.lblDetaliiAntrenori.Location = new System.Drawing.Point(20, 200);
            this.lblDetaliiAntrenori.Name = "lblDetaliiAntrenori";
            this.lblDetaliiAntrenori.Size = new System.Drawing.Size(200, 23);
            this.lblDetaliiAntrenori.TabIndex = 0;
            this.Controls.Add(this.lblDetaliiAntrenori);
        }


    }

}

    #endregion

