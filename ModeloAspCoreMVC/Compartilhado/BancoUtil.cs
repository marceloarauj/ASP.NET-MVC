﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModeloAspCoreMVC.Compartilhado
{
    public class BancoUtil
    {
        public static Dictionary<string,List<string>> executarQuery(string query)
        {
            NpgsqlConnection consulta = 
                new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres; Password=1234;Database=github");

            consulta.Open();

            NpgsqlCommand comando = new NpgsqlCommand(query,consulta);

            NpgsqlDataReader ler = comando.ExecuteReader();

            Dictionary<string, List<string>> resultado = new Dictionary<string, List<string>>();

            for(int i =0; i < ler.FieldCount;i++)
            {
                resultado.Add(ler.GetName(i), new List<string>());
            }

            while (ler.Read())
            {
                for(int i =0; i < ler.FieldCount; i++)
                {
                    resultado[ler.GetName(i)].Add(ler.GetValue(i).ToString());
                }
            }
            consulta.Close();

            return resultado;
        }
        public static void cadastrarUsuario(string login, string password)
        {
            NpgsqlConnection connection =
                new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres; Password=1234;Database=github");

            connection.Open();

            NpgsqlCommand comando = new NpgsqlCommand("insert into usuario (id_usuario,nome,senha) values (@id,@login,@password)",connection);
            int id = 2;

            var paramId = comando.CreateParameter();
            var paramNome = comando.CreateParameter();
            var paramSenha = comando.CreateParameter();

            paramId.ParameterName = "id"; paramId.Value = id;
            paramNome.ParameterName = "login"; paramNome.Value = login;
            paramSenha.ParameterName = "password"; paramSenha.Value = password;


            comando.Parameters.Add(paramId);
            comando.Parameters.Add(paramNome);
            comando.Parameters.Add(paramSenha);

            comando.ExecuteNonQuery();
            
            connection.Close();
        } 
        public static void executarDelete(string delete)
        {

        }
        public static void executarUpdate(string update)
        {

        }
    }
}
