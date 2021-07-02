namespace HelloTask.Infrastructure.Commands.Assignments
{
    public class PutAssignment : ICommand
    {
        public string NewName { get; set; }
        public string NewDescription { get; set; }
    }
}
