namespace HelloTask.Infrastructure.Commands.Assignments
{
    public class PostAssignment : ICommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
