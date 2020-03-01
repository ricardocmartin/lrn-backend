using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Lrn.Api.Test
{
    public class CourseControllerTest : TestBase
    {
        public CourseControllerTest()
        {
            _controllerPath = "/api/Course";
        }
    }

    public class ContentControllerTest : TestBase
    {
        public ContentControllerTest()
        {
            _controllerPath = "/api/Content";
        }
    }

    public class ContentVoteControllerTest : TestBase
    {
        public ContentVoteControllerTest()
        {
            _controllerPath = "/api/ContentVote";
        }
    }

    public class CourseTopicControllerTest : TestBase
    {
        public CourseTopicControllerTest()
        {
            _controllerPath = "/api/CourseTopic";
        }
    }
}
