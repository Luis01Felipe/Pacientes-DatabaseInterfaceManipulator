using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

/* Nomeclature:
 * 
 * btn = Button
 * lb  = Label
 * tb  = TextBox
 * 
*/

namespace GUI_C_
{
    public partial class WindowManipulate : Form
    {
        private string myConnectionString;
        public WindowManipulate()
        {
            InitializeComponent();

            // Reverter a propriedade TransparencyKey para o valor padrão (Color.Empty)
            this.TransparencyKey = Color.Empty;

            myConnectionString = "server=localhost;database=pacientes;uid=root;pwd=pateta;";

            GerarTabela();

        }

        private void GerarTabela()
        {
            MySqlConnection connection = new MySqlConnection(myConnectionString);

            MySqlCommand command = new MySqlCommand("SELECT * FROM pacientes", connection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataSet dataSet = new DataSet();

            adapter.Fill(dataSet, "YourTable");

            visãoTabela.DataSource = dataSet.Tables["YourTable"];
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
            MySqlConnection cnn = new MySqlConnection(myConnectionString);
            try
            {
                cnn.Open();
                MessageBox.Show("Connection Open!");

                // Crie a instrução SQL de INSERT
                string query = "INSERT INTO pacientes (ID, Nome, DataQui, Hospital, Chegada, Medicamento, PréQui, DuranteQui, ApósQui, Observações) VALUES (@valor1, @valor2, @valor3, @valor4, @valor5, @valor6, @valor7, @valor8, @valor9, @valor10)";

                MySqlCommand cmd = new MySqlCommand(query, cnn);

                // Substitua @valor1 e @valor2 pelos valores que você deseja inserir
                cmd.Parameters.AddWithValue("@valor1", tbID.Text);
                cmd.Parameters.AddWithValue("@valor2", tbName.Text);
                cmd.Parameters.AddWithValue("@valor3", tbDate.Text); 
                cmd.Parameters.AddWithValue("@valor4", tbHospital.Text);
                cmd.Parameters.AddWithValue("@valor5", tbArrive.Text);
                cmd.Parameters.AddWithValue("@valor6", tbMedicine.Text);
                cmd.Parameters.AddWithValue("@valor7", tbPreQui.Text);
                cmd.Parameters.AddWithValue("@valor8", tbDuringQui.Text);
                cmd.Parameters.AddWithValue("@valor9", tbAfterQui.Text);
                cmd.Parameters.AddWithValue("@valor10",tbObs.Text);

                // Execute o comando INSERT
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data Inserted!");

                cnn.Close();
                GerarTabela();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot open connection: " + ex.Message);
            }

        }

        private void Selecionar_Click(object sender, EventArgs e)
        {
            MySqlConnection cnn = new MySqlConnection(myConnectionString);
            try
            {
                cnn.Open();
                MessageBox.Show("Connection Open!");

                // Crie a instrução SQL SELECT
                string query = "SELECT * FROM pacientes WHERE id = @id"; // Supondo que você queira selecionar com base em um ID

                MySqlCommand cmd = new MySqlCommand(query, cnn);

                // Substitua @id pelo valor que você deseja selecionar
                cmd.Parameters.AddWithValue("@id", tbID.Text);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Preencha os campos de texto com os resultados da consulta
                        tbName.Text = reader["Nome"].ToString(); // Substitua "nome" pelo nome da coluna em seu banco de dados
                        tbDate.Text = reader["DataQui"].ToString();
                        tbHospital.Text = reader["Hospital"].ToString();
                        tbArrive.Text = reader["Chegada"].ToString();
                        tbMedicine.Text = reader["Medicamento"].ToString();
                        tbPreQui.Text = reader["PréQui"].ToString();
                        tbDuringQui.Text = reader["DuranteQui"].ToString();
                        tbAfterQui.Text = reader["ApósQui"].ToString();
                        tbObs.Text = reader["Observações"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Nenhum registro encontrado.");
                    }
                }

                cnn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot open connection: " + ex.Message);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MySqlConnection cnn = new MySqlConnection(myConnectionString);
            try
            {
                cnn.Open();
                MessageBox.Show("Connection Open!");

                // Crie a instrução SQL de INSERT
                string query = "DELETE FROM pacientes WHERE ID=@valor1";

                MySqlCommand cmd = new MySqlCommand(query, cnn);

                // Substitua @valor1 e @valor2 pelos valores que você deseja inserir
                cmd.Parameters.AddWithValue("@valor1", tbID.Text);

                // Execute o comando INSERT
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data Deleted!");

                cnn.Close();
                GerarTabela();
                Clear_Click(sender, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot open connection: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MySqlConnection cnn = new MySqlConnection(myConnectionString);
            try
            {
                cnn.Open();
                MessageBox.Show("Connection Open!");

                // Crie a instrução SQL de UPDATE com uma cláusula WHERE para especificar o registro a ser atualizado
                string query = "UPDATE pacientes SET Nome = IF(@valor1 <> '', @valor1, Nome), DataQui = IF(@valor2 <> '', @valor2, DataQui), Hospital = IF(@valor3 <> '', @valor3, Hospital), Chegada = IF(@valor4 <> '', @valor4, Chegada), Medicamento = IF(@valor5 <> '', @valor5, Medicamento), PréQui = IF(@valor6 <> '', @valor6, PréQui), DuranteQui = IF(@valor7 <> '', @valor7, DuranteQui), ApósQui = IF(@valor8 <> '', @valor8, ApósQui), Observações = IF(@valor9 <> '', @valor9, Observações) WHERE ID = @id";

                MySqlCommand cmd = new MySqlCommand(query, cnn);

                // Substitua @valor1 a @valor9 pelos valores que você deseja atualizar
                cmd.Parameters.AddWithValue("@valor1", tbName.Text);
                cmd.Parameters.AddWithValue("@valor2", tbDate.Text);
                cmd.Parameters.AddWithValue("@valor3", tbHospital.Text);
                cmd.Parameters.AddWithValue("@valor4", tbArrive.Text);
                cmd.Parameters.AddWithValue("@valor5", tbMedicine.Text);
                cmd.Parameters.AddWithValue("@valor6", tbPreQui.Text);
                cmd.Parameters.AddWithValue("@valor7", tbDuringQui.Text);
                cmd.Parameters.AddWithValue("@valor8", tbAfterQui.Text);
                cmd.Parameters.AddWithValue("@valor9", tbObs.Text);

                // Substitua @id pelo ID do registro que você deseja atualizar
                cmd.Parameters.AddWithValue("@id", tbID.Text);

                // Execute o comando UPDATE
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data Updated!");

                cnn.Close();
                GerarTabela();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot open connection: " + ex.Message);
            }
        }

        private void tbID_TextChanged_1(object sender, EventArgs e)
        {
            if (!int.TryParse(tbID.Text, out int result))
            {
                // Se o texto não puder ser convertido para um número inteiro, você pode mostrar uma mensagem de erro.
                if(tbID.Text != string.Empty)
                {
                    MessageBox.Show("O ID deve ser um número inteiro de até quatro dígitos.");

                }

                tbID.Text = string.Empty; // Limpa o TextBox
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Digite os dados a serem inseridos nas caixas de texto correspondentes. O único dado obrigatório a ser preenchido é o ID. " +
                "Quando terminar, clique em Adicionar. Se desejar visualizar os dados de um paciente específico, insira o ID correspondente e, em seguida, " +
                "clique em Selecionar. Para atualizar informações, preencha o campo ID com as alterações desejadas e pressione Atualizar. " +
                "O mesmo procedimento se aplica para excluir informações. O botão Limpar permite remover o texto das caixas de texto. " +
                "A janela ao lado permite que o usuário visualize todas as informações em tempo real.\r\n\r\n");
        }
    }
}





