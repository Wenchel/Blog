using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Shared.DataTransferObjects
{
    public class BlogClassificationServiceDtoBase
    {
        public Guid ClassificationId { get; set; }
        public string ClassificationName { get; set; }
        public DateTime CreateClassificationTime { get; set; }
        public DateTime UpdateClassificationTime { get; set; }
    }
    public class BlogClassificationService_AddDto : BlogClassificationServiceDtoBase { }
    public class BlogClassificationService_GetDto : BlogClassificationServiceDtoBase { }
    public class BlogClassificationService_UpdateDto : BlogClassificationServiceDtoBase { }
}
