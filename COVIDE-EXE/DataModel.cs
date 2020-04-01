using Newtonsoft.Json;
using System;

namespace COVID_19
{
    public class DataModel
    {
        [JsonProperty("data")]
        public DateTime Data { get; set; }
        [JsonProperty("stato")]
        public string Nazione { get; set; }
        [JsonProperty("ricoverati_con_sintomi")]
        public int RicoveratiConSintomi { get; set; }
        [JsonProperty("terapia_intensiva")]
        public int TerapiaIntensiva { get; set; }
        [JsonProperty("totale_ospedalizzati")]
        public int Ospedalizzazione { get; set; }
        [JsonProperty("isolamento_domiciliare")]
        public int IsolamentoDomiciliare { get; set; }
        [JsonProperty("totale_positivi")]
        public int Positivi { get; set; }
        [JsonProperty("variazione_totale_positivi")]
        public int VariazioneTotalePositivi { get; set; }
        [JsonProperty("nuovi_positivi")]
        public int NuoviPositivi { get; set; }
        [JsonProperty("dimessi_guariti")]
        public int Guariti { get; set; }
        [JsonProperty("deceduti")]
        public int Deceduti { get; set; }
        [JsonProperty("totale_casi")]
        public int TotaleCasi { get; set; }
        [JsonProperty("tamponi")]
        public int Tamponi { get; set; }
        [JsonProperty("codice_regione")]
        public int CodiceRegione { get; set; }
        [JsonProperty("denominazione_regione")]
        public string Regione { get; set; }

        public override string ToString()
        {
            return $"Data: {Data.ToString()} - Regione: {Regione} - TotalePositivi: {TotaleCasi} NuoviPositivi: {NuoviPositivi} - Terapia Intensiva: {TerapiaIntensiva} - Totale morti: {Deceduti}";
        }
    }
}
