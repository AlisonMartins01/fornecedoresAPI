using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Dapper;
using WebApplication1.MVC.Model;
using System.Text.Json;

namespace WebApplication1.Base.Controller
{
    public class BaseController
    {
        const string connectionString = "CONNECTION STRING DO BANCO";
        public Fornecedor CommandGetFornecedorById(int id) {
            using (var db = new SqlConnection(connectionString)) 
            {
                try
                {
                    return db.QueryFirst<Fornecedor>("select * from Fornecedor where id = @id", new {id = id });
                    
                }
                catch (Exception)
                {

                    return null;//
                }
            }
        }
        public IEnumerable<Fornecedor> CommandGetFornecedores(FiltroFornecedores filtro) {
            using (var db = new SqlConnection(connectionString))
            {
                try
                {
                    return db.Query<Fornecedor>("select * from Fornecedor f " +
                        "where f.Nome = @nome " +
                        "or f.Cidade = @cidade" +
                        "or f.CNPJ = @cnpj", 
                        new { 
                            nome = filtro.Nome, cidade = filtro.Cidade, cnpj = filtro.Cnpj 
                        });

                }
                catch (Exception)
                {

                    return null;
                }
            }
        }
        public int CommandPostFornecedor(Fornecedor fornecedor) {
            using (var db = new SqlConnection(connectionString))
            {
                try
                {
                    var idFornecedor = db.Execute($"insert into Fornecedor (Nome,CNPJ,Telefone,Email) values ({fornecedor.Nome}, {fornecedor.CNPJ}, {fornecedor.Telefone},{fornecedor.Email})");
                    foreach (var endereco in fornecedor.Endereco) {
                        var Endereco = db.Execute($"insert into Endereco (CEP,Rua,Numero,Complemento,Cidade,Estado,Pais,ID_Fornecedor)values ({endereco.CEP},{endereco.Rua},{endereco.Numero},{endereco.Complemento},{endereco.Cidade},{endereco.Estado},{endereco.Pais},{idFornecedor})");
                    }
                    return idFornecedor;
                }
                catch (Exception)
                {

                    return 0;
                }
            }
        }
        public int CommandPutFornecedores(Fornecedor fornecedor)
        {
            using (var db = new SqlConnection(connectionString))
            {
                try
                {
                    return db.Execute($"update Fornecedor set nome = {fornecedor.Nome} and cnpj = {fornecedor.CNPJ} and telefone = {fornecedor.Telefone} email = {fornecedor.Email} where id = {fornecedor.Id} ");

                }
                catch (Exception)
                {

                    return 0;
                }
            }
        }
    }
}
