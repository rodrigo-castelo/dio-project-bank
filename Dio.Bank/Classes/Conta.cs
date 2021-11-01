using System;

namespace Dio.Bank
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool SacarConta(double valorSaque)
        {
            //Valida o saldo atual
            if (this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
            return true;
        }

        public void DepositarConta(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
        }

        public void TransferirConta(double valorTransferencia, Conta contaDestino)
        {
            if(this.SacarConta(valorTransferencia))
            {
                contaDestino.DepositarConta(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno +=  "Tipo da Conta: " + this.TipoConta + " | ";
            retorno +=  "Nome: " + this.Nome + " | ";
            retorno +=  "Saldo: R$ " + this.Saldo + " | ";
            retorno +=  "Crédito: R$ " + this.Credito;
            return retorno;
        }

    }
}