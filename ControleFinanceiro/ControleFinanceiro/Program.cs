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
            int terProcedimento = 0;

            string contaCabecalho = "";

            Console.WriteLine("Bem vindo ao Controle Financeiro!");
            while (procedimentoPrincipal > 0)
            {
                Console.Clear();
                Console.WriteLine("Informe o procedimento a ser executado:");
                Console.WriteLine("1 - Gerir Contas");
                Console.WriteLine("2 - Acessar Contas");
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
                            retornaRegistroConta(sqlCon, 1);
                        }
                        else if (subProcedimento == 5)
                        {
                            // FUNCAO DE LISTAR TODOS
                            retornaTodosRegistroConta(sqlCon);
                        }
                        else if (subProcedimento > 5)
                        {
                            Console.WriteLine("Processo inválido! Precione enter para prosseguir!");
                            Console.ReadLine();
                        }
                    } while (subProcedimento > 0);
                }
                else if (procedimentoPrincipal == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Por gentileza selecine a conta que deseja acessar:");
                    codigo = retornaRegistroConta(sqlCon, 0);
                    do
                    {

                        // Busca e lista dados da conta atual
                        Console.Clear();
                        contaCabecalho = codigo.ToString();
                        Console.WriteLine("Conta Ativa: " + contaCabecalho + "\n");
                        Console.WriteLine("Qual o procedimento será efetuado?");
                        Console.WriteLine("1 - Gerir Receitas");
                        Console.WriteLine("2 - Gerir Despesas");
                        Console.WriteLine("---------------------");
                        Console.WriteLine("3 - Listar Receitas");
                        Console.WriteLine("4 - Listar Despesas");
                        Console.WriteLine("---------------------");
                        Console.WriteLine("5 - Extrato total da Conta\n");
                        Console.WriteLine("0 - Voltar ao menu principal");
                        subProcedimento = Convert.ToInt32(Console.ReadLine());

                        if (subProcedimento == 1)
                        {
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Conta Ativa: " + contaCabecalho + "\n");
                                Console.WriteLine("Informe o processo desejado:");
                                Console.WriteLine("1 - Incluir Receita");
                                Console.WriteLine("2 - Alterar Receita");
                                Console.WriteLine("3 - Excluir Receita");                                
                                Console.WriteLine("0 - Retornar ao menu da conta");
                                terProcedimento = Convert.ToInt32(Console.ReadLine());

                                switch (terProcedimento) {
                                    case 1:
                                        criaRegistroReceita(codigo, sqlCon);
                                        break;
                                    case 2:
                                        alteraRegistroReceitas(codigo, sqlCon);
                                        break;
                                    case 3:
                                        excluirRegistroReceitas(codigo, sqlCon);
                                        break;
                                    case 0:
                                        Console.WriteLine("Voltando...");
                                        break;
                                    default:
                                        Console.WriteLine("Procedimento inválido! Precione enter para prosseguir!");
                                        Console.ReadLine();
                                        break;
                                }
                            } while (terProcedimento > 0);

                        }
                        else if (subProcedimento == 2)
                            do {
                                Console.Clear();
                                Console.WriteLine("Conta Ativa: " + contaCabecalho + "\n");
                                Console.WriteLine("Informe o processo desejado:");
                                Console.WriteLine("1 - Incluir Despesas");
                                Console.WriteLine("2 - Alterar Despesas");
                                Console.WriteLine("3 - Excluir Despesas");
                                Console.WriteLine("0 - Retornar ao menu da conta");
                                terProcedimento = Convert.ToInt32(Console.ReadLine());

                                switch (terProcedimento)
                                {
                                    case 1:
                                        break;
                                    case 2:
                                        break;
                                    case 3:
                                        break;
                                    case 0:
                                        Console.WriteLine("Voltando...");
                                        break;
                                    default:
                                        Console.WriteLine("Procedimento inválido! Precione enter para prosseguir!");
                                        Console.ReadLine();
                                        break;
                                }
                            } while (terProcedimento > 0) ;
                        else if (subProcedimento == 3)
                        {
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Conta Ativa: " + contaCabecalho + "\n");
                                Console.WriteLine("1 - Lista Receita - Data");
                                Console.WriteLine("2 - Lista Receita - Tipo");
                                Console.WriteLine("3 - Extrato do total de Receitas");
                                Console.WriteLine("0 - Retonar ao menu de contas\n");
                                terProcedimento = Convert.ToInt32(Console.ReadLine());

                                switch (terProcedimento) {
                                    case 1:

                                        break;
                                    case 2:

                                        break;
                                    case 3:

                                        break;
                                    case 0:
                                        Console.WriteLine("Voltando...");
                                        break;
                                    default:
                                        Console.WriteLine("Processo inválido! Precione enter para prosseguir.");
                                        Console.ReadLine();
                                        break;
                                }
                                
                            } while (terProcedimento > 0);
                            
                        }
                        else if (subProcedimento == 4)
                        {
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Conta Ativa: " + contaCabecalho + "\n");
                                Console.WriteLine("1 - Lista Despesas - Data");
                                Console.WriteLine("2 - Lista Despesas - Tipo");
                                Console.WriteLine("3 - Extrato do total de Despesas");
                                Console.WriteLine("0 - Retonar ao menu de contas\n");
                                terProcedimento = Convert.ToInt32(Console.ReadLine());

                                switch (terProcedimento)
                                {
                                    case 1:

                                        break;
                                    case 2:

                                        break;
                                    case 3:

                                        break;
                                    case 0:
                                        Console.WriteLine("Voltando...");
                                        break;
                                    default:
                                        Console.WriteLine("Processo inválido! Precione enter para prosseguir.");
                                        Console.ReadLine();
                                        break;
                                }

                            } while (terProcedimento > 0);
                        }
                        else if (subProcedimento == 5)
                        {
                            // Listar SALDO TOTAL
                            Console.Clear();
                            Console.WriteLine("Conta Ativa: " + contaCabecalho + "\n");
                            Console.WriteLine("O Saldo total da conta é de: " + retornaTotalConta(codigo, sqlCon));
                            Console.WriteLine("Receitas: ");
                            // Funcao que retorna todas as receitas
                            Console.WriteLine("Descontos: ");
                            // Funcao que retorna todos os descontos

                            Console.WriteLine("Procedimento Concluído! Precione enter para prosseguir!");
                            Console.ReadLine();
                        }
                        else if(subProcedimento > 5){
                            Console.WriteLine("Procedimento inválido! Precione enter para prosseguir!");
                            Console.ReadLine();
                        }
                    } while (subProcedimento > 0);
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
        private static int retornaRegistroConta(SqlConnection sqlCon, int tipoDeBusca)
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
                if (tipoDeBusca == 1)
                {
                    Console.WriteLine("Precione enter para voltar ao menu das contas");
                    Console.ReadLine();
                    Console.Clear();
                }
                return conta;
            }
            catch (SqlException)
            {
                Console.WriteLine("Erro no retorno das contas! Precine Enter para retornar ao menu das contas!");
                Console.ReadLine();
                Console.Clear();
                return 0;
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
        private static void criaRegistroReceita(int conta, SqlConnection sqlCon)
        {

            string tipoRecebimento = "";
            string descricao = "";
            float valor = 0.0f;
            DateTime dataRecebimento;
            DateTime dataRecebimentoEsperado;

            Console.Clear();
            Console.WriteLine("Informe a data de Esperada do recebimento - formato(Ano/Mes/Dia):");
            dataRecebimentoEsperado = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Informe a data do recebimento - formato(Ano/Mes/Dia): ");
            dataRecebimento = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Informe a Descrição da receita:");
            descricao = Console.ReadLine();

            Console.WriteLine("Informe o tipo da receita:");
            tipoRecebimento = Console.ReadLine();

            Console.WriteLine("Informe o valor da receita: ");
            valor = float.Parse(Console.ReadLine());

            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO dbo.Receita " +
                    " (conta, descricao, dataRecebimentoEsperado, dataRecebimento, tipoRecebimento, valor)" + 
                    " VALUES (" + conta + ",'" + descricao + "','" + dataRecebimentoEsperado +
                    "','" + dataRecebimento + "','" + tipoRecebimento + "'," + valor + ")", sqlCon);
                command.ExecuteNonQuery();
                Console.WriteLine("Receita incluida com sucesso! Precione enter para voltar ao menu das contas");
                Console.ReadLine();
                Console.Clear();
            }
            catch (SqlException)
            {
                Console.WriteLine("Erro no momento da criação! Receita não foi incluida! Precine Enter para retornar ao menu das contas!");
                Console.ReadLine();
                Console.Clear();
            }

        }
        private static void alteraRegistroReceitas(int conta, SqlConnection sqlCon)
        {
            string tipoRecebimento = "";
            string descricao = "";
            float valor = 0.0f;
            DateTime dataRecebimento;
            DateTime dataRecebimentoEsperado;

            Console.Clear();
            Console.WriteLine("Informe a data de Esperada do recebimento:");
            dataRecebimentoEsperado = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Informe a data do recebimento: ");
            dataRecebimento = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Informe a Descrição da receita:");
            descricao = Console.ReadLine();

            Console.WriteLine("Informe o tipo da receita:");
            tipoRecebimento = Console.ReadLine();

            Console.WriteLine("Informe o valor da receita: ");
            valor = float.Parse(Console.ReadLine());

            try
            {
                SqlCommand command = new SqlCommand("UPDATE dbo.Receita " +
                    " SET tipoReceita = '" + tipoRecebimento + 
                    "', dataRecebimentoEsperado = '" + dataRecebimentoEsperado +
                    "', dataRecebimento = '" + dataRecebimento +
                    "', descricao = '" + dataRecebimento +
                    "', tipoRecebimento = '" + dataRecebimento +
                    "', valor = " + valor +
                    " WHERE conta = " + conta, sqlCon);
                command.ExecuteNonQuery();
                Console.WriteLine("Receita alterada com sucesso! Precione enter para voltar ao menu das contas");
                Console.ReadLine();
                Console.Clear();
            }
            catch (SqlException)
            {
                Console.WriteLine("Erro no momento da alteração! Receita não foi alterada! Precine Enter para retornar ao menu das contas!");
                Console.ReadLine();
                Console.Clear();
            }
        }
        private static void excluirRegistroReceitas(int codigo,SqlConnection sqlCon) {

            Console.Clear();
            Console.WriteLine("Informe a data da receita que deseja excluir - Formato (Ano/Mes/Dia): ");
            DateTime dataRecebimento = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Informe o tipo da receita que deseja excluir:");
            string tipoReceita = Console.ReadLine();
            try
            {
                SqlCommand command = new SqlCommand("DELETE FROM dbo.Receita " +
                    " WHERE codigo = " + codigo +
                    " AND " + dataRecebimento +
                    " AND " + tipoReceita, sqlCon);
                command.ExecuteNonQuery();
                Console.WriteLine("Receita excluida com sucesso! Precione enter para voltar ao menu das contas");
                Console.ReadLine();
                Console.Clear();
            }
            catch (SqlException)
            {
                Console.WriteLine("Erro no momento da excluida! Receita não foi excluida! Precine Enter para retornar ao menu das contas!");
                Console.ReadLine();
                Console.Clear();
            }
        }
        private static void listaReceitasPorData(int codigo, SqlConnection sqlCon)
        {
            string sqlReturn = "";

            Console.Clear();
            Console.WriteLine("Informe o inicio do período que deseja pesquisar:");
            DateTime dataInicial = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Informe o final do período que deseja pesquisar:");
            DateTime dataFinal = Convert.ToDateTime(Console.ReadLine());
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.Receita " +
                    "where codigo = " + codigo + 
                    " and dataRecebimento >= " + dataInicial +
                    " and dataRecebimento <= " + dataFinal, sqlCon);
                SqlDataReader reader = command.ExecuteReader();
                Console.WriteLine("Conta: " + codigo);
                Console.WriteLine("--------------------------");
                while (reader.Read())
                {
                    sqlReturn = "Data de recebimento: " + reader["DataRecebimento"].ToString() + "\n";
                    sqlReturn += "Data do recebimento esperado: " + reader["dataRecebimentoEsperado"].ToString() + "\n";
                    sqlReturn += "Descrição: " + reader["Descricao"].ToString() + "\n";
                    sqlReturn += "Tipo da receita: " + reader["tipoReceita"].ToString() + "\n";
                    sqlReturn += "Valor: " + reader["valor"].ToString() + "\n";
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

        private static float retornaTotalConta(int codigo, SqlConnection sqlCon) {
            return 0.0f;
        }
    }
    
}
