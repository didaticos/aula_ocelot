namespace modelos
{
    public class Pedidos
    {
        public DateTime Data { get; set; }

        public Guid Id { get; set; }

        public string? Dados { get; set; }
        public string? Maquina { get; set; }
    }
}