using Google.Apis.YouTube.v3;
using Lrn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Google.Apis.YouTube.v3;
using Google.Apis.Services;
using Google.Apis.YouTube.v3.Data;
using System.IO;

namespace Lrn.Service.Services
{
    public class YoutubeClientService : IServiceProvider
    {
        private YouTubeService youTubeService;
        private YoutubeClientService _youtubeClientService;
        private readonly string _serviceKey = "AIzaSyDomxHS-8MnEN10p5pGK6tI-c5d8I_e1VY";

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
            //https://developers.google.com/youtube/v3/code_samples/dotnet?hl=pt#search_by_keyword

            var contentist = new List<Content>();

            SearchResource.ListRequest listRequest = youTubeService.Search.List("snippet");
            listRequest.Q = q;
            listRequest.Order = SearchResource.ListRequest.OrderEnum.Relevance;
            listRequest.Type = "video";
            listRequest.RegionCode = "BRA"; //TODO: reginalizar
            listRequest.MaxResults = maxResults;

            SearchListResponse searchResponse = listRequest.Execute();

            foreach (SearchResult searchResult in searchResponse.Items) {
                var content = new Content();

                content.ContentType = ContentType.YoutubeVideo;
                content.Created = DateTime.Now;
                content.Data = searchResult.Id.VideoId;
                content.Idiom = "PT-BR"; //TODO
                content.Modificated = DateTime.Now;
                content.Thumbnail = searchResult.Snippet.Thumbnails.Standard.Url;
                content.Title = searchResult.Snippet.Title;
                content.Description = searchResult.Snippet.Description;
            }

            return contentist;
        }


        public string GetCaption(string id) {
            var downloadCaptionRequest = youTubeService.Captions.Download(id);
            var stream = new MemoryStream();

            downloadCaptionRequest.DownloadWithStatus(stream);

            return new StreamReader(stream).ReadToEnd();
        }
    }
}
