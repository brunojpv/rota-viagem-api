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
        public required string Origem { get; set; }

        /// <summary>
        /// Código do aeroporto de destino (ex: CDG).
        /// </summary>
        public required string Destino { get; set; }

        /// <summary>
        /// Valor (custo) da rota.
        /// </summary>
        public decimal Valor { get; set; }
    }
}
