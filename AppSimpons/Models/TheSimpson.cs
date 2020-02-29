using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace AppSimpons.Models
{
    public class TheSimpson
    {
        SQLiteConnection connection;
        readonly string ruta = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "/thesimpson";

        public TheSimpson()
        {
            connection = new SQLiteConnection(ruta);
            connection.CreateTable<Temporada>();
        }

        public async Task DescargarTemporadas()
        {
            if (connection.Table<Temporada>().Count() == 0)// no existen datos en la tabla
            {
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    HttpClient cliente = new HttpClient();
                    var res = await cliente.GetAsync("http://itesrc.net/api/simpsons/temporadas");

                    if (res.IsSuccessStatusCode)
                    {
                        List<Temporada> listaTemporadas = JsonConvert.DeserializeObject<List<Temporada>>(await res.Content.ReadAsStringAsync());

                        foreach (Temporada temporada in listaTemporadas)
                        {
                            Temporada t = new Temporada()
                            {
                                Numero = temporada.Numero,
                                TotalEpisodios = temporada.TotalEpisodios,
                                Periodo = temporada.Periodo
                            };
                            connection.Insert(t);
                        }
                    }
                    else
                    {
                        throw new Exception(await res.Content.ReadAsStringAsync());
                    }
                }
                else
                {
                    throw new Exception("No hay conexión a Internet");
                }
            }
        }

        public ObservableCollection<Temporada> GetTemporadas()
        {
            return new ObservableCollection<Temporada>(connection.Table<Temporada>().OrderByDescending(x=>x.Numero));
        }
    }
}
