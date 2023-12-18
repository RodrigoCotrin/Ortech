package br.teste.adapters;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import java.util.List;

import br.teste.classes.HistoricoPedidos;
import br.teste.R;

public class HistoricoPedidoAdapter extends RecyclerView.Adapter<HistoricoPedidoAdapter.MyViewHolder> {

    List<HistoricoPedidos> historicopedido;
    public HistoricoPedidoAdapter(List<HistoricoPedidos> historicopedido){this.historicopedido = historicopedido;}

    @NonNull
    @Override
    public HistoricoPedidoAdapter.MyViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View itemLista = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_adapter1, parent, false);
        return new HistoricoPedidoAdapter.MyViewHolder(itemLista);
    }

    @Override
    public void onBindViewHolder(@NonNull HistoricoPedidoAdapter.MyViewHolder holder, int position) {
        HistoricoPedidos historicoDePedidos1 = historicopedido.get(position);
        holder.cpf.setText(historicoDePedidos1.getCpf());
        holder.num_ped.setText(historicoDePedidos1.getNum_ped());
        holder.num_item.setText(historicoDePedidos1.getNum_item());
        holder.data.setText(historicoDePedidos1.getData());
        holder.valor.setText(historicoDePedidos1.getValor());
        if(historicoDePedidos1.getCpf().length() == 11){
            holder.text5.setText("CPF:");
        } else{holder.text5.setText("Funcionário:");}
    }
    @Override
    public int getItemCount() {return historicopedido.size();}
    public class MyViewHolder extends RecyclerView.ViewHolder{
        TextView num_ped, cpf, valor, data, num_item, text5;
        public MyViewHolder(@NonNull View itemView) {
            super(itemView);
            num_ped = itemView.findViewById(R.id.num_ped);
            cpf = itemView.findViewById(R.id.cpf);
            valor = itemView.findViewById(R.id.valor);
            data = itemView.findViewById(R.id.data);
            num_item = itemView.findViewById(R.id.num_item);
            text5 = itemView.findViewById(R.id.text5);
        }
    }
}
