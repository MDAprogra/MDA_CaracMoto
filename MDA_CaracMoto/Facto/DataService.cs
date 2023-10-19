using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDA_CaracMoto.Facto
{
    public interface IDataService
    {
        List<CaracMoto> GetMoto();
        void AddMoto(CaracMoto moto);
        void DelMoto(int id);
        void ModifMoto(CaracMoto moto, int id);
        CaracMoto GetMotoID(int id);

    }
    class DataService : IDataService
    {
        private readonly SqlConnection _connexion;
        public DataService()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost";
            builder.UserID = "sa";
            builder.Password = "Info76240#";
            builder.InitialCatalog = "DB_Moto";
            builder.TrustServerCertificate = true;
            _connexion = new SqlConnection(builder.ConnectionString);
        }
        public List<CaracMoto> GetMoto()
        {
            string sql = "select ID,Ref,Marque,Modele,Annee,Prix,CV,KW,Poids from Caracteristique";
            List<CaracMoto> values;
            _connexion.Open();
            using (SqlCommand command = new SqlCommand(sql, _connexion))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    values = reader.Cast<IDataRecord>().Select(r => new CaracMoto
                    {
                        ID = r["ID"] as int?,
                        Ref = r["Ref"] as string,
                        Marque = r["Marque"] as string,
                        Modele = r["Modele"] as string,
                        Annee = r["Annee"] as int?,
                        Prix = r["Prix"] as int?,
                        CV = r["CV"] as int?,
                        KW = r["KW"] as int?,
                        Poids = r["Poids"] as int?
                    }).ToList();
                }
            }
            _connexion.Close();
            return values;
        }
        public void AddMoto(CaracMoto moto)
        {
            string sql = $"insert into Caracteristique(Ref, Marque, Modele, Annee, Prix, CV, KW, Poids, CheminImg) values('{moto.Ref}', '{moto.Marque}', '{moto.Modele}','{moto.Annee}', '{moto.Prix}', '{moto.CV}', '{moto.KW}', '{moto.Poids}','{moto.Img}')";
            _connexion.Open();
            using (SqlCommand cmd = new SqlCommand(sql, _connexion))
            {
                cmd.ExecuteNonQuery();
            }
            _connexion.Close();
            return;
        }
        public void DelMoto(int id)
        {
            string sql = $"delete from Caracteristique where ID = '{id}'";
            _connexion.Open();
            using (SqlCommand cmd = new SqlCommand(sql, _connexion))
            {
                cmd.ExecuteNonQuery();
            }
            _connexion.Close();
            return;
        }
        public void ModifMoto(CaracMoto moto, int id)
        {
            string sql = $"update Caracteristique set Ref = '{moto.Ref}', Marque = '{moto.Marque}', Modele = '{moto.Modele}', Annee = '{moto.Annee}', Prix = '{moto.Prix}', CV = '{moto.CV}', KW = '{moto.KW}', Poids = '{moto.Poids}' where ID = '{id}'";
            _connexion.Open();
            using (SqlCommand cmd = new SqlCommand(sql, _connexion))
            {
                cmd.ExecuteNonQuery();
            }
            _connexion.Close();
            return;
        }
        public CaracMoto GetMotoID(int id)
        {
            string sql = $"select ID,Ref,Marque,Modele,Annee,Prix,CV,KW,Poids from Caracteristique where ID = '{id}'";
            CaracMoto values;
            _connexion.Open();
            using (SqlCommand command = new SqlCommand(sql, _connexion))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    values = reader.Cast<IDataRecord>().Select(r => new CaracMoto
                    {
                        ID = r["ID"] as int?,
                        Ref = r["Ref"] as string,
                        Marque = r["Marque"] as string,
                        Modele = r["Modele"] as string,
                        Annee = r["Annee"] as int?,
                        Prix = r["Prix"] as int?,
                        CV = r["CV"] as int?,
                        KW = r["KW"] as int?,
                        Poids = r["Poids"] as int?
                    }).FirstOrDefault();
                }
            }
            _connexion.Close();
            return values;
        }
    }
}
