package com.example.hot_rolls_club.adapters;

import android.annotation.SuppressLint;
import android.graphics.Bitmap;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.hot_rolls_club.R;
import com.example.hot_rolls_club.classes.Produtos;

import java.math.BigDecimal;
import java.math.RoundingMode;
import java.util.List;

public class CartAdapter extends RecyclerView.Adapter<CartAdapter.CartViewHolder> {

    private List<Produtos> cartItems;
    Produtos produtos;
    RecyclerProdutosInterface recyclerProdutosInterface;

    int quantidadePratos;


    public CartAdapter(List<Produtos> cartItems) {
        this.cartItems = cartItems;
        this.recyclerProdutosInterface = recyclerProdutosInterface;
    }

    // ViewHolder para representar cada item no RecyclerView


    @NonNull
    @Override
    public CartViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        // Inflar o layout do item do carrinho aqui e retornar um ViewHolder
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.viewholder_cart, parent, false);
        return new CartViewHolder(view, recyclerProdutosInterface);
    }

    public void addItem(String nomeProduto, String precoProduto) {
        Produtos novoProduto = new Produtos("", nomeProduto, "", precoProduto, "", "",null);
        cartItems.add(novoProduto);
        notifyDataSetChanged(); // Notifica o RecyclerView sobre a mudança nos dados
        Log.d("CartAdapter", "Tamanho da lista após adicionar item: " + cartItems.size());
    }


    @Override
    public void onBindViewHolder(@NonNull CartViewHolder holder, @SuppressLint("RecyclerView") int position) {
        Produtos produto = cartItems.get(position);

        holder.txtNomePratoHolder.setText(produto.getNomeProduto());
        holder.txtPrecoPratoCarrinho.setText(produto.getPrecoProduto());
        holder.txtQuantidade.setText(String.valueOf(produto.getQuantidadeSelecionada()));

        Bitmap imgProduto = produto.getImgProduto();
        if (imgProduto != null) {
            holder.imageView7.setImageBitmap(imgProduto);
        }

        int quantidadeAtual = produto.getQuantidadeSelecionada();
        BigDecimal precoPrato = new BigDecimal(produto.getPrecoProduto().replace("R$", "").trim());
        BigDecimal precoTotal = precoPrato.multiply(BigDecimal.valueOf(quantidadeAtual));

        holder.txtPrecoPratoCarrinho.setText("R$ " + precoTotal.setScale(2, RoundingMode.HALF_UP).toString());
        holder.txtQuantidade.setText(String.valueOf(quantidadeAtual));

        holder.btnAumentar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                int position = holder.getAdapterPosition();
                if (position != RecyclerView.NO_POSITION) {
                    Produtos produto = cartItems.get(position);
                    int quantidadeAtual = produto.getQuantidadeSelecionada();
                    quantidadeAtual++;
                    produto.setQuantidadeSelecionada(quantidadeAtual);

                    BigDecimal precoPrato = new BigDecimal(produto.getPrecoProduto().replace("R$", "").trim());
                    BigDecimal precoTotal = precoPrato.multiply(BigDecimal.valueOf(quantidadeAtual));

                    holder.txtPrecoPratoCarrinho.setText("R$ " + precoTotal.setScale(2, RoundingMode.HALF_UP).toString());
                    holder.txtQuantidade.setText(String.valueOf(quantidadeAtual));
                }
            }
        });

        holder.btnDiminuir.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                int position = holder.getAdapterPosition();
                if (position != RecyclerView.NO_POSITION) {
                    Produtos produto = cartItems.get(position);
                    int quantidadeAtual = produto.getQuantidadeSelecionada();

                    if (quantidadeAtual > 1) {
                        quantidadeAtual--;
                        produto.setQuantidadeSelecionada(quantidadeAtual);

                        // Recupera o preço do prato original da lista cartItems como BigDecimal
                        BigDecimal precoPratoOriginal = new BigDecimal(produto.getPrecoProduto().replace("R$", "").trim());

                        // Calcula o preço total subtraindo o preço original do produto
                        BigDecimal precoTotal = precoPratoOriginal.multiply(BigDecimal.valueOf(quantidadeAtual));

                        // Atualiza os TextViews com os novos valores
                        holder.txtPrecoPratoCarrinho.setText("R$ " + precoTotal.setScale(2, RoundingMode.HALF_UP).toString());
                        holder.txtQuantidade.setText(String.valueOf(quantidadeAtual));
                    }
                    else {
                        cartItems.remove(position);
                        notifyItemRemoved(position);
                    }
                }
            }
        });
    }

    @Override
    public int getItemCount() {
        return cartItems.size();
    }

    public static class CartViewHolder extends RecyclerView.ViewHolder  {

        TextView txtNomePratoHolder;
        TextView txtPrecoPratoCarrinho;
        TextView txtQuantidade;
        ImageView btnDiminuir;
        ImageView btnAumentar;
        ImageView imageView7;

        public CartViewHolder(View itemView, RecyclerProdutosInterface recyclerProdutosInterface) {
            super(itemView);
            txtNomePratoHolder = itemView.findViewById(R.id.txtNomePratoHolder);
            txtPrecoPratoCarrinho = itemView.findViewById(R.id.txtPrecoPratoCarrinho);
            txtQuantidade = itemView.findViewById(R.id.txtQuantidade);
            txtPrecoPratoCarrinho = itemView.findViewById(R.id.txtPrecoPratoCarrinho);
            btnDiminuir = itemView.findViewById(R.id.btnDiminuir);
            btnAumentar = itemView.findViewById(R.id.btnAumentar);
            imageView7 = itemView.findViewById(R.id.imageView7);
        }
    }
    public List<Produtos> getCartItems() {
        return cartItems;
    }
}