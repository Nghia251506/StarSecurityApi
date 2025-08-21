using System;

namespace StarSecurityApi.Dtos.AboutUs
{
    public class AboutUsUpdateDto
    {
        public string SectionTitle { get; set; }
        public string SectionContent { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
    }
}