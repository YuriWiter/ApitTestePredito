using DesafioBackEnd.Enums;

namespace DesafioBackEnd.Entidades
{
    public class Sensor
    {
        public int Id { get; set; }
        public string Altura { get; set; }
        public string Largura { get; set; }
        public string Comprimento { get; set; }
        public double TensaoBateria { get; set; }
        public Marca Marca { get; set; }
        public Tipo Tipo { get; set; }
        public string UltimaMedicao { get; set; }
        public string Localizacao { get; set; }
    }
}
