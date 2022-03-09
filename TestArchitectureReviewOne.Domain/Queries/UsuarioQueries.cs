namespace TestArchitectureReviewOne.Domain.Queries
{
    public static class UsuarioQueries
    {
        public static string ExistePorEmail()
        {
            return "Select Id from Usuario where Email = @Email";
        }
    }
}