using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Collections.Generic;
using System.ComponentModel;

/* Nomeclature:
 * 
 * btn = Button
 * lb  = Label
 * tb  = TextBox
 * dgv = DataGridView
 * 
*/

namespace GUI_C_
{

    public partial class WindowManipulate : Form
    {
        public WindowManipulate()
        {
            InitializeComponent();

            // Reverter a propriedade TransparencyKey para o valor padrão (Color.Empty)
            this.TransparencyKey = Color.Empty;

            client = new FireSharp.FirebaseClient(config);

            //dgvTableView.ReadOnly = true;
            
            //dgvTableView.AutoGenerateColumns = true; // Isso é útil para gerar colunas automaticamente com base nas propriedades do seu objeto


        }

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "YG9GJQGnUbrsz0JCOB5Q7nlVdvcWu75lrfjZVnpz",
            BasePath = "https://controlepacientes-d535b-default-rtdb.firebaseio.com"
        };

        IFirebaseClient client;


        private void Clear_Click(object sender, EventArgs e)
        {
            tbID.ResetText();
            tbName.ResetText();
            tbDate.ResetText();
            tbHospital.ResetText();
            tbArrive.ResetText();
            tbMedicine.ResetText();
            tbPreQui.ResetText();
            tbDuringQui.ResetText();
            tbAfterQui.ResetText();
            tbObs.ResetText();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            var data = new
            {
                ID = tbID.Text,
                Nome = tbName.Text,
                DataQui = tbDate.Text,
                Hospital = tbHospital.Text,
                Chegada = tbArrive.Text,
                Medicamento = tbMedicine.Text,
                PréQui = tbPreQui.Text,
                DuranteQui = tbDuringQui.Text,
                ApósQui = tbAfterQui.Text,
                Observações = tbObs.Text
            };

            SetResponse response = client.Set("pacientes/" + tbID.Text, data);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show("Dados Inseridos!");
                btnUpdateView_Click(null, null);
            }
            else
            {
                MessageBox.Show("Erro ao inserir dados no Firebase.");
            }
        }

        private void Selecionar_Click(object sender, EventArgs e)
        {
            try
            {
                var data = client.Get("pacientes/" + tbID.Text);

                if (data.Body != null)
                {
                    var paciente = data.ResultAs<Paciente>(); // Certifique-se de criar uma classe "Paciente" para mapear os dados.

                    tbName.Text = paciente.Nome;
                    tbDate.Text = paciente.DataQui;
                    tbHospital.Text = paciente.Hospital;
                    tbArrive.Text = paciente.Chegada;
                    tbMedicine.Text = paciente.Medicamento;
                    tbPreQui.Text = paciente.PréQui;
                    tbDuringQui.Text = paciente.DuranteQui;
                    tbAfterQui.Text = paciente.ApósQui;
                    tbObs.Text = paciente.Observações;

                    MessageBox.Show("Registro encontrado.");
                }
                else
                {
                    MessageBox.Show("Nenhum registro encontrado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar o registro: " + ex.Message);
            }


        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Crie uma instância do FirebaseClient com sua configuração
                var firebaseClient = new FireSharp.FirebaseClient(config);

                // Substitua "seu_nó" pelo caminho correto em seu banco de dados
                var response = await firebaseClient.DeleteAsync("pacientes/" + tbID.Text);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("Registro excluído com sucesso!");
                    Clear_Click(sender, e);
                    btnUpdateView_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Falha ao excluir o registro. Verifique o ID.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir o registro: " + ex.Message);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var firebaseClient = new FireSharp.FirebaseClient(config);

                var data = client.Get("pacientes/" + tbID.Text);

                if (data.Body != null)
                {
                    var paciente = data.ResultAs<Paciente>();

                    if (paciente != null)
                    {
                        // Atualize apenas os campos que foram preenchidos
                        if (!string.IsNullOrEmpty(tbName.Text))
                            paciente.Nome = tbName.Text;
                        if (!string.IsNullOrEmpty(tbDate.Text))
                            paciente.DataQui = tbDate.Text;
                        if (!string.IsNullOrEmpty(tbHospital.Text))
                            paciente.Hospital = tbHospital.Text;
                        if (!string.IsNullOrEmpty(tbArrive.Text))
                            paciente.Chegada = tbArrive.Text;
                        if (!string.IsNullOrEmpty(tbMedicine.Text))
                            paciente.Medicamento = tbMedicine.Text;
                        if (!string.IsNullOrEmpty(tbPreQui.Text))
                            paciente.PréQui = tbPreQui.Text;
                        if (!string.IsNullOrEmpty(tbDuringQui.Text))
                            paciente.DuranteQui = tbDuringQui.Text;
                        if (!string.IsNullOrEmpty(tbAfterQui.Text))
                            paciente.ApósQui = tbAfterQui.Text;
                        if (!string.IsNullOrEmpty(tbObs.Text))
                            paciente.Observações = tbObs.Text;

                        // Agora, atualize o registro com os campos relevantes
                        var response = await firebaseClient.UpdateAsync("pacientes/" + tbID.Text, paciente);

                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            MessageBox.Show("Registro atualizado com sucesso!");
                            //Clear_Click(sender, e);
                            btnUpdateView_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Falha ao atualizar o registro. Verifique o ID.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Registro não foi carregado corretamente. Verifique a estrutura dos dados no Firebase.");
                    }
                }
                else
                {
                    MessageBox.Show("Nenhum registro encontrado para atualizar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar o registro: " + ex.Message);
            }


        }

        private void tbID_TextChanged_1(object sender, EventArgs e)
        {
            if (!int.TryParse(tbID.Text, out int result))
            {
                // Se o texto não puder ser convertido para um número inteiro, você pode mostrar uma mensagem de erro.
                if (tbID.Text != string.Empty)
                {
                    MessageBox.Show("O ID deve ser um número inteiro de até quatro dígitos.");
                }

                tbID.Text = string.Empty; // Limpa o TextBox
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show
                (
                "Digite os dados a serem inseridos nas caixas de texto correspondentes. O único dado obrigatório a ser preenchido é o ID. " +
                "Quando terminar, clique em Adicionar. Se desejar visualizar os dados de um paciente específico, insira o ID correspondente e, em seguida, " +
                "clique em Selecionar. Para atualizar informações, preencha o campo ID com as alterações desejadas e pressione Atualizar. " +
                "O mesmo procedimento se aplica para excluir informações. O botão Limpar permite remover o texto das caixas de texto. " +
                "A janela ao lado permite que o usuário visualize todas as informações em tempo real.\r\n\r\n"
                );
        }

        private void btnUpdateView_Click(object sender, EventArgs e)
        {
           
        }

        private void tbDate_TextChanged(object sender, EventArgs e)
        {
            if (tbDate.Text.Length == 2 || tbDate.Text.Length == 5)
            {
                tbDate.Text += "/"; // Adiciona a barra nas posições corretas
                tbDate.SelectionStart = tbDate.Text.Length; // Coloca o cursor no final
            }

            if (tbDate.Text.Length >= 10)
            {
                tbDate.Text = tbDate.Text.Substring(0, 10); // Limita a data a 10 caracteres (dd/mm/yyyy)
            }

            // Verifica se o dia (dd) está dentro do limite (1 a 31)
            if (tbDate.Text.Length >= 2 && int.Parse(tbDate.Text.Substring(0, 2)) > 31)
            {
                tbDate.Text = "31" + tbDate.Text.Substring(2);
            }

            // Verifica se o mês (mm) está dentro do limite (1 a 12)
            if (tbDate.Text.Length >= 5 && int.Parse(tbDate.Text.Substring(3, 2)) > 12)
            {
                tbDate.Text = tbDate.Text.Substring(0, 3) + "12" + tbDate.Text.Substring(5);
            }
        }

        private void tbDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica se a tecla pressionada não é um número ou uma tecla de controle (como Backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Impede a entrada do caractere não desejado
            }
        }

        private void tbArrive_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica se a tecla pressionada não é um dígito ou uma tecla de controle (como Backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Impede a entrada do caractere não desejado
            }
        }

        private void tbArrive_TextChanged(object sender, EventArgs e)
        {
            if (tbArrive.Text.Length == 2)
            {
                tbArrive.Text += ":"; // Adiciona a barra nas posições corretas
                tbArrive.SelectionStart = tbArrive.Text.Length; // Coloca o cursor no final
            }

            // Verifica se as horas (hh) está dentro do limite (1 a 12)
            if (tbArrive.Text.Length >= 2)
            {
                int hours = int.Parse(tbArrive.Text.Substring(0, 2));
                if (hours > 12)
                {
                    tbArrive.Text = "12" + tbArrive.Text.Substring(2);
                }
            }

            // Verifica se os minutos (mm) estão dentro do limite (0 a 59)
            if (tbArrive.Text.Length >= 5)
            {
                int minutes = int.Parse(tbArrive.Text.Substring(3, 2));
                if (minutes > 59)
                {
                    tbArrive.Text = tbArrive.Text.Substring(0, 3) + "59";
                }
            }
        }

        private void tbArrive_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica se a tecla pressionada é o 'Backspace'
            if (e.KeyCode == Keys.Back)
            {
                // Obtém o texto atual do TextBox
                string text = tbArrive.Text;

                // Verifica se o texto contém ':' na última posição
                if (text.EndsWith(":"))
                {
                    // Remove o último caractere (':') do texto
                    text = text.Substring(0, text.Length - 1);

                    // Define o texto atual do TextBox
                    tbArrive.Text = text;

                    // Define o cursor para o final do texto
                    tbArrive.SelectionStart = text.Length;

                    // Marca o evento como manipulado (para evitar que o Backspace exclua outros caracteres)
                    e.Handled = true;
                }
            }
        }
    }

    public class Paciente
    {
        public string Nome { get; set; }
        public string DataQui { get; set; }
        public string Hospital { get; set; }
        public string Chegada { get; set; }
        public string Medicamento { get; set; }
        public string PréQui { get; set; }
        public string DuranteQui { get; set; }
        public string ApósQui { get; set; }
        public string Observações { get; set; }
    }
}





