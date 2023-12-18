package com.example.hot_rolls_club.fragments;


import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentTransaction;

import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;

import com.example.hot_rolls_club.R;
import com.example.hot_rolls_club.adapters.CartAdapter;
import com.example.hot_rolls_club.classes.AbreProdutos;
import com.example.hot_rolls_club.classes.ConexaoSQL;
import com.example.hot_rolls_club.classes.Produtos;
import com.example.hot_rolls_club.databinding.FragmentTelaPratoBinding;

import java.math.BigDecimal;
import java.math.RoundingMode;
import java.util.ArrayList;
import java.util.List;

public class TelaPratoFragment extends Fragment {

    FragmentTelaPratoBinding binding;
    CartAdapter cartAdapter;
    AbreProdutos abreProdutos;
    ConexaoSQL conexaoSQL;
    private int quantidadePratos = 1;




    private boolean ativar = true;
    List<Produtos> cartItems;

    public TelaPratoFragment() {
        // Required empty public constructor
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        binding = FragmentTelaPratoBinding.inflate(inflater, container, false);
        View view = binding.getRoot();

        binding.txtNomePrato.setText(AbreProdutos.getNome());
        binding.txtDescricaoPrato.setText(AbreProdutos.getDescricao());
        binding.txtPrecoPrato.setText("R$ " + AbreProdutos.getPreco());

        String valorString = binding.txtPrecoPrato.getText().toString();
        valorString = valorString.replace("R$", "").trim();
        BigDecimal valorPorPrato = new BigDecimal(valorString);
        valorPorPrato = valorPorPrato.setScale(2, RoundingMode.HALF_UP);
        BigDecimal total = valorPorPrato.multiply(BigDecimal.valueOf(quantidadePratos)).setScale(2, RoundingMode.HALF_UP);
        binding.txtTotalValor.setText("Total: R$ " + total.toString());


        return view;
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        binding.btnVoltar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                openChildFragment();
            }
        });

        binding.btnFavoritar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if (ativar) {
                    binding.btnFavoritar.setImageResource(R.drawable.imgcoracaofilled); // Altera para a segunda imagem
                    ativar = false;

                } else {
                    binding.btnFavoritar.setImageResource(R.drawable.imgcoracao); // Altera de volta para a primeira imagem
                    ativar = true;
                }
            }
        });

        binding.txtDiminuir.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String valorString = binding.txtPrecoPrato.getText().toString();
                valorString = valorString.replace("R$", "").trim();

                BigDecimal valorPorPrato = new BigDecimal(valorString);
                valorPorPrato = valorPorPrato.setScale(2, RoundingMode.HALF_UP);

                if (quantidadePratos > 1){quantidadePratos = quantidadePratos - 1;}
                binding.txtQuantidade.setText(String.valueOf(quantidadePratos));

                binding.txtPrecoPrato.setText("R$ " + valorPorPrato.toString());
                BigDecimal total = valorPorPrato.multiply(BigDecimal.valueOf(quantidadePratos)).setScale(2, RoundingMode.HALF_UP);
                binding.txtTotalValor.setText("Total: R$ " + total.toString());
            }
        });
        binding.txtAumentar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String valorString = binding.txtPrecoPrato.getText().toString();
                valorString = valorString.replace("R$", "").trim();

                BigDecimal valorPorPrato = new BigDecimal(valorString);
                valorPorPrato = valorPorPrato.setScale(2, RoundingMode.HALF_UP);

                quantidadePratos = quantidadePratos + 1;
                binding.txtQuantidade.setText(String.valueOf(quantidadePratos));
                binding.txtPrecoPrato.setText("R$ " + valorPorPrato.toString());
                BigDecimal total = valorPorPrato.multiply(BigDecimal.valueOf(quantidadePratos)).setScale(2, RoundingMode.HALF_UP);
                binding.txtTotalValor.setText("Total: R$ " + total.toString());
            }

        });
        binding.btnAdicionarCarrinho.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Produtos produtoSelecionado = criarObjetoProdutos();
                adicionarAoCarrinho(produtoSelecionado);
            }
        });
    }

    private Produtos criarObjetoProdutos() {
        String nomeProduto = binding.txtNomePrato.getText().toString();
        String precoProduto = binding.txtPrecoPrato.getText().toString();
        String quantidadeProduto = binding.txtQuantidade.getText().toString();

        Produtos produto = new Produtos("", nomeProduto, "", precoProduto, "", "");
        produto.setQuantidadeSelecionada(Integer.parseInt(quantidadeProduto));
        return produto;
    }
    private void adicionarAoCarrinho(Produtos produto) {
        // Verifique se a lista de itens do carrinho foi inicializada
        if (cartItems == null) {
            cartItems = new ArrayList<Produtos>(); // Inicialize a lista se ainda não foi feito
        }

        // Defina a quantidade e outras informações do item (pode ser ajustado conforme sua lógica)
        produto.setQuantidadeSelecionada(quantidadePratos);
        // Adicione outros detalhes do produto, se necessário

        // Adicione o produto à lista de itens do carrinho
        cartItems.add(produto);

        // Mostre uma mensagem ou faça outra ação para indicar que o pedido foi adicionado ao carrinho
        cartAdapter.notifyDataSetChanged();
        Toast.makeText(getActivity(), "Pedido adicionado ao carrinho!", Toast.LENGTH_SHORT).show();
        Log.d("CartAdapter", "Tamanho da lista após adicionar item: " + cartItems.size());
    }

    private void openChildFragment() {
        FragmentTransaction fragmentTransaction = getChildFragmentManager().beginTransaction();
        fragmentTransaction.replace(R.id.fram7, new CardapioFragment());
        fragmentTransaction.addToBackStack(null);
        fragmentTransaction.commit();
    }
    private void openChildFragmentCarrinho() {
        FragmentTransaction fragmentTransaction = getChildFragmentManager().beginTransaction();
        fragmentTransaction.replace(R.id.fram7, new CarrinhoFragment());
        fragmentTransaction.addToBackStack(null);
        fragmentTransaction.commit();
    }

}
