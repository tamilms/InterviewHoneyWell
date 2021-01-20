using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XamarinInterviewTask.Constants;

namespace XamarinInterviewTask.Services
{
    public class WebServices
    {
        public static ServiceResponse<String> GenericRestCallUsingHttpClient<T, Tr>(string endpoint, HttpMethod method, Tr content)
        {
            var serviceResponse = new ServiceResponse<String> { IsSuccess = false };
            string returnValue = string.Empty;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(AppConstants.BASE_URL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = null;
                    if (method == HttpMethod.Get || method == HttpMethod.Delete)
                    {

                        if (method == HttpMethod.Get)
                        {
                            response = client.GetAsync(endpoint).Result;

                        }
                        else
                        {
                            response = client.DeleteAsync(endpoint).Result;

                        }

                        if (response.IsSuccessStatusCode)
                        {
                            serviceResponse.IsSuccess = true;
                            serviceResponse.Data = response.Content.ReadAsStringAsync().Result;
                        }
                        else
                        {

                            serviceResponse.IsSuccess = false;
                            serviceResponse.Message = response.Content.ReadAsStringAsync().Result;
                        }
                    }
                    else
                    {

                        string Body = JsonConvert.SerializeObject(content, Formatting.None,
                                                                                new JsonSerializerSettings
                                                                                {
                                                                                    NullValueHandling = NullValueHandling.Ignore
                                                                                });

                        switch (method.Method)
                        {
                            case "POST":
                                {
                                    response = client.PostAsync(endpoint, new StringContent(Body, Encoding.UTF8, "application/json")).Result;
                                }
                                break;
                            case "PUT":
                                response = client.PutAsync(endpoint, new StringContent(Body, Encoding.UTF8, "application/json")).Result;
                                break;
                        }
                        if (response.IsSuccessStatusCode)
                        {
                            serviceResponse.IsSuccess = true;
                            serviceResponse.Data = response.Content.ReadAsStringAsync().Result;
                        }
                        else
                        {

                            serviceResponse.IsSuccess = false;
                            serviceResponse.Message = response.Content.ReadAsStringAsync().Result;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Exception generated: " + ex.Message;
            }
            return serviceResponse;
        }

        public static async Task<ServiceResponse<T>> RestCalls<T, Tr>(string endpoint, HttpMethod method, Tr content)
        {
            var returnResult = new ServiceResponse<T>();
            HttpClient client = null;
            try
            {
                client = new HttpClient();
                client.BaseAddress = new Uri(AppConstants.BASE_URL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.Timeout = new TimeSpan(0, 0, 15);
                HttpResponseMessage result = null;
                HttpStatusCode statusCode;
                StringContent data = null;
                if (content != null)
                    data = new StringContent(JsonConvert.SerializeObject(content), UTF8Encoding.UTF8, "application/json");

                if (method == HttpMethod.Get)
                    result = await client.GetAsync(endpoint);

                if (method == HttpMethod.Put)
                    result = await client.PutAsync(endpoint, data);

                if (method == HttpMethod.Delete)
                    result = await client.DeleteAsync(endpoint);

                if (method == HttpMethod.Post)
                    result = await client.PostAsync(endpoint, data);

                if (result != null)
                {
                    if (result.IsSuccessStatusCode && result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        returnResult.IsSuccess = true;
                        var json = result.Content.ReadAsStringAsync().Result;
                        returnResult.Data = JsonConvert.DeserializeObject<T>(json);
                    }
                    else //if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        statusCode = result.StatusCode;
                        returnResult.IsSuccess = false;
                        returnResult.Message = string.Format("{0} {1}",(int)statusCode, result.ReasonPhrase);
                    }
                }

            }
            catch (Exception ex)
            {
                //Error log api here 
            }
            finally
            {
                if (client != null)
                    client.Dispose();
            }
            return returnResult;
        }
    }

}
