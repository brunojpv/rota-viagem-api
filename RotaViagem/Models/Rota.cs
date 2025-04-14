namespace RotaViagem.Models
{
    /// <summary>
    /// Representa uma rota de viagem entre dois aeroportos com um custo associado.
    /// </summary>
    public class Rota
    {
        /// <summary>
        /// Identificador único da rota.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Código do aeroporto de origem (ex: GRU).
        /// </summary>
        public string Origem { get; set; } = string.Empty;

        /// <summary>
        /// Código do aeroporto de destino (ex: CDG).
        /// </summary>
        public string Destino { get; set; } = string.Empty;

        /// <summary>
        /// Valor (custo) da rota.
        /// </summary>
        public decimal Valor { get; set; }
    }
}
