using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


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
        private IFirebaseClient client;

        public WindowManipulate()
        {
            InitializeComponent();
            this.TransparencyKey = Color.Empty;
            client = new FireSharp.FirebaseClient(config);

            PreencherDataGridViewFirebase();
        }


        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "YG9GJQGnUbrsz0JCOB5Q7nlVdvcWu75lrfjZVnpz",
            BasePath = "https://controlepacientes-d535b-default-rtdb.firebaseio.com"
        };

        private void PreencherDataGridViewFirebase()
        {
            try
            {
                var firebaseClient = new FireSharp.FirebaseClient(config);

                var data = firebaseClient.Get("pacientes");

                if (data.Body != "null")
                {
                    var jsonArray = JArray.Parse(data.Body);
                    var pacientes = jsonArray.ToObject<List<Paciente>>();

                    if (pacientes.Count > 0)
                    {
                        dgvTableView.DataSource = pacientes;
                    }
                    else
                    {
                        MessageBox.Show("Nenhum registro de paciente encontrado.");
                    }
                }
                else
                {
                    MessageBox.Show("Nenhum registro encontrado para exibir.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao exibir registros: " + ex.Message);
            }
        }

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
            try
            {
                var firebaseClient = new FireSharp.FirebaseClient(config);
                var existingData = firebaseClient.Get("pacientes/" + tbID.Text);

                if (existingData.Body != "null")
                {
                    MessageBox.Show("ID já existe no banco de dados. Utilize um ID único.");
                }
                else
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir o registro: " + ex.Message);
            }
        }

        private void Selecionar_Click(object sender, EventArgs e)
        {
            try
            {
                var data = client.Get("pacientes/" + tbID.Text);

                if (data.Body != null)
                {
                    var paciente = data.ResultAs<Paciente>();

                    tbName.Text = paciente.Nome;
                    tbDate.Text = paciente.DataQui;
                    tbHospital.Text = paciente.Hospital;
                    tbArrive.Text = paciente.Chegada;
                    tbMedicine.Text = paciente.Medicamento;
                    tbPreQui.Text = paciente.PréQui;
                    tbDuringQui.Text = paciente.DuranteQui;
                    tbAfterQui.Text = paciente.ApósQui;
                    tbObs.Text = paciente.Observacoes;

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
                if (string.IsNullOrWhiteSpace(tbID.Text))
                {
                    MessageBox.Show("É necessário inserir um ID para excluir!");
                }
                else if (tbID.Text == "0")
                {
                    MessageBox.Show("Não é possível excluir o registro de ID 0.");
                }
                else
                {
                    var firebaseClient = new FireSharp.FirebaseClient(config);
                    var existingData = firebaseClient.Get("pacientes/" + tbID.Text);

                    if (existingData.Body != "null")
                    {
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
                    else
                    {
                        MessageBox.Show("O registro com o ID fornecido não existe.");
                    }
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

                // Verifique se o registro com o ID fornecido existe no Firebase
                var existingData = firebaseClient.Get("pacientes/" + tbID.Text);

                if (existingData.Body != "null")
                {
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
                                paciente.Observacoes = tbObs.Text;

                            var response = await firebaseClient.UpdateAsync("pacientes/" + tbID.Text, paciente);

                            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                MessageBox.Show("Registro atualizado com sucesso!");
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
                else
                {
                    MessageBox.Show("O registro com o ID fornecido não existe. Não é possível atualizá-lo.");
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
                "Digite os dados nas caixas de texto e clique em 'Adicionar' para inserir um novo registro.\n\n" +
                "Para atualizar um registro, digite o ID do registro que deseja atualizar e clique em 'Selecionar'. Os dados do registro serão carregados nas caixas de texto. Altere os dados que deseja atualizar e clique em 'Atualizar'.\n\n" +
                "Para excluir um registro, digite o ID do registro que deseja excluir e clique em 'Excluir'.\n\n" +
                "Para visualizar um registro, digite o ID do registro que deseja visualizar e clique em 'Selecionar' ou clique duas vezes em uma celula da tabela correspondente a linha do registro. Os dados do registro serão carregados nas caixas de texto.\n\n" +
                "Para limpar as caixas de texto, clique em 'Limpar'.\n\n" +
                "Para atualizar visualização da tabela de registros, clique em 'Atualizar Tabela'.\n\n"
                );
        }

        private void btnUpdateView_Click(object sender, EventArgs e)
        {
            PreencherDataGridViewFirebase();
        }

        private void tbDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica se a tecla pressionada não é um número ou uma tecla de controle (como Backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Impede a entrada do caractere não desejado
            }
        }

        private void tbDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (tbDate.Text.Length == 2 || tbDate.Text.Length == 5)
                {
                    tbDate.Text += "/";
                    tbDate.SelectionStart = tbDate.Text.Length; // Coloca o cursor no final
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
            catch (Exception ex)
            {
                if (ex.Message.Contains("A cadeia de caracteres de entrada não estava em um formato correto."))
                {
                    MessageBox.Show("Erro ao alterar a data. Este erro ocorre quando tenta-se apagar um valor antes de alguma barra (/). Por favor, insira uma data válida no formato 'dd/mm/yyyy'.");
                }
                else
                {
                    MessageBox.Show("Erro ao alterar a data: " + ex.Message);
                }
                tbDate.Text = string.Empty;
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
            try
            {
                if (tbArrive.Text.Length == 2 & !(tbArrive.Text.Contains(":")))
                {
                    tbArrive.Text += ":";
                    tbArrive.SelectionStart = tbArrive.Text.Length; // Coloca o cursor no final
                }

                // Verifica se as horas (hh) está dentro do limite (1 a 12)
                if (tbArrive.Text.Length >= 2)
                {
                    int hours = int.Parse(tbArrive.Text.Substring(0, 2));
                    if (hours > 24)
                    {
                        tbArrive.Text = "24" + tbArrive.Text.Substring(2);
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
            catch (Exception ex)
            {
                if (ex.Message.Contains("A cadeia de caracteres de entrada não estava em um formato correto."))
                {
                    MessageBox.Show("Erro ao alterar a hora. Este erro ocorre quando tenta-se apagar um valor antes do dois pontos (:). Por favor, insira um horário válido no formato 'hh:mm'.");
                }
                else
                {
                    MessageBox.Show("Erro ao alterar a hora: " + ex.Message);
                }
                tbArrive.Text = string.Empty;
            }
        }

        private void dgvTableView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Verifica se o evento ocorreu em uma linha válida
                DataGridViewRow selectedRow = dgvTableView.Rows[e.RowIndex];
                if (selectedRow.Cells["ID"].Value != null)
                {
                    // Obtém o valor da coluna "ID" da linha clicada
                    string idValue = selectedRow.Cells["ID"].Value.ToString();
                    tbID.Text = idValue;
                    Selecionar_Click(sender, e);
                }
            }
        }
    }

    public class Paciente
    {
        [JsonProperty("ID")]
        public string ID { get; set; }

        [JsonProperty("Nome")]
        public string Nome { get; set; }

        [JsonProperty("DataQui")]
        public string DataQui { get; set; }

        [JsonProperty("Hospital")]
        public string Hospital { get; set; }

        [JsonProperty("Chegada")]
        public string Chegada { get; set; }

        [JsonProperty("Medicamento")]
        public string Medicamento { get; set; }

        [JsonProperty("PréQui")]
        public string PréQui { get; set; }

        [JsonProperty("DuranteQui")]
        public string DuranteQui { get; set; }

        [JsonProperty("ApósQui")]
        public string ApósQui { get; set; }

        [JsonProperty("Observações")]
        public string Observacoes { get; set; }
    }
}