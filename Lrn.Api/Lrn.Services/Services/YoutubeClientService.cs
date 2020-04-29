using Google.Apis.YouTube.v3;
using Lrn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Google.Apis.YouTube.v3;
using Google.Apis.Services;
using Google.Apis.YouTube.v3.Data;
using System.IO;
using Lrn.Infra.CrossCutting.Log;

namespace Lrn.Service.Services
{
    public class YoutubeClientService : IServiceProvider
    {
        private YouTubeService youTubeService;
        private YoutubeClientService _youtubeClientService;
        private readonly string _serviceKey = "AIzaSyD5UY_3F_IdpVzXm-XGrWsd29uulAAwCkM";

        public YoutubeClientService()
        {
            
            InitYouTubeClient();
        }

        private void InitYouTubeClient() {
            var initializer = new BaseClientService.Initializer(){
                ApiKey = _serviceKey
            };

            this.youTubeService = new YouTubeService(initializer);
        }

        public object GetService(Type serviceType)
        {
            return _youtubeClientService;
        }

        public List<Content> FindContent(string q, int maxResults) {

            var contentist = new List<Content>();

            try
            {
                //https://developers.google.com/youtube/v3/code_samples/dotnet?hl=pt#search_by_keyword

                SearchResource.ListRequest listRequest = youTubeService.Search.List("snippet");
                listRequest.Q = q;
                listRequest.Order = SearchResource.ListRequest.OrderEnum.Relevance;
                listRequest.Type = "video";
                //listRequest.RegionCode = "BRA"; //TODO: reginalizar
                listRequest.MaxResults = maxResults;

                SearchListResponse searchResponse = listRequest.Execute();

                foreach (SearchResult searchResult in searchResponse.Items)
                {
                    contentist.Add(new Content
                    {
                        ContentType = ContentType.YoutubeVideo,
                        Created = DateTime.Now,
                        Data = searchResult.Id.VideoId,
                        Idiom = "PT-BR", //TODO
                        Modificated = DateTime.Now,
                        Thumbnail = GetThumbNail(searchResult.Snippet.Thumbnails),
                        Title = searchResult.Snippet.Title,
                        Description = searchResult.Snippet.Description,
                    });
                }
            }
            catch (Exception ex) {
                //TODO: Melhorar essa verificação, precisa pera a exceptions correta e verificar se é uma System.Net.HttpStatusCode.Forbidden
                if (ex.Message.Contains("The request cannot be completed because you have exceeded your")){
                    LogManager.Warning($"A cota de consumo do youtube foi excedida para a chave {_serviceKey}");
                    throw new Exception("Cota excedida");
                }
                else
                    throw ex;
            }

            return contentist;
        }

        private string GetThumbNail(ThumbnailDetails t) {
            if (t.High != null)
                return t.High.Url;
            if (t.Medium != null)
                return t.Medium.Url;
            if (t.Standard != null)
                return t.Standard.Url;
            if (t.Default__ != null)
                return t.Default__.Url;

            return "";
        }


        public string GetCaption(string id) {
            var downloadCaptionRequest = youTubeService.Captions.Download(id);
            var stream = new MemoryStream();

            downloadCaptionRequest.DownloadWithStatus(stream);

            return new StreamReader(stream).ReadToEnd();
        }
    }
}
