using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SistemaCadastro
{
    public partial class Form1 : Form
    {
        struct tdado //cada tado é um 'objeto'
        {
          
            public string nome, cpf;

  
        };
        int qtd = 0;
        //cada posição da fila há um objeto
        Queue<tdado> fila = new Queue<tdado>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void mostrar()
        {
            txtFila.Clear();
            foreach (tdado d in fila)
                txtFila.AppendText(d.nome + "-" + d.cpf + "\r\n");

        }

        private void btnConfirmar_Click(object sender, EventArgs e) //cadastrar
        {
            tdado d;
            d.nome = txtNome.Text;
            d.cpf = txtCPF.Text;
            fila.Enqueue(d);
            txtNome.Clear();//enfeite
            txtCPF.Clear();//enfeite
            txtNome.Focus();//enfeite
            MessageBox.Show("Cadastrado com sucesso! :)");
            mostrar();
        }
        void salvar()
        {
            BinaryWriter arq = new BinaryWriter(File.Open("fila.txt", FileMode.Create));
            arq.Write(fila.Count());
            foreach (tdado b in fila)
            {
                arq.Write(b.nome);
                arq.Write(b.cpf);
            }
            arq.Close();
            MessageBox.Show("Dados Salvos com Sucesso", "Mensagem");
        }
        void carregar()
        {

            BinaryReader arq = new BinaryReader(
                File.Open("fila.txt", FileMode.Open));
            if (File.Exists("fila.txt"))
            {
                qtd = arq.ReadInt32();
                for (int i = 0; i < qtd; i++)
                {
                    tdado b;
                    b.nome = arq.ReadString();
                    b.cpf = arq.ReadString();
                    fila.Enqueue(b);
                }// fim for
                arq.Close();
                mostrar();
            }// fim if 
            else
                MessageBox.Show("Arquivo não encontrado", "Erro");
        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            carregar();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            salvar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            {
                int cont = 1;
                bool flag = false;
                foreach (Form1.tdado current in this.fila)//percorrer a fila posição por posição
                {
                    bool flag2 = current.cpf == this.txtBuscar.Text;//para verificar que o cpf atual é igual a busca
                    if (flag2)
                    {
                        MessageBox.Show(string.Concat(new object[]
                        {
                        current.nome,
                        " está na ",
                        cont,
                        "º posição da fila"
                        }));
                        flag = true;
                        break;
                    }
                    cont++;
                }
                
                if (!flag)
                {
                    MessageBox.Show("CPF:" + this.txtBuscar.Text + " não está na fila");
                }
            }

    

    }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            
        }


        private void btnAtender_Click(object sender, EventArgs e)
        {
            bool flag = this.fila.Count<Form1.tdado>() > 0;//verificar se existe elementos na fila
            if (flag)
            {
                Form1.tdado tdado = this.fila.Dequeue();
                this.lblAtendimento.Text = "Próximo \n" + tdado.nome + " \n CPF:" + tdado.cpf;
                this.mostrar();
            }
            else
            {
                MessageBox.Show("Fila Vazia");
            }
        }
         

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}