using System.Net.Http.Json;

namespace Banco
{
    public partial class Form1 : Form
    {
        private int numeroDeContas = 0;

        //	Esse	array	já	estava	declarado	na	classe
        private Conta[] contas;

        public Form1()
        {
            InitializeComponent();
        }

        //	implementação	das	ações	do	formulário
        public void AdicionaConta(Conta conta)
        {
            if (contas.Length <= this.numeroDeContas)
            {
                Array.Resize<Conta>(ref contas, this.numeroDeContas + 1);
            }

            this.contas[this.numeroDeContas] = conta;
            this.numeroDeContas++;
            comboContas.Items.Add(conta.Titular.Nome);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //	criando	o	array	para	guardar	as	contas
            contas = new Conta[4];

            //	vamos	inicializar	algumas	instâncias	de	Conta.
            Conta c1 = new Conta();
            c1.Titular = new Cliente("victor");
            c1.Numero = 1;
            this.AdicionaConta(c1);

            Conta c2 = new ContaPoupanca();
            c2.Titular = new Cliente("mauricio");
            c2.Numero = 2;
            this.AdicionaConta(c2);

            Conta c3 = new ContaCorrente();
            c3.Titular = new Cliente("osni");
            c3.Numero = 3;
            this.AdicionaConta(c3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string valorDigitado = textoValor.Text;
            double valorOperacao = Convert.ToDouble(valorDigitado);

            //	primeiro	precisamos	recuperar	o	índice	da	conta	selecionada
            int indice = comboContas.SelectedIndex;

            //	e	depois	precisamos	ler	a	posição	correta	do	array.
            Conta selecionada = this.contas[indice];

            selecionada.Saca(valorOperacao);
            textoSaldo.Text = Convert.ToString(selecionada.Saldo);

            MessageBox.Show(valorDigitado);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //	primeiro	precisamos	recuperar	o	índice	da	conta	selecionada
            int indice = comboContas.SelectedIndex;

            //	e	depois	precisamos	ler	a	posição	correta	do	array.
            Conta selecionada = this.contas[indice];

            double valor = Convert.ToDouble(textoValor.Text);
            selecionada.Deposita(valor);
            textoSaldo.Text = Convert.ToString(selecionada.Saldo);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int indice = Convert.ToInt32(comboContas.SelectedIndex);
            Conta selecionada = this.contas[indice];

            textoNumero.Text = Convert.ToString(selecionada.Numero);
            textoTitular.Text = selecionada.Titular.Nome;
            textoSaldo.Text = Convert.ToString(selecionada.Saldo);
        }

        private void botaoNovaConta_Click(object sender, EventArgs e)
        {
            //	this	representa	a	instância	de	Form1	que	está	sendo	utilizada	pelo
            //	Windows	Form
            FormCadastroConta formularioDeCadastro = new FormCadastroConta(this);
            formularioDeCadastro.ShowDialog();
        }
    }
}