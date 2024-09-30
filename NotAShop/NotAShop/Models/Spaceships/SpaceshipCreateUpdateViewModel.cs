namespace NotAShop.Models.Spaceships
{
    public class SpaceshipCreateUpdateViewModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string SpaceshipModel { get; set; }
        public DateTime BuiltDate { get; set; }
        public int Crew { get; set; }
        public int EnginePower { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<ImageViewModel> Image { get; set; }
            = new List<ImageViewModel>();

        //only for database
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
