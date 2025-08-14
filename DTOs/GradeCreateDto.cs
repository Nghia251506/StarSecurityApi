namespace StarSecurityApi.Dtos
{
    public class GradeCreateDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Level { get; set; }
        public string? Description { get; set; }
    }
}