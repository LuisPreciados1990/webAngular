using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSystem.Models.Formas.ELEC
{
    public class APCIAS
    {
        public int Id { get; set; }
        public string Ruc { get; set; }
        public string R_social { get; set; }
        public string N_comercial { get; set; }
        public string Direccion { get; set; }
        public string Resol_contribespecial { get; set; }
        public Boolean Obligado_cnt { get; set; }
        public string Pto_estab { get; set; }
        public string Logo_imagen { get; set; }
        public string Tipoambiente { get; set; }
        public string Archivo_firma { get; set; }
        public string Pass_archivoFirma { get; set; }
        public string Moneda { get; set; }
        public string Path_cg { get; set; }
        public string Path_cf { get; set; }
        public string Path_ca { get; set; }
        public string Path_cr { get; set; }
        public string Codnumerico { get; set; }
        public string Path_dbf { get; set; }
        public string Line_configura { get; set; }
        public string Noparte_ce { get; set; }
        public string RideFac { get; set; }
        public string RideGui { get; set; }
        public string RideCre { get; set; }
        public string RideDeb { get; set; }
        public string RideRet { get; set; }
        public string RepoFac { get; set; }
        public string RepoGui { get; set; }
        public string RepoCre { get; set; }
        public string RepoDeb { get; set; }
        public string RepoRet { get; set; }
        public string NameImpresora { get; set; }
        public int NnivelDBF { get; set; }
        public string TextoAviso { get; set; }
        public DateTime? Fecha_cadu_ce { get; set; }
        public int Diasavisoce { get; set; }
        public string DesfieldDet1 { get; set; }
        public string DesfieldDet2 { get; set; }
        public string DesfieldDet3 { get; set; }
        public int ActLanza { get; set; }
        public int Delayws { get; set; }
        public int Delaypdf { get; set; }
        public int Imastretch { get; set; }
    }
}
