namespace SpaceBank.Microservices.Media.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key) : base($"Entoty \"{name}\" ({key}) no fue encontrado")
        {

        }
    }
}
