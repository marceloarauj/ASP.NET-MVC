using Npgsql;
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
                new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres Password=1234;Database=github");

            consulta.Open();

            NpgsqlCommand comando = new NpgsqlCommand(query);

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
        public static void executarInsert(string insert)
        {

        }
        public static void executarDelete(string delete)
        {

        }
        public static void executarUpdate(string update)
        {

        }
    }
}
