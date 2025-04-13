using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interfata.Validari;
using SalaDeFitness.LibrarieModele;

namespace Interfata
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }


        private void BtnAdaugareAntrenor_Click(object sender, EventArgs e)
        {
            btnAdaugareClient.Hide();
            btnAfisareClienti.Hide();
            btnCautaClient.Hide();
            btnBackClienti.Hide();



            Panel panelForm = new Panel()
            {
                Size = new Size(400, 500),
                Location = new Point((this.Width - 400) / 2, 50),
                BackColor = System.Drawing.ColorTranslator.FromHtml("#373D55"),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblTitle = new Label()
            {
                Text = "Adaugare Antrenor",
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(120, 10)
            };

            TextBox txtNume = CreateTextBox("Nume", 50);
            Label lblErrorNume = CreateErrorLabel(80);

            TextBox txtPrenume = CreateTextBox("Prenume", 100);
            Label lblErrorPrenume = CreateErrorLabel(130);

            TextBox txtCNP = CreateTextBox("CNP", 150);
            Label lblErrorCNP = CreateErrorLabel(180);

            TextBox txtEmail = CreateTextBox("Email", 200);
            Label lblErrorEmail = CreateErrorLabel(230);

            TextBox txtTelefon = CreateTextBox("Telefon", 250);
            Label lblErrorTelefon = CreateErrorLabel(280);

            TextBox txtFunctie = CreateTextBox("Functie", 300);
            Label lblErrorFunctie = CreateErrorLabel(330);

            Button btnSubmit = new Button()
            {
                Text = "Adauga Antrenor",
                Location = new Point(100, 370),
                Width = 200,
                BackColor = System.Drawing.ColorTranslator.FromHtml("#1E2235"),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            Button btnBack = new Button()
            {
                Text = "Inapoi",
                Location = new Point(100, 340),
                Width = 200,
                BackColor = System.Drawing.ColorTranslator.FromHtml("#1E2235"),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

         
            btnBack.Click += (s, mouseEvent) =>
            {
                this.Controls.Remove(panelForm);
                btnBackClienti.Show();
                btnAdaugareClient.Show();
                btnAfisareClienti.Show();
                btnCautaClient.Show();
            };

            btnSubmit.Click += (s, mouseEvent) =>
            {
                lblErrorNume.Text = "";
                lblErrorPrenume.Text = "";
                lblErrorCNP.Text = "";
                lblErrorEmail.Text = "";
                lblErrorTelefon.Text = "";
                lblErrorFunctie.Text = "";

                txtNume.BackColor = Color.White;
                txtPrenume.BackColor = Color.White;
                txtCNP.BackColor = Color.White;
                txtEmail.BackColor = Color.White;
                txtTelefon.BackColor = Color.White;
                txtFunctie.BackColor = Color.White;

                string numeAntrenor = txtNume.Text.Trim();
                string prenumeAntrenor = txtPrenume.Text.Trim();
                string cnpAntrenor = txtCNP.Text.Trim();
                string emailAntrenor = txtEmail.Text.Trim();
                string telefonAntrenor = txtTelefon.Text.Trim();
                string functieAntrenor = txtFunctie.Text.Trim();

                bool valid = true;

                string numeValidation = Validator.ValidateName(numeAntrenor);
                if (numeValidation != null)
                {
                    lblErrorNume.Text = numeValidation;
                    txtNume.BackColor = Color.LightCoral;
                    valid = false;
                }

                string prenumeValidation = Validator.ValidateName(prenumeAntrenor);
                if (prenumeValidation != null)
                {
                    lblErrorPrenume.Text = prenumeValidation;
                    txtPrenume.BackColor = Color.LightCoral;
                    valid = false;
                }

                string cnpValidation = Validator.ValidateCNP(cnpAntrenor);
                if (cnpValidation != null)
                {
                    lblErrorCNP.Text = cnpValidation;
                    txtCNP.BackColor = Color.LightCoral;
                    valid = false;
                }

                string emailValidation = Validator.ValidateEmail(emailAntrenor);
                if (emailValidation != null)
                {
                    lblErrorEmail.Text = emailValidation;
                    txtEmail.BackColor = Color.LightCoral;
                    valid = false;
                }

                string phoneValidation = Validator.ValidatePhone(telefonAntrenor);
                if (phoneValidation != null)
                {
                    lblErrorTelefon.Text = phoneValidation;
                    txtTelefon.BackColor = Color.LightCoral;
                    valid = false;
                }

                string functieValidation = Validator.ValidateFunctie(functieAntrenor);
                if (functieValidation != null)
                {
                    lblErrorFunctie.Text = functieValidation;
                    txtFunctie.BackColor = Color.LightCoral;
                    valid = false;
                }

                if (!valid) return;

                Antrenor antrenor = new Antrenor(numeAntrenor, prenumeAntrenor, cnpAntrenor, emailAntrenor, telefonAntrenor, functieAntrenor);
                adminAntrenori.AddAntrenor(antrenor);

                MessageBox.Show("Antrenorul a fost adaugat cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Controls.Remove(panelForm);
                btnAdaugareClient.Show();
                btnAfisareClienti.Show();
                btnCautaClient.Show();
            };

            panelForm.Controls.Add(lblTitle);
            panelForm.Controls.Add(txtNume);
            panelForm.Controls.Add(lblErrorNume);
            panelForm.Controls.Add(txtPrenume);
            panelForm.Controls.Add(lblErrorPrenume);
            panelForm.Controls.Add(txtCNP);
            panelForm.Controls.Add(lblErrorCNP);
            panelForm.Controls.Add(txtEmail);
            panelForm.Controls.Add(lblErrorEmail);
            panelForm.Controls.Add(txtTelefon);
            panelForm.Controls.Add(lblErrorTelefon);
            panelForm.Controls.Add(txtFunctie);
            panelForm.Controls.Add(lblErrorFunctie);
            panelForm.Controls.Add(btnSubmit);
            panelForm.Controls.Add(btnBack);  

            this.Controls.Add(panelForm);
        }


        private void AddHomeButton()
        {
            btnHome = new Button()
            {
                Text = "Home",
                Width = 200,
                Height = 50,
                BackColor = System.Drawing.ColorTranslator.FromHtml("#2F3347"),
                ForeColor = Color.White,
                Font = new Font("Arial", 12, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand,
                UseVisualStyleBackColor = false,
                Margin = new Padding(0),
                Padding = new Padding(0),
            };

            btnHome.MouseEnter += (sender, e) => {
                btnHome.BackColor = System.Drawing.ColorTranslator.FromHtml("#3A4053");
            };

            btnHome.MouseLeave += (sender, e) => {
                btnHome.BackColor = System.Drawing.ColorTranslator.FromHtml("#2F3347");
            };

            int centerX = 300;
            btnHome.Location = new Point(centerX, 0);

            btnHome.Click += BtnHome_Click;
            this.Controls.Add(btnHome);
        }



        private void BtnHome_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {

                if (ctrl is Button &&
                    ctrl != btnClienti &&
                    ctrl != btnAntrenori &&
                    ctrl != btnAngajat &&
                    ctrl != btnAbonament &&
                    ctrl != btnHome)
                {
                    ctrl.Hide();
                }

                else if (ctrl is Panel || ctrl is Label || ctrl is ListView)
                {
                    ctrl.Hide();
                }
            }


            btnClienti.Show();
            btnAntrenori.Show();
            btnAngajat.Show();
            btnAbonament.Show();
            btnHome.Show();
        }



        private void BtnAdaugareClient_Click(object sender, EventArgs e)
        {
            btnAdaugareClient.Hide();
            btnAfisareClienti.Hide();
            btnCautaClient.Hide();
            btnBackClienti.Hide();

            Panel panelForm = new Panel()
            {
                Size = new Size(400, 500),
                Location = new Point((this.Width - 400) / 2, 50),
                BackColor = System.Drawing.ColorTranslator.FromHtml("#373D55"),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblTitle = new Label()
            {
                Text = "Adaugare Client",
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(120, 10)
            };

            TextBox txtNume = CreateTextBox("Nume", 50);
            Label lblErrorNume = CreateErrorLabel(80);

            TextBox txtPrenume = CreateTextBox("Prenume", 100);
            Label lblErrorPrenume = CreateErrorLabel(130);

            TextBox txtCNP = CreateTextBox("CNP", 150);
            Label lblErrorCNP = CreateErrorLabel(180);

            TextBox txtEmail = CreateTextBox("Email", 200);
            Label lblErrorEmail = CreateErrorLabel(230);

            TextBox txtTelefon = CreateTextBox("Telefon", 250);
            Label lblErrorTelefon = CreateErrorLabel(280);

            Button btnSubmit = new Button()
            {
                Text = "Adauga Client",
                Location = new Point(100, 350),
                Width = 200,
                BackColor = System.Drawing.ColorTranslator.FromHtml("#1E2235"),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            Button btnBack = new Button()
            {
                Text = "Inapoi",
                Location = new Point(100, 320),
                Width = 200,
                BackColor = System.Drawing.ColorTranslator.FromHtml("#1E2235"),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

          
            btnBack.Click += (s, mouseEvent) =>
            {
                this.Controls.Remove(panelForm);
                btnAdaugareClient.Show();
                btnAfisareClienti.Show();
                btnCautaClient.Show();
                btnBackClienti.Show();
            };

            btnSubmit.Click += (s, mouseEvent) =>
            {
                bool valid = true;

                txtNume.BackColor = Color.White;
                lblErrorNume.Text = "";
                txtPrenume.BackColor = Color.White;
                lblErrorPrenume.Text = "";
                txtCNP.BackColor = Color.White;
                lblErrorCNP.Text = "";
                txtEmail.BackColor = Color.White;
                lblErrorEmail.Text = "";
                txtTelefon.BackColor = Color.White;
                lblErrorTelefon.Text = "";


                string nameValidation = Validator.ValidateName(txtNume.Text.Trim());
                if (nameValidation != null)
                {
                    lblErrorNume.Text = nameValidation;
                    txtNume.BackColor = Color.LightCoral;
                    valid = false;
                }

                string prenumeValidation = Validator.ValidateName(txtPrenume.Text.Trim());
                if (prenumeValidation != null)
                {
                    lblErrorPrenume.Text = prenumeValidation;
                    txtPrenume.BackColor = Color.LightCoral;
                    valid = false;
                }
                string cnpValidation = Validator.ValidateCNP(txtCNP.Text.Trim());
                if (cnpValidation != null)
                {
                    lblErrorCNP.Text = cnpValidation;
                    txtCNP.BackColor = Color.LightCoral;
                    valid = false;
                }

                string emailValidation = Validator.ValidateEmail(txtEmail.Text.Trim());
                if (emailValidation != null)
                {
                    lblErrorEmail.Text = emailValidation;
                    txtEmail.BackColor = Color.LightCoral;
                    valid = false;
                }

                string phoneValidation = Validator.ValidatePhone(txtTelefon.Text.Trim());
                if (phoneValidation != null)
                {
                    lblErrorTelefon.Text = phoneValidation;
                    txtTelefon.BackColor = Color.LightCoral;
                    valid = false;
                }

                if (!valid) return;

                Client client = new Client(txtNume.Text.Trim(), txtPrenume.Text.Trim(), txtCNP.Text.Trim(), txtEmail.Text.Trim(), txtTelefon.Text.Trim());
                adminClienti.AddClient(client);

                MessageBox.Show("Clientul a fost adaugat cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Controls.Remove(panelForm);
                btnAdaugareClient.Show();
                btnAfisareClienti.Show();
                btnCautaClient.Show();
            };

            panelForm.Controls.Add(lblTitle);
            panelForm.Controls.Add(txtNume);
            panelForm.Controls.Add(lblErrorNume);
            panelForm.Controls.Add(txtPrenume);
            panelForm.Controls.Add(lblErrorPrenume);
            panelForm.Controls.Add(txtCNP);
            panelForm.Controls.Add(lblErrorCNP);
            panelForm.Controls.Add(txtEmail);
            panelForm.Controls.Add(lblErrorEmail);
            panelForm.Controls.Add(txtTelefon);
            panelForm.Controls.Add(lblErrorTelefon);
            panelForm.Controls.Add(btnSubmit);
            panelForm.Controls.Add(btnBack); 

            this.Controls.Add(panelForm);
        }



        private void BtnClienti_Click(object sender, EventArgs e)
        {
            btnAbonament.Hide();
            btnAngajat.Hide();
            btnAntrenori.Hide();
            btnClienti.Hide();
            btnBackClienti.Show();

            btnAdaugareClient = new Button();
            btnAfisareClienti = new Button();
            btnCautaClient = new Button();
            Button btnBack = new Button(); 

            Font buttonFont = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
            int buttonWidth = 300;
            int buttonHeight = 50;
            int spaceBetweenButtons = 20;

            int centerX = (this.ClientSize.Width - buttonWidth) / 2;
            int startY = (this.ClientSize.Height - (buttonHeight * 3) - (spaceBetweenButtons * 2)) / 2;

            btnAdaugareClient.Text = "Adaugare client";
            btnAdaugareClient.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            btnAdaugareClient.Location = new System.Drawing.Point(centerX, startY);
            btnAdaugareClient.BackColor = System.Drawing.ColorTranslator.FromHtml("#2F3347");
            btnAdaugareClient.ForeColor = System.Drawing.Color.White;
            btnAdaugareClient.Font = buttonFont;
            btnAdaugareClient.FlatStyle = FlatStyle.Flat;
            btnAdaugareClient.FlatAppearance.BorderSize = 0;
            btnAdaugareClient.Click += BtnAdaugareClient_Click;
            btnAdaugareClient.MouseEnter += (s, mouseEvent) => { btnAdaugareClient.BackColor = System.Drawing.ColorTranslator.FromHtml("#3A4053"); };
            btnAdaugareClient.MouseLeave += (s, mouseEvent) => { btnAdaugareClient.BackColor = System.Drawing.ColorTranslator.FromHtml("#2F3347"); };

            btnAfisareClienti.Text = "Afisare clienti";
            btnAfisareClienti.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            btnAfisareClienti.Location = new System.Drawing.Point(centerX, startY + buttonHeight + spaceBetweenButtons);
            btnAfisareClienti.BackColor = System.Drawing.ColorTranslator.FromHtml("#2F3347");
            btnAfisareClienti.ForeColor = System.Drawing.Color.White;
            btnAfisareClienti.Font = buttonFont;
            btnAfisareClienti.FlatStyle = FlatStyle.Flat;
            btnAfisareClienti.FlatAppearance.BorderSize = 0;
            btnAfisareClienti.Click += BtnAfisareClienti_Click;
            btnAfisareClienti.MouseEnter += (s, mouseEvent) => { btnAfisareClienti.BackColor = System.Drawing.ColorTranslator.FromHtml("#3A4053"); };
            btnAfisareClienti.MouseLeave += (s, mouseEvent) => { btnAfisareClienti.BackColor = System.Drawing.ColorTranslator.FromHtml("#2F3347"); };

            btnCautaClient.Text = "Cautare client dupa nume";
            btnCautaClient.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            btnCautaClient.Location = new System.Drawing.Point(centerX, startY + 2 * (buttonHeight + spaceBetweenButtons));
            btnCautaClient.BackColor = System.Drawing.ColorTranslator.FromHtml("#2F3347");
            btnCautaClient.ForeColor = System.Drawing.Color.White;
            btnCautaClient.Font = buttonFont;
            btnCautaClient.FlatStyle = FlatStyle.Flat;
            btnCautaClient.FlatAppearance.BorderSize = 0;
            btnCautaClient.Click += BtnCautaClient_Click;
            btnCautaClient.MouseEnter += (s, mouseEvent) => { btnCautaClient.BackColor = System.Drawing.ColorTranslator.FromHtml("#3A4053"); };
            btnCautaClient.MouseLeave += (s, mouseEvent) => { btnCautaClient.BackColor = System.Drawing.ColorTranslator.FromHtml("#2F3347"); };

            

            this.Controls.Add(btnAdaugareClient);
            this.Controls.Add(btnAfisareClienti);
            this.Controls.Add(btnCautaClient);
          
        }


        private void BtnAntrenori_Click(object sender, EventArgs e)
        {
            btnAbonament.Hide();
            btnAngajat.Hide();
            btnAntrenori.Hide();
            btnClienti.Hide();
            btnBackClienti.Show();

            btnAdaugareClient = new Button();
            btnAfisareClienti = new Button();
            btnCautaClient = new Button();


            Font buttonFont = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
            int buttonWidth = 300;
            int buttonHeight = 50;
            int spaceBetweenButtons = 20;

            int centerX = (this.ClientSize.Width - buttonWidth) / 2;
            int startY = (this.ClientSize.Height - (buttonHeight * 3) - (spaceBetweenButtons * 2)) / 2;


            btnAdaugareClient.Text = "Adaugare antrenori";
            btnAdaugareClient.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            btnAdaugareClient.Location = new System.Drawing.Point(centerX, startY);
            btnAdaugareClient.BackColor = System.Drawing.ColorTranslator.FromHtml("#2F3347");
            btnAdaugareClient.ForeColor = System.Drawing.Color.White;
            btnAdaugareClient.Font = buttonFont;
            btnAdaugareClient.FlatStyle = FlatStyle.Flat;
            btnAdaugareClient.FlatAppearance.BorderSize = 0;
            btnAdaugareClient.Click += BtnAdaugareAntrenor_Click;
            btnAdaugareClient.MouseEnter += (s, mouseEvent) => { btnAdaugareClient.BackColor = System.Drawing.ColorTranslator.FromHtml("#3A4053"); };
            btnAdaugareClient.MouseLeave += (s, mouseEvent) => { btnAdaugareClient.BackColor = System.Drawing.ColorTranslator.FromHtml("#2F3347"); };

            btnAfisareClienti.Text = "Afisare antrenori";
            btnAfisareClienti.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            btnAfisareClienti.Location = new System.Drawing.Point(centerX, startY + buttonHeight + spaceBetweenButtons);
            btnAfisareClienti.BackColor = System.Drawing.ColorTranslator.FromHtml("#2F3347");
            btnAfisareClienti.ForeColor = System.Drawing.Color.White;
            btnAfisareClienti.Font = buttonFont;
            btnAfisareClienti.FlatStyle = FlatStyle.Flat;
            btnAfisareClienti.FlatAppearance.BorderSize = 0;
            btnAfisareClienti.Click += BtnAntrenoriAfisare_Click;
            btnAfisareClienti.MouseEnter += (s, mouseEvent) => { btnAfisareClienti.BackColor = System.Drawing.ColorTranslator.FromHtml("#3A4053"); };
            btnAfisareClienti.MouseLeave += (s, mouseEvent) => { btnAfisareClienti.BackColor = System.Drawing.ColorTranslator.FromHtml("#2F3347"); };

            btnCautaClient.Text = "Cautare antrenor dupa nume";
            btnCautaClient.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            btnCautaClient.Location = new System.Drawing.Point(centerX, startY + 2 * (buttonHeight + spaceBetweenButtons));
            btnCautaClient.BackColor = System.Drawing.ColorTranslator.FromHtml("#2F3347");
            btnCautaClient.ForeColor = System.Drawing.Color.White;
            btnCautaClient.Font = buttonFont;
            btnCautaClient.FlatStyle = FlatStyle.Flat;
            btnCautaClient.FlatAppearance.BorderSize = 0;
            btnCautaClient.Click += BtnCautaAntrenor_Click;
            btnCautaClient.MouseEnter += (s, mouseEvent) => { btnCautaClient.BackColor = System.Drawing.ColorTranslator.FromHtml("#3A4053"); };
            btnCautaClient.MouseLeave += (s, mouseEvent) => { btnCautaClient.BackColor = System.Drawing.ColorTranslator.FromHtml("#2F3347"); };

            this.Controls.Add(btnAdaugareClient);
            this.Controls.Add(btnAfisareClienti);
            this.Controls.Add(btnCautaClient);
        }

        private void BtnAngajat_Click(object sender, EventArgs e)
        {
            btnAbonament.Hide();
            btnAngajat.Hide();
            btnAntrenori.Hide();
            btnClienti.Hide();
            btnBackClienti.Show();

            btnAdaugareClient = new Button();
            btnAfisareClienti = new Button();
            btnCautaClient = new Button();


            Font buttonFont = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
            int buttonWidth = 300;
            int buttonHeight = 50;
            int spaceBetweenButtons = 20;

            int centerX = (this.ClientSize.Width - buttonWidth) / 2;
            int startY = (this.ClientSize.Height - (buttonHeight * 3) - (spaceBetweenButtons * 2)) / 2;


            btnAdaugareClient.Text = "Adaugare angajati";
            btnAdaugareClient.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            btnAdaugareClient.Location = new System.Drawing.Point(centerX, startY);
            btnAdaugareClient.BackColor = System.Drawing.ColorTranslator.FromHtml("#2F3347");
            btnAdaugareClient.ForeColor = System.Drawing.Color.White;
            btnAdaugareClient.Font = buttonFont;
            btnAdaugareClient.FlatStyle = FlatStyle.Flat;
            btnAdaugareClient.FlatAppearance.BorderSize = 0;
            btnAdaugareClient.Click += BtnAdaugareAngajat_Click;
            btnAdaugareClient.MouseEnter += (s, mouseEvent) => { btnAdaugareClient.BackColor = System.Drawing.ColorTranslator.FromHtml("#3A4053"); };
            btnAdaugareClient.MouseLeave += (s, mouseEvent) => { btnAdaugareClient.BackColor = System.Drawing.ColorTranslator.FromHtml("#2F3347"); };

            btnAfisareClienti.Text = "Afisare angajati";
            btnAfisareClienti.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            btnAfisareClienti.Location = new System.Drawing.Point(centerX, startY + buttonHeight + spaceBetweenButtons);
            btnAfisareClienti.BackColor = System.Drawing.ColorTranslator.FromHtml("#2F3347");
            btnAfisareClienti.ForeColor = System.Drawing.Color.White;
            btnAfisareClienti.Font = buttonFont;
            btnAfisareClienti.FlatStyle = FlatStyle.Flat;
            btnAfisareClienti.FlatAppearance.BorderSize = 0;
            btnAfisareClienti.Click += BtnAngajatAfisare_Click;
            btnAfisareClienti.MouseEnter += (s, mouseEvent) => { btnAfisareClienti.BackColor = System.Drawing.ColorTranslator.FromHtml("#3A4053"); };
            btnAfisareClienti.MouseLeave += (s, mouseEvent) => { btnAfisareClienti.BackColor = System.Drawing.ColorTranslator.FromHtml("#2F3347"); };

            btnCautaClient.Text = "Cautare angajat dupa nume";
            btnCautaClient.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            btnCautaClient.Location = new System.Drawing.Point(centerX, startY + 2 * (buttonHeight + spaceBetweenButtons));
            btnCautaClient.BackColor = System.Drawing.ColorTranslator.FromHtml("#2F3347");
            btnCautaClient.ForeColor = System.Drawing.Color.White;
            btnCautaClient.Font = buttonFont;
            btnCautaClient.FlatStyle = FlatStyle.Flat;
            btnCautaClient.FlatAppearance.BorderSize = 0;
            btnCautaClient.Click += BtnCautaAngajat_Click;
            btnCautaClient.MouseEnter += (s, mouseEvent) => { btnCautaClient.BackColor = System.Drawing.ColorTranslator.FromHtml("#3A4053"); };
            btnCautaClient.MouseLeave += (s, mouseEvent) => { btnCautaClient.BackColor = System.Drawing.ColorTranslator.FromHtml("#2F3347"); };

            this.Controls.Add(btnAdaugareClient);
            this.Controls.Add(btnAfisareClienti);
            this.Controls.Add(btnCautaClient);
        }

        private void BtnAdaugareAngajat_Click(object sender, EventArgs e)
        {
            btnAdaugareClient.Hide();
            btnAfisareClienti.Hide();
            btnCautaClient.Hide();
            btnBackClienti.Hide();

            Panel panelForm = new Panel()
            {
                Size = new Size(400, 500),
                Location = new Point((this.Width - 400) / 2, 50),
                BackColor = System.Drawing.ColorTranslator.FromHtml("#373D55"),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblTitle = new Label()
            {
                Text = "Adaugare Angajat",
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(120, 10)
            };

            TextBox txtNume = CreateTextBox("Nume", 50);
            TextBox txtPrenume = CreateTextBox("Prenume", 100);
            TextBox txtCNP = CreateTextBox("CNP", 150);
            TextBox txtEmail = CreateTextBox("Email", 200);
            TextBox txtTelefon = CreateTextBox("Telefon", 250);
            TextBox txtFunctie = CreateTextBox("Functie", 300);

            Label lblErrorNume = CreateErrorLabel(80);
            Label lblErrorPrenume = CreateErrorLabel(130);
            Label lblErrorCNP = CreateErrorLabel(180);
            Label lblErrorEmail = CreateErrorLabel(230);
            Label lblErrorTelefon = CreateErrorLabel(280);
            Label lblErrorFunctie = CreateErrorLabel(330);

            Button btnSubmit = new Button()
            {
                Text = "Adauga Angajat",
                Location = new Point(100, 370),
                Width = 200,
                BackColor = System.Drawing.ColorTranslator.FromHtml("#1E2235"),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            Button btnBack = new Button()
            {
                Text = "Inapoi",
                Location = new Point(100, 340),
                Width = 200,
                BackColor = System.Drawing.ColorTranslator.FromHtml("#1E2235"),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

       
            btnBack.Click += (s, mouseEvent) =>
            {
                this.Controls.Remove(panelForm);
                btnAdaugareClient.Show();
                btnAfisareClienti.Show();
                btnCautaClient.Show();
                btnBackClienti.Show();
            };

            btnSubmit.Click += (s, mouseEvent) =>
            {
                lblErrorNume.Text = "";
                lblErrorPrenume.Text = "";
                lblErrorCNP.Text = "";
                lblErrorEmail.Text = "";
                lblErrorTelefon.Text = "";
                lblErrorFunctie.Text = "";

                txtNume.BackColor = Color.White;
                txtPrenume.BackColor = Color.White;
                txtCNP.BackColor = Color.White;
                txtEmail.BackColor = Color.White;
                txtTelefon.BackColor = Color.White;
                txtFunctie.BackColor = Color.White;

                string numeAngajat = txtNume.Text.Trim();
                string prenumeAngajat = txtPrenume.Text.Trim();
                string cnpAngajat = txtCNP.Text.Trim();
                string emailAngajat = txtEmail.Text.Trim();
                string telefonAngajat = txtTelefon.Text.Trim();
                string functieAngajat = txtFunctie.Text.Trim();

                bool valid = true;

                string numeValidation = Validator.ValidateName(numeAngajat);
                if (numeValidation != null)
                {
                    lblErrorNume.Text = numeValidation;
                    txtNume.BackColor = Color.LightCoral;
                    valid = false;
                }

                string prenumeValidation = Validator.ValidateName(prenumeAngajat);
                if (prenumeValidation != null)
                {
                    lblErrorPrenume.Text = prenumeValidation;
                    txtPrenume.BackColor = Color.LightCoral;
                    valid = false;
                }

                string cnpValidation = Validator.ValidateCNP(cnpAngajat);
                if (cnpValidation != null)
                {
                    lblErrorCNP.Text = cnpValidation;
                    txtCNP.BackColor = Color.LightCoral;
                    valid = false;
                }

                string emailValidation = Validator.ValidateEmail(emailAngajat);
                if (emailValidation != null)
                {
                    lblErrorEmail.Text = emailValidation;
                    txtEmail.BackColor = Color.LightCoral;
                    valid = false;
                }

                string phoneValidation = Validator.ValidatePhone(telefonAngajat);
                if (phoneValidation != null)
                {
                    lblErrorTelefon.Text = phoneValidation;
                    txtTelefon.BackColor = Color.LightCoral;
                    valid = false;
                }

                string functieValidation = Validator.ValidateFunctie(functieAngajat);
                if (functieValidation != null)
                {
                    lblErrorFunctie.Text = functieValidation;
                    txtFunctie.BackColor = Color.LightCoral;
                    valid = false;
                }

                if (!valid) return;

                Angajat angajat = new Angajat(numeAngajat, prenumeAngajat, cnpAngajat, emailAngajat, telefonAngajat, functieAngajat);
                adminAngajati.AddAngajat(angajat);

                MessageBox.Show("Angajatul a fost adaugat cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Controls.Remove(panelForm);
                btnAdaugareClient.Show();
                btnAfisareClienti.Show();
                btnCautaClient.Show();
            };

            panelForm.Controls.Add(lblTitle);
            panelForm.Controls.Add(txtNume);
            panelForm.Controls.Add(lblErrorNume);
            panelForm.Controls.Add(txtPrenume);
            panelForm.Controls.Add(lblErrorPrenume);
            panelForm.Controls.Add(txtCNP);
            panelForm.Controls.Add(lblErrorCNP);
            panelForm.Controls.Add(txtEmail);
            panelForm.Controls.Add(lblErrorEmail);
            panelForm.Controls.Add(txtTelefon);
            panelForm.Controls.Add(lblErrorTelefon);
            panelForm.Controls.Add(txtFunctie);
            panelForm.Controls.Add(lblErrorFunctie);
            panelForm.Controls.Add(btnSubmit);
            panelForm.Controls.Add(btnBack); 

            this.Controls.Add(panelForm);
        }


        private Label CreateErrorLabel(int y)
        {
            return new Label()
            {
                ForeColor = Color.Red,
                Font = new Font("Arial", 8, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(50, y)
            };
        }

        private TextBox CreateTextBox(string placeholder, int yPos)
        {
            TextBox txtBox = new TextBox()
            {
                Location = new Point(50, yPos),
                Width = 300,
                ForeColor = Color.Gray,
                Text = placeholder
            };

            txtBox.GotFocus += (s, e) => UpdatePlaceholder(txtBox, placeholder);
            txtBox.LostFocus += (s, e) => SetPlaceholder(txtBox, placeholder);

            return txtBox;
        }

        private void UpdatePlaceholder(TextBox txtBox, string placeholder)
        {
            if (txtBox.Text == placeholder)
            {
                txtBox.Text = "";
                txtBox.ForeColor = Color.Black;
            }
        }

        private void SetPlaceholder(TextBox txtBox, string placeholder)
        {
            if (string.IsNullOrWhiteSpace(txtBox.Text))
            {
                txtBox.Text = placeholder;
                txtBox.ForeColor = Color.Gray;
            }
        }

        private void BtnAfisareClienti_Click(object sender, EventArgs e)
        {
            btnBackClienti.Hide();
            btnAdaugareClient.Hide();
            btnAfisareClienti.Hide();
            btnCautaClient.Hide();
            

            ListView listViewClienti = new ListView
            {
                Dock = DockStyle.Bottom,
                Height = 400,
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                ForeColor = Color.White,
                Font = new Font("Arial", 12, FontStyle.Regular),
                BackColor = Color.FromArgb(45, 45, 48),
                HeaderStyle = ColumnHeaderStyle.Nonclickable
            };

            listViewClienti.Location = new Point(0, 50);
            listViewClienti.Columns.Add("ID", 60, HorizontalAlignment.Center);
            listViewClienti.Columns.Add("Nume Prenume", 200, HorizontalAlignment.Left);
            listViewClienti.Columns.Add("CNP", 160, HorizontalAlignment.Center);
            listViewClienti.Columns.Add("Email", 250, HorizontalAlignment.Left);
            listViewClienti.Columns.Add("Telefon", 130, HorizontalAlignment.Center);

            var clienti = adminClienti.GetClienti();
            if (clienti.Count == 0)
            {
                MessageBox.Show("Nu exista clienti adaugati.", "Informatie", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                foreach (var client in clienti)
                {
                    string numePrenume = $"{client.Nume} {client.Prenume}";
                    ListViewItem item = new ListViewItem(client.Id.ToString())
                    {
                        BackColor = System.Drawing.ColorTranslator.FromHtml("#2F3347"),
                        ForeColor = Color.WhiteSmoke
                    };

                    item.SubItems.Add(numePrenume ?? "Nume necunoscut");
                    item.SubItems.Add(client.CNP);
                    item.SubItems.Add(client.Email);
                    item.SubItems.Add(client.NumarTelefon);

                    listViewClienti.Items.Add(item);
                }
            }

            listViewClienti.Location = new Point(0, 100);

            Button btnBack = new Button()
            {
                Text = "Inapoi",
                Location = new Point(10, 10),
                BackColor = System.Drawing.ColorTranslator.FromHtml("#1E2235"),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            btnBack.Click += (s, mouseEvent) =>
            {
                this.Controls.Remove(listViewClienti);
                btnAdaugareClient.Show();
                btnAfisareClienti.Show();
                btnCautaClient.Show();
                btnBackClienti.Show();
                btnBack.Hide();
            };

            this.Controls.Add(btnBack);
            this.Controls.Add(listViewClienti);
        }


        private Label CreateStyledLabel(string text, Point location, int width, int fontSize)
        {
            return new Label()
            {
                Text = text,
                AutoSize = false,
                Width = width,
                Location = location,
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", fontSize),
                BackColor = Color.FromArgb(60, 60, 60),
                Padding = new Padding(5),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5),
                Height = 25,
                Cursor = Cursors.Hand
            };
        }

        private void BtnCautaClient_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(btnBackClienti);
            btnAdaugareClient.Hide();
            btnAfisareClienti.Hide();
            btnCautaClient.Hide();

            Panel panelCautare = new Panel()
            {
                Size = new Size(400, 400),
                Location = new Point((this.Width - 400) / 2, 50),
                BackColor = System.Drawing.ColorTranslator.FromHtml("#373D55"),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblTitle = new Label()
            {
                Text = "Cautare Client",
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(120, 10)
            };

       
            Label lblSearch = new Label()
            {
                Text = "Nume client:",
                ForeColor = Color.White,
                Location = new Point(20, 50)
            };

            TextBox txtSearch = new TextBox()
            {
                Location = new Point(150, 50),
                Width = 200
            };

       
            Button btnSearch = new Button()
            {
                Text = "Cauta",
                Location = new Point(150, 90),
                Width = 100,
                BackColor = System.Drawing.ColorTranslator.FromHtml("#1E2235"),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

     
            ListBox lstResults = new ListBox()
            {
                Location = new Point(20, 140),
                Width = 350,
                Height = 150
            };

  
            Label lblNoResults = new Label()
            {
                Text = "Niciun client gasit!",
                ForeColor = Color.Red,
                Location = new Point(120, 140),
                Visible = false
            };

       
            Button btnBack = new Button()
            {
                Text = "Inapoi",
                Location = new Point(170, 300), 
                BackColor = System.Drawing.ColorTranslator.FromHtml("#1E2235"),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

          
           

            btnBack.Click += (s, mouseEvent) =>
            {
                foreach (Control control in panelCautare.Controls)
                {
                    control.Hide();
                }

               
                panelCautare.Hide();

               
                if (!this.Controls.Contains(btnBackClienti))
                {
                    this.Controls.Add(btnBackClienti);
                }

                btnAdaugareClient.Show();
                btnAfisareClienti.Show();
                btnCautaClient.Show();
                btnBackClienti.Show();
            };



            btnSearch.Click += (s, ev) =>
            {
                string numeCautat = txtSearch.Text.Trim().ToLower();
                lstResults.DataSource = null;
                lstResults.Items.Clear();
                lblNoResults.Visible = false;

                if (string.IsNullOrEmpty(numeCautat))
                {
                    MessageBox.Show("Introduceti un nume pentru cautare!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var clientiGasiti = adminClienti.GetClienti()
                                     .Where(c => c.Nume.ToLower().Contains(numeCautat))
                                     .ToList();

                if (clientiGasiti.Any())
                {
                    lstResults.DataSource = clientiGasiti;
                    lstResults.DisplayMember = "DisplayText";
                }
                else
                {
                    lblNoResults.Visible = true;
                }
            };

          
            panelCautare.Controls.Add(lblTitle);
            panelCautare.Controls.Add(lblSearch);
            panelCautare.Controls.Add(txtSearch);
            panelCautare.Controls.Add(btnSearch);
            panelCautare.Controls.Add(lstResults);
            panelCautare.Controls.Add(lblNoResults);
            panelCautare.Controls.Add(btnBack);  

         
            this.Controls.Add(panelCautare);
        }


        private void BtnCautaAntrenor_Click(object sender, EventArgs e)
        {
            btnAdaugareClient.Hide();
            btnAfisareClienti.Hide();
            btnCautaClient.Hide();
            btnBackClienti.Hide();


            Panel panelCautare = new Panel()
            {
                Size = new Size(400, 400),
                Location = new Point((this.Width - 400) / 2, 50),
                BackColor = System.Drawing.ColorTranslator.FromHtml("#373D55"),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblTitle = new Label()
            {
                Text = "Cautare Antrenor",
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(120, 10)
            };

            Label lblSearch = new Label()
            {
                Text = "Introduceti numele:",
                ForeColor = Color.White,
                Location = new Point(20, 50)
            };

            TextBox txtSearch = new TextBox()
            {
                Location = new Point(150, 50),
                Width = 200
            };

            Button btnSearch = new Button()
            {
                Text = "Cauta",
                Location = new Point(150, 100),
                Width = 100,
                BackColor = System.Drawing.ColorTranslator.FromHtml("#1E2235"),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            ListBox lstResults = new ListBox()
            {
                Location = new Point(20, 140),
                Width = 350,
                Height = 150
            };

            Label lblNoResults = new Label()
            {
                Text = "Niciun antrenor gasit!",
                ForeColor = Color.Red,
                Location = new Point(120, 140),
                Visible = false
            };

            Button btnBack = new Button()
            {
                Text = "Inapoi",
                Location = new Point(170, 300), 
                BackColor = System.Drawing.ColorTranslator.FromHtml("#1E2235"),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            btnBack.Click += (s, mouseEvent) =>
            {
                this.Controls.Remove(panelCautare); 
                btnAdaugareClient.Show(); 
                btnAfisareClienti.Show();
                btnCautaClient.Show();
                btnBack.Hide();
                btnBackClienti.Show();
            };

            btnSearch.Click += (s, ev) =>
            {
                string cautare = txtSearch.Text.Trim();
                lstResults.DataSource = null;
                lstResults.Items.Clear();
                lblNoResults.Visible = false;

                if (string.IsNullOrEmpty(cautare))
                {
                    MessageBox.Show("Introduceti numele antrenorului!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var antrenoriGasiti = adminAntrenori.SearchAntrenori(cautare);

                if (antrenoriGasiti.Any())
                {
                    lstResults.DataSource = antrenoriGasiti;
                    lstResults.DisplayMember = "DisplayText";
                }
                else
                {
                    lblNoResults.Visible = true;
                }
            };

            panelCautare.Controls.Add(lblTitle);
            panelCautare.Controls.Add(lblSearch);
            panelCautare.Controls.Add(txtSearch);
            panelCautare.Controls.Add(btnSearch);
            panelCautare.Controls.Add(lstResults);
            panelCautare.Controls.Add(lblNoResults);
            panelCautare.Controls.Add(btnBack); 

            this.Controls.Add(panelCautare);
        }

        private void BtnCautaAngajat_Click(object sender, EventArgs e)
        {
            btnAdaugareClient.Hide();
            btnAfisareClienti.Hide();
            btnCautaClient.Hide();
            btnBackClienti.Hide();

            Panel panelCautare = new Panel()
            {
                Size = new Size(400, 400),
                Location = new Point((this.Width - 400) / 2, 50),
                BackColor = System.Drawing.ColorTranslator.FromHtml("#373D55"),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblTitle = new Label()
            {
                Text = "Cautare Angajat",
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(120, 10)
            };

            Label lblSearch = new Label()
            {
                Text = "Introduceti numele:",
                ForeColor = Color.White,
                Location = new Point(20, 50)
            };

            TextBox txtSearch = new TextBox()
            {
                Location = new Point(150, 50),
                Width = 200
            };

            Button btnSearch = new Button()
            {
                Text = "Cauta",
                Location = new Point(150, 90),
                Width = 100,
                BackColor = System.Drawing.ColorTranslator.FromHtml("#1E2235"),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            ListBox lstResults = new ListBox()
            {
                Location = new Point(20, 140),
                Width = 350,
                Height = 150
            };

            Label lblNoResults = new Label()
            {
                Text = "Niciun angajat gasit!",
                ForeColor = Color.Red,
                Location = new Point(120, 140),
                Visible = false
            };

            Button btnBack = new Button()
            {
                Text = "Inapoi",
                Location = new Point(150, 300),
                Width = 80,
                BackColor = System.Drawing.ColorTranslator.FromHtml("#1E2235"),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

         
            btnBack.Click += (s, mouseEvent) =>
            {
                this.Controls.Remove(panelCautare);  
                btnAdaugareClient.Show();  
                btnAfisareClienti.Show();
                btnCautaClient.Show();
                btnBackClienti.Show();
            };

            btnSearch.Click += (s, ev) =>
            {
                string cautare = txtSearch.Text.Trim();
                lstResults.DataSource = null;
                lstResults.Items.Clear();
                lblNoResults.Visible = false;

                if (string.IsNullOrEmpty(cautare))
                {
                    MessageBox.Show("Introduceti numele angajatului!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var angajatiGasiti = adminAngajati.SearchAngajati(cautare);

                if (angajatiGasiti.Any())
                {
                    lstResults.DataSource = angajatiGasiti;
                    lstResults.DisplayMember = "DisplayText";
                }
                else
                {
                    lblNoResults.Visible = true;
                }
            };

            panelCautare.Controls.Add(lblTitle);
            panelCautare.Controls.Add(lblSearch);
            panelCautare.Controls.Add(txtSearch);
            panelCautare.Controls.Add(btnSearch);
            panelCautare.Controls.Add(lstResults);
            panelCautare.Controls.Add(lblNoResults);
            panelCautare.Controls.Add(btnBack);  

       
            this.Controls.Add(panelCautare);
        }


        private void BtnCautaAbonament_Click(object sender, EventArgs e)
        {
            btnAdaugareClient.Hide();
            btnAfisareClienti.Hide();
            btnCautaClient.Hide();
            btnBackClienti.Hide();

            Panel panelCautare = new Panel()
            {
                Size = new Size(400, 400),
                Location = new Point((this.Width - 400) / 2, 50),
                BackColor = System.Drawing.ColorTranslator.FromHtml("#373D55"),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblTitle = new Label()
            {
                Text = "Cautare Abonament",
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(120, 10)
            };

            Label lblSearch = new Label()
            {
                Text = "Introduceti numele clientului:",
                ForeColor = Color.White,
                Location = new Point(20, 50)
            };

            TextBox txtSearch = new TextBox()
            {
                Location = new Point(150, 50),
                Width = 200
            };

            Button btnSearch = new Button()
            {
                Text = "Cauta",
                Location = new Point(150, 90),
                Width = 100,
                BackColor = System.Drawing.ColorTranslator.FromHtml("#1E2235"),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            ListBox lstResults = new ListBox()
            {
                Location = new Point(20, 140),
                Width = 350,
                Height = 150
            };

            Label lblNoResults = new Label()
            {
                Text = "Niciun abonament gasit!",
                ForeColor = Color.Red,
                Location = new Point(120, 140),
                Visible = false
            };

        
            Button btnBack = new Button()
            {
                Text = "Inapoi",
                Location = new Point(150, 300),
                Width = 80,
                BackColor = System.Drawing.ColorTranslator.FromHtml("#1E2235"),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            btnBack.Click += (s, mouseEvent) =>
            {
                this.Controls.Remove(panelCautare);
                btnAdaugareClient.Show();
                btnAfisareClienti.Show();
                btnCautaClient.Show();
                btnBackClienti.Show();
            };

            btnSearch.Click += (s, ev) =>
            {
                string cautare = txtSearch.Text.Trim();
                lstResults.DataSource = null;
                lstResults.Items.Clear();
                lblNoResults.Visible = false;

                if (string.IsNullOrEmpty(cautare))
                {
                    MessageBox.Show("Introduceti numele clientului!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var abonamenteGasite = adminAbonamente.SearchAbonamenteClienti(cautare);

                if (abonamenteGasite.Any())
                {
                    lstResults.DataSource = abonamenteGasite;
                    lstResults.DisplayMember = "DisplayText";
                }
                else
                {
                    lblNoResults.Visible = true;
                }
            };

     
            panelCautare.Controls.Add(lblTitle);
            panelCautare.Controls.Add(lblSearch);
            panelCautare.Controls.Add(txtSearch);
            panelCautare.Controls.Add(btnSearch);
            panelCautare.Controls.Add(lstResults);
            panelCautare.Controls.Add(lblNoResults);
            panelCautare.Controls.Add(btnBack);  

            this.Controls.Add(panelCautare);
        }


        private void BtnAntrenoriAfisare_Click(object sender, EventArgs e)
        {
            btnAdaugareClient.Hide();
            btnAfisareClienti.Hide();
            btnCautaClient.Hide();
            btnBackClienti.Hide();

            ListView listViewAntrenori = new ListView
            {
                Height = 400,
                Width = 800,
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                ForeColor = Color.White,
                Font = new Font("Arial", 12, FontStyle.Regular),
                BackColor = Color.FromArgb(45, 45, 48),
                HeaderStyle = ColumnHeaderStyle.Nonclickable
            };

            listViewAntrenori.Location = new Point(0, 50); 

            listViewAntrenori.Columns.Add("ID", 60, HorizontalAlignment.Center);
            listViewAntrenori.Columns.Add("Nume", 180, HorizontalAlignment.Left);
            listViewAntrenori.Columns.Add("CNP", 160, HorizontalAlignment.Center);
            listViewAntrenori.Columns.Add("Email", 250, HorizontalAlignment.Left);
            listViewAntrenori.Columns.Add("Telefon", 130, HorizontalAlignment.Center);
            listViewAntrenori.Columns.Add("Specializare", 150, HorizontalAlignment.Left);

            var antrenori = adminAntrenori.GetAntrenori();
            if (antrenori.Count == 0)
            {
                MessageBox.Show("Nu exista antrenori adaugati.", "Informatie", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int index = 0;
                foreach (var antrenor in antrenori)
                {
                    string[] detaliiLinii = antrenor.AfiseazaDetalii().Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    Dictionary<string, string> detalii = new Dictionary<string, string>();

                    foreach (var linie in detaliiLinii)
                    {
                        string[] parts = linie.Split(new[] { ':' }, 2);
                        if (parts.Length == 2)
                        {
                            detalii[parts[0].Trim()] = parts[1].Trim();
                        }
                    }

                    ListViewItem item = new ListViewItem(new[] {
                detalii.ContainsKey("ID") ? detalii["ID"] : "",
                detalii.ContainsKey("Nume") ? detalii["Nume"] : "",
                detalii.ContainsKey("CNP") ? detalii["CNP"] : "",
                detalii.ContainsKey("Email") ? detalii["Email"] : "",
                detalii.ContainsKey("Telefon") ? detalii["Telefon"] : "",
                detalii.ContainsKey("Specializare") ? detalii["Specializare"] : ""
            });

                    item.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E2235");
                    item.ForeColor = Color.WhiteSmoke;

                    listViewAntrenori.Items.Add(item);
                    index++;
                }
            }

         
            Button btnBack = new Button()
            {
                Text = "Inapoi",
                Location = new Point(20, 20),  
                BackColor = System.Drawing.ColorTranslator.FromHtml("#1E2235"),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            btnBack.Click += (s, mouseEvent) =>
            {
                this.Controls.Remove(listViewAntrenori);  
                btnAdaugareClient.Show(); 
                btnAfisareClienti.Show();
                btnCautaClient.Show();
                btnBack.Hide();
                btnBackClienti.Show();
            };

            this.Controls.Add(btnBack);  
            this.Controls.Add(listViewAntrenori);  
        }

        private void BtnAngajatAfisare_Click(object sender, EventArgs e)
        {
            btnAdaugareClient.Hide();
            btnAfisareClienti.Hide();
            btnCautaClient.Hide();
            btnBackClienti.Hide();

            ListView listViewAngajati = new ListView
            {
                Height = 400,
                Width = 800,
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                ForeColor = Color.White,
                Font = new Font("Arial", 12, FontStyle.Regular),
                BackColor = Color.FromArgb(45, 45, 48),
                HeaderStyle = ColumnHeaderStyle.Nonclickable
            };

            listViewAngajati.Location = new Point(0, 50);

            listViewAngajati.Columns.Add("ID", 60, HorizontalAlignment.Center);
            listViewAngajati.Columns.Add("Nume", 180, HorizontalAlignment.Left);
            listViewAngajati.Columns.Add("CNP", 160, HorizontalAlignment.Center);
            listViewAngajati.Columns.Add("Email", 250, HorizontalAlignment.Left);
            listViewAngajati.Columns.Add("Telefon", 130, HorizontalAlignment.Center);
            listViewAngajati.Columns.Add("Functie", 150, HorizontalAlignment.Left);

            var angajati = adminAngajati.GetAngajati();
            if (angajati.Count == 0)
            {
                MessageBox.Show("Nu exista angajati adaugati.", "Informatie", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int index = 0;
                foreach (var angajat in angajati)
                {
                    string[] detaliiLinii = angajat.AfiseazaDetalii().Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    Dictionary<string, string> detalii = new Dictionary<string, string>();

                    foreach (var linie in detaliiLinii)
                    {
                        string[] parts = linie.Split(new[] { ':' }, 2);
                        if (parts.Length == 2)
                        {
                            detalii[parts[0].Trim()] = parts[1].Trim();
                        }
                    }

                    ListViewItem item = new ListViewItem(new[] {
                detalii.ContainsKey("ID") ? detalii["ID"] : "",
                detalii.ContainsKey("Nume") ? detalii["Nume"] : "",
                detalii.ContainsKey("CNP") ? detalii["CNP"] : "",
                detalii.ContainsKey("Email") ? detalii["Email"] : "",
                detalii.ContainsKey("Telefon") ? detalii["Telefon"] : "",
                detalii.ContainsKey("Functie") ? detalii["Functie"] : ""
            });
                    item.BackColor = System.Drawing.ColorTranslator.FromHtml("#1E2235");
                    item.ForeColor = Color.WhiteSmoke;

                    listViewAngajati.Items.Add(item);
                    index++;
                }
            }

            Button btnBack = new Button()
            {
                Text = "Inapoi",
                Location = new Point(20, 10),
                Width = 80,
                BackColor = System.Drawing.ColorTranslator.FromHtml("#1E2235"),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            btnBack.Click += (s, mouseEvent) =>
            {
                this.Controls.Remove(listViewAngajati);
                btnAdaugareClient.Show();
                btnAfisareClienti.Show();
                btnCautaClient.Show();
                btnBack.Hide();
                btnBackClienti.Show();
            };

     
            this.Controls.Add(btnBack);

            this.Controls.Add(listViewAngajati);
        }


        private void BtnAbonament_Click(object sender, EventArgs e)
        {
            btnAbonament.Hide();
            btnAngajat.Hide();
            btnAntrenori.Hide();
            btnClienti.Hide();
            btnBackClienti.Show();

            btnAdaugareClient = new Button();
            btnAfisareClienti = new Button();
            btnCautaClient = new Button();

            Font buttonFont = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
            int buttonWidth = 300;
            int buttonHeight = 50;
            int spaceBetweenButtons = 20;

            int centerX = (this.ClientSize.Width - buttonWidth) / 2;
            int startY = (this.ClientSize.Height - (buttonHeight * 3) - (spaceBetweenButtons * 2)) / 2;

            btnAdaugareClient.Text = "Adaugare abonament";
            btnAdaugareClient.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            btnAdaugareClient.Location = new System.Drawing.Point(centerX, startY);
            btnAdaugareClient.BackColor = System.Drawing.ColorTranslator.FromHtml("#2F3347");
            btnAdaugareClient.ForeColor = System.Drawing.Color.White;
            btnAdaugareClient.Font = buttonFont;
            btnAdaugareClient.FlatStyle = FlatStyle.Flat;
            btnAdaugareClient.FlatAppearance.BorderSize = 0;
            btnAdaugareClient.Click += BtnAdaugareAbonament_Click;
            btnAdaugareClient.MouseEnter += (s, mouseEvent) => { btnAdaugareClient.BackColor = System.Drawing.ColorTranslator.FromHtml("#3A4053"); };
            btnAdaugareClient.MouseLeave += (s, mouseEvent) => { btnAdaugareClient.BackColor = System.Drawing.ColorTranslator.FromHtml("#2F3347"); };

            btnAfisareClienti.Text = "Afisare abonament";
            btnAfisareClienti.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            btnAfisareClienti.Location = new System.Drawing.Point(centerX, startY + buttonHeight + spaceBetweenButtons);
            btnAfisareClienti.BackColor = System.Drawing.ColorTranslator.FromHtml("#2F3347");
            btnAfisareClienti.ForeColor = System.Drawing.Color.White;
            btnAfisareClienti.Font = buttonFont;
            btnAfisareClienti.FlatStyle = FlatStyle.Flat;
            btnAfisareClienti.FlatAppearance.BorderSize = 0;
            btnAfisareClienti.Click += BtnAbonamentList_Click;
            btnAfisareClienti.MouseEnter += (s, mouseEvent) => { btnAfisareClienti.BackColor = System.Drawing.ColorTranslator.FromHtml("#3A4053"); };
            btnAfisareClienti.MouseLeave += (s, mouseEvent) => { btnAfisareClienti.BackColor = System.Drawing.ColorTranslator.FromHtml("#2F3347"); };

            btnCautaClient.Text = "Cautare abonament";
            btnCautaClient.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            btnCautaClient.Location = new System.Drawing.Point(centerX, startY + 2 * (buttonHeight + spaceBetweenButtons));
            btnCautaClient.BackColor = System.Drawing.ColorTranslator.FromHtml("#2F3347");
            btnCautaClient.ForeColor = System.Drawing.Color.White;
            btnCautaClient.Font = buttonFont;
            btnCautaClient.FlatStyle = FlatStyle.Flat;
            btnCautaClient.FlatAppearance.BorderSize = 0;
            btnCautaClient.Click += BtnCautaAbonament_Click;
            btnCautaClient.MouseEnter += (s, mouseEvent) => { btnCautaClient.BackColor = System.Drawing.ColorTranslator.FromHtml("#3A4053"); };
            btnCautaClient.MouseLeave += (s, mouseEvent) => { btnCautaClient.BackColor = System.Drawing.ColorTranslator.FromHtml("#2F3347"); };

            this.Controls.Add(btnAdaugareClient);
            this.Controls.Add(btnAfisareClienti);
            this.Controls.Add(btnCautaClient);
        }

        private void BtnAbonamentList_Click(object sender, EventArgs e)
        {
            btnAdaugareClient.Hide();
            btnAfisareClienti.Hide();
            btnCautaClient.Hide();
            btnBackClienti.Hide();

            ListView listViewAbonamente = new ListView
            {
                Height = 400,
                Width = 800,
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                ForeColor = Color.White,
                Font = new Font("Arial", 12, FontStyle.Regular),
                BackColor = Color.FromArgb(45, 45, 48),
                HeaderStyle = ColumnHeaderStyle.Nonclickable
            };
            listViewAbonamente.Location = new Point(0, 50);

            listViewAbonamente.Columns.Add("ID Abonament", 100, HorizontalAlignment.Center);
            listViewAbonamente.Columns.Add("Tip Abonament", 180, HorizontalAlignment.Center);
            listViewAbonamente.Columns.Add("Pret Lunar", 120, HorizontalAlignment.Center);
            listViewAbonamente.Columns.Add("Luni", 80, HorizontalAlignment.Center);
            listViewAbonamente.Columns.Add("Data inceput", 150, HorizontalAlignment.Center);
            listViewAbonamente.Columns.Add("Data Expirare", 150, HorizontalAlignment.Center);
            listViewAbonamente.Columns.Add("Antrenor", 200, HorizontalAlignment.Left);
            listViewAbonamente.Columns.Add("Client", 200, HorizontalAlignment.Left);

            var abonamente = adminAbonamente.GetAbonamenteClienti();
            if (abonamente.Count == 0)
            {
                MessageBox.Show("Nu exista abonamente active.", "Informatie", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                foreach (var abonament in abonamente)
                {
                    string[] detaliiLinii = abonament.AfiseazaDetalii().Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    Dictionary<string, string> detalii = new Dictionary<string, string>();

                    foreach (var linie in detaliiLinii)
                    {
                        string[] parts = linie.Split(new[] { ':' }, 2);
                        if (parts.Length == 2)
                        {
                            detalii[parts[0].Trim()] = parts[1].Trim();
                        }
                    }

                    ListViewItem item = new ListViewItem(new[] {
                detalii.ContainsKey("ID") ? detalii["ID"] : "N/A",
                detalii.ContainsKey("Tip Abonament") ? detalii["Tip Abonament"] : "N/A",
                detalii.ContainsKey("Pret Lunar") ? detalii["Pret Lunar"] : "N/A",
                detalii.ContainsKey("Luni") ? detalii["Luni"] : "N/A",
                detalii.ContainsKey("Incepe") ? detalii["Incepe"] : "N/A",
                detalii.ContainsKey("Expira") ? detalii["Expira"] : "N/A",
                detalii.ContainsKey("Antrenor") ? detalii["Antrenor"] : "N/A",
                detalii.ContainsKey("Client") ? detalii["Client"] : "N/A"
            });

                    item.BackColor = ColorTranslator.FromHtml("#1E2235");
                    item.ForeColor = Color.WhiteSmoke;
                    listViewAbonamente.Items.Add(item);
                }
            }

            Button btnBack = new Button()
            {
                Text = "Inapoi",
                Location = new Point(0, 10),
                Width = 200,
                BackColor = System.Drawing.ColorTranslator.FromHtml("#1E2235"),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

        
            btnBack.Click += (s, mouseEvent) =>
            {
                this.Controls.Remove(listViewAbonamente);
                btnAdaugareClient.Show();
                btnAfisareClienti.Show();
                btnCautaClient.Show();
                btnBackClienti.Show();
                btnBack.Hide();
            };

            this.Controls.Add(btnBack);  
            this.Controls.Add(listViewAbonamente);
        }

        private void BtnAdaugareAbonament_Click(object sender, EventArgs e)
        {
            btnAdaugareClient.Hide();
            btnAfisareClienti.Hide();
            btnCautaClient.Hide();
            btnBackClienti.Hide();

            Panel panelForm = new Panel()
            {
                Size = new Size(400, 600),
                Location = new Point((this.Width - 400) / 2, 50),
                BackColor = System.Drawing.ColorTranslator.FromHtml("#373D55"),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblTitle = new Label()
            {
                Text = "Adaugare Abonament",
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(100, 10)
            };

            Label lblTipAbonament = new Label() { Text = "Tip abonament:", ForeColor = Color.White, Location = new Point(20, 50) };
            ComboBox cmbTipAbonament = new ComboBox() { Location = new Point(150, 50), Width = 200 };
            cmbTipAbonament.Items.AddRange(Abonament.TipuriAbonamente.Select(a => a.Tip).ToArray());
            Label lblErrorTipAbonament = CreateErrorLabel(80);

            Label lblNumarLuni = new Label() { Text = "Numar luni:", ForeColor = Color.White, Location = new Point(20, 100) };
            TextBox txtNumarLuni = new TextBox() { Location = new Point(150, 100), Width = 200 };
            Label lblErrorNumarLuni = CreateErrorLabel(130);

            Label lblAntrenor = new Label() { Text = "Antrenor:", ForeColor = Color.White, Location = new Point(20, 150) };
            ComboBox cmbAntrenor = new ComboBox() { Location = new Point(150, 150), Width = 200 };
            var listaAntrenori = adminAntrenori.GetAntrenori();
            cmbAntrenor.Items.AddRange(listaAntrenori.ToArray());
            cmbAntrenor.DisplayMember = "Nume";
            cmbAntrenor.ValueMember = "Id";
            Label lblErrorAntrenor = CreateErrorLabel(180);

            Label lblClient = new Label() { Text = "Client:", ForeColor = Color.White, Location = new Point(20, 200) };
            ComboBox cmbClient = new ComboBox() { Location = new Point(150, 200), Width = 200 };

            var listaClienti = adminClienti.GetClienti();

            cmbClient.DataSource = null;
            cmbClient.Items.Clear();
            cmbClient.DataSource = listaClienti;
            cmbClient.DisplayMember = "DisplayText";
            cmbClient.ValueMember = "CNP";

            Label lblErrorClient = CreateErrorLabel(230);

            Button btnSubmit = new Button()
            {
                Text = "Adauga Abonament",
                Location = new Point(100, 300),
                Width = 200,
                BackColor = System.Drawing.ColorTranslator.FromHtml("#1E2235"),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            Button btnBack = new Button()
            {
                Text = "Inapoi",
                Location = new Point(100, 350),
                Width = 200,
                BackColor = System.Drawing.ColorTranslator.FromHtml("#1E2235"),
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

        
            btnBack.Click += (s, mouseEvent) =>
            {
                this.Controls.Remove(panelForm);
                btnAdaugareClient.Show();
                btnAfisareClienti.Show();
                btnCautaClient.Show();
                btnBackClienti.Show();
            };

            btnSubmit.Click += (s, mouseEvent) =>
            {
                bool valid = true;

                cmbTipAbonament.BackColor = Color.White;
                lblErrorTipAbonament.Text = "";
                txtNumarLuni.BackColor = Color.White;
                lblErrorNumarLuni.Text = "";
                cmbAntrenor.BackColor = Color.White;
                lblErrorAntrenor.Text = "";
                cmbClient.BackColor = Color.White;
                lblErrorClient.Text = "";

                string tipAbonamentValidation = Validator.ValidateTipAbonament(cmbTipAbonament.SelectedItem?.ToString());
                if (tipAbonamentValidation != null)
                {
                    lblErrorTipAbonament.Text = tipAbonamentValidation;
                    cmbTipAbonament.BackColor = Color.LightCoral;
                    valid = false;
                }

                string numarLuniValidation = Validator.ValidateNumarLuni(txtNumarLuni.Text.Trim());
                if (numarLuniValidation != null)
                {
                    lblErrorNumarLuni.Text = numarLuniValidation;
                    txtNumarLuni.BackColor = Color.LightCoral;
                    valid = false;
                }

                Antrenor antrenorAbonamentSelectat = cmbAntrenor.SelectedItem as Antrenor;
                string antrenorValidation = Validator.ValidateAntrenor(antrenorAbonamentSelectat);
                if (antrenorValidation != null)
                {
                    lblErrorAntrenor.Text = antrenorValidation;
                    cmbAntrenor.BackColor = Color.LightCoral;
                    valid = false;
                }

                Client clientAbonamentSelectat = cmbClient.SelectedItem as Client;
                if (clientAbonamentSelectat == null)
                {
                    lblErrorClient.Text = "Te rog selecteaza un client valid.";
                    cmbClient.BackColor = Color.LightCoral;
                    valid = false;
                }

                if (!valid) return;

                string tipAbonamentNou = cmbTipAbonament.SelectedItem?.ToString();
                Abonament abonamentSelectat = Abonament.TipuriAbonamente.FirstOrDefault(a => a.Tip.Equals(tipAbonamentNou, StringComparison.OrdinalIgnoreCase));

                if (abonamentSelectat == null)
                {
                    MessageBox.Show("Tipul de abonament nu este valid.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(txtNumarLuni.Text, out int numarLuniAbonament) || numarLuniAbonament <= 0)
                {
                    MessageBox.Show("Introduceti un numar valid de luni!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DateTime dataIncepereAbonament = DateTime.Now;
                DateTime dataExpirareAbonament = dataIncepereAbonament.AddMonths(numarLuniAbonament);

                AbonamentClient abonamentClientNou = new AbonamentClient(abonamentSelectat, numarLuniAbonament, dataIncepereAbonament, antrenorAbonamentSelectat, clientAbonamentSelectat)
                {
                    Id = Guid.NewGuid()
                };

                clientAbonamentSelectat.AbonamentClient = abonamentClientNou;
                clientAbonamentSelectat.Status = "Activ";
                adminAbonamente.AddAbonamentClient(abonamentClientNou);

                MessageBox.Show("Abonamentul a fost atribuit cu succes clientului!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Controls.Remove(panelForm);
                btnAdaugareClient.Show();
                btnAfisareClienti.Show();
                btnCautaClient.Show();
            };

            panelForm.Controls.Add(lblTitle);
            panelForm.Controls.Add(lblTipAbonament);
            panelForm.Controls.Add(cmbTipAbonament);
            panelForm.Controls.Add(lblErrorTipAbonament);
            panelForm.Controls.Add(lblNumarLuni);
            panelForm.Controls.Add(txtNumarLuni);
            panelForm.Controls.Add(lblErrorNumarLuni);
            panelForm.Controls.Add(lblAntrenor);
            panelForm.Controls.Add(cmbAntrenor);
            panelForm.Controls.Add(lblErrorAntrenor);
            panelForm.Controls.Add(lblClient);
            panelForm.Controls.Add(cmbClient);
            panelForm.Controls.Add(lblErrorClient);
            panelForm.Controls.Add(btnSubmit);
            panelForm.Controls.Add(btnBack);  

            this.Controls.Add(panelForm);
        }
        private void BtnReintoarcere_Click(object sender, EventArgs e)
        {

            btnBackClienti.Hide();
            foreach (Control control in this.Controls)
            {
                if (control is Button)
                {
                    control.Hide(); 
                }
            }

            btnClienti.Show();
            btnAntrenori.Show();
            btnAngajat.Show();
            btnAbonament.Show();
            btnHome.Show();

        }

    }
}

