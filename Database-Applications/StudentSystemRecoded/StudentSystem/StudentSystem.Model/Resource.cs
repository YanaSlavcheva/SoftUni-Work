namespace StudentSystem.Model
{
    using System.Security.AccessControl;

    public class Resource
    {
        //Resources: id, name, type of resource (video / presentation / document / other), link
        public int Id { get; set; }

        public string Name { get; set; }

        public ResourceType ResourceType { get; set; }

        public string Link { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
