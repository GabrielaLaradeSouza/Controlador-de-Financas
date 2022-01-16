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
                                        criaRegistroDespesas(codigo, sqlCon);
                                        break;
                                    case 2:
                                        alteraRegistroDespesas(codigo, sqlCon);
                                        break;
                                    case 3:
                                        excluirRegistroDespesas(codigo, sqlCon);
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
                                        listaReceitasPorData(codigo, sqlCon);
                                        break;
                                    case 2:
                                        listaReceitasPorTipo(codigo, sqlCon);
                                        break;
                                    case 3:
                                        listaReceitas(codigo, sqlCon);
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
                                        listaDespesasPorData(codigo, sqlCon);
                                        break;
                                    case 2:
                                        listaDespesasPorTipo(codigo, sqlCon);
                                        break;
                                    case 3:
                                        listaDespesas(codigo, sqlCon);
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
                            Console.WriteLine("Procedimento Concluído! Precione enter para prosseguir!");
                            Console.ReadLine();
                        }
                        else if (subProcedimento > 5) {
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

            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO dbo.Contas " +
                    " (codigo, tipoConta, instituicaoFinanceira)" +
                    " values (" + conta + ",'" + tipoConta + "','" + banco + "')", sqlCon);
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

            try
            {
                SqlCommand command = new SqlCommand("UPDATE dbo.Contas " +
                    " SET tipoConta = '" + tipoConta + "', instituicaoFinanceira = '" + banco + "' where codigo = " + conta, sqlCon);
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
                atualizaSaldo(conta, sqlCon);
                Console.WriteLine("Receita incluida com sucesso! Precione enter para voltar ao menu das receitas");
                Console.ReadLine();
                Console.Clear();
            }
            catch (SqlException)
            {
                Console.WriteLine("Erro no momento da criação! Receita não foi incluida! Precine Enter para retornar ao menu das receitas!");
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
            Console.WriteLine("Informe a data do recebimento a ser alterado - Formato (Ano/Mes/Ano): ");
            dataRecebimento = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Informe o tipo da receita a ser alterado:");
            tipoRecebimento = Console.ReadLine();

            Console.WriteLine("Informe a data de Esperada do recebimento - Formato (Ano/Mes/Ano):");
            dataRecebimentoEsperado = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Informe a Descrição da receita:");
            descricao = Console.ReadLine();

            Console.WriteLine("Informe o valor da receita: ");
            valor = float.Parse(Console.ReadLine());

            try
            {
                SqlCommand command = new SqlCommand("UPDATE dbo.Receita " +
                    " SET dataRecebimentoEsperado = '" + dataRecebimentoEsperado +
                    "', descricao = '" + dataRecebimento +
                    "', valor = " + valor +
                    " WHERE conta = " + conta +
                    " AND dataRecebimento = '" + dataRecebimento + "' AND " +
                    "tipoRecebimento = '" + tipoRecebimento + "'", sqlCon);
                command.ExecuteNonQuery();
                atualizaSaldo(conta, sqlCon);
                Console.WriteLine("Receita alterada com sucesso! Precione enter para voltar ao menu das receitas");
                Console.ReadLine();
                Console.Clear();
            }
            catch (SqlException)
            {
                Console.WriteLine("Erro no momento da alteração! Receita não foi alterada! Precine Enter para retornar ao menu das receitas!");
                Console.ReadLine();
                Console.Clear();
            }
        }
        private static void excluirRegistroReceitas(int codigo, SqlConnection sqlCon) {

            Console.Clear();
            Console.WriteLine("Informe a data da receita que deseja excluir - Formato (Ano/Mes/Dia): ");
            DateTime dataRecebimento = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Informe o tipo da receita que deseja excluir:");
            string tipoReceita = Console.ReadLine();
            try
            {
                SqlCommand command = new SqlCommand("DELETE FROM dbo.Receita " +
                    " WHERE conta = " + codigo +
                    " AND dataRecebimento = '" + dataRecebimento + "'" +
                    " AND tipoRecebimento = '" + tipoReceita + "'", sqlCon);
                command.ExecuteNonQuery();
                atualizaSaldo(codigo, sqlCon);
                Console.WriteLine("Receita excluida com sucesso! Precione enter para voltar ao menu das receitas");
                Console.ReadLine();
                Console.Clear();
            }
            catch (SqlException)
            {
                Console.WriteLine("Erro no momento da excluida! Receita não foi excluida! Precine Enter para retornar ao menu das receitas!");
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
                    "where conta = " + codigo +
                    " and dataRecebimento >= '" + dataInicial +
                    "' and dataRecebimento <= '" + dataFinal + "'", sqlCon);
                SqlDataReader reader = command.ExecuteReader();
                Console.WriteLine("Conta: " + codigo);
                Console.WriteLine("--------------------------");
                while (reader.Read())
                {
                    sqlReturn = "Data de recebimento: " + reader["DataRecebimento"].ToString() + "\n";
                    sqlReturn += "Data do recebimento esperado: " + reader["dataRecebimentoEsperado"].ToString() + "\n";
                    sqlReturn += "Descrição: " + reader["Descricao"].ToString() + "\n";
                    sqlReturn += "Tipo da receita: " + reader["tipoRecebimento"].ToString() + "\n";
                    sqlReturn += "Valor: " + reader["valor"].ToString() + "\n";
                    Console.WriteLine(sqlReturn);
                }
                reader.Close();
                Console.WriteLine("Precione enter para voltar ao menu das receitas");
                Console.ReadLine();
                Console.Clear();
            }
            catch (SqlException)
            {
                Console.WriteLine("Erro no retorno das receitas! Precine Enter para retornar ao menu das receitas!");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private static void listaReceitasPorTipo(int codigo, SqlConnection sqlCon)
        {
            string sqlReturn = "";

            Console.Clear();
            Console.WriteLine("Informe o tipo da receita que deseja pesquisar:");
            string tipoReceita = Console.ReadLine();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.Receita " +
                    "where conta = " + codigo +
                    " and tipoRecebimento = '" + tipoReceita + "'", sqlCon);
                SqlDataReader reader = command.ExecuteReader();
                Console.WriteLine("Conta: " + codigo);
                Console.WriteLine("--------------------------");
                while (reader.Read())
                {
                    sqlReturn = "Data de recebimento: " + reader["DataRecebimento"].ToString() + "\n";
                    sqlReturn += "Data do recebimento esperado: " + reader["dataRecebimentoEsperado"].ToString() + "\n";
                    sqlReturn += "Descrição: " + reader["Descricao"].ToString() + "\n";
                    sqlReturn += "Tipo da receita: " + reader["tipoRecebimento"].ToString() + "\n";
                    sqlReturn += "Valor: " + reader["valor"].ToString() + "\n";
                    Console.WriteLine(sqlReturn);
                }
                reader.Close();
                Console.WriteLine("Precione enter para voltar ao menu das receitas");
                Console.ReadLine();
                Console.Clear();
            }
            catch (SqlException)
            {
                Console.WriteLine("Erro no retorno das receitas! Precione Enter para retornar ao menu das receitas!");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private static void listaReceitas(int codigo, SqlConnection sqlCon)
        {
            string sqlReturn = "";

            Console.Clear();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.Receita " +
                    "where conta = " + codigo, sqlCon);
                SqlDataReader reader = command.ExecuteReader();
                Console.WriteLine("Conta: " + codigo);
                Console.WriteLine("--------------------------");
                while (reader.Read())
                {
                    sqlReturn = "Data de recebimento: " + reader["DataRecebimento"].ToString() + "\n";
                    sqlReturn += "Data do recebimento esperado: " + reader["dataRecebimentoEsperado"].ToString() + "\n";
                    sqlReturn += "Descrição: " + reader["Descricao"].ToString() + "\n";
                    sqlReturn += "Tipo da receita: " + reader["tipoRecebimento"].ToString() + "\n";
                    sqlReturn += "Valor: " + reader["valor"].ToString() + "\n";
                    Console.WriteLine(sqlReturn);
                }
                reader.Close();
                Console.WriteLine("Precione enter para voltar ao menu das receitas");
                Console.ReadLine();
                Console.Clear();
            }
            catch (SqlException)
            {
                Console.WriteLine("Erro no retorno das receitas! Precine Enter para retornar ao menu das receitas!");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private static void criaRegistroDespesas(int conta, SqlConnection sqlCon)
        {

            string tipoDespesa = "";
            string descricao = "";
            float valor = 0.0f;
            DateTime dataDespesa;
            DateTime dataDespesaEsperada;

            Console.Clear();
            Console.WriteLine("Informe a data de Esperada da despesa - formato(Ano/Mes/Dia):");
            dataDespesaEsperada = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Informe a data da despesa - formato(Ano/Mes/Dia): ");
            dataDespesa = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Informe o tipo da despesa:");
            tipoDespesa = Console.ReadLine();

            Console.WriteLine("Informe o valor da despesa: ");
            valor = float.Parse(Console.ReadLine());

            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO dbo.Descontos " +
                    " (conta, dataPagamentoEsperado, dataPagamento, tipoDespesa, valor)" +
                    " VALUES (" + conta + ",'" + dataDespesaEsperada +
                    "','" + dataDespesa + "','" + tipoDespesa + "'," + valor + ")", sqlCon);
                command.ExecuteNonQuery();
                atualizaSaldo(conta, sqlCon);
                Console.WriteLine("Despesa incluida com sucesso! Precione enter para voltar ao menu das contas");
                Console.ReadLine();
                Console.Clear();
            }
            catch (SqlException)
            {
                Console.WriteLine("Erro no momento da criação! Despesa não foi incluida! Precine Enter para retornar ao menu das contas!");
                Console.ReadLine();
                Console.Clear();
            }

        }

        private static void alteraRegistroDespesas(int conta, SqlConnection sqlCon)
        {
            string tipoDesconto = "";
            string descricao = "";
            float valor = 0.0f;
            DateTime dataPagamento;
            DateTime dataPagamentoEsperado;

            Console.Clear();
            Console.WriteLine("Informe a data do pagamento - Formato (Ano/Mes/Dia):");
            dataPagamento = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Informe o tipo da despesa:");
            tipoDesconto = Console.ReadLine();

            Console.WriteLine("Informe a data de Esperada do pagamento - Formato (Ano/Mes/Dia):");
            dataPagamentoEsperado = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Informe o valor da despesa: ");
            valor = float.Parse(Console.ReadLine());

            try
            {
                SqlCommand command = new SqlCommand("UPDATE dbo.Descontos " +
                    " SET dataPagamentoEsperado = '" + dataPagamentoEsperado +
                    "', valor = " + valor +
                    " WHERE conta = " + conta + " AND dataPagamento = '" + dataPagamento +
                    "' AND tipoDespesa = '" + tipoDesconto + "'", sqlCon);
                command.ExecuteNonQuery();
                atualizaSaldo(conta, sqlCon);
                Console.WriteLine("Despesa alterada com sucesso! Precione enter para voltar ao menu das despesas");
                Console.ReadLine();
                Console.Clear();
            }
            catch (SqlException)
            {
                Console.WriteLine("Erro no momento da alteração! Despesa não foi alterada! Precine Enter para retornar ao menu das despesas!");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private static void excluirRegistroDespesas(int codigo, SqlConnection sqlCon)
        {

            Console.Clear();
            Console.WriteLine("Informe a data da despesa que deseja excluir - Formato (Ano/Mes/Dia): ");
            DateTime dataPagamento = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Informe o tipo da despesa que deseja excluir:");
            string tipoDespesa = Console.ReadLine();
            try
            {
                SqlCommand command = new SqlCommand("DELETE FROM dbo.Descontos " +
                    " WHERE conta = " + codigo +
                    " AND dataPagamento = '" + dataPagamento + "'" +
                    " AND tipoDespesa = '" + tipoDespesa + "'", sqlCon);
                command.ExecuteNonQuery();
                atualizaSaldo(codigo, sqlCon);
                Console.WriteLine("Receita excluida com sucesso! Precione enter para voltar ao menu das despesas");
                Console.ReadLine();
                Console.Clear();
            }
            catch (SqlException)
            {
                Console.WriteLine("Erro no momento da excluida! Receita não foi excluida! Precine Enter para retornar ao menu das despesas!");
                Console.ReadLine();
                Console.Clear();
            }
        }
        private static void listaDespesasPorData(int codigo, SqlConnection sqlCon)
        {
            string sqlReturn = "";

            Console.Clear();
            Console.WriteLine("Informe o inicio do período que deseja pesquisar - Formato (Ano/Mes/Dia)");
            DateTime dataInicial = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Informe o final do período que deseja pesquisar - Formato (Ano/Mes/Dia:");
            DateTime dataFinal = Convert.ToDateTime(Console.ReadLine());
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.Descontos " +
                    "where conta = " + codigo +
                    " and dataPagamento >= '" + dataInicial +
                    "' and dataPagamento <= '" + dataFinal + "'", sqlCon);
                SqlDataReader reader = command.ExecuteReader();
                Console.WriteLine("Conta: " + codigo);
                Console.WriteLine("--------------------------");
                while (reader.Read())
                {
                    sqlReturn = "Data de pagamento: " + reader["DataPagamento"].ToString() + "\n";
                    sqlReturn += "Data do pagamento esperado: " + reader["dataPagamentoEsperado"].ToString() + "\n";
                    sqlReturn += "Tipo da Despesa: " + reader["tipoDespesa"].ToString() + "\n";
                    sqlReturn += "Valor: " + reader["valor"].ToString() + "\n";
                    Console.WriteLine(sqlReturn);
                }
                reader.Close();
                Console.WriteLine("Precione enter para voltar ao menu das despesas");
                Console.ReadLine();
                Console.Clear();
            }
            catch (SqlException)
            {
                Console.WriteLine("Erro no retorno das despesas! Precine Enter para retornar ao menu das despesas!");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private static void listaDespesasPorTipo(int codigo, SqlConnection sqlCon)
        {
            string sqlReturn = "";

            Console.Clear();
            Console.WriteLine("Informe o tipo da despesa que deseja pesquisar:");
            string tipoDespesa = Console.ReadLine();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.Descontos " +
                    "where conta = " + codigo +
                    " and tipoDespesa = '" + tipoDespesa + "'", sqlCon);
                SqlDataReader reader = command.ExecuteReader();
                Console.WriteLine("Conta: " + codigo);
                Console.WriteLine("--------------------------");
                while (reader.Read())
                {
                    sqlReturn = "Data de pagamento: " + reader["DataPagamento"].ToString() + "\n";
                    sqlReturn += "Data do pagamento esperado: " + reader["dataPagamentoEsperado"].ToString() + "\n";
                    sqlReturn += "Tipo da Despesa: " + reader["tipoDespesa"].ToString() + "\n";
                    sqlReturn += "Valor: " + reader["valor"].ToString() + "\n";
                    Console.WriteLine(sqlReturn);
                }
                reader.Close();
                Console.WriteLine("Precione enter para voltar ao menu das despesas");
                Console.ReadLine();
                Console.Clear();
            }
            catch (SqlException)
            {
                Console.WriteLine("Erro no retorno das despesas! Precine Enter para retornar ao menu das despesas!");
                Console.ReadLine();
                Console.Clear();
            }
        }
        private static void listaDespesas(int codigo, SqlConnection sqlCon)
        {
            string sqlReturn = "";

            Console.Clear();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.Descontos " +
                    "where conta = " + codigo, sqlCon);
                SqlDataReader reader = command.ExecuteReader();
                Console.WriteLine("Conta: " + codigo);
                Console.WriteLine("--------------------------");
                while (reader.Read())
                {
                    sqlReturn = "Data de Pagamento: " + reader["DataPagamento"].ToString() + "\n";
                    sqlReturn += "Data do Pagamento esperado: " + reader["DataPagamentoEsperado"].ToString() + "\n";
                    sqlReturn += "Tipo do desconto: " + reader["tipoDespesa"].ToString() + "\n";
                    sqlReturn += "Valor: " + reader["valor"].ToString() + "\n";
                    Console.WriteLine(sqlReturn);
                }
                reader.Close();
                Console.WriteLine("Precione enter para voltar ao menu das despesas");
                Console.ReadLine();
                Console.Clear();
            }
            catch (SqlException)
            {
                Console.WriteLine("Erro no retorno das despesas! Precine Enter para retornar ao menu das despesas!");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private static float retornaTotalConta(int codigo, SqlConnection sqlCon) {
            string sqlReturn = "";
            float total = 0.0f;
            Console.Clear();
            Console.WriteLine("Conta: " + codigo);
            Console.WriteLine("--------------------------");
            Console.WriteLine("Receitas: ");
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.Receita " +
                    "where conta = " + codigo, sqlCon);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    sqlReturn = "Data de Recebimento: " + reader["DataRecebimento"].ToString() + "\n";
                    sqlReturn += "Tipo da Receita: " + reader["tipoRecebimento"].ToString() + "\n";
                    sqlReturn += "Valor: " + reader["valor"].ToString() + "\n";
                    total += float.Parse(reader["valor"].ToString());
                    Console.WriteLine(sqlReturn);
                }
                reader.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("Erro no retorno do extrato total! Precione Enter para retornar ao menu das contas!");
                Console.ReadLine();
                Console.Clear();
            }
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Despesas:");
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.Descontos " +
                    "where conta = " + codigo, sqlCon);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    sqlReturn = "Data de Pagamento: " + reader["DataPagamento"].ToString() + "\n";
                    sqlReturn += "Tipo do desconto: " + reader["tipoDespesa"].ToString() + "\n";
                    sqlReturn += "Valor: " + reader["valor"].ToString() + "\n";
                    total -= float.Parse(reader["valor"].ToString());
                    Console.WriteLine(sqlReturn);
                }
                reader.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("Erro no retorno do extrato total! Precione Enter para retornar ao menu das contas!");
                Console.ReadLine();
                Console.Clear();
            }

            return total;
        }

        private static void atualizaSaldo(int conta, SqlConnection sqlCon) {
            float receitas = 0.0f;
            float descontos = 0.0f;

            try
            {
                SqlCommand command = new SqlCommand("SELECT valor FROM dbo.Receita " +
                    "where conta = " + conta, sqlCon);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    receitas += float.Parse(reader["valor"].ToString());
                }
                reader.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("Erro no retorno das receitas!");
            }
            try
            {
                SqlCommand command = new SqlCommand("SELECT valor FROM dbo.Descontos " +
                    "where conta = " + conta, sqlCon);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    descontos -= float.Parse(reader["valor"].ToString());
                }
                reader.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("Erro no retorno das despesas!");
            }

            try
            {
                SqlCommand command = new SqlCommand("UPDATE dbo.Contas " +
                    " SET Saldo = (" + receitas + " - " + descontos + ")" +
                    " WHERE codigo = " + conta, sqlCon);
                command.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                Console.WriteLine("Erro na Atualização do saldo!");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
    
}
