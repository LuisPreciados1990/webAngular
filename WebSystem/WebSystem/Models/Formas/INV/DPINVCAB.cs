﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSystem.Models.Formas.INV
{
    public class DPINVCAB
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Numero { get; set; }
        public string Numero_b { get; set; }
        public string Referencia { get; set; }
        public string Grupo { get; set; }
        public string Tipo_t { get; set; }
        public DateTime? Fecha_tra { get; set; }
        public DateTime? Fecha_ven { get; set; }
        public string Bodega_d { get; set; }
        public string Bodega { get; set; }
        public string Prov_cli { get; set; }
        public string Vendedor { get; set; }
        public string Tp_precio { get; set; }
        public decimal Total_mov { get; set; }
        public decimal Pordes { get; set; }
        public decimal Total_des { get; set; }
        public decimal Poriva { get; set; }
        public decimal Total_iva { get; set; }
        public decimal Total_trn { get; set; }
        public DateTime? Userfec { get; set; }
        public string Userfec_2 { get; set; }
        public string Usertim { get; set; }
        public string Usercla { get; set; }
        public string Comenta { get; set; }
        public string Comenta1 { get; set; }
        public string Comenta2 { get; set; }
        public string Comenta3 { get; set; }
        public string Vta_cli { get; set; }
        public string Vta_ruc { get; set; }
        public string Vta_dir { get; set; }
        public string Vta_fo1 { get; set; }
        public string Vta_fo2 { get; set; }               
        public Boolean Anulada { get; set; }
        public DateTime? Fecha_anu2 { get; set; }
        public DateTime? Fecha_anu { get; set; }
        public string Hora_anu { get; set; }
        public string User_anu { get; set; }
        public decimal Abono { get; set; }
        public string Fac_pro { get; set; }
        public string Codigo_i { get; set; }
        public string Codigo_e { get; set; }
        public string Integracnt { get; set; }
        public string Vapor { get; set; }
        public DateTime? Fec_emb { get; set; }
        public string Semana { get; set; }
        public string Guia_remi { get; set; }
        public string Numfue { get; set; }
        public decimal Librasne { get; set; }
        public decimal Pesone { get; set; }
        public decimal Pesobru { get; set; }
        public string Marca { get; set; }
        public string Destino { get; set; }
        public string Cartonera { get; set; }
        public string Cancelapto { get; set; }
        public string Comprodev { get; set; }
        public int Van { get; set; }
        public string Cajero { get; set; }
        public decimal Flete { get; set; }
        public string Transporte { get; set; }
        public string Terminos { get; set; }
        public string St { get; set; }
        public Boolean Canc_lote { get; set; }
        public string Factura { get; set; }
        public string Dirdes { get; set; }
        public string Remite { get; set; }
        public DateTime? Fec_ini { get; set; }
        public DateTime? Fec_fin { get; set; }
        public string Trasladox { get; set; }
        public decimal Base_0 { get; set; }
        public decimal Base_tax { get; set; }
        public decimal Val_trans { get; set; }
        public decimal Porcom { get; set; }
        public string Integracos { get; set; }
        public string Ordcom { get; set; }
        public decimal Cubica_t { get; set; }
        public int Ano { get; set; }
        public int Periodo { get; set; }
        public int Catego { get; set; }
        public int Programa { get; set; }
        public int Cuota { get; set; }
        public string Contrib { get; set; }
        public string Rma { get; set; }
        public string Ocompra { get; set; }
        public string S_impcadu { get; set; }
        public string S_autoriza { get; set; }
        public Boolean Od { get; set; }
        public DateTime? Fecha_ve1 { get; set; }
        public string Status_flu { get; set; }
        public DateTime? Fecha_flu { get; set; }
        public string Ctacont { get; set; }
        public decimal Total_ser { get; set; }
        public decimal Por_comitc { get; set; }
        public decimal Base_tc { get; set; }
        public decimal Valcomitc { get; set; }
        public Boolean Contabi { get; set; }
        public string Impreso { get; set; }
        public string Desc_fac { get; set; }
        public decimal Valor_rt { get; set; }
        public string Pesada { get; set; }
        public string Lote { get; set; }
        public string Contenedor { get; set; }
        public string Sellos { get; set; }
        public string Export { get; set; }
        public string SubpartiAn { get; set; }
        public string Marcas { get; set; }
        public string Guia_placa { get; set; }
        public string Guia_nDestina { get; set; }
        public string Guia_RucDest { get; set; }
        public string Aguaje { get; set; }
        public decimal Lrecibida { get; set; }
        public decimal Lbasura { get; set; }
        public decimal Rendimiento { get; set; }
        public decimal Total_lib { get; set; }
        public decimal Total_kil { get; set; }
        public decimal Total_caj { get; set; }
        public decimal Sobrante { get; set; }
        public decimal Sobr_basura { get; set; }
        public decimal Sobr_remite { get; set; }
        public decimal Sobr_rendi { get; set; }
        public decimal Peso_planta { get; set; }
        public string Trans_ruc { get; set; }
        public string Partida { get; set; }
        public string Transporta { get; set; }
        public string Llegada { get; set; }
        public string Ruta { get; set; }
        public string Ce_autoriz { get; set; }
        public string Ce_clave { get; set; }
        public DateTime? Ce_fecaut { get; set; }
        public string Ce_activo { get; set; }
        public string Ce_estado { get; set; }
        public string Ce_deserra { get; set; }
        public DateTime? Fecha_clu { get; set; }
        public DateTime? Ap_comi { get; set; }
        public string Recibido { get; set; }
        public DateTime? Fecha_rec { get; set; }
        public string Hora_rec { get; set; }
        public string User_rec { get; set; }
        public string Comenta_re { get; set; }
        public string Conceptox { get; set; }
        public string Rs_scan { get; set; }
        public Boolean EstadoFac { get; set; }
        public decimal Flete_loc { get; set; }
        public decimal Gasto_loc { get; set; }
        public decimal Valor_fob { get; set; }
        public decimal Flete_int { get; set; }
        public decimal Seguro { get; set; }
        public decimal Valor_cif { get; set; }
        public decimal Valor_adu { get; set; }
        public decimal Gastos_lod { get; set; }
        public decimal Valtransp { get; set; }
        public decimal Valotros { get; set; }
        public decimal Total_sub { get; set; }
        public string Tipo_trans { get; set; }
        public string Pais { get; set; }
        public string Doc_embar { get; set; }
        public string Pto_embar { get; set; }
        public string Tam_conte { get; set; }
        public string Num_conte { get; set; }
        public string Tipo_segur { get; set; }
        public DateTime? Embarque { get; set; }
        public string Liquida { get; set; }
        public string Import { get; set; }
        public string Come_anula { get; set; }
        public decimal Total_ice { get; set; }
        public string Csf_nombre { get; set; }
        public string Csf_cedula { get; set; }
        public string Csf_direcc { get; set; }
        public string Cpcodigo_1 { get; set; }
        public decimal CpValor_1 { get; set; }
        public string Cpcodpla_1 { get; set; }
        public decimal Cpvalpla_1 { get; set; }
        public string Cpcodigo_2 { get; set; }
        public decimal CpValor_2 { get; set; }
        public string Cpcodpla_2 { get; set; }
        public decimal Cpvalpla_2 { get; set; }
        public string Cpcodigo_3 { get; set; }
        public decimal CpValor_3 { get; set; }
        public string Cpcodpla_3 { get; set; }
        public decimal Cpvalpla_3 { get; set; }
        public string Cpcodigo_4 { get; set; }
        public decimal CpValor_4 { get; set; }
        public string Cpcodpla_4 { get; set; }
        public decimal Cpvalpla_4 { get; set; }
        public decimal Porpromc { get; set; }
        public int EsCotiza { get; set; }
        public string CSaldo { get; set; }

    }
}
