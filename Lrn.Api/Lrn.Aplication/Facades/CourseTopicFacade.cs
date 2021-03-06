﻿using Lrn.Aplication.Interfaces;
using Lrn.Domain.Entities;
using Lrn.Infra.CrossCutting.Log;
using Lrn.Service.Services;
using Lrn.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lrn.Aplication.Facades
{
    public class CourseTopicFacade : ICourseTopicFacade
    {
        private BaseService<CourseTopic> service = new BaseService<CourseTopic>();
        private BaseService<Content> serviceContent = new BaseService<Content>();

        public CourseTopic Get(int Id)
        {
            return service.Get(Id);
        }

        public void GenerateContent() {
            this.GenerateContent(0);
        }

        public void GenerateContent(int DaysOfSet)
        {
            //Get all topics modifield more then 30 day behind from now
            var courseTopics = this.List().Where(x => x.Modificated < DateTime.Now.AddDays(-DaysOfSet)).OrderBy(x => x.Modificated);
            //var courseTopics = this.List().OrderByDescending(x => x.Modificated).Take(3);

            YoutubeClientService youtubeService = new YoutubeClientService();
            int videosToReturn = 10;

            foreach (CourseTopic c in courseTopics)
            {
                try
                {
                    var videos = youtubeService.FindContent(c.Title, videosToReturn);

                    foreach (Content content in videos)
                    {
                        content.CourseTopicId = c.Id;

                        //Tenta buscar na base se o video já existe
                        var contentsInBase = serviceContent.Get().Where(x => x.Data == content.Data);

                        //se existe
                        if (contentsInBase.Any())
                        {
                            content.Id = contentsInBase.FirstOrDefault().Id;
                            serviceContent.Put<ContentValidator>(content);
                        }
                        else
                        {
                            serviceContent.Post<ContentValidator>(content);
                        }
                    }

                    //If api return the videos solicitaded, update course topic to avoid repeting FindContent execution
                    if (videos.Count() == videosToReturn)
                    {
                        c.Modificated = DateTime.Now;
                        this.Update(c);
                    }
                }
                catch (Exception ex) {
                    if (ex.Message == "Cota excedida"){
                        break;
                    }
                    else{
                        LogManager.Error(ex.Message);
                    }
                }
            }
        }

        public IList<CourseTopic> List()
        {
            return service.Get();
        }

        public void Update(CourseTopic obj)
        {
            service.Put<CourseTopicValidator>(obj);
        }

        public void Insert(CourseTopic obj)
        {
            service.Post<CourseTopicValidator>(obj);
        }
        public void Delete(int _Id)
        {
            service.Delete(new CourseTopic { Id = _Id });
        }
    }
}
