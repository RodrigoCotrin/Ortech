package br.teste.adapters;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import java.util.List;

import br.teste.classes.Pedido;
import br.teste.R;

public class PedidoAdapter extends RecyclerView.Adapter<PedidoAdapter.MyViewHolder> {

    List<Pedido> pedido;
    public PedidoAdapter(List<Pedido> pedidos){
        this.pedido = pedidos;
    }

    @NonNull
    @Override
    public MyViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View itemLista = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_adapter, parent, false);
        return new MyViewHolder(itemLista);
    }

    @Override
    public void onBindViewHolder(@NonNull MyViewHolder holder, int position) {
       Pedido pedido1 = pedido.get(position);
       holder.nome_prato.setText(pedido1.getNome_prato());
       holder.quantidade.setText(pedido1.getQuantidade());
       holder.prato.setImageBitmap(pedido1.getImg());
    }

    @Override
    public int getItemCount() {
        return pedido.size();
    }

    public class MyViewHolder extends RecyclerView.ViewHolder{
        ImageView prato;
        TextView nome_prato, quantidade;
        public MyViewHolder(@NonNull View itemView) {
            super(itemView);
            prato = itemView.findViewById(R.id.img_prato);
            nome_prato = itemView.findViewById(R.id.nome_prato);
            quantidade = itemView.findViewById(R.id.quantidade);
        }
    }

}
