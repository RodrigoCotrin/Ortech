package br.teste.adapters;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import java.util.List;

import br.teste.R;
import br.teste.classes.Reservas;

public class ReservaAdapter extends RecyclerView.Adapter<ReservaAdapter.MyViewHolder> {

    List<Reservas> reserva;
    public ReservaAdapter(List<Reservas> reserva){
        this.reserva = reserva;
    }

    @NonNull
    @Override
    public ReservaAdapter.MyViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View itemLista1 = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_adapter2, parent, false);
        return new ReservaAdapter.MyViewHolder(itemLista1);
    }

    @Override
    public void onBindViewHolder(@NonNull ReservaAdapter.MyViewHolder holder, int position) {
        Reservas reservas = reserva.get(position);
        holder.cpf.setText(reservas.getCpf());
        holder.data.setText(reservas.getDataReserva());
        holder.hora.setText(reservas.getHorareserva());
        holder.num_pessoas.setText(reservas.getQuantidadePessoas());
    }
    @Override
    public int getItemCount() {return reserva.size();}
    public class MyViewHolder extends RecyclerView.ViewHolder{
        TextView cpf, hora, data, num_pessoas;
        public MyViewHolder(@NonNull View itemView1) {
            super(itemView1);
            cpf = itemView.findViewById(R.id.cpf);
            hora = itemView.findViewById(R.id.hora);
            data = itemView.findViewById(R.id.data);
            num_pessoas = itemView.findViewById(R.id.num_pessoas);
        }
    }
}
