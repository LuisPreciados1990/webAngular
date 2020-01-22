export interface IDp02a130 {
  id?: number;
  cuenta: string;
  codigo: string;
  nombre: string;
  porcen: number;
  tipret: string;
  tpcompro: string;
  fechaini?: Date;
  fechafin?: Date;
  te?: string;
  tbs?: string;
  codsri?: string;
  estado?: string;
  generaRt0?: string;
  visual_rep?: string;
  sec_fic?: string;  
}

export interface IDp02a130EXT extends IDp02a130 {
  nombreCta: string;
  base: number;
  valorRet: number;  
}
