using Smart.Door.Gajet.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Smart.Door.Gajet.Client.Infrastructure
{
    public abstract class ServiceBase : object
    {
        public ServiceBase
            (System.Net.Http.HttpClient httpClient, ApplicationSettingsService applicationSettingsService, LogsService logsService)
            :base()
        {
            HttpClient = httpClient;

            LogsService = logsService;

            ApplicationSettingsService = applicationSettingsService;

            BaseUrl = ApplicationSettingsService.BaseUrl;

            JsonOptions =
                new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
        }

        public string BaseUrl { get; }

        public LogsService LogsService { get; }

        protected ApplicationSettingsService ApplicationSettingsService { get; }

        protected System.Net.Http.HttpClient HttpClient { get; }

        protected System.Text.Json.JsonSerializerOptions JsonOptions { get; set; }

        protected  async Task<TResponse> GetAsync<TResponse>(string url, string query = null)
        {
            System.Net.Http.HttpResponseMessage response = null;

            try
            {
                string requestUri =
                    $"{ BaseUrl }/{ url }";

                if (string.IsNullOrWhiteSpace(query) == false)
                {
                    requestUri =
                        $"{ requestUri }?{ query }";
                }

                response = await
                    HttpClient.GetAsync
                    (requestUri: requestUri)
                    ;

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode == true)
                {
                    try
                    {
                        TResponse result =
                            await response.Content.ReadFromJsonAsync<TResponse>()
                            ;

                        return result;
                    }
                    //when content type is not valid!
                    catch (NotSupportedException ex)
                    {
                        string errorMessage =
                            $"Exception: { ex.Message } - The content type is not supported.";

                        // Static داخل تابع غیر
                        LogsService.AddLog(type: GetType(), message: errorMessage);

                        // Static داخل تابع
                        //LogsService.AddLog(type: typeof(ServiceBase), message: errorMessage);
                    }
                    //invalid Jason
                    catch (System.Text.Json.JsonException ex) 
                    {
                        string errorMessage =
                            $"Exception: { ex.Message } - Invalid JSON.";

                        LogsService.AddLog(type: GetType(), message: errorMessage);
                    }
                }
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                string errorMessage =
                   $"Exception: { ex.Message }";

                LogsService.AddLog(type: GetType(), message: errorMessage);
            }
            finally
            {
                response.Dispose();
            }

            return default;
        }
   
    }

}
