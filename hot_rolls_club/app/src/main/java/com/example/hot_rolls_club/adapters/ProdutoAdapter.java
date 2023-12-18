package com.example.hot_rolls_club.adapters;

import android.graphics.Bitmap;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.hot_rolls_club.R;
import com.example.hot_rolls_club.classes.Produtos;

import java.util.ArrayList;
import java.util.List;

public class ProdutoAdapter extends RecyclerView.Adapter<ProdutoAdapter.ProdutoViewHolder> {
    final RecyclerProdutosInterface recyclerProdutosInterface;
    List<Produtos> listaProdutos;
    List<Produtos> listaProdutosFiltrados;

    public ProdutoAdapter(List<Produtos> listaProdutos, RecyclerProdutosInterface recyclerProdutosInterface)
    {
        this.listaProdutos = listaProdutos;
        this.listaProdutosFiltrados = new ArrayList<>(listaProdutos);
        this.recyclerProdutosInterface = recyclerProdutosInterface;
    }

    @NonNull
    @Override
    public ProdutoViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.adapter_produtos, parent, false);
        return new ProdutoViewHolder(view, recyclerProdutosInterface);
    }

    @Override
    public void onBindViewHolder(@NonNull ProdutoViewHolder holder, int position) {
        Produtos produto = listaProdutosFiltrados.get(position);
        holder.txtNome.setText(produto.getNomeProduto());
        holder.txtPreco.setText("R$ " + produto.getPrecoProduto());
        Bitmap imgProduto = produto.getImgProduto();
        if (imgProduto != null) {
            holder.imgProduto.setImageBitmap(imgProduto);
        }
    }
    @Override
    public int getItemCount() {return listaProdutosFiltrados.size();}

    // Método para filtrar produtos por categoria
    public void filtrarPorCategoria(String categoria) {
        listaProdutosFiltrados.clear();

        if (categoria == null || categoria.isEmpty()) {
            listaProdutosFiltrados.addAll(listaProdutos);
        } else {
            for (Produtos produto : listaProdutos) {
                if (produto.getCategoriaProduto().equals(categoria)) {
                    listaProdutosFiltrados.add(produto);
                }
            }
        }
        notifyDataSetChanged();
    }
    public void filtrarPorNome(String nome) {
        listaProdutosFiltrados.clear();

        for (Produtos produto : listaProdutos) {
            if (produto.getNomeProduto().toLowerCase().contains(nome.toLowerCase())) {
                listaProdutosFiltrados.add(produto);
            }
        }

        notifyDataSetChanged();
    }

    public class ProdutoViewHolder extends RecyclerView.ViewHolder {
        TextView txtNome, txtPreco;
        ImageView imgProduto;
        public ProdutoViewHolder(View itemView, RecyclerProdutosInterface recyclerProdutosInterface) {
            super(itemView);
            txtNome = itemView.findViewById(R.id.txtProduto);
            txtPreco = itemView.findViewById(R.id.txtValor);
            imgProduto = itemView.findViewById(R.id.imgProduto);

            itemView.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    if(recyclerProdutosInterface != null)
                    {
                        int pos = getAdapterPosition();
                        if(pos != RecyclerView.NO_POSITION)
                        {
                            recyclerProdutosInterface.onItemClick(pos);
                        }
                    }
                }
            });
        }
    }
}
