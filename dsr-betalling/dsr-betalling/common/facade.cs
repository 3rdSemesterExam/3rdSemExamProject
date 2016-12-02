using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using dsr_betalling.exception;
using dsr_betalling.Interface;
using Newtonsoft.Json;
using static System.String;

// ReSharper disable RedundantCatchClause

namespace dsr_betalling.Common
{
    public static class Facade
    {
        private const string ServerUrl = "http://dsr-webservice.azurewebsites.net"; // HTTP URL of Server
        private const string ApiBaseUrl = "/api/"; // Base Directory of the Api (Remember Leading and Trailing "/")
        private static string Token;

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
                if (!IsNullOrEmpty(Token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
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
            var result = new T();
            var handler = new HttpClientHandler { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (!IsNullOrEmpty(Token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

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
        /// Posts an Object to the Webservice, Serialized as JSON
        /// </summary>
        /// <typeparam name="T">Objekt Type</typeparam>
        /// <param name="obj">Objekt som skal sendes</param>
        /// <returns></returns>
        public static async Task<bool> PostAsync<T>(T obj) where T : IWebUri
        {
            if (IsNullOrEmpty(Token)) return false;
            var handler = new HttpClientHandler { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
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
        /// Updates an Object in the Webservice, serialized as JSON, by Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<bool> PutAsync<T>(T obj, int id) where T : IWebUri
        {
            if (IsNullOrEmpty(Token)) return false;
            var handler = new HttpClientHandler { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
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
        /// Deletes an Object from the Webservice, by Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<bool> DeleteAsync<T>(T obj, int id) where T : IWebUri
        {
            if (IsNullOrEmpty(Token)) return false;
            var handler = new HttpClientHandler { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
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

        /// <summary>
        /// Performs a Login check
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static async Task<bool> DoLoginAsync(string username, string password)
        {
            var handler = new HttpClientHandler { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                var kvp = new List<KeyValuePair<string, string>>
                        {
                            new KeyValuePair<string, string>( "username", username ),
                            new KeyValuePair<string, string> ( "password", password ),
                            new KeyValuePair<string, string>( "grant_type", "password" )
                        };
                var EncodedContent = new FormUrlEncodedContent(kvp);
                try
                {
                    var response = await client.PostAsync("/token", EncodedContent);
                    if (!response.IsSuccessStatusCode)
                    {
                        if (response.StatusCode == HttpStatusCode.Unauthorized) return false;
                        throw new HttpErrorException("HTTP Error\n" + "Login: " + response.ReasonPhrase);
                    }
                    Token = (await response.Content.ReadAsStringAsync()).Split('"')[3];
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Changes the password of the user currently Logged In
        /// </summary>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public static async Task<bool> DoChangePasswordAsync(string oldPassword, string newPassword)
        {
            if (IsNullOrEmpty(Token)) return false;
            var handler = new HttpClientHandler { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var kvp = new List<KeyValuePair<string, string>>
                        {
                            new KeyValuePair<string, string>( "OldPassword", oldPassword ),
                            new KeyValuePair<string, string> ( "NewPassword", newPassword ),
                            new KeyValuePair<string, string>( "ConfirmPassword", newPassword )
                        };
                var EncodedContent = JsonConvert.SerializeObject(kvp);
                try
                {
                    var response = await client.PostAsJsonAsync("/api/Account/ChangePassword", EncodedContent);
                    if (response.IsSuccessStatusCode) return true;
                    if (response.StatusCode == HttpStatusCode.BadRequest &&
                        response.ReasonPhrase.Contains("The new password and confirmation password do not match."))
                        return false;
                    throw new HttpErrorException("HTTP Error\n" + "Change Password: " + response.ReasonPhrase);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Creates a User that can access the Authorized part of the Webservice
        /// </summary>
        /// <param name="email"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static async Task<bool> DoCreateUser(string email, string username, string password)
        {
            if (IsNullOrEmpty(Token)) return false;
            var handler = new HttpClientHandler { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var kvp = new List<KeyValuePair<string, string>>
                        {
                            new KeyValuePair<string, string>( "Email", email ),
                            new KeyValuePair<string, string>( "Username", username ),
                            new KeyValuePair<string, string>( "Password", password ),
                            new KeyValuePair<string, string>( "ConfirmPassword", password )
                        };
                var EncodedContent = JsonConvert.SerializeObject(kvp);
                try
                {
                    var response = await client.PostAsJsonAsync("/api/Account/Register", EncodedContent);
                    if (response.IsSuccessStatusCode) return true;
                    if (response.StatusCode == HttpStatusCode.BadRequest)
                        return false;
                    throw new HttpErrorException("HTTP Error\n" + "Create User: " + response.ReasonPhrase);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}