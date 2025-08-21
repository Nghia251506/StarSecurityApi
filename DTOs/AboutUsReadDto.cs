using System;

namespace StarSecurityApi.Dtos.AboutUs
{
    public class AboutUsReadDto
    {
        public int Id{ get; set; }
        public string SectionTitle { get; set; }
        public string SectionContent { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
    }
}