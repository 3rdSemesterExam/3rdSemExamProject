using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using dsr_betalling.exception;

using dsr_betalling.@interface;

namespace dsr_betalling.common
{
    public static class facade
    {
        private const string ServerUrl = "http://statuedatabasewepapi.azurewebsites.net"; // HTTP URL of Server
        // private const string ServerUrl = "http://localhost:55000"; // HTTP URL of Server
        private const string ApiBaseUrl = "/api/"; // Base Directory of the Api (Remember Leading and Trailing "/")

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns>Enumerable List of T</returns>
        public static async Task<IEnumerable<T>> GetListAsync<T>(T obj) where T : IWebUri
        {
            var handler = new HttpClientHandler { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = await client.GetAsync(ApiBaseUrl + obj.ResourceUri);
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new HttpErrorException("HTTP Error\n" + obj.VerboseName + ": " + response.ReasonPhrase);
                    }
                    var listOfObjects = response.Content.ReadAsAsync<IEnumerable<T>>().Result;
                    return listOfObjects;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<T> GetAsync<T>(T obj, int id) where T : IWebUri, new()
        {
            T result = new T();
            var handler = new HttpClientHandler { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = await client.GetAsync(ApiBaseUrl + result.ResourceUri + "/" + id);
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new HttpErrorException("HTTP Error\n" + obj.VerboseName + ": " + response.ReasonPhrase);
                    }
                    result = response.Content.ReadAsAsync<T>().Result;
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Sender et objekt til webservicen, serialiseret som JSON
        /// </summary>
        /// <typeparam name="T">Objekt Type</typeparam>
        /// <param name="obj">Objekt som skal sendes</param>
        /// <returns></returns>
        public static async Task<bool> PostAsync<T>(T obj) where T : IWebUri
        {
            var handler = new HttpClientHandler { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = await client.PostAsJsonAsync(ApiBaseUrl + obj.ResourceUri, obj);
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new HttpErrorException("HTTP Error\n" + obj.VerboseName + ": " + response.ReasonPhrase);
                    }
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<bool> PutAsync<T>(T obj, int id) where T : IWebUri
        {
            var handler = new HttpClientHandler { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = await client.PutAsJsonAsync(ApiBaseUrl + obj.ResourceUri + "/" + id, obj);
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new HttpErrorException("HTTP Error\n" + obj.VerboseName + ": " + response.ReasonPhrase);
                    }
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<bool> DeleteAsync<T>(T obj, int id) where T : IWebUri
        {
            var handler = new HttpClientHandler { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = await client.DeleteAsync(ApiBaseUrl + obj.ResourceUri + "/" + id);
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new HttpErrorException("HTTP Error\n" + obj.VerboseName + ": " + response.ReasonPhrase);
                    }
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}