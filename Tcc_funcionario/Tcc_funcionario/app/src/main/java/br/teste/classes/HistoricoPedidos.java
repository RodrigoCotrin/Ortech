package br.teste.classes;

import java.text.DecimalFormat;

public class HistoricoPedidos {

      String num_ped, cpf, valor, data, num_item;
      public String getNum_ped() {
            return num_ped;
      }

      public void setNum_ped(String num_ped) {
            this.num_ped = num_ped;
      }

      public String getCpf() {
            return cpf;
      }

      public void setCpf(String cpf) {
            this.cpf = cpf;
      }

      public String getValor() {
            return valor;
      }

      public void setValor(String valor) {
            this.valor = valor;
      }

      public String getData() {
            return data;
      }

      public void setData(String data) {
            this.data = data;
      }

      public String getNum_item() {
            return num_item;
      }

      public void setNum_item(String num_item) {
            this.num_item = num_item;
      }

      public HistoricoPedidos(String num_ped, String cpf, String valor,String data, String num_item) {
            this.num_ped = num_ped;
            this.cpf = cpf;
            this.valor = valor;
            this.data = data;
            this.num_item = num_item;
      }
}
