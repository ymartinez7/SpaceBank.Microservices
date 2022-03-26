namespace SpaceBank.Microservices.Infra.Bus
{
    public class RabbitMQSetting
    {
        public string HostName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public RabbitMQSetting()
        {
            HostName = string.Empty;
            UserName = string.Empty;
            Password = string.Empty;
        }
    }
}
