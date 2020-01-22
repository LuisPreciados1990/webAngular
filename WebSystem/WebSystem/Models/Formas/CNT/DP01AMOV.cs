using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSystem.Models.Formas.CNT
{
    public class DP01AMOV
    {        
        public int Id { get; set; }
        public string Tipo_asi { get; set; }
        public string Asiento { get; set; }
        public int Linea { get; set; }
        public DateTime Fecha_asi { get; set; }
        public string Codmov { get; set; }
        public string Tipo { get; set; }
        public string Refer { get; set; }
        public string Concepto { get; set; }
        public decimal Importe { get; set; }
        public decimal Importe_ex { get; set; }
        public Boolean Cerrado { get; set; }
        public string Ges_apl { get; set; }
        public string Codpro { get; set; }
        public string Numfac { get; set; }
        public decimal Baseret { get; set; }
        public decimal Por_ret { get; set; }
        public string Chequeno { get; set; }
        public string Con_ch { get; set; }
        public string Con_rt { get; set; }
        public string Numrete { get; set; }
        public decimal Monto_anu { get; set; }
        public Boolean Anulado { get; set; }
        public string Codsri { get; set; }
        public string Comproba { get; set; }
        public DateTime? Fecche { get; set; }
        public string Centro_cos { get; set; }
        public string S_sectra { get; set; }
        public string S_tipcon { get; set; }
        public DateTime? S_fecha1 { get; set; }
        public DateTime? S_fecha2 { get; set; }        
        public string S_drawback { get; set; }
        public string S_serie { get; set; }
        public string S_secue { get; set; }
        public string S_autoriza { get; set; }
        public string S_idcre { get; set; }
        public decimal S_nvt { get; set; }
        public decimal S_nnc { get; set; }
        public decimal S_nnd { get; set; }
        public decimal S_base0 { get; set; }
        public decimal S_montoice { get; set; }
        public decimal S_base12 { get; set; }
        public string S_codiva { get; set; }
        public decimal S_montoiva { get; set; }
        public Boolean S_ri1 { get; set; }
        public decimal S_valiva1 { get; set; }
        public string S_codri1 { get; set; }
        public decimal S_montori1 { get; set; }
        public Boolean S_ri2 { get; set; }
        public decimal S_valiva2 { get; set; }
        public string S_codri2 { get; set; }
        public decimal S_montori2 { get; set; }
        public string S_impcadu { get; set; }
        public DateTime? Fecha { get; set; }
        public DateTime? S_fecha0 { get; set; }
        public string Fecconci { get; set; }
        public string Serie_rt { get; set; }
        public string Autori_rt { get; set; }
        public string Cod_flujo { get; set; }
        public string Cat_ecp { get; set; }
    }
}
