using System;
using System.Data.SqlClient;

namespace ControleFinanceiro
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sqlCon = new SqlConnection("Database=controle_Financas;Server=BAUER-PC;user=sa;password=sa");
            sqlCon.Open();

            int codigo = 0;
            int procedimentoPrincipal = 1;
            int subProcedimento = 0;

            Console.WriteLine("Bem vindo ao Controle Financeiro!");
            while (procedimentoPrincipal > 0)
            {
                Console.WriteLine("Informe o procedimento a ser executado:");
                Console.WriteLine("1 - Gerir Contas");
                Console.WriteLine("2 - Accesss Contas");
                Console.WriteLine("0 - Encerar Programa");
                procedimentoPrincipal = Convert.ToInt32(Console.ReadLine());

                if (procedimentoPrincipal == 1)
                {
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Por favor informe o que deseja realizar com as contas:");
                        Console.WriteLine("1 - Criar");
                        Console.WriteLine("2 - Alterar");
                        Console.WriteLine("3 - Excluir");
                        Console.WriteLine("4 - Listar");
                        Console.WriteLine("5 - Listar Todas");
                        Console.WriteLine("0 - Voltar para menu principal");
                        subProcedimento = Convert.ToInt32(Console.ReadLine());

                        if (subProcedimento == 1)
                        {
                            // FUNCAO DE INCLUSÃO
                            criaRegistroConta(sqlCon);
                        }
                        else if (subProcedimento == 2)
                        {
                            // FUNCAO DE ALTERAÇÃO
                            alteraRegistroConta(sqlCon);
                        }
                        else if (subProcedimento == 3)
                        {
                            // FUNCAO DE EXCLUSAO
                            excluirRegistroConta(sqlCon);
                        }
                        else if (subProcedimento == 4)
                        {
                            // FUNCAO DE LISTAR UM
                            retornaRegistroConta(sqlCon);
                        }
                        else if (subProcedimento == 5)
                        {
                            // FUNCAO DE LISTAR TODOS
                            retornaTodosRegistroConta(sqlCon);
                        }
                        else if (subProcedimento > 5)
                        {
                            Console.WriteLine("Processo inválido! Precione enter para prosseguir!");
                        }
                    } while (subProcedimento > 0);
                }
                else if (procedimentoPrincipal == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Por gentileza selecine a conta que deseja acessar:");
                    Console.WriteLine("Código da conta: ");
                    codigo = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Encerrando....");
                }
            }
            sqlCon.Close();
        }

        private static void criaRegistroConta(SqlConnection sqlCon)
        {

            int conta = 0;
            string tipoConta = "";
            string banco = "";
            float saldo = 0.0f;

            Console.Clear();
            Console.WriteLine("Informe o código da conta: ");
            conta = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Informe o tipo da Conta:");
            tipoConta = Console.ReadLine();

            Console.WriteLine("Informe a instuição financeira da Conta:");
            banco = Console.ReadLine();

            Console.WriteLine("Informe o saldo atual da conta: ");
            saldo = float.Parse(Console.ReadLine());

            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO dbo.Contas " +
                    " (codigo, tipoConta, instituicaoFinanceira, saldo)" +
                    " values (" + conta + ",'" + tipoConta + "','" + banco + "'," + saldo + ")", sqlCon);
                command.ExecuteNonQuery();
                Console.WriteLine("Conta incluida com sucesso! Precione enter para voltar ao menu das contas");
                Console.ReadLine();
                Console.Clear();
            }
            catch (SqlException)
            {
                Console.WriteLine("Erro no momento da criação! Conta não foi incluida! Precine Enter para retornar ao menu das contas!");
                Console.ReadLine();
                Console.Clear();
            }

        }
        private static void alteraRegistroConta(SqlConnection sqlCon)
        {

            int conta = 0;
            string tipoConta = "";
            string banco = "";
            float saldo = 0.0f;

            Console.Clear();
            Console.WriteLine("Informe o código da conta que deseja alterar: ");
            conta = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Informe o novo tipo da Conta:");
            tipoConta = Console.ReadLine();

            Console.WriteLine("Informe a nova instuição financeira da Conta:");
            banco = Console.ReadLine();

            Console.WriteLine("Informe o saldo atual da conta: ");
            saldo = float.Parse(Console.ReadLine());

            try
            {
                SqlCommand command = new SqlCommand("UPDATE dbo.Contas " +
                    " SET tipoConta = '" + tipoConta + "', instituicaoFinanceira = '" + banco + "', saldo = " + saldo +
                    " where codigo = " + conta, sqlCon);
                command.ExecuteNonQuery();
                Console.WriteLine("Conta alterada com sucesso! Precione enter para voltar ao menu das contas");
                Console.ReadLine();
                Console.Clear();
            }
            catch (SqlException)
            {
                Console.WriteLine("Erro no momento da alteração! Conta não foi alterada! Precine Enter para retornar ao menu das contas!");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private static void excluirRegistroConta(SqlConnection sqlCon)
        {

            int conta = 0;

            Console.Clear();
            Console.WriteLine("Informe o código da conta que deseja excluir: ");
            conta = Convert.ToInt32(Console.ReadLine());

            try
            {
                SqlCommand command = new SqlCommand("DELETE FROM dbo.Contas where codigo = " + conta, sqlCon);
                command.ExecuteNonQuery();
                Console.WriteLine("Conta excluida com sucesso! Precione enter para voltar ao menu das contas");
                Console.ReadLine();
                Console.Clear();
            }
            catch (SqlException)
            {
                Console.WriteLine("Erro no momento da excluida! Conta não foi excluida! Precine Enter para retornar ao menu das contas!");
                Console.ReadLine();
                Console.Clear();
            }
        }
        private static void retornaRegistroConta(SqlConnection sqlCon)
        {

            string sqlReturn = "";
            int conta = 0;
            Console.Clear();
            Console.WriteLine("Informe o código da conta que deseja pesquisar: ");
            conta = Convert.ToInt32(Console.ReadLine());
            try
            {
                SqlCommand command = new SqlCommand("SELECT codigo, tipoConta, instituicaoFinanceira, saldo FROM dbo.Contas where codigo = " + conta, sqlCon);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    sqlReturn = "Conta: " + reader["codigo"].ToString() + "\n";
                    sqlReturn += "Tipo: " + reader["tipoConta"].ToString() + "\n";
                    sqlReturn += "Instituição: " + reader["tipoConta"].ToString() + "\n";
                    sqlReturn += "Saldo: " + reader["saldo"].ToString() + "\n";
                    Console.WriteLine(sqlReturn);
                }
                reader.Close();
                Console.WriteLine("Precione enter para voltar ao menu das contas");
                Console.ReadLine();
                Console.Clear();
            }
            catch (SqlException)
            {
                Console.WriteLine("Erro no retorno das contas! Precine Enter para retornar ao menu das contas!");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private static void retornaTodosRegistroConta(SqlConnection sqlCon)
        {

            string sqlReturn = "";
            Console.Clear();

            try
            {
                SqlCommand command = new SqlCommand("SELECT codigo, tipoConta, instituicaoFinanceira, saldo FROM dbo.Contas", sqlCon);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    sqlReturn = "Conta: " + reader["codigo"].ToString() + "\n";
                    sqlReturn += "Tipo: " + reader["tipoConta"].ToString() + "\n";
                    sqlReturn += "Instituição: " + reader["tipoConta"].ToString() + "\n";
                    sqlReturn += "Saldo: " + reader["saldo"].ToString() + "\n";
                    sqlReturn += "-------------------------------------------------";
                    Console.WriteLine(sqlReturn);
                }
                reader.Close();
                Console.WriteLine("Precione enter para voltar ao menu das contas");
                Console.ReadLine();
                Console.Clear();
            }
            catch (SqlException)
            {
                Console.WriteLine("Erro no retorno das contas! Precine Enter para retornar ao menu das contas!");
                Console.ReadLine();
                Console.Clear();
            }
        }
        
    }
}
