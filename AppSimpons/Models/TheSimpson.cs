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
            connection.CreateTable<Episodio>();
        }

        public async Task DescargarTemporadas()
        {
            if (connection.Table<Temporada>().Count() == 0)
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
            return new ObservableCollection<Temporada>(connection.Table<Temporada>().OrderByDescending(x=> x.Numero));
        }

        public async Task DescargarEpisodiosDeTemporada(int numeroTemporada)
        {
            Temporada temporada = connection.Table<Temporada>().First(x => x.Numero == numeroTemporada);

            if (!connection.Table<Episodio>().Any(x => x.NumeroTemporada == numeroTemporada) ||
                connection.Table<Episodio>().Count(x => x.NumeroTemporada == temporada.Numero) < temporada.TotalEpisodios)
            {
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    HttpClient cliente = new HttpClient();
                    var res = await cliente.GetAsync($"http://itesrc.net/api/simpsons/temporada/{temporada.Numero}");

                    if (res.IsSuccessStatusCode)
                    {
                        List<EpisodioViewModel> listaCapitulos = JsonConvert.DeserializeObject<List<EpisodioViewModel>>(await res.Content.ReadAsStringAsync());
                        foreach (EpisodioViewModel episodio in listaCapitulos)
                        {
                            Episodio e = new Episodio()
                            {
                                NumeroTemporada = episodio.Temporada,
                                NumeroEpisodio = episodio.Episodio,
                                Nombre = episodio.Titulo,
                                Imagen = $"http://itesrc.net{episodio.Imagen}"
                            };

                            var resultado = await cliente.GetAsync($"http://itesrc.net/api/simpsons/episodio/{e.NumeroTemporada}/{e.NumeroEpisodio}");

                            if (resultado.IsSuccessStatusCode)
                            {
                                Episodio ep = JsonConvert.DeserializeObject<Episodio>(await resultado.Content.ReadAsStringAsync());

                                e.Id = ep.Id;
                                e.NombreOriginal = ep.NombreOriginal;
                                e.FechaEmision = ep.FechaEmision;
                                e.Duracion = ep.Duracion;
                                e.Sinopsis = ep.Sinopsis;

                                connection.Insert(e);
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

        public ObservableCollection<Episodio> GetEpisodiosByNumeroTemporada(int numeroTemp)
        {
            return new ObservableCollection<Episodio>(connection.Table<Episodio>().Where(x => x.NumeroTemporada == numeroTemp));
        }


        public ObservableCollection<Episodio> GetUltimosEpisodios()
        {
            return new ObservableCollection<Episodio>(connection.Table<Episodio>().Where(x => x.NumeroTemporada == 30));
        }

        //public ObservableCollection<Capitulo> GetCapitulosRandom()
        //{
        //    Random r = new Random();
        //    return new ObservableCollection<Capitulo>(connection.Table<Capitulo>().ToList().OrderBy(x => r.Next()).Take(30));
        //}

        public async Task DescargarEpisodio(Episodio episodio)
        {
            if (string.IsNullOrWhiteSpace(episodio.Sinopsis))
            {
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    HttpClient client = new HttpClient();
                    var resultado = await client.GetAsync($"http://itesrc.net/api/simpsons/episodio/{episodio.NumeroTemporada}/{episodio.NumeroEpisodio}");

                    if (resultado.IsSuccessStatusCode)
                    {
                        Episodio e = JsonConvert.DeserializeObject<Episodio>(await resultado.Content.ReadAsStringAsync());

                        episodio.Id = e.Id;
                        episodio.NombreOriginal = e.NombreOriginal;
                        episodio.FechaEmision = e.FechaEmision;
                        episodio.Duracion = e.Duracion;
                        episodio.Sinopsis = e.Sinopsis;

                        connection.Update(episodio);
                    }
                    else
                    {
                        throw new Exception(await resultado.Content.ReadAsStringAsync());
                    }
                }
            }
        }

    }
}
