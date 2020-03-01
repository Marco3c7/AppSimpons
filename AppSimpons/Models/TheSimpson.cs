using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Linq;
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
            connection.CreateTable<CapituloDeTemporada>();
            connection.CreateTable<Capitulo>();
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

        public async Task DescargarCapitulosDeTemporada(int numeroTemporada)
        {
            if(!connection.Table<CapituloDeTemporada>().Any(x=> x.Temporada == numeroTemporada))
            {
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    HttpClient cliente = new HttpClient();
                    var res = await cliente.GetAsync($"http://itesrc.net/api/simpsons/temporada/{numeroTemporada}");

                    if (res.IsSuccessStatusCode)
                    {
                        List<CapituloDeTemporada> listaCapitulos = JsonConvert.DeserializeObject<List<CapituloDeTemporada>>(await res.Content.ReadAsStringAsync());
                        foreach (CapituloDeTemporada capitulo in listaCapitulos)
                        {
                            CapituloDeTemporada c = new CapituloDeTemporada()
                            {
                                Temporada = capitulo.Temporada,
                                Episodio = capitulo.Episodio,
                                Titulo = capitulo.Titulo,
                                Imagen = $"http://itesrc.net{capitulo.Imagen}"
                            };
                            connection.Insert(c);

                            HttpClient client = new HttpClient();
                            var resultado = await cliente.GetAsync($"http://itesrc.net/api/simpsons/episodio/{numeroTemporada}/{capitulo.Episodio}");
                            if (resultado.IsSuccessStatusCode)
                            {
                                Capitulo cap = JsonConvert.DeserializeObject<Capitulo>(await resultado.Content.ReadAsStringAsync());
                                cap.Imagen = $"http://itesrc.net{cap.Imagen}";
                                connection.Insert(cap);
                            }
                            else
                            {
                                throw new Exception(await resultado.Content.ReadAsStringAsync());
                            }
                        }
                    }
                    else
                    {
                        throw new Exception(await res.Content.ReadAsStringAsync());
                    }
                }
                else
                {
                    throw new Exception("No hay conexión a Internet.");
                }
            }
        }

        public ObservableCollection<Capitulo> GetCapitulosByTemporada(int numeroTemp)
        {
            return new ObservableCollection<Capitulo>(connection.Table<Capitulo>().Where(x => x.Temporada == numeroTemp));
        }

        public ObservableCollection<Capitulo> GetCapitulosRandom()
        {
            Random r = new Random();
            return new ObservableCollection<Capitulo>(connection.Table<Capitulo>().ToList().OrderBy(x => r.Next()).Take(30));
        }
    }
}
