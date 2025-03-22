namespace OeX.Dashboard.Application.OrdensProducao.DTOs
{
    public class QualidadeProducaoMensalDto
    {
        public decimal TotalBoas { get; set; }
        public decimal TotalRuins { get; set; }
        public decimal TotalPerdas { get; set; }
        public string Mes { get; set; }

        public QualidadeProducaoMensalDto(
                decimal totalBoas,
                decimal totalRuins,
                decimal totalPerdas, 
                int mes)
        {
            TotalBoas = totalBoas;
            TotalRuins = totalRuins;
            TotalPerdas = totalPerdas;
            Mes = GetNomeMes(mes);
        }

        private string GetNomeMes(int mes)
        {
            if (mes == 1) return "Janeiro";
            if (mes == 2) return "Fevereiro";
            if (mes == 3) return "Março";
            if (mes == 4) return "Abril";
            if (mes == 5) return "Maio";
            if (mes == 6) return "Junho";
            if (mes == 7) return "Julho";
            if (mes == 8) return "Agosto";
            if (mes == 9) return "Setembro";
            if (mes == 10) return "Outubro";
            if (mes == 11) return "Novembro";
            if (mes == 12) return "Dezembro";
            
            return "N/A";
        }
    }
}
